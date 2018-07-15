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
            public const string EmailAddress = "EmailAddress";
            public const string PhoneNumber = "PhoneNumber";
        }

        public class OrderStatus
        {
            public const string NotAccept = "0";
            public const string AcceptNotFinish = "1";
            public const string Finished = "2";
        }

        //规定面议金额表示为-1
        public const string NegotiablePrice= "-1";

        public class FlagContactMode
        {
            //交流：寻求任务模式
            public const int AskTask = 0;
            //交流：发布任务与接受任务者交流模式
            public const int PublishTask = 1;
        }
        public class ContactContent
        {
            public const string Subject = "来自邻里帮";
            public static string EmailBody_AskTask(string fromName,string fromEmailAddress,string taskTitle)
            {
                return $"你好，我是{fromName},来自邻里帮.我对你的{taskTitle}任务感兴趣,我的邮箱地址:{fromEmailAddress}";
            }
            public static string SmsBody_AskTask(string fromName,string fromPhoneNumber,string taskTitle)
            {
                return $"你好，我是{fromName},来自邻里帮.我对你的{taskTitle}任务感兴趣,我的联系方式:{fromPhoneNumber}";
            }
            public static string EmailBody_PublishTask(string fromName,string taskTitle)
            {
                return $"你好，我是{fromName},来自邻里帮.你为我完成了{taskTitle}";
            }
            public static string SmsBody_PublishTask(string fromName,string taskTitle)
            {
                return $"你好，我是{fromName},来自邻里帮.你为我完成了{taskTitle}";
            }
        }
    }
}
