﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfFluentControls.ControlPages
{
    /// <summary>
    /// Interaction logic for FramePage.xaml
    /// </summary>
    public partial class FramePage : Page
    {
        public FramePage()
        {
            InitializeComponent();
        }

        private void OpenFrameWindow_Click(object sender, RoutedEventArgs e)
        {
            FrameWindow window = new FrameWindow();
            window.Show();
        }
    }
}
