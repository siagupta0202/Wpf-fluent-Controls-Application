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
    /// Interaction logic for ResizeGripPage.xaml
    /// </summary>
    public partial class ResizeGripPage : Page
    {
        public ResizeGripPage()
        {
            InitializeComponent();
        }

        private void OpenResizeGripWindow_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window()
            {
                Width=400,
                Height=300,
                ResizeMode=ResizeMode.CanResizeWithGrip
            };
            window.Show();
        }
    }
}
