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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            if (Victory.WonLvl)
            {
                AddFirstRecepie();
            }
        }
        private void AddFirstRecepie()
        {
            TitleR.Text = "Waffels";
            contentR.Text = "- 1 Banana\n- 2 Eggs\n- 140g Flour\n- Strawberries\n- Chochlate Chips";
        }
        private void NextLvl(object sender, RoutedEventArgs e)
        {
            HomePage.myFrame.NavigationService.Navigate(new FirstLvl());
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            SignUpP mainWindow = new SignUpP();
            HomePage.myFrame.NavigationService.Navigate(mainWindow);
        }
    }
}
