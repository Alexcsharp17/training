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

namespace BusCarrier.WPFClient.Views
{
    /// <summary>
    /// Interaction logic for StationsView.xaml
    /// </summary>
    public partial class StationsView : UserControl
    {
        public StationsView()
        {
            InitializeComponent();
            var window = new Window()
            {
                Content = new WebBrowser { Source = new Uri("D:\\test2.html") },
                Width = 700,
                Height = 500
            };
            
            window.Show();
        }
    }
}
