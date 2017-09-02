﻿using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Spectro.Services;
using Spectro.ViewModels;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Spectro.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NavigationRoot : Page
    {
        public NavigationRootViewModel Vm => (NavigationRootViewModel)DataContext;

        public NavigationRoot()
        {
            this.InitializeComponent();
            ServiceLocator.Current.GetInstance<NavigationServiceEx>().Frame = appNavFrame;
        }

        private void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //TODO: replace with viewmodellocator

            appNavFrame.Navigate(typeof(NewsFeedList));
        }

        public void NavigateToFeedsTapped(object sender, RoutedEventArgs args)
        {
            Vm.NavigateCommand.Execute("");
        }

        public void NavigateToProfileTapped(object sender, RoutedEventArgs args)
        {
            Vm.NavigateCommand.Execute("");
        }

        public void ItemInvoked(object sender, NavigationViewItemInvokedEventArgs args)
        {
            //Expeectiving navigationex

            //TODO: localize this
            //TODO: switch statement
            if (args.InvokedItem.ToString() == "Profile")
            {
                ServiceLocator.Current.GetInstance<NavigationServiceEx>().Navigate(typeof(ProfileViewModel).FullName);
            } else
            {
                ServiceLocator.Current.GetInstance<NavigationServiceEx>().Navigate(typeof(NewsFeedListViewModel).FullName);
            }

            if (args.IsSettingsInvoked)
            {
                ServiceLocator.Current.GetInstance<NavigationServiceEx>().Navigate(typeof(SettingsViewModel).FullName);
            }
        }

    }
}
