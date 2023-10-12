using MasterChef.UserControls;
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
    /// Interaction logic for AdminP.xaml
    /// </summary>
    public partial class AdminP : Page
    {
        public AdminP()
        {
            InitializeComponent();
            FillTable1();
        }
        public void FillTable1()
        {
            table1.RowGroups.Clear(); //מנקים את כל התוכן הישן
            TableRow currentRow;
            int i = 2; //שורה ראשונה שממנה ממלאים באופן דינמי כי שורה ראשונה שמורה לכותרת הטבלה והשנייה לקטגוריות
            AddHeadLines();
            string connectionString = DAL.ConnectionString;



            OleDbConnection conn = new OleDbConnection(connectionString);
            string sql = "";
            sql = BuildSqlCommand();


            OleDbCommand cmd = new OleDbCommand(sql, conn);
            conn.Open();
            OleDbDataReader reader;
            reader = cmd.ExecuteReader();



            while (reader.Read())
            {
                currentRow = new TableRow();
                table1.RowGroups[0].Rows.Add(currentRow); //כל פעם נוסיף שורה לטבלה

                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(reader["User ID"].ToString()))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(reader["Username"].ToString()))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(reader["Family"].ToString()))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(reader["Gender"].ToString()))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(reader["Date of Birth"].ToString()))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(reader["Email"].ToString()))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(reader["Mobile"].ToString()))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(reader["Membership"].ToString()))));
            }
            reader.Close();
            conn.Close();

        }

        private string BuildSqlCommand()
        {
            string sql = "Select *  from Users";
            return sql;
        }

        private void AddHeadLines()
        {
            table1.RowGroups.Add(new TableRowGroup());
            // Add the first (title) row.
            table1.RowGroups[0].Rows.Add(new TableRow());
            // Alias the current working row for easy reference.
            TableRow currentRow = table1.RowGroups[0].Rows[0];
            // Global formatting for the title row.
            currentRow.Background = Brushes.Silver;
            currentRow.FontSize = 40;
            currentRow.FontWeight = FontWeights.Bold;

            // Add the header row with content,
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Users"))));
            // and set the row to span all NUM_COLUMNS columns.
            currentRow.Cells[0].ColumnSpan = 3;
            table1.RowGroups[0].Rows.Add(new TableRow());
            currentRow = table1.RowGroups[0].Rows[1];

            // Global formatting for the header row.
            currentRow.FontSize = 18;
            currentRow.FontWeight = FontWeights.Bold;


            // Add cells with content to the second row.
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("User's ID"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("First Name"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Last Name"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Gender"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Date of Birth"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Email"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Mobile"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Membership"))));

        }

        private void Remove(object sender, RoutedEventArgs e)
        {
            MessageWin m = new MessageWin();
            m.Show();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            SignUpP mainWindow = new SignUpP();
            HomePage.myFrame.NavigationService.Navigate(mainWindow);
        }

        private void NextLvl(object sender, RoutedEventArgs e)
        {
            HomePage.myFrame.NavigationService.Navigate(new FirstLvl());
        }
    }
}
