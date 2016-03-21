using Newtonsoft.Json.Linq;
using rongYunWebApiSample.Common;
using rongYunWebApiSample.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace rongYunWebApiSample.Models
{
    public class UserDetails
    {
        public class UserModel
        {
            public string id { get; set; }
            [Required]
            public string userName { get; set; }
            [Required]
            public string password { get; set; }
            [Required]
            public string email { get; set; }
            [Required]
            public string phoneNumber { get; set; }
            public string token { get; set; }
            public string avatorUri { get; set; }
            public string sex { get; set; }
            public string resident { get; set; }
            public string signature { get; set; }
        }

        public interface IUserInfoRepository
        {
            bool IsExists(string userName);
            string CreateUser(UserModel model);
            UserModel GetModel(string userName);
            int UpdateModel(string userName, UserModel model);
        }

        public class UserInfoRepository : IUserInfoRepository
        {
            /// <summary>
            /// 创建用户，创建成功返回token
            /// </summary>
            /// <param name="model"></param>
            /// <returns>用户token</returns>
            public string CreateUser(UserModel model)
            {
                if (IsExists(model.userName))
                    return "Repeat UserName";
                string guid = Guid.NewGuid().ToString();
                string userName = model.userName;
                string email = model.email;
                string phoneNumber = model.phoneNumber;
                string password = EncriyptHelper.ToMd5(model.password);

                //获取用户token
                string appKey = ConfigurationManager.AppSettings["rongYunAppkey"].ToString();
                string secret = ConfigurationManager.AppSettings["rongYunSecret"].ToString();
                string token_response = RongCloudServer.GetToken(appKey, secret, guid, userName, "https://mycontainner.blob.core.chinacloudapi.cn/container/defaultAvator");
                string token = string.Empty;
                try
                {
                    JObject jsonObject = JObject.Parse(token_response);
                    if(jsonObject["code"].ToString()=="200")
                    {
                        token = jsonObject["token"].ToString();
                    }
                }
                catch { }
                string strSql = "INSERT INTO dbo.Users VALUES(@id,@userName,@email,@phoneNumber,@password,@token,@avatorUri,@sex,@resident,@signature)";
                SqlParameter[] parameters =
                {
                        new SqlParameter("@id",System.Data.SqlDbType.VarChar,50),
                        new SqlParameter("@userName",System.Data.SqlDbType.NVarChar,50),
                        new SqlParameter("@email",System.Data.SqlDbType.VarChar,50),
                        new SqlParameter("@phoneNumber",System.Data.SqlDbType.VarChar,50),
                        new SqlParameter("@password",System.Data.SqlDbType.VarChar,50),
                        new SqlParameter("@token",System.Data.SqlDbType.VarChar,200),
                        new SqlParameter("@avatorUri",System.Data.SqlDbType.VarChar,100),
                        new SqlParameter("@sex",System.Data.SqlDbType.NChar,10),
                        new SqlParameter("@resident",System.Data.SqlDbType.NVarChar,50),
                        new SqlParameter("@signature",System.Data.SqlDbType.NVarChar,50)
                };
                parameters[0].Value = guid;
                parameters[1].Value = userName;
                parameters[2].Value = email;
                parameters[3].Value = phoneNumber;
                parameters[4].Value = password;
                parameters[5].Value = token;
                parameters[6].Value = "https://mycontainner.blob.core.chinacloudapi.cn/container/defaultAvator";
                parameters[7].Value = "男";
                parameters[8].Value = "无";
                parameters[9].Value = "空空如也~";

                if (DBHelper.ExecuteNonQuery(strSql, parameters)>0)
                {
                    return token;
                }
                else
                {
                    return string.Empty;
                }
            }

            public UserModel GetModel(string userName)
            {
                string strSql = "SELECT * FROM dbo.Users WHERE UserName=@userName";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@userName",System.Data.SqlDbType.NVarChar,50)
                };
                parameters[0].Value = userName;

                using (SqlDataReader sdr = DBHelper.ExecuteSqlReader(strSql, parameters))
                {
                    if (sdr.Read())
                    {
                        UserModel model = new UserModel();
                        model.userName = sdr["UserName"].ToString();
                        model.email = sdr["Email"].ToString();
                        model.phoneNumber = sdr["PhoneNumber"].ToString();
                        model.password = sdr["Password"].ToString();
                        model.token = sdr["Token"].ToString();
                        model.avatorUri = sdr["AvatorUri"].ToString();
                        model.sex = sdr["Sex"].ToString();
                        model.resident = sdr["Resident"].ToString();
                        model.signature = sdr["Signature"].ToString();

                        return model;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            public bool IsExists(string userName)
            {
                string strSql = "SELECT COUNT(*) FROM dbo.Users WHERE UserName=@userName";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@userName",System.Data.SqlDbType.NVarChar,50)
                };

                parameters[0].Value = userName;

                return Convert.ToInt32(DBHelper.ExcuteSqlScalar(strSql, parameters)) > 0 ? true : false;
            }

            public int UpdateModel(string userName, UserModel model)
            {
                string strSql = "UPDATE dbo.Users SET UserName=@userName,Email=@email,PhoneNumber=@phoneNumber,Password=@password,Token=@token,AvatorUri=@avatorUri,Sex=@sex,Resident=@resident,Signature=@signature WHERE UserName=@userName_Old";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@userName",System.Data.SqlDbType.NVarChar,50),
                    new SqlParameter("@email",System.Data.SqlDbType.VarChar,50),
                    new SqlParameter("@phoneNumber",System.Data.SqlDbType.VarChar,50),
                    new SqlParameter("@password",System.Data.SqlDbType.VarChar,50),
                    new SqlParameter("@token",System.Data.SqlDbType.VarChar,200),
                    new SqlParameter("@avatorUri",System.Data.SqlDbType.VarChar,50),
                    new SqlParameter("@sex",System.Data.SqlDbType.NChar,10),
                    new SqlParameter("@resident",System.Data.SqlDbType.NVarChar,50),
                    new SqlParameter("@signature",System.Data.SqlDbType.NVarChar,50),
                    new SqlParameter("@userName_Old",System.Data.SqlDbType.NVarChar,50)
                };
                parameters[0].Value = model.userName;
                parameters[1].Value = model.email;
                parameters[2].Value = model.phoneNumber;
                parameters[3].Value = model.password;
                parameters[4].Value = model.token;
                parameters[5].Value = model.avatorUri;
                parameters[6].Value = model.sex;
                parameters[7].Value = model.resident;
                parameters[8].Value = model.signature;
                parameters[9].Value = userName;

                return DBHelper.ExecuteNonQuery(strSql, parameters);
            }
        }
    }
}