using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Calls;
using Windows.ApplicationModel.Chat;
using Windows.ApplicationModel.Email;

namespace rongYunSample.Helpers
{
    public class ContactHelper
    {
        public static void PhoneCall(string phoneNumber,string diaplayName)
        {
            PhoneCallManager.ShowPhoneCallUI(phoneNumber, diaplayName);
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="toEmailAddress">目标邮箱地址</param>
        /// <param name="body">邮件主体</param>
        /// <returns></returns>
        public static async Task ComposeEmail(string toEmailAddress,string body)
        {
            EmailMessage emailMessage = new EmailMessage();
            emailMessage.To.Add(new EmailRecipient(toEmailAddress));
            emailMessage.Subject = Constants.ContactContent.Subject;
            emailMessage.Body = body;
            await EmailManager.ShowComposeNewEmailAsync(emailMessage);
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="toPhoneNumber">目标电话号码</param>
        /// <param name="body">短信主体</param>
        /// <returns></returns>
        public static async Task ComposeSms(string toPhoneNumber, string body)
        {
            var chatMessage = new Windows.ApplicationModel.Chat.ChatMessage();
            chatMessage.Body = body;
            chatMessage.Recipients.Add(toPhoneNumber);
            await ChatMessageManager.ShowComposeSmsMessageAsync(chatMessage);
        }
    }
}
