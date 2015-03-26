﻿using System;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace App_SimpleTimer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int minute = 0;
        int second = 0;
        int rest = 0;
        int minute1, minute2, second1, second2;
        int rest1, rest2, rest3;
        bool flag = false; //default: not running 

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }
        //start
        private void bksclick(object sender, RoutedEventArgs e)
        {
            flag = true; //start running
            ChangeTime();
        }

        //stop
        private void btzclick(object sender, RoutedEventArgs e)
        {
            flag = false;//not running
            ShowTime();
        }

        //back to zero
        private void bqlclick(object sender, RoutedEventArgs e)
        {
            flag = false;
            minute = 0;
            second = 0;
            rest = 0;
            TimeSplit();
            textblock1.Text = "00:00";
            textblock2.Text = ".000";
        }

        //change time
        private void ChangeTime()
        {
            while(flag)
            {
                //sleep Task.Delay(1);
                TimeSplit();
                ShowTime();
            }

        }

        private void TimeSplit()
        {
            minute1 = minute / 10;
            minute2 = minute % 10;
            second1 = second / 10;
            second2 = second % 10;
            rest1 = rest / 100;
            rest2 = (rest - rest1 * 100) / 10;
            rest3 = (rest - rest1 * 100 - rest2 * 10);
        }

        private void ShowTime()
        {
            textblock1.Text = minute1 + minute2 + ":" + second1 + second2;
            textblock2.Text = "." + rest1 + rest2 + rest3;
        }
    
    }
}
