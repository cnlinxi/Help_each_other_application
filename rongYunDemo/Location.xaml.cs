using Newtonsoft.Json.Linq;
using rongYunDemo.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
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
    public sealed partial class Location : Page
    {
        private CancellationTokenSource _cts = null;
        private uint _desireAccuracyInMetersValue = 0;

        public Location()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            GetGeolocation();

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if(_cts!=null)
            {
                _cts.Cancel();
                _cts = null;
            }

            base.OnNavigatedFrom(e);
        }

        private async void GetGeolocation()
        {
            this.loading.IsActive = true;

            try
            {
                // Request permission to access location
                var accessStatus = await Geolocator.RequestAccessAsync();

                switch (accessStatus)
                {
                    case GeolocationAccessStatus.Allowed:

                        // Get cancellation token
                        _cts = new CancellationTokenSource();
                        CancellationToken token = _cts.Token;

                        // If DesiredAccuracy or DesiredAccuracyInMeters are not set (or value is 0), DesiredAccuracy.Default is used.
                        Geolocator geolocator = new Geolocator { DesiredAccuracyInMeters = _desireAccuracyInMetersValue };

                        // Carry out the operation
                        Geoposition pos = await geolocator.GetGeopositionAsync().AsTask(token);

                        await UpdateLocationData(pos);
                        tbMessage.Text += "\nLocation updated.";
                        break;

                    case GeolocationAccessStatus.Denied:
                        tbMessage.Text = "Access to location is denied.";
                        await UpdateLocationData(null);
                        //没有权限，应该向用户申请权限
                        //参考资料：https://msdn.microsoft.com/zh-cn/library/windows/apps/xaml/mt219698.aspx
                        //bool result = await Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-location"));
                        //                < TextBlock x: Name = "LocationDisabledMessage" FontStyle = "Italic"
                        //         Visibility = "Collapsed" Margin = "0,15,0,0" TextWrapping = "Wrap" >

                        //      < Run Text = "This app is not able to access Location. Go to " />

                        //           < Hyperlink NavigateUri = "ms-settings:privacy-location" >

                        //                < Run Text = "Settings" />

                        //             </ Hyperlink >

                        //         < Run Text = " to check the location privacy settings." />
                        //</ TextBlock >
                        break;

                    case GeolocationAccessStatus.Unspecified:
                        tbMessage.Text = "Unspecified error.";
                        await UpdateLocationData(null);
                        break;
                }
            }
            catch (TaskCanceledException)
            {
                
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                _cts = null;
            }
        }

        private async Task UpdateLocationData(Geoposition pos)
        {
            try
            {
                if (pos == null)
                {
                    this.tbMessage.Text += "\nNo data.";
                }
                else
                {
                    string longitude = pos.Coordinate.Point.Position.Longitude.ToString();//精度
                    string latitude = pos.Coordinate.Point.Position.Latitude.ToString();//纬度
                    this.tbMessage.Text += $"\n经度为{longitude}，纬度为{latitude}";
                    HttpService http = new HttpService();
                    string response = await http.SendGetRequest(InterfaceUrl.GetRegeoUrl(longitude, latitude));
                    if (response != string.Empty)
                    {
                        string city = GetCityAndDistrict(response);
                        string formattedAddress = GetFormattedAddress(response);
                        tbMessage.Text += $"\n城市为{city}，全位置为{formattedAddress}";
                    }
                }
            }
            catch { }
            finally
            {
                this.loading.IsActive = false;
            }
        }

        private string GetCityAndDistrict(string jsonContent)
        {
            try
            {
                JObject jsonObject = JObject.Parse(jsonContent);
                return jsonObject["regeocode"]["addressComponent"]["city"].ToString() +
                    jsonObject["regeocode"]["addressComponent"]["district"].ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        private string GetFormattedAddress(string jsonContent)
        {
            try
            {
                JObject jsonObject = JObject.Parse(jsonContent);
                return jsonObject["regeocode"]["formatted_address"].ToString();
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
