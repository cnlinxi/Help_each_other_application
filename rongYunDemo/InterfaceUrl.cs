using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rongYunDemo
{
    public class InterfaceUrl
    {
        private static string apiHost = "http://rongyunsample.chinacloudsites.cn/";

        public static string CreateInformationUrl = apiHost + "api/Information";
        public static string GetInformationByUserName(string userName)
        {
            return apiHost + $"api/Information?userName={userName}";
        }
        public static string GetInformationListByAddress(int pageIndex,int pageSize,string address)
        {
            if(address=="")
            {
            return apiHost + $"api/InformationList?pageIndex={pageIndex}&pageSize={pageSize}";
            }
            else
            {
                return apiHost + $"api/InformationList?pageIndex={pageIndex}&pageSize={pageSize}&address={address}";
            }
        }

        private static string amapHost = "http://restapi.amap.com/v3/geocode/regeo";
        public static string GetRegeoUrl(string longitude,string latitude)
        {
            return amapHost + $"?output=json&key=d8c91faa67ec4cb4d8f843285c71d960&location={longitude},{latitude}";
        }

    }
}
