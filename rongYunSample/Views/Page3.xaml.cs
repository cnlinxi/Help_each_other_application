using rongYunSample.Data;
using rongYunSample.Helpers;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace rongYunSample.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page3 : Page
    {
        private MyTaskList myTaskList;
        private string userName = string.Empty;

        public Page3()
        {
            this.InitializeComponent();

            myTaskList = new MyTaskList();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            UserAccountHelper userAccout = new UserAccountHelper ();
            userName = userAccout.GetUserNameFromLocker();
            if(userName==string.Empty)
            {
                await new MessageBox("你尚未登陆", MessageBox.NotifyType.CommonMessage).ShowAsync();
                this.Frame.Navigate(typeof(UserAccount));
                return;
            }

            this.lvInformationList.ItemsSource = myTaskList;
            myTaskList.DataLoading += LstInformationList_DataLoading;
            myTaskList.DataLoaded += LstInformationList_DataLoaded;

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

        private async void PullToRefreshBox_RefreshInvoked(DependencyObject sender, object args)
        {
            myTaskList.DoRefresh();
            await lvInformationList.LoadMoreItemsAsync();
        }

        private void lvInformationList_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(ShowMyTask), new object[] { e.ClickedItem });
        }
    }
}
