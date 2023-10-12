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
    /// Interaction logic for MessageWin.xaml
    /// </summary>
    public partial class MessageWin : Window
    {
        public MessageWin()
        {
            InitializeComponent();
        }

        private void OK(object sender, RoutedEventArgs e)
        {
            int ID;
            try
            {
                ID = int.Parse(Message.Text.ToString());
                string sqlCommand = $"delete from Users where User ID= {ID}";
                int n = DAL.ExecuteNonQuery(sqlCommand);
            }
            catch(Exception ex) { }
        }
    }
}
