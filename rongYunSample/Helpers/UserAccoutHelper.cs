using Newtonsoft.Json.Linq;
using rongYunSample.Common;
using rongYunSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Credentials;
using Windows.Storage;
using Windows.Web.Http;

namespace rongYunSample.Helpers
{
    public class UserAccountHelper
    {
        static ApplicationDataContainer roamdingSettings = ApplicationData.Current.RoamingSettings;
        private string resourceName = "rongYunSample";

        /// <summary>
        /// 登录服务
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>登录成功返回true,反之返回false</returns>
        public static async Task<bool>Login(string userName,string password)
        {
            HttpService http = new HttpService();
            string response = await http.SendGetRequest(InterfaceUrl.UserLogin(userName));
            if(response!=string.Empty)
            {
                try
                {
                    JObject jsonObject = JObject.Parse(response);
                    if(EncriptHelper.ToMd5(password)==jsonObject["password"].ToString())
                    {
                        roamdingSettings.Values[Constants.SettingName.Token] = jsonObject["token"].ToString();
                        return true;
                    }
                }
                catch
                {

                }
            }
            return false;
        }

        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>RegisterStatus类型</returns>
        public static async Task<RegisterStatus> Register(string userName,string email,string phoneNumber,string password)
        {
            UserModel user = new UserModel();
            user.userName = userName;
            user.email = email;
            user.phoneNumber = phoneNumber;
            user.password = EncriptHelper.ToMd5(password);
            try
            {
                string jsonContent = JsonHelper.ObjectToJson(user);
                HttpService http = new HttpService();
                HttpResponseMessage response = await http.SendPostRequest(InterfaceUrl.UserAccountUrl,jsonContent);
                if(response!=null)
                {
                    if(response.StatusCode==HttpStatusCode.Created)
                    {
                        roamdingSettings.Values[Constants.SettingName.Token] = response.Content;
                        return RegisterStatus.Success;
                    }
                    else if(response.StatusCode==HttpStatusCode.Conflict)
                    {
                        return RegisterStatus.ConflictUserName;
                    }
                }
            }
            catch
            {

            }
            return RegisterStatus.Failed;
        }

        /// <summary>
        /// 从凭据保险箱获取凭据
        /// </summary>
        /// <returns>无凭据返回空，否则返回PasswordCredential</returns>
        public PasswordCredential GetCredentialFromLocker()
        {
            try
            {
                PasswordCredential credential = null;

                var vault = new PasswordVault();
                var credentialList = vault.FindAllByResource(resourceName);
                if (credentialList.Count > 0)
                {
                    credential = credentialList[0];
                }
                return credential;
            }
            catch { return null; }
        }

        public string GetUserNameFromLocker()
        {
            PasswordCredential credential = GetCredentialFromLocker();
            if (credential != null)
            {
                return credential.UserName;
            }
            return string.Empty;
        }

        public void ClearAllCredentialFromLocker()
        {
            var vault = new PasswordVault();
            var credentialList = vault.FindAllByResource(resourceName);
            if (credentialList.Count > 0)
            {
                foreach (var obj in credentialList)
                {
                    ClearCredentialFromLocker(obj.UserName, obj.Password);
                }
            }
        }

        /// <summary>
        /// 从凭据保险箱删除凭据
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void ClearCredentialFromLocker(string userName, string password)
        {
            var vault = new PasswordVault();
            var credential = new PasswordCredential(resourceName, userName, password);
            vault.Remove(credential);
        }

        public enum RegisterStatus
        {
            Success, ConflictUserName, Failed
        }
    }
}
