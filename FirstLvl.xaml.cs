using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for FirstLvl.xaml
    /// </summary>
    public partial class FirstLvl : Page
    {
        bool flag1 = false, flag2 = false, flag3 = false, flag4 = false, flag5 = false; // checks if the player won
        public Random rnd = new Random();
        public List<Image> imgObj = new List<Image>();
        readonly List<string> ALLIMAGESNAMES = new List<string>()
            { "banana.png", "egg.png", "flour.png", "Strawberry.png", "chocolate-chip.png", "cucamber.png", "honey.png", "milk.png", "potato.png", "rice.png", "sugar.png", "salt.png"};
        public FirstLvl()
        {
            InitializeComponent();
            Build();
        }
        private void Build()
        {
            imgObj.Clear();
            ingredients.Children.Clear();

            List<string> imageNames = new List<string>(ALLIMAGESNAMES);
            int img = 0;
            while (imageNames.Count() > img)
            {
                string imgFullPath = Path() + "//" + imageNames[img];
                var bitmap = new BitmapImage(new Uri(imgFullPath));
                Image image = new Image();
                image.Source = bitmap;

                image.Height = 100;
                image.Tag = img;
                image.MouseDown += Check;

                ingredients.Children.Add(image);
                //imageNames.RemoveAt(img);
                img++;
            }
        }

        public static string Path()
        {
            string s = Environment.CurrentDirectory; // מקבלים כתובת של קובץ הרצה שרץ כרגע
            string[] ss = s.Split('\\');//מפרקים את המחרוזת לחלקים כאשר בין החלקים קו נתוי הפוך ומכניסים את החלקים למערך
            int x = ss.Length - 2;//אנו רוצים למחוק מהמערך את 3 המקומות האחרונים , כי צריכים לעלות 2 תיקיות למעלה
            ss[x] = "images";//אז במקום השלישי מהסוף מכניסים את שם התיקיה עם תמונות
            Array.Resize(ref ss, x + 1);//חותכים את המערך
            string s1 = String.Join("\\", ss); //מחזירים את המערך חזרה למחרוזת עם קו נתוי אחורה בין האיברים במערך
            return s1;
        }
        private void Check(object sender, MouseButtonEventArgs e)
        {
            Image image = (Image)sender;
            if (e.ChangedButton == MouseButton.Left)
            {
                if(image.Tag.Equals(0))
                {
                    MessageBox.Show("Great job!");
                    image.Visibility = Visibility.Collapsed;
                    flag1 = true;
                }
                else if(image.Tag.Equals(1))
                {
                    MessageBox.Show("Well done!");
                    image.Visibility = Visibility.Collapsed;
                    flag2 = true;
                }
                else if (image.Tag.Equals(2))
                {
                    MessageBox.Show("Amazing!");
                    image.Visibility = Visibility.Collapsed;
                    flag3 = true;
                }
                else if (image.Tag.Equals(3))
                {
                    MessageBox.Show("Amazing!");
                    image.Visibility = Visibility.Collapsed;
                    flag4 = true;
                }
                else if (image.Tag.Equals(4))
                {
                    MessageBox.Show("Great job!");
                    image.Visibility = Visibility.Collapsed;
                    flag5 = true;
                }
                else
                {
                    MessageBox.Show("Try again...");
                }
            }
            EndTheLvl(flag5, flag1, flag2, flag4, flag3);
        }
        public void EndTheLvl(bool f1, bool f2, bool f3, bool f4, bool f5)
        {
            if (f1 && f2 && f3 && f4 && f5)
            {
                HomePage.myFrame.NavigationService.Navigate(new Victory());
            }
        }

    }
}
