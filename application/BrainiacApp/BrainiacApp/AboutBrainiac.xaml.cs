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
    /// AboutBrainiac.xaml etkileşim mantığı
    /// </summary>
    public partial class AboutBrainiac : Page
    {
        public AboutBrainiac()
        {
            InitializeComponent();
            this.FontFamily = new FontFamily("Alata");
        }
    }
}
