using rongYunSample.Data;
using System;
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

        public Page1()
        {
            this.InitializeComponent();

            lstInformationList = new LstInformationList();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.lvInformationList.ItemsSource = lstInformationList;
            lstInformationList.DataLoading += LstInformationList_DataLoading;
            lstInformationList.DataLoaded += LstInformationList_DataLoaded;

            base.OnNavigatedTo(e);
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
