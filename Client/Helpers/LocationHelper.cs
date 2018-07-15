using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Storage;

namespace rongYunSample.Helpers
{
    public class LocationHelper:IDisposable
    {
        private static CancellationTokenSource _cts = null;
        private static uint _desireAccuracyInMetersValue = 0;
        static ApplicationDataContainer roamingSettings = ApplicationData.Current.RoamingSettings;

        /// <summary>
        /// 获取地址
        /// </summary>
        /// <returns>KeyValuePair类型，键名为GeocationAccessStatus,值为城市全称。注意：当GeolocationAccessStatus为Denied时，应请求用户给予权限</returns>
        public async Task<KeyValuePair<GeolocationAccessStatus,string>> GetLoacationAsync()
        {
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

                        string fomattedAddress = await UpdateLocationData(pos);
                        return new KeyValuePair<GeolocationAccessStatus, string>(GeolocationAccessStatus.Allowed, fomattedAddress);
                        //tbMessage.Text += "\nLocation updated.";

                    case GeolocationAccessStatus.Denied:
                        //tbMessage.Text = "Access to location is denied.";
                        await UpdateLocationData(null);
                        return new KeyValuePair<GeolocationAccessStatus, string>(GeolocationAccessStatus.Denied, string.Empty);
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

                    case GeolocationAccessStatus.Unspecified:
                        //tbMessage.Text = "Unspecified error.";
                        await UpdateLocationData(null);
                        return new KeyValuePair<GeolocationAccessStatus, string>(GeolocationAccessStatus.Unspecified, string.Empty);
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

            return new KeyValuePair<GeolocationAccessStatus, string>(GeolocationAccessStatus.Unspecified, string.Empty);
        }

        /// <summary>
        /// 此方法获取坐标对应的地理名，将城镇明储存在同步存储中，返回全称
        /// </summary>
        /// <param name="pos">Geoposition 类型的地理坐标</param>
        /// <returns>城市全称</returns>
        private async Task<string> UpdateLocationData(Geoposition pos)
        {
            try
            {
                if (pos == null)
                {
                    //this.tbMessage.Text += "\nNo data.";
                    return string.Empty;
                }
                else
                {
                    string longitude = pos.Coordinate.Point.Position.Longitude.ToString();//精度
                    string latitude = pos.Coordinate.Point.Position.Latitude.ToString();//纬度
                    //this.tbMessage.Text += $"\n经度为{longitude}，纬度为{latitude}";
                    HttpService http = new HttpService();
                    string response = await http.SendGetRequest(InterfaceUrl.GetRegeoUrl(longitude, latitude));
                    if (response != string.Empty)
                    {
                        string city = GetCityAndDistrict(response);
                        roamingSettings.Values[Constants.SettingName.Location] = city;
                        string formattedAddress = GetFormattedAddress(response);
                        return formattedAddress;
                        //tbMessage.Text += $"\n城市为{city}，全位置为{formattedAddress}";
                    }
                }
            }
            catch { }
            return string.Empty;
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

        public void Dispose()
        {
            if (_cts != null)
            {
                _cts.Cancel();
                _cts = null;
            }
        }
    }
}
