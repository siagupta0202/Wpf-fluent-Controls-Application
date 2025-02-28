using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAero2DatePicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Aero2_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.ThemeMode = ThemeMode.None;
            this.FontSize = 12;
        }

        private void Light_Click(object sender, RoutedEventArgs e)
        {
            this.FontSize = 14;
            Application.Current.ThemeMode = ThemeMode.Light;
        }

        private void Dark_Click(object sender, RoutedEventArgs e)
        {
            this.FontSize = 14;
            Application.Current.ThemeMode = ThemeMode.Dark;
        }
    }
}