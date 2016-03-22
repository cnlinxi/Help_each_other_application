using rongYunSample.Data;
using rongYunSample.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace rongYunSample.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page1 : Page
    {
        private LstInformationList lstInformationList;
        private LocationHelper location;

        public Page1()
        {
            this.InitializeComponent();

            lstInformationList = new LstInformationList();
            location = new LocationHelper();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            this.lvInformationList.ItemsSource = lstInformationList;
            lstInformationList.DataLoading += LstInformationList_DataLoading;
            lstInformationList.DataLoaded += LstInformationList_DataLoaded;

            //获取地理位置
            await InitLocation();

            base.OnNavigatedTo(e);
        }

        private async Task InitLocation()
        {
            tbLocationStatus.Text = "定位中...";
            KeyValuePair<GeolocationAccessStatus, string> addressPair = await location.GetLoacationAsync();
            if (addressPair.Key == GeolocationAccessStatus.Allowed)
            {
                tbLocationStatus.Text = addressPair.Value;
            }
            else if (addressPair.Key == GeolocationAccessStatus.Denied)
            {
                tbLocationStatus.Text = "最远的距离就是:我不知道你身在何处。修改定位选项：";
            }
            else if (addressPair.Key == GeolocationAccessStatus.Unspecified)
            {
                tbLocationStatus.Text = "我对你的定位出了一丢丢的问题~";
            }
        }

        private void LstInformationList_DataLoaded()
        {
            this.loading.IsActive = false;
        }

        private void LstInformationList_DataLoading()
        {
            this.loading.IsActive = true;
        }

        private void linkUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void PullToRefreshBox_RefreshInvoked(DependencyObject sender, object args)
        {
            lstInformationList.DoRefresh();
            await lvInformationList.LoadMoreItemsAsync();
        }

        private void lvInformationList_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
