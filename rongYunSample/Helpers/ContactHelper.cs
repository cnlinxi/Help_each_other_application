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
        /// <param name="toEmailAddress">目标邮箱</param>
        /// <param name="fromName">发送人的用户名</param>
        /// <param name="fromEmailAddress">发送人的邮箱</param>
        /// <param name="taskTitle">任务名称</param>
        /// <returns></returns>
        public static async Task ComposeEmail(string toEmailAddress,string fromName,string fromEmailAddress,string taskTitle)
        {
            EmailMessage emailMessage = new EmailMessage();
            emailMessage.To.Add(new EmailRecipient(toEmailAddress));
            emailMessage.Subject = Constants.ContactContent.Subject;
            emailMessage.Body = Constants.ContactContent.EmailBody(fromName,fromEmailAddress,taskTitle);
            await EmailManager.ShowComposeNewEmailAsync(emailMessage);
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="toPhoneNumber">目标电话号码</param>
        /// <param name="fromName">发送人的用户名</param>
        /// <param name="fromPhoneNumber">发送人的电话号码</param>
        /// <param name="taskTitle">任务地址</param>
        /// <returns></returns>
        public static async Task ComposeSms(string toPhoneNumber, string fromName, string fromPhoneNumber, string taskTitle)
        {
            var chatMessage = new Windows.ApplicationModel.Chat.ChatMessage();
            chatMessage.Body = Constants.ContactContent.SmsBody(fromName,fromPhoneNumber,taskTitle);
            chatMessage.Recipients.Add(toPhoneNumber);
            await ChatMessageManager.ShowComposeSmsMessageAsync(chatMessage);
        }
    }
}
