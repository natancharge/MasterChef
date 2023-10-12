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
    /// Interaction logic for SignUpP.xaml
    /// </summary>
    public partial class SignUpP : Page
    {
        public static SignUpP win = new SignUpP();
        public SignUpP()
        {
            InitializeComponent();
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            win.Name.Text = Name.Text.ToString();
            win.Family.Text = Family.Text;
            if (Name.Text.ToString() != null)
            {
                Add(Name.Text.ToString(), "Username");
            }
            if (Family.Text.ToString() != null)
                Add(Family.Text.ToString(), "Family");
            if (Date.Text.ToString() != null)
                Add(Date.Text.ToString(), "Date of Birth");
            if (Email.Text.ToString() != null)
                Add(Email.Text.ToString(), "Email");
            if (Mobile.Text.ToString() != null)
                Add(Mobile.Text.ToString(), "Mobile");
            NextBtn.Visibility = Visibility.Visible;
            HomePage.signOut.Visibility = Visibility.Visible;
            HomePage.profile.Visibility = Visibility.Visible;
            HomePage.signIn.Visibility = Visibility.Hidden;
            HomePage.signUp.Visibility = Visibility.Hidden;
        }
        public void Add(string str, string place)
        {
            //הוספת שורה
            string sqlCommand = $"insert into Users ({place}) values ('{str}')";
            int n = DAL.ExecuteNonQuery(sqlCommand);
        }

        private void ContinueToMainPage(object sender, RoutedEventArgs e)
        {
            if (Name.Text.ToString() != null)
            {
                HomePage.myFrame.NavigationService.Navigate(new MainPage());
                HomePage.signOut.Visibility = Visibility.Visible;
                HomePage.profile.Visibility = Visibility.Visible;
                HomePage.signIn.Visibility = Visibility.Hidden;
                HomePage.signUp.Visibility = Visibility.Hidden;
            }

        }

        private void Male(object sender, MouseButtonEventArgs e)
        {
            string sqlCommand = $"insert into Users (Gender) values (0)";
            int n = DAL.ExecuteNonQuery(sqlCommand);
        }

        private void Female(object sender, MouseButtonEventArgs e)
        {
            string sqlCommand = $"insert into Users (Gender) values (1)";
            int n = DAL.ExecuteNonQuery(sqlCommand);
        }

        private void ClearRegistration(object sender, RoutedEventArgs e)
        {
            Name.Clear();
            Family.Clear();
            Date.Clear();
            Mobile.Clear();
            Email.Clear();
        }

        private void Login(object sender, MouseButtonEventArgs e)
        {
            LoginP win = new LoginP();
            HomePage.myFrame.NavigationService.Navigate(win);
        }
    }
}
