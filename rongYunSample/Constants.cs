using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rongYunSample
{
    public class Constants
    {
        //标题最大字数
        public const int TitleMaxLength = 25;
        //内容最大字数
        public const int ContentMaxLength = 2000;
        // 规定每次加载10个item
        public const int PageSize = 10;

        public class SettingName
        {
            public const string LoadPageSize = "LoadPageSize";
            public const string UserAddress = "UserAddress";
            public const string Token = "Token";
            public const string Location = "Location";
        }

        public class ContactContent
        {
            public const string Subject = "来自邻里帮";
            public static string EmailBody(string fromName,string fromEmailAddress,string taskTitle)
            {
                return $"你好，我是{fromName},来自邻里帮.我对你的{taskTitle}任务感兴趣,我的邮箱地址:{fromEmailAddress}";
            }
            public static string SmsBody(string fromName,string fromPhoneNumber,string taskTitle)
            {
                return $"你好，我是{fromName},来自邻里帮.我对你的{taskTitle}任务感兴趣,我的联系方式:{fromPhoneNumber}";
            }
        }
    }
}
