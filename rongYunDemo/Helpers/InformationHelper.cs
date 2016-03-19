using Newtonsoft.Json.Linq;
using rongYunDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rongYunDemo.Helpers
{
    public class InformationHelper
    {
        public async static Task<List<InformationListModel>>GetInformationListByAddressAsync(int pageIndex,int pageSize,string address)
        {
            try
            {
                HttpService http = new HttpService();
                string response = await http.SendGetRequest(
                    InterfaceUrl.GetInformationListByAddress(pageIndex, pageSize, address));
                if(response!=string.Empty)
                {
                    JArray jsonArray = JArray.Parse(response);
                    List<InformationListModel> lstInformationList = new List<InformationListModel>();
                    foreach(var json in jsonArray)
                    {
                        InformationListModel model = new InformationListModel();
                        model.informationId = json["informationId"].ToString();
                        model.userId = json["userId"].ToString();
                        model.avatorUri = json["avatorUri"].ToString();
                        model.userName = json["userName"].ToString();
                        model.title = json["title"].ToString();
                        model.summary = json["summary"].ToString();
                        model.viewCount = json["viewCount"].ToString();
                        model.publishTime = json["publishTime"].ToString();
                        model.publishAddress = json["publishAddress"].ToString();
                        lstInformationList.Add(model);
                    }
                    return lstInformationList;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
