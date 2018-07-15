using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace rongYunSample.Helpers
{
    public class FileHelper
    {
        /// <summary>
        /// 使用UserName生成唯一文件名
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>文件名</returns>
        public static string GenerateFileNameByUserName(string userName)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return userName + time;
        }

        /// <summary>
        /// 生成blob storage中文件的Url
        /// </summary>
        /// <param name="strFileName">文件名</param>
        /// <param name="containerName">容器名</param>
        /// <returns>Url</returns>
        public static string GenerateFileUrl(string strFileName, string containerName)
        {
            return $"http://mycontainner.blob.core.chinacloudapi.cn/{containerName}/{strFileName}";
        }

        public static string GenerateXMLDocument(string content, List<string> lstFileUrl)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlElement rootElement = xmlDoc.CreateElement("p");
                xmlDoc.AppendChild(rootElement);

                XmlElement contentElement = xmlDoc.CreateElement("p");
                contentElement.InnerText = content;
                rootElement.AppendChild(contentElement);

                XmlElement imgElement_p = xmlDoc.CreateElement("p");
                for (int i = 0; i < lstFileUrl.Count; ++i)
                {
                    XmlElement imgElement = xmlDoc.CreateElement("img");
                    imgElement.SetAttribute("src", lstFileUrl[i]);
                    imgElement.SetAttribute("alt", "image");
                    imgElement_p.AppendChild(imgElement);
                }
                rootElement.AppendChild(imgElement_p);

                return xmlDoc.InnerXml;
            }
            catch
            {
                return null;
            }
        }
    }
}
