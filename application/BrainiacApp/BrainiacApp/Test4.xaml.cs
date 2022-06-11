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
using System.Windows.Threading;
namespace BrainiacApp {
    /// <summary>
    /// Test4.xaml etkileşim mantığı
    /// </summary>
    public partial class Test4 : Page {
        private Test mainTest;
        public bool[] Results;
        public Test4(Test main) {
            InitializeComponent();
            mainTest = main;
            this.FontFamily = new FontFamily("Alata");
            setLanguage("en-Us");
            Results = new bool[5];
        }

        public void setLanguage(String lang) {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(lang);
            T4Info1.Text = Properties.strings.T4Info1;
            T4Info2.Text = Properties.strings.T4Info2;
            T4Info3.Text = Properties.strings.T4Info3;
            T4Info4.Text = Properties.strings.T4Info4;
            QuestionText.Text = Properties.strings.T4Q1;
        }
        private void StartTest4(object sender, RoutedEventArgs e) {
            Introduction.Visibility = Visibility.Collapsed;
            QuestionText.Visibility = Visibility.Visible;
            InputBox.Visibility = Visibility.Visible;
            mainTest.initiateTest4();
        }

        public void changeQuestion(int questionNo) {

            if (questionNo == 2) {
                Rest.Visibility = Visibility.Collapsed;
                InputBox.Visibility = Visibility.Visible;
                QuestionText.Visibility = Visibility.Visible;
                QuestionText.Text = Properties.strings.T4Q2;
                mainTest.initiateTest4();
            }
            else if (questionNo == 3) {
                Rest.Visibility = Visibility.Collapsed;
                InputBox.Visibility = Visibility.Visible;
                QuestionText.Visibility = Visibility.Visible;
                QuestionText.Text = Properties.strings.T4Q3;

                mainTest.initiateTest4();
            }
            else if (questionNo == 4) {
                Rest.Visibility = Visibility.Collapsed;
                InputBox.Visibility = Visibility.Visible;
                QuestionText.Visibility = Visibility.Visible;
                QuestionText.Text = Properties.strings.T4Q4;
                mainTest.initiateTest4();
            }
            else if (questionNo == 5) {
                Rest.Visibility = Visibility.Collapsed;
                InputBox.Visibility = Visibility.Visible;
                QuestionText.Visibility = Visibility.Visible;
                QuestionText.Text = Properties.strings.T4Q5;
                mainTest.initiateTest4();
            }
        }

        public void changeToRestTime() {
            Rest.Visibility = Visibility.Visible;
            InputBox.Visibility = Visibility.Collapsed;
            QuestionText.Visibility = Visibility.Collapsed;
        }
    }
}
