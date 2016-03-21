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
        }
    }
}
