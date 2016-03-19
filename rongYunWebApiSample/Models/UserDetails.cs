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
            public string token { get; set; }
        }

        public interface IUserInfoRepository
        {
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
                string guid = Guid.NewGuid().ToString();
                string userName = model.userName;
                string password = EncriyptHelper.ToMd5(model.password);

                //获取用户token
                string appKey = ConfigurationManager.AppSettings["rongYunAppkey"].ToString();
                string secret = ConfigurationManager.AppSettings["rongYunSecret"].ToString();
                string token = RongCloudServer.GetToken(appKey, secret, guid, userName, "");

                string strSql = "INSERT INTO dbo.Users VALUES(@id,@userName,@password,@token,@avatorUri)";
                SqlParameter[] parameters =
                {
                        new SqlParameter("@id",System.Data.SqlDbType.VarChar,50),
                        new SqlParameter("@userName",System.Data.SqlDbType.NVarChar,50),
                        new SqlParameter("@password",System.Data.SqlDbType.VarChar,50),
                        new SqlParameter("@token",System.Data.SqlDbType.VarChar,50),
                        new SqlParameter("@avatorUri",System.Data.SqlDbType.VarChar,100)
                };
                parameters[0].Value = guid;
                parameters[1].Value = userName;
                parameters[2].Value = password;
                parameters[3].Value = token;
                parameters[4].Value = "https://mycontainner.blob.core.chinacloudapi.cn/container/defaultAvator";

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
                        model.password = sdr["Password"].ToString();
                        model.token = sdr["Token"].ToString();

                        return model;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            public int UpdateModel(string userName, UserModel model)
            {
                string strSql = "UPDATE dbo.Users SET UserName=@userName,Password=@password WHERE UserName=@userName_Old";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@userName",System.Data.SqlDbType.NVarChar,50),
                    new SqlParameter("@password",System.Data.SqlDbType.VarChar,50),
                    new SqlParameter("@userName_Old",System.Data.SqlDbType.NVarChar,50)
                };
                parameters[0].Value = model.userName;
                parameters[1].Value = model.password;
                parameters[2].Value = userName;

                return DBHelper.ExecuteNonQuery(strSql, parameters);
            }
        }
    }
}