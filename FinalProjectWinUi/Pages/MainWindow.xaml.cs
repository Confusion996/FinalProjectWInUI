using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Windowing;
using System;
using FinalProjectWinUi.Pages;
using Microsoft.UI;

namespace FinalProjectWinUi
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.MaximizeWindow();
            nvSample.IsBackButtonVisible = NavigationViewBackButtonVisible.Collapsed;
            nvSample.SelectionChanged += NavView_SelectionChanged;
            contentFrame.Navigate(typeof(HomePage));
        }

        private void MaximizeWindow()
        {
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            var windowId = Win32Interop.GetWindowIdFromWindow(hwnd);
            var appWindow = AppWindow.GetFromWindowId(windowId);
            if (appWindow.Presenter is OverlappedPresenter presenter)
            {
                presenter.Maximize();
            }
        }


        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItem is NavigationViewItem selectedItem)
            {
                string selectedTag = selectedItem.Tag?.ToString() ?? string.Empty;

                Type pageType = selectedTag switch
                {
                    "HomePage" => typeof(HomePage),
                    "PlansPage" => typeof(PlansPage),
                    "BuyPage" => typeof(BuyPage),
                    _ => null
                };

                if (pageType != null)
                {
                    contentFrame.Navigate(pageType);
                }
            }
        }

    }
}

