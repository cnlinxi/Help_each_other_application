using rongYunSample.Helpers;
using rongYunSample.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace rongYunSample.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ShowInformationDetails : Page
    {
        private string userName = string.Empty;
        private string infoAuthorName = string.Empty;
        private string taskTitle = string.Empty;

        private ContactModel contactModel;
        InformationModel inforModel;
        private ApplicationDataContainer roamingSetting = ApplicationData.Current.RoamingSettings;
        public ShowInformationDetails()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.loading.IsActive = true;
            UserAccountHelper userAccount = new UserAccountHelper();
            userName = userAccount.GetUserNameFromLocker();

            IntialMyContactModel();

            //初始化页面内容
            object[] parameters = e.Parameter as object[];
            InitPageContent(parameters);
            this.loading.IsActive = false;

            base.OnNavigatedTo(e);
        }

        /// <summary>
        /// 初始化交流发送方的信息
        /// </summary>
        private void IntialMyContactModel()
        {
            contactModel = new ContactModel();
            contactModel.fromUserName = userName;
            if (roamingSetting.Values.ContainsKey(Constants.SettingName.PhoneNumber))
                contactModel.fromPhoneNumber = roamingSetting.Values[Constants.SettingName.PhoneNumber].ToString();
            if (roamingSetting.Values.ContainsKey(Constants.SettingName.EmailAddress))
                contactModel.fromEmailAddress = roamingSetting.Values[Constants.SettingName.EmailAddress].ToString();
        }

        /// <summary>
        /// 初始化页面内容
        /// </summary>
        /// <param name="parameters">页面传参</param>
        private void InitPageContent(object[] parameters)
        {
            if (parameters != null)
            {
                if (parameters.Length == 1 && parameters[0] is InformationListModel)
                {
                    //InformationModel中不含发布者的AvatorUri，故用InformationListModel来初始化UserAvator
                    InformationListModel model = parameters[0] as InformationListModel;
                    BitmapImage bitmap = new BitmapImage(new Uri(model.avatorUri));
                    this.imgAvatar.Source = bitmap;
                    inforModel = InformationHelper.GetInformationByIdAsync(model.informationId).Result;
                    if (inforModel != null)
                    {
                        this.wvConent.NavigateToString(inforModel.content);
                        tbTitle.Text = taskTitle = inforModel.title;
                        tbWage.Text = " ￥ " + inforModel.wage;
                        linkUserName.Content = infoAuthorName = inforModel.userName;
                        tbPublishTime.Text = " 发布于 " + inforModel.addTime;
                        tbViewCount.Text = "(" + inforModel.viewCount + ")";
                    }
                }
            }
        }

        private void linkUserName_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            AppBarButton btn = sender as AppBarButton;
            //点击交谈按钮
            if(btn.Label== "Contact")
            {
                if (infoAuthorName == string.Empty)
                    return;
                this.loading.IsActive = true;
                ContactModel authorContactModel = await InformationHelper.GetInfoAuthorDetails(infoAuthorName);
                contactModel.toEmailAddress = authorContactModel.toEmailAddress;
                contactModel.toPhoneNumber = authorContactModel.toPhoneNumber;
                contactModel.toUserName = authorContactModel.toUserName;
                contactModel.taskTitle = taskTitle;
                this.loading.IsActive = false;

                await new ContactDialog(contactModel).ShowAsync();
            }

            if(btn.Label== "Accept")
            {
                var dialog = new MessageBox("是否接受任务？请核对任务金额，完成后你将从任务发布者获得任务酬劳。另外，为了保证任务完成，你的联系方式将暴露给任务发布者",
                    MessageBox.NotifyType.CommonMessage);
                ContentDialogResult dialogResult = await dialog.ShowAsync();
                if(dialogResult==ContentDialogResult.Primary)
                {
                    this.loading.IsActive = true;
                    inforModel.isAcceptOrder = Constants.OrderStatus.AcceptNotFinish;
                    await InformationHelper.UpdateInfo(inforModel.id, inforModel);
                    this.loading.IsActive = false;
                    await new MessageBox("已接单，请尽快完成任务",MessageBox.NotifyType.CommonMessage).ShowAsync();
                }
            }
        }
    }
}
