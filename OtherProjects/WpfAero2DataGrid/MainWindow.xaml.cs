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

namespace WpfAero2DataGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<User> users = new List<User>();
            users.Add(new User() { Id = 1, Name = "John Doe", Birthday = new DateTime(1971, 7, 23) });
            users.Add(new User() { Id = 2, Name = "Jane Doe", Birthday = new DateTime(1974, 1, 17) });
            users.Add(new User() { Id = 3, Name = "Sammy Doe", Birthday = new DateTime(1991, 9, 2) });

            dataGrid.ItemsSource = users;
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

    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public DateTime Birthday { get; set; }
    }
}