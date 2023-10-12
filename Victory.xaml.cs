using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MasterChef
{
    /// <summary>
    /// Interaction logic for Victory.xaml
    /// </summary>
    public partial class Victory : Page
    {
        public static bool WonLvl = false;
        public Victory()
        {
            InitializeComponent();
        }

        private void ContinueToMainPage(object sender, RoutedEventArgs e)
        {
            WonLvl = true;
            if (LoginP.isAdmin)
                HomePage.myFrame.NavigationService.Navigate(new AdminP());
            else
            {
                MainPage mainPage = new MainPage();
                HomePage.myFrame.NavigationService.Navigate(mainPage);
            }
        }
    }
}
