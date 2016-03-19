using rongYunDemo.Common;
using rongYunDemo.Helpers;
using rongYunDemo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Xml;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace rongYunDemo
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string imageName = string.Empty;
        int numForImageName = 0;
        string userName = "cmn";
        string encriptUserName = string.Empty;
        List<string> lstFileUrl;
        string address = "zjg";
        public MainPage()
        {
            this.InitializeComponent();
            //关闭缓存页面
            this.NavigationCacheMode = NavigationCacheMode.Disabled;
            encriptUserName = EncriptHelper.ToMd5(userName).ToLower();
            lstFileUrl = new List<string>();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            //当从ShowPicture返回时，如果执行了取消上传的操作，e.Parameter是有值的
            //那么就将这个StorageFile从App.list中移除
            if (e.Parameter is Dictionary<string, Image>)
            {
                Dictionary<string, Image> data = e.Parameter as Dictionary<string, Image>;
                KeyValuePair<string, Image> value = data.FirstOrDefault();
                if (value.Value != null)
                {
                    App.lstPicture.RemoveAt(Convert.ToInt32(value.Key));

                    #region 2016年2月14日19:34:27 此代码依靠页面缓存，实现：如果取消一图片上传，回到此界面时此图片预览消失，但是由于需要改动页面状态中某些图片的名字（Name属性），与系统默认的缓存机制发生冲突，会发生VS无法捕获的异常
                    //Image image = value.Value;
                    //string strRight = null;
                    ////string strLeft = "null";
                    //Object objRight = image.GetValue(RelativePanel.RightOfProperty);
                    //if (objRight != null)
                    //{
                    //    strRight = objRight.ToString();
                    //}
                    ////object objLeft= image.GetValue(RelativePanel.LeftOfProperty);
                    ////if(objLeft!=null)
                    ////{
                    ////    strLeft = objLeft.ToString();
                    ////}
                    ////this.tbMessage.Text = "AlignRight:" + strRight + "\nAlignLeft:" + strLeft;

                    //string name = image.Name;
                    //string imgNeedModifyName = "";
                    //foreach (var obj in root.Children)
                    //{
                    //    if(obj is Image)
                    //    {
                    //        object objRightName = obj.GetValue(RelativePanel.RightOfProperty);
                    //        if (objRightName != null)
                    //        {
                    //            string strRightName = objRightName.ToString();
                    //            if (strRightName == name)
                    //            {
                    //                Image imgRightNeedModify = obj as Image;
                    //                imgNeedModifyName=imgRightNeedModify.Name;
                    //                imgRightNeedModify.SetValue(RelativePanel.RightOfProperty, strRight);
                    //                break;
                    //                //isNeedModifyName = true;
                    //            }
                    //            //if(isNeedModifyName)
                    //            //{
                    //            //    Image imageNeedModifyName = obj as Image;
                    //            //    imageNeedModifyName.Name = (Convert.ToInt32(imageNeedModifyName.Name) - 1).ToString();
                    //            //}
                    //        }
                    //    }
                    //}

                    //bool isNeedModifyName = false;
                    //foreach (var obj in root.Children)
                    //{
                    //    if (obj is Image)
                    //    {
                    //        object objRightName = obj.GetValue(RelativePanel.RightOfProperty);
                    //        if (objRightName != null)
                    //        {
                    //            string strRightName = objRightName.ToString();
                    //            if (strRightName == name)
                    //            {
                    //                isNeedModifyName = true;
                    //            }
                    //            if (isNeedModifyName)
                    //            {
                    //                Image imageNeedModifyName = obj as Image;
                    //                imageNeedModifyName.Name = (Convert.ToInt32(imageNeedModifyName.Name) - 1).ToString();
                    //            }
                    //        }
                    //    }
                    //}
                    //numForImageName--;
                    //image.Visibility = Visibility.Collapsed;
                    #endregion

                    #region 废旧代码 2016年2月13日22:56:13
                    //int pictureCounter = App.list.Count;
                    //numForImageName = 0;
                    //if (pictureCounter > 0)
                    //{
                    //    int i = 0;
                    //    while (i < pictureCounter)
                    //    {
                    //        Image image = new Image();
                    //        BitmapImage bitmap = new BitmapImage();
                    //        using (var stream = await App.list[i].OpenReadAsync())
                    //        {
                    //            await bitmap.SetSourceAsync(stream);
                    //            image.Source = bitmap;
                    //            image.Name = numForImageName.ToString();
                    //            image.Height = 50;
                    //            image.Width = 50;
                    //            image.Margin = new Thickness(5);
                    //            image.Tapped += Image_Tapped;
                    //            if (imageName == "")
                    //            {
                    //                image.SetValue(RelativePanel.AlignLeftWithPanelProperty, true);
                    //                imageName = image.Name;
                    //            }
                    //            else
                    //            {
                    //                image.SetValue(RelativePanel.RightOfProperty, imageName);
                    //                imageName = image.Name;
                    //            }
                    //            root.Children.Add(image);
                    //            i++;
                    //            numForImageName++;
                    //        }
                    //    }
                    //    btnAdd.SetValue(RelativePanel.RightOfProperty, imageName);
                    //    //btnAdd.Visibility = Visibility.Collapsed;
                    //}
                    #endregion
                }
            }

            //注意:页面状态全部由我自己维护，所以以下代码使用App.list中储存的StorageFile
            //来恢复想要上传的图片预览和按钮
            numForImageName = 0;
            int pictureCounter = App.lstPicture.Count;
            if (pictureCounter > 0)
            {
                int i = 0;
                while (i < pictureCounter)
                {
                    Image image = new Image();
                    BitmapImage bitmap = new BitmapImage();
                    using (var stream = await App.lstPicture[i].OpenReadAsync())
                    {
                        await bitmap.SetSourceAsync(stream);
                        image.Source = bitmap;
                        image.Name = numForImageName.ToString();
                        image.Height = 50;
                        image.Width = 50;
                        image.Margin = new Thickness(5);
                        image.Tapped += Image_Tapped;
                        if (imageName == "")
                        {
                            image.SetValue(RelativePanel.AlignLeftWithPanelProperty, true);
                            imageName = image.Name;
                        }
                        else
                        {
                            image.SetValue(RelativePanel.RightOfProperty, imageName);
                            imageName = image.Name;
                        }
                        root.Children.Add(image);
                        i++;
                        numForImageName++;
                    }
                }
                btnAddPicture.SetValue(RelativePanel.RightOfProperty, imageName);
            }

            base.OnNavigatedTo(e);
        }

        private void txtContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbContentRemaining.Text = (Constants.ContentMaxLength - txtContent.Text.Length).ToString();
        }

        private void txtTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbTitleRemaining.Text = (Constants.TitleMaxLength - txtTitle.Text.Length).ToString();
        }

        private async void btnAddPicture_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            var file = await picker.PickMultipleFilesAsync();

            int pictureCounter = file.Count;
            if (pictureCounter > 0)
            {
                App.lstPicture.AddRange(file.ToList());//this code is wrong , it should be list.add

                int i = 0;
                while (i < pictureCounter)
                {
                    Image image = new Image();
                    BitmapImage bitmap = new BitmapImage();
                    using (var stream = await file[i].OpenReadAsync())
                    {
                        await bitmap.SetSourceAsync(stream);
                        image.Source = bitmap;
                        image.Name = numForImageName.ToString();
                        image.Height = 50;
                        image.Width = 50;
                        image.Margin = new Thickness(5);
                        image.Tapped += Image_Tapped;
                        if (imageName == "")
                        {
                            image.SetValue(RelativePanel.AlignLeftWithPanelProperty, true);
                            imageName = image.Name;
                        }
                        else
                        {
                            image.SetValue(RelativePanel.RightOfProperty, imageName);
                            imageName = image.Name;
                        }
                        root.Children.Add(image);
                        i++;
                        numForImageName++;
                    }
                }
                btnAddPicture.SetValue(RelativePanel.RightOfProperty, imageName);
                //btnAdd.Visibility = Visibility.Collapsed;
            }
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Image image = sender as Image;
            Dictionary<string, Image> dataPicture = new Dictionary<string, Image>();
            dataPicture.Add(image.Name, image);
            this.Frame.Navigate(typeof(ShowPicture), dataPicture);
        }

        private async void btnPublish_Click(object sender, RoutedEventArgs e)
        {
            if (userName == string.Empty)
                return;
            this.loading.IsActive = true;
            btnPublish.IsEnabled = false;
            await PublishInformation(txtTitle.Text, txtContent.Text);
            this.loading.IsActive = false;
            btnPublish.IsEnabled = true;
        }

        private async Task PublishInformation(string title,string content)
        {
            string strFileName = FileHelper.GenerateFileNameByUserName(userName);
            BlobHelper blob = new BlobHelper();
            await blob.CreateContainer(encriptUserName);
            for(int i=0;i<App.lstPicture.Count;++i)
            {
                string fileUrl = strFileName + i;
                await blob.UploadFromStorageFile(App.lstPicture[i], encriptUserName, fileUrl);
                lstFileUrl.Add(FileHelper.GenerateFileUrl(fileUrl,encriptUserName));
            }
            InformationModel model = new InformationModel();
            model.title = title;
            model.content = FileHelper.GenerateXMLDocument(content, lstFileUrl);
            model.addTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            model.userName = userName;
            model.viewCount = "0";
            model.address = address;
            string jsonContent = JsonHelper.ObjectToJson(model);
            HttpService http = new HttpService();
            await http.SendPostRequest(InterfaceUrl.CreateInformationUrl, jsonContent);
        }

        private void btnGetInformationContent_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ViewInformation));
        }

        private void btnGetGeolocation_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Location));
        }

        private void btnUploadAvator_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(UploadAvator));
        }
    }
}
