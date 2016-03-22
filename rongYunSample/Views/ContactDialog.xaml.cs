﻿using rongYunSample.Helpers;
using rongYunSample.Models;
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

// “内容对话框”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上进行了说明

namespace rongYunSample.Views
{
    public sealed partial class ContactDialog : ContentDialog
    {
        ContactModel contactModel;
        public ContactDialog(ContactModel model)
        {
            this.InitializeComponent();

            this.contactModel = model;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
        private async void btnContactByEmail_Click(object sender, RoutedEventArgs e)
        {
            if (contactModel == null)
                return;
            if(contactModel.fromEmailAddress!=string.Empty&&
                contactModel.fromUserName!=string.Empty&&
                contactModel.toUserName!=string.Empty&&
                contactModel.toEmailAddress!=string.Empty)
            {
                await ContactHelper.ComposeEmail(contactModel.toEmailAddress, 
                    contactModel.fromUserName,contactModel.fromEmailAddress, contactModel.taskTitle);
            }
        }

        private void btnContactByPhone_Click(object sender, RoutedEventArgs e)
        {
            if (contactModel == null)
                return;
            if (contactModel.toPhoneNumber != string.Empty &&
                contactModel.toUserName != string.Empty)
            {
                ContactHelper.PhoneCall(contactModel.toPhoneNumber, contactModel.toUserName);
            }
        }

        private async void btnContactBySms_Click(object sender, RoutedEventArgs e)
        {
            if (contactModel == null)
                return;
            if (contactModel.fromPhoneNumber != string.Empty &&
                contactModel.toPhoneNumber != string.Empty &&
                contactModel.toUserName!=string.Empty&&
                contactModel.taskTitle != string.Empty)
            {
                await ContactHelper.ComposeSms(contactModel.toPhoneNumber,
                    contactModel.fromUserName, contactModel.fromPhoneNumber, contactModel.taskTitle);
            }
        }

        private void btnContactByRongYun_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
