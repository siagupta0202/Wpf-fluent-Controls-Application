using System.Configuration;
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
using WpfFluentControls.ControlPages;

namespace WpfFluentControls;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MainFrame.Navigate(new GridSplitterPage()); // Default page
    }

    private void NavigationList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (NavigationList.SelectedItem is ListViewItem selectedItem)
        {
            string pageName = selectedItem.Tag.ToString();
            switch (pageName)
            {
                case "GridSplitter.xaml":
                    MainFrame.Navigate(new GridSplitterPage());
                    break;
                case "GroupBoxPage.xaml":
                    MainFrame.Navigate(new GroupBoxPage());
                    break;
                case "ThumbPage.xaml":
                    MainFrame.Navigate(new ThumbPage());
                    break;
                case "HyperlinkPage.xaml":
                    MainFrame.Navigate(new HyperlinkPage());
                    break;
            }
        }
    }
}