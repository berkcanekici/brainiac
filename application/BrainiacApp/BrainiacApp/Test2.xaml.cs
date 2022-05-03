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
using System.Threading;
using System.Globalization;

namespace BrainiacApp
{
    /// <summary>
    /// Test2.xaml etkileşim mantığı
    /// </summary>
    public partial class Test2 : Page
    {
        private Test mainTest;
        public Test2(Test main)
        {
            InitializeComponent();
            mainTest = main;
            this.FontFamily = new FontFamily("Alata");
            setLanguage("en-Us");
        }
        public void setLanguage(String lang)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(lang);
            T2Info1.Text = Properties.strings.T2Info1;
            T2Info2.Text = Properties.strings.T2Info2;
            T2Info3.Text = Properties.strings.T2Info3;
            QuestionText.Text = Properties.strings.T2Q;
        }
        private void StartTest2(object sender, RoutedEventArgs e)
        {
            Introduction.Visibility = Visibility.Collapsed;
            QuestionPanel.Visibility = Visibility.Visible;
            mainTest.initiateTest2();
        }
        public void changeToRestTime()
        {
            Rest.Visibility = Visibility.Visible;
            QuestionPanel.Visibility = Visibility.Collapsed;
        }

        public void changeQuestion(int questionNo)
        {
            //TODO
        }
    }
}
