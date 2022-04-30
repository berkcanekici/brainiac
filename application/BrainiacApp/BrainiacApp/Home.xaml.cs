using System;
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

namespace BrainiacApp
{
    /// <summary>
    /// Home.xaml etkileşim mantığı
    /// </summary>

    public partial class Home : Page
    {
        private MainWindow mainWind;
        public Home(MainWindow wind)
        {
            mainWind = wind;
            InitializeComponent();
            this.FontFamily = new FontFamily("Alata");
        }

        private void GoToTest(object sender, RoutedEventArgs e)
        {
            mainWind.CheckTest();
        }

        private void GoToInfo(object sender, RoutedEventArgs e)
        {
            mainWind.CheckInfo();
        }
    }
}
