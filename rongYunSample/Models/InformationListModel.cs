using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rongYunSample.Models
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
}
