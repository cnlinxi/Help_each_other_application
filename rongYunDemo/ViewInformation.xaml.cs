using Newtonsoft.Json.Linq;
using rongYunDemo.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace rongYunDemo
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ViewInformation : Page
    {
        string userName = string.Empty;
        public ViewInformation()
        {
            this.InitializeComponent();
            userName = "cmn";
        }

        private async void btnGetContent_Click(object sender, RoutedEventArgs e)
        {
            this.btnGetContent.IsEnabled = false;
            this.loading.IsActive = true;
            await GetInformation();
            this.btnGetContent.IsEnabled = true;
            this.loading.IsActive = false;
        }

        private async Task GetInformation()
        {
            try
            {
                HttpService http = new HttpService();
                string response = 
                    await http.SendGetRequest(InterfaceUrl.GetInformationByUserName(userName));
                string content = GetContent(response);
                if (content != string.Empty)
                {
                    wvConent.NavigateToString(content);
                    txtMessage.Text = response+"\n"+content;
                }
            }
            catch (Exception ex)
            {
                txtMessage.Text = "拉取失败，失败原因：" + ex.Message;
            }
        }

        private string GetContent(string jsonContent)
        {
            if (jsonContent == string.Empty)
                return string.Empty;
            try
            {
                JArray jsonArray = JArray.Parse(jsonContent);
                if (jsonArray.Count <= 0)
                    return string.Empty;
                return jsonArray[0]["content"].ToString();
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
