using rongYunWebApiSample.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;

namespace rongYunWebApiSample.Models
{
    public class InformationListDetails
    {
        public class InformationListModel
        {
            public string informationId { get; set; }
            public string userId { get; set; }
            public string avatorUri { get; set; }
            public string userName { get; set; }
            public string title { get; set; }
            public string summary { get; set; }
            public string viewCount { get; set; }
            public string publishTime { get; set; }
            public string publishAddress { get; set; }
        }

        public interface IInformationListRepository
        {
            IList<InformationListModel> GetInformationListByAddress(int pageIndex, int pageSize,string address="");
        }

        public class InformationListRepository : IInformationListRepository
        {
            public IList<InformationListModel> GetInformationListByAddress(int pageIndex, int pageSize, string address="")
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT ");
                if(pageSize>0)
                {
                    strSql.Append("TOP "+pageSize);
                }
                strSql.Append(" dbo.Information.Id AS InformationId,dbo.Users.Id AS UserId,dbo.Users.AvatorUri,dbo.Users.UserName,dbo.Information.Title,dbo.Information.Content,dbo.Information.ViewCount,dbo.Information.AddTime,dbo.Information.Address");
                strSql.Append(" FROM dbo.Information INNER JOIN dbo.Users ON dbo.Information.UserName=dbo.Users.UserName");
                if(pageIndex>0&&pageSize>0)
                {
                    strSql.Append(" WHERE dbo.Information.Id NOT IN");
                    strSql.Append("(SELECT TOP " + pageSize*(pageIndex-1));
                    strSql.Append(" Id FROM dbo.Information ORDER BY dbo.Information.AddTime DESC)");
                }
                if(address!="")
                {
                    strSql.Append(" AND Address LIKE '%");
                    strSql.Append(address + "%'");
                }
                strSql.Append(" ORDER BY dbo.Information.AddTime DESC");

                IList<InformationListModel> lstInformation = new List<InformationListModel>();
                using (SqlDataReader sdr = DBHelper.ExecuteSqlReader(strSql.ToString()))
                {
                    while(sdr.Read())
                    {
                        InformationListModel model = new InformationListModel();
                        model.informationId = sdr["InformationId"].ToString();
                        
                        model.avatorUri = sdr["AvatorUri"].ToString();
                        model.userId = sdr["UserId"].ToString();
                        model.title = sdr["Title"].ToString();
                        string xmlContent= sdr["Content"].ToString();
                        XmlDocument xmlDocument = new XmlDocument();
                        xmlDocument.LoadXml(xmlContent);
                        XmlNode contentNode = xmlDocument.FirstChild;
                        string content = contentNode.InnerText;
                        if(content.Length>30)
                        {
                            model.summary = content.Substring(0, 30);//截取30个字符作为summamry
                        }
                        else
                        {
                            model.summary = content;
                        }
                        model.viewCount = sdr["ViewCount"].ToString();
                        model.publishTime = sdr["AddTime"].ToString();
                        model.publishAddress = sdr["Address"].ToString();
                        lstInformation.Add(model);
                    }
                }
                return lstInformation;
            }
        }
    }
}