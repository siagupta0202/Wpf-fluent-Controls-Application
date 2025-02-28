using System;
using System.Collections.Generic;
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

namespace WpfFluentControls.ControlPages
{
    /// <summary>
    /// Interaction logic for DatePickerPage.xaml
    /// </summary>
    public partial class DatePickerPage : Page
    {
        public DatePickerPage()
        {
            InitializeComponent();
        }

        private void OpenDatePickerWindow_Click(object sender, RoutedEventArgs e)
        {
            var window = new DatePickerCurrentWindow();
            window.Show();
        }
    }
}
