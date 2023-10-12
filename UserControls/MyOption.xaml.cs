using System.Windows;
using System.Windows.Controls;

namespace MasterChef.UserControls
{
    public partial class MyOption : UserControl
    {
        public MyOption()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); } // Getter for the Text property
            set { SetValue(TextProperty, value); } // Setter for the Text property
        }
        // Defines a DependencyProperty called TextProperty of type string for the MyOption class
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(MyOption));

        public FontAwesome.WPF.FontAwesomeIcon Icon
        {
            get { return (FontAwesome.WPF.FontAwesomeIcon)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        // Defines a DependencyProperty called IconProperty of type FontAwesomeIcon for the MyOption class
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(FontAwesome.WPF.FontAwesomeIcon), typeof(MyOption));
    }
}
