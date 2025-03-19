using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace FinalProjectWinUi.Pages
{
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
        }

        private void Plans_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PlansPage));
        }

        private void BuyNow_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BuyPage));
        }
    }
}
