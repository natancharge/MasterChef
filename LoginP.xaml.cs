using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
    /// Interaction logic for LoginP.xaml
    /// </summary>
    public partial class LoginP : Page
    {
        public static bool isAdmin = false;
        public LoginP()
        {
            InitializeComponent();
        }
        private void Login(object sender, RoutedEventArgs e)
        {
            string username = Name.Text.ToString();

            string password = Family.Text.ToString();

            if (username == "Netanel" && password == "Chertkov")
            {
                isAdmin = true;
                AdminP sign = new AdminP();
                HomePage.myFrame.NavigationService.Navigate(sign);
                HomePage.signOut.Visibility = Visibility.Visible;
                HomePage.profile.Visibility = Visibility.Visible;
                HomePage.signIn.Visibility = Visibility.Hidden;
                HomePage.signUp.Visibility = Visibility.Hidden;
            }

            string connectionString = DAL.ConnectionString;



            OleDbConnection conn = new OleDbConnection(connectionString);

            string sql = "Select * from Users where [Username]='" + username + "' and [Family]='" + password + "'";

            OleDbCommand cmd = new OleDbCommand(sql, conn);

            conn.Open();

            OleDbDataReader reader;

            reader = cmd.ExecuteReader();



            if (reader.Read())
            {

                //אז קיים
                MessageBox.Show("Welcome Back " + username + "!");
                NextBtn.Visibility = Visibility.Visible;
                HomePage.signOut.Visibility = Visibility.Visible;
                HomePage.profile.Visibility = Visibility.Visible;
                HomePage.signIn.Visibility = Visibility.Hidden;
                HomePage.signUp.Visibility = Visibility.Hidden;
            }

            else
            {

                //אז לא קיים
                MessageBox.Show("Sorry, couldn't found you. Please try again");
            }
        }

        private void ClearRegistration(object sender, RoutedEventArgs e)
        {
            SignUpP sign = new SignUpP();
            HomePage.myFrame.NavigationService.Navigate(sign);
        }

        private void ContinueToMainPage(object sender, RoutedEventArgs e)
        {
            MainPage sign = new MainPage();
            HomePage.myFrame.NavigationService.Navigate(sign);
            HomePage.signOut.Visibility = Visibility.Visible;
            HomePage.profile.Visibility = Visibility.Visible;
            HomePage.signIn.Visibility = Visibility.Hidden;
            HomePage.signUp.Visibility = Visibility.Hidden;
        }
    }
}
