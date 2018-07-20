﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Selection
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Page
    {
        private DateTime first;
        private DateTime second;

        public MainWindow()
        {
            this.InitializeComponent();
            Window.Current.SizeChanged += App.WindowSizeChanged;

            first = DateTime.Now;
            second = DateTime.Now;

            firstDate.Text = first.ToString("d MMMM yyyy");
            secondDate.Text = second.ToString("d MMMM yyyy");
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void firstDateAdjusterValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            first = DateTime.Now.AddDays(e.NewValue);
            firstDate.Text = first.ToString("d MMMM yyyy");
        }

        private void secondDateAdjusterValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            second = DateTime.Now.AddDays(e.NewValue);
            secondDate.Text = second.ToString("d MMMM yyyy");
        }

        private void compareClick(object sender, RoutedEventArgs e)
        {
            int diff = dateCompare(first, second);
            info.Text = "";
            show("firstDate == secondDate", diff == 0);
            show("firstDate != secondDate", diff != 0);
            show("firstDate <  secondDate", diff < 0);
            show("firstDate <= secondDate", diff <= 0);
            show("firstDate >  secondDate", diff > 0);
            show("firstDate >= secondDate", diff >= 0);
        }

        private void show(string exp, bool result)
        {
            info.Text += exp;
            info.Text += " : " + result.ToString();
            info.Text += "\n";
        }

        private int dateCompare(DateTime leftHandSide, DateTime rightHandSide)
        {
            int result;

            if (leftHandSide.Year < rightHandSide.Year)
            {
                result = -1;
            }
            else if (leftHandSide.Year > rightHandSide.Year)
            {
                result = 1;
            }
            else if (leftHandSide.Month < rightHandSide.Month)
            {
                result = -1;
            }
            else if (leftHandSide.Month > rightHandSide.Month)
            {
                result = 1;
            }
            else if (leftHandSide.Day < rightHandSide.Day)
            {
                result = -1;
            }
            else if (leftHandSide.Day > rightHandSide.Day)
            {
                result = 1;
            }
            else
            {
                result = 0;
            }

            return result;
        }
    }
}
