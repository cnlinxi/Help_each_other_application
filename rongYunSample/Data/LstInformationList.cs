using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.Foundation;
using rongYunDemo.Helpers;
using rongYunSample.Models;
using rongYunSample.Helpers;

namespace rongYunSample.Data
{
    public class LstInformationList : ObservableCollection<InformationListModel>, ISupportIncrementalLoading
    {
        private bool isBusy = false;
        private bool isHaveMoreItems = false;
        private int pageSize = Constants.PageSize;
        private int currentPage = 1;
        public event DataLoadedEventHandler DataLoaded;
        public event DataLoadingEventHandler DataLoading;
        private Windows.Storage.ApplicationDataContainer roamingSettings = Windows.Storage.ApplicationData.Current.RoamingSettings;
        private string address = string.Empty;

        public LstInformationList()
        {
            isHaveMoreItems = true;
            if(roamingSettings.Values.ContainsKey(Constants.SettingName.LoadPageSize))
            {
                pageSize = Convert.ToInt32(roamingSettings.Values[Constants.SettingName.LoadPageSize]);
            }
            if(roamingSettings.Values.ContainsKey(Constants.SettingName.UserAddress))
            {
                address = roamingSettings.Values[Constants.SettingName.UserAddress].ToString();
            }
        }
        public bool HasMoreItems
        {
            get
            {
                if (isBusy)
                    return false;
                else
                    return isHaveMoreItems;
            }
            set
            {
                isHaveMoreItems = value;
            }
        }

        public uint TotalCount
        {
            get; set;
        }

        public void DoRefresh()
        {
            isHaveMoreItems = true;
            currentPage = 1;
            TotalCount = 0;
            Clear();
        }

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            return InnerLoadMoreItemsAsync(count).AsAsyncOperation();
        }

        private async Task<LoadMoreItemsResult> InnerLoadMoreItemsAsync(uint count)
        {
            isBusy = true;
            uint actualCount = 0;
            List<InformationListModel> lstInformationList = null;
            try
            {
                if (DataLoading != null)
                {
                    DataLoading();
                }
                lstInformationList = await InformationHelper.GetInformationListByAddressAsync(currentPage, pageSize,address);
            }
            catch
            {
                isHaveMoreItems = false;
            }
            finally
            {
                if(lstInformationList!=null&&lstInformationList.Any())
                {
                    actualCount = (uint)lstInformationList.Count;
                    TotalCount += actualCount;
                    ++currentPage;
                    isHaveMoreItems = true;
                    lstInformationList.ForEach((item) => this.Add(item));
                }
                else
                {
                    isHaveMoreItems = false;
                }

                if(DataLoaded!=null)
                {
                    DataLoaded();
                }
                isBusy = false;
            }

            return new LoadMoreItemsResult
            {
                Count = actualCount
            };
        }
    }
}
