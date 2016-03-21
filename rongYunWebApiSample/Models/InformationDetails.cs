using rongYunWebApiSample.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace rongYunWebApiSample.Models
{
    public class InformationDetails
    {
        public class InformationModel
        {
            public string id { get; set; }
            public string userName { get; set; }
            public string title { get; set; }
            public string content { get; set; }
            public string wage { get; set; }
            public string viewCount { get; set; }
            public string addTime { get; set; }
            public string address { get; set; }
            //varchar(3),0为未接单；1为已接单，但未完成；2为已接单，已完成
            public string isAcceptOrder { get; set; }
            //接单人
            public string getOrderUserName { get; set; }
        }

        public interface IInformationRepository
        {
            int CreateInformation(InformationModel model);
            IList<InformationModel> GetModelsByUserName(string userName);
            InformationModel GetModelById(string id);
        }

        public class InformationRepository : IInformationRepository
        {
            public int CreateInformation(InformationModel model)
            {
                string strSql = "INSERT INTO dbo.Information VALUES(@id,@userName,@title,@content,@wage,@viewCount,@addTime,@address,@isAcceptOrder,@getOrderUserName)";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@id",System.Data.SqlDbType.VarChar,50),
                    new SqlParameter("@userName",System.Data.SqlDbType.NVarChar,50),
                    new SqlParameter("@title",System.Data.SqlDbType.NVarChar,200),
                    new SqlParameter("@content",System.Data.SqlDbType.NText),
                    new SqlParameter("@wage",System.Data.SqlDbType.VarBinary,50),
                    new SqlParameter("@viewCount",System.Data.SqlDbType.VarChar,50),
                    new SqlParameter("@addTime",System.Data.SqlDbType.VarChar,50),
                    new SqlParameter("@address",System.Data.SqlDbType.NVarChar,100),
                    new SqlParameter("@isAcceptOrder",System.Data.SqlDbType.VarChar,3),
                    new SqlParameter("@getOrderUserName",System.Data.SqlDbType.NVarChar,50)
                };
                parameters[0].Value = Guid.NewGuid().ToString("N");
                parameters[1].Value = model.userName;
                parameters[2].Value = model.title;
                parameters[3].Value = model.content;
                parameters[4].Value = model.wage;
                parameters[5].Value = model.viewCount;
                parameters[6].Value = model.addTime;
                parameters[7].Value = model.address;
                parameters[8].Value = model.isAcceptOrder;
                parameters[9].Value = model.getOrderUserName;

                return DBHelper.ExecuteNonQuery(strSql, parameters);
            }

            public IList<InformationModel> GetModelsByUserName(string userName)
            {
                string strSql = "SELECT * FROM dbo.Information WHERE UserName=@userName";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@userName",System.Data.SqlDbType.NVarChar,50)
                };
                parameters[0].Value = userName;

                IList<InformationModel> lstInformation = new List<InformationModel>();
                using (SqlDataReader sdr = DBHelper.ExecuteSqlReader(strSql,parameters))
                {
                    while(sdr.Read())
                    {
                        InformationModel model = new InformationModel();
                        model.id = sdr["Id"].ToString();
                        model.userName = sdr["UserName"].ToString();
                        model.title = sdr["Title"].ToString();
                        model.content = sdr["Content"].ToString();
                        model.wage = sdr["Wage"].ToString();
                        model.viewCount = sdr["ViewCount"].ToString();
                        model.address = sdr["Address"].ToString();
                        model.addTime = sdr["AddTime"].ToString();
                        model.isAcceptOrder = sdr["IsAcceptOrder"].ToString();
                        model.getOrderUserName = sdr["GetOrderUserName"].ToString();
                        lstInformation.Add(model);
                    }
                }

                return lstInformation;
            }

            public InformationModel GetModelById(string id)
            {
                string strSql = "SELECT * FROM dbo.Information WHERE Id=@id";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@id",System.Data.SqlDbType.VarChar,50)
                };
                parameters[0].Value = id;

                InformationModel model =new InformationModel();
                using (SqlDataReader sdr = DBHelper.ExecuteSqlReader(strSql, parameters))
                {
                    if (sdr.Read())
                    {
                        model.id = sdr["Id"].ToString();
                        model.userName = sdr["UserName"].ToString();
                        model.title = sdr["Title"].ToString();
                        model.content = sdr["Content"].ToString();
                        model.wage = sdr["Wage"].ToString();
                        model.viewCount = sdr["ViewCount"].ToString();
                        model.address = sdr["Address"].ToString();
                        model.addTime = sdr["AddTime"].ToString();
                        model.isAcceptOrder = sdr["IsAcceptOrder"].ToString();
                        model.getOrderUserName = sdr["GetOrderUserName"].ToString();
                    }
                }

                return model;
            }

            public IList<InformationModel> GetModelsByAddress(string address)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT * FROM dbo.Information WHERE Address LIKE '%");
                strSql.Append(address + "%' ORDER BY AddTime DESC");

                IList<InformationModel> lstInformation = new List<InformationModel>();
                using (SqlDataReader sdr = DBHelper.ExecuteSqlReader(strSql.ToString()))
                {
                    while (sdr.Read())
                    {
                        InformationModel model = new InformationModel();
                        model.id = sdr["Id"].ToString();
                        model.userName = sdr["UserName"].ToString();
                        model.title = sdr["Title"].ToString();
                        model.content = sdr["Content"].ToString();
                        model.wage = sdr["Wage"].ToString();
                        model.viewCount = sdr["ViewCount"].ToString();
                        model.address = sdr["Address"].ToString();
                        model.addTime = sdr["AddTime"].ToString();
                        model.isAcceptOrder = sdr["IsAcceptOrder"].ToString();
                        model.getOrderUserName = sdr["GetOrderUserName"].ToString();
                        lstInformation.Add(model);
                    }
                }

                return lstInformation;
            }
        }
    }
}