using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace rongYunWebApiSample.Common
{
    public class EncriyptHelper
    {
        public static string ToMd5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = md5.ComputeHash(Encoding.Default.GetBytes(str)); 
            return BitConverter.ToString(bytes).Replace("-", "");
        }
    }
}