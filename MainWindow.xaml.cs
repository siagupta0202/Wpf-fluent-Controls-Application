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
using System.Xml.Linq;
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
            string pageName = selectedItem.Tag.ToString() ?? "";
            NavigateToPage(pageName);
        }
    }

    private void NavigateToPage(string pageName)
    {
        switch (pageName)
        {
            case "GridSplitterPage.xaml":
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
            case "ResizeGripPage.xaml":
                MainFrame.Navigate(new ResizeGripPage());
                break;
            case "FramePage.xaml":
                MainFrame.Navigate(new FramePage());
                break;
        }
    }

    private void ThemeChanger_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if(sender is ComboBox cb)
        {
            ComboBoxItem? cbi = cb.SelectedItem as ComboBoxItem;
            string theme = cbi?.Tag.ToString() ?? "";
            switch (theme)
            {
                case "Light":
                    Application.Current.ThemeMode = ThemeMode.Light;
                    ReloadControlStyleDictionaries("Light");
                    break;
                case "Dark":
                    Application.Current.ThemeMode = ThemeMode.Dark;
                    ReloadControlStyleDictionaries("Dark");
                    break;
                case "HighContrast":
                    ReloadControlStyleDictionaries("HighContrast");
                    break;
            }
        }
    }

    private void ReloadControlStyleDictionaries(string colorName)
    {
        ResourceDictionary applicationResources = Application.Current.Resources;
        List<ResourceDictionary> addDictionaries = new();
        List<int> removeIndexes = new();

        for(int i=0;i<applicationResources.MergedDictionaries.Count;i++)
        {
            ResourceDictionary dictionary = applicationResources.MergedDictionaries[i];

            string sourceUri = dictionary.Source.ToString();
            
            if (sourceUri.Contains("ResourceDictionaries"))
            {
                ResourceDictionary newDictionary = new ResourceDictionary()
                {
                    Source = new Uri(sourceUri, UriKind.RelativeOrAbsolute)
                };
                
                ResourceDictionary? colorDictionary = GetColorDictionary(newDictionary, colorName);
                
                if(colorDictionary != null)
                {
                    newDictionary.MergedDictionaries.Clear();
                    newDictionary.MergedDictionaries.Add(colorDictionary);
                    removeIndexes.Add(i);
                    addDictionaries.Add(newDictionary);
                }
            }
        }

        removeIndexes.Reverse();

        foreach(int index in removeIndexes)
        {
            applicationResources.MergedDictionaries.RemoveAt(index);
        }

        foreach(ResourceDictionary rd in addDictionaries)
        {
            applicationResources.MergedDictionaries.Add(rd);
        }
    }

    private ResourceDictionary? GetColorDictionary(ResourceDictionary dictionary, string colorName)
    {
        int index = 0;
        foreach (ResourceDictionary rd in dictionary.MergedDictionaries)
        {
            if (rd is ColorDictionary cd)
            {
                if (cd.Name == colorName)
                    break;
            }
            index++;
        }

        if (index == dictionary.MergedDictionaries.Count)
            return null;

        return dictionary.MergedDictionaries[index];
    }

    private void RearrangeColorDictionaries(string name)
    {
        if (name != "Light" && name != "Dark" && name != "HighContrast")
            throw new ArgumentException($"name should be Light, Dark or HighContrast. The name provided is {name}");

        foreach(ResourceDictionary dictionary in Application.Current.Resources.MergedDictionaries)
        {
            string sourceUri = dictionary.Source.ToString();
            if(sourceUri.Contains("ResourceDictionaries"))
            {
                int index = 0;
                foreach(ResourceDictionary rd in dictionary.MergedDictionaries)
                {
                    if(rd is ColorDictionary cd)
                    {
                        if (cd.Name == name)
                            break;
                    }
                    index++;
                }

                if (index == dictionary.MergedDictionaries.Count)
                    continue;

                dictionary.MergedDictionaries.Add(dictionary.MergedDictionaries[index]);
                dictionary.MergedDictionaries.RemoveAt(index);
            }
        }

        ListViewItem? selectedItem = NavigationList.SelectedItem as ListViewItem;
        NavigateToPage(selectedItem?.Tag.ToString() ?? "");
    }
}