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
using System.Windows.Shapes;

namespace MasterChef
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        public static Frame myFrame; // frame
        public MainPage p = new MainPage(); // profile
        public AdminP admin = new AdminP(); // admin profile
        public static MenuItem signOut = new MenuItem(); // menu item: sign out
        public static MenuItem profile = new MenuItem(); // menu item: user's profile
        public static MenuItem signIn = new MenuItem(); // menu item: sign in
        public static MenuItem signUp = new MenuItem(); // menu item: sign up
        public HomePage()
        {
            InitializeComponent();
            myFrame = frame;
            signOut = so;
            profile = pro;
            signIn = si;
            signUp = su;
            frame.Navigate(new SignUpP());
        }

        private void Profile(object sender, RoutedEventArgs e)
        {
            if (LoginP.isAdmin)
                frame.Navigate(admin);
            else frame.Navigate(p); 
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            SignUpP mainWindow = new SignUpP();
            frame.Navigate(mainWindow);
        }

        private void MinimizeWin(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }

        private void CloseSWin(object sender, MouseButtonEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void LogIN(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new LoginP());
        }
    }
}
