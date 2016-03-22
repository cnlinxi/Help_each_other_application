using rongYunSample.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace rongYunSample.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class UserAccount : Page
    {
        public UserAccount()
        {
            this.InitializeComponent();
        }

        private void btnNavToLogin_Click(object sender, RoutedEventArgs e)
        {
            if (this.rootPivot.SelectedIndex > 0)
                this.rootPivot.SelectedIndex = 0;
        }

        private async void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if(txtAccount_reg.Text.Length<=0||txtEmail_reg.Text.Length<=0||
                txtPhone_reg.Text.Length<=0||txtPhone_reg.Text.Length<=0)
            {
                await new MessageBox("缺少必填字段", MessageBox.NotifyType.CommonMessage).ShowAsync();
                return;
            }
            UserAccountHelper.RegisterStatus status = await UserAccountHelper.Register(txtAccount_reg.Text, txtEmail_reg.Text, 
                txtPhone_reg.Text, txtPassword_reg.Password);
            if (status == UserAccountHelper.RegisterStatus.Success)
            {
                await new MessageBox("注册成功！", MessageBox.NotifyType.CommonMessage).ShowAsync();
            }
            else if (status == UserAccountHelper.RegisterStatus.ConflictUserName)
            {
                await new MessageBox("已存在的用户名，更换用户名重试！", MessageBox.NotifyType.CommonMessage).ShowAsync();
            }
            else if (status == UserAccountHelper.RegisterStatus.Failed)
            {
                await new MessageBox("注册失败！", MessageBox.NotifyType.CommonMessage).ShowAsync();
            }
        }

        private void btnNavToRegister_Click(object sender, RoutedEventArgs e)
        {
            if (this.rootPivot.SelectedIndex > -1)
                this.rootPivot.SelectedIndex = 1;
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtAccount.Text.Length <= 0 || txtPassword.Password.Length <= 0)
                return;
            bool isLoginSuccess = UserAccountHelper.Login(txtAccount.Text, txtPassword.Password).Result;
            if (isLoginSuccess)
            {
                await new MessageBox("登录成功！", MessageBox.NotifyType.CommonMessage).ShowAsync();
            }
            else
            {
                await new MessageBox("登录失败！", MessageBox.NotifyType.CommonMessage).ShowAsync();
            }
        }
    }
}
