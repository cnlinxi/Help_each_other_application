using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rongYunSample.Models
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
}
