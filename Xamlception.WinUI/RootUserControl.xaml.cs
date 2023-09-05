using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ApplicationSettings;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Xamlception.WinUI
{
    public sealed partial class RootUserControl : UserControl
    {
        public RootUserControl()
        {
            this.InitializeComponent();

            navigationView.SelectedItem = navigationView.MenuItems[0];
            NavigationView_Navigate(typeof(SamplePage), new EntranceNavigationTransitionInfo());
        }

        private void navigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.InvokedItemContainer != null)
            {
                Type navPageType = Type.GetType(args.InvokedItemContainer.Tag.ToString());
                NavigationView_Navigate(navPageType, args.RecommendedNavigationTransitionInfo);
            }
        }

        private void NavigationView_Navigate(Type navPageType, NavigationTransitionInfo transitionInfo)
        {            
            Type preNavPageType = rootFrame.CurrentSourcePageType;
            
            if (navPageType is not null && !Type.Equals(preNavPageType, navPageType))
            {
                rootFrame.Navigate(navPageType, null, transitionInfo);
            }
        }
    }
}
