using Newtonsoft.Json.Linq;
using rongYunSample.Common;
using rongYunSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rongYunSample.Helpers
{
    public class InformationHelper
    {
        public async static Task<List<InformationListModel>>GetInformationListByAddressAsync(int pageIndex,int pageSize,string address="")
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

        public async static Task<List<InformationListModel>> GetInformationListByUserNameAsync(int pageIndex, int pageSize, string userName)
        {
            try
            {
                HttpService http = new HttpService();
                string response = await http.SendGetRequest(
                    InterfaceUrl.GetInformationListByUserName(pageIndex, pageSize, userName));
                if (response != string.Empty)
                {
                    JArray jsonArray = JArray.Parse(response);
                    List<InformationListModel> lstInformationList = new List<InformationListModel>();
                    foreach (var json in jsonArray)
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

        public async static Task<InformationModel> GetInformationByIdAsync(string id)
        {
            try
            {
                HttpService http = new HttpService();
                string response = await http.SendGetRequest(InterfaceUrl.GetInformationById(id));
                if(response!=string.Empty)
                {
                    JObject jsonObject = JObject.Parse(response);
                    InformationModel model = new InformationModel();
                    model.id = jsonObject["id"].ToString();
                    model.userName = jsonObject["userName"].ToString();
                    model.wage = jsonObject["wage"].ToString();
                    model.title = jsonObject["title"].ToString();
                    model.viewCount = jsonObject["viewCount"].ToString();
                    model.content = jsonObject["content"].ToString();
                    model.isAcceptOrder = jsonObject["isAcceptOrder"].ToString();
                    model.getOrderUserName = jsonObject["getOrderUserName"].ToString();
                    model.addTime = jsonObject["addTime"].ToString();
                    model.address = jsonObject["address"].ToString();
                    return model;
                }
            }
            catch
            {

            }
            return null;
        }

        public async static Task<ContactModel> GetInfoAuthorDetails(string authorName)
        {
            try
            {
                HttpService http = new HttpService();
                string response = await http.SendGetRequest(InterfaceUrl.UserLogin(authorName));
                if(response!=string.Empty)
                {
                    ContactModel authorDetail = new ContactModel();
                    JObject jsonObject = JObject.Parse(response);
                    authorDetail.toUserName = jsonObject["UserName"].ToString();
                    authorDetail.toEmailAddress = jsonObject["Email"].ToString();
                    authorDetail.toPhoneNumber = jsonObject["PhoneNumber"].ToString();
                    return authorDetail;
                }
            }
            catch { }
            return null;
        }

        public async static Task UpdateInfo(string infoId,InformationModel model)
        {
            try
            {
                HttpService http = new HttpService();
                string jsonContent = JsonHelper.ObjectToJson(model);
                await http.SendPutRequest(InterfaceUrl.UpdateInformation(infoId), jsonContent);
            }
            catch { }
        }

        public async static Task DeleteInfo(string infoId)
        {
            try
            {
                HttpService http = new HttpService();
                await http.SendDeleteRequest(InterfaceUrl.DeleteInformation(infoId));
            }
            catch
            { }
        }
    }
}
