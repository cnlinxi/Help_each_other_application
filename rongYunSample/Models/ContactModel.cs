using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rongYunSample.Models
{
    public class ContactModel
    {
        public string taskTitle { get; set; }
        public string toEmailAddress { get; set; }
        public string fromEmailAddress { get; set; }
        public string fromPhoneNumber { get; set; }
        public string toPhoneNumber { get; set; }
        public string fromUserName { get; set; }
        public string toUserName { get; set; }
    }
}
