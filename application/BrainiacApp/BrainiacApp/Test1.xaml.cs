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
    /// Test1.xaml etkileşim mantığı
    /// </summary>
    public partial class Test1 : Page
    {
        private Test mainTest;
        public Test1(Test main)
        {
            InitializeComponent();
            mainTest = main;
            this.FontFamily = new FontFamily("Alata");
            setLanguage("en-Us");
        }

        public void setLanguage(String lang)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(lang);
            T1Info1.Text = Properties.strings.T1Info1;
            T1Info2.Text = Properties.strings.T1Info2;
            T1Info3.Text = Properties.strings.T1Info3;
            QuestionText.Text = Properties.strings.T1Q1;
        }
        private void StartTest1(object sender, RoutedEventArgs e)
        {
            Introduction.Visibility = Visibility.Collapsed;
            QuestionText.Visibility = Visibility.Visible;
            mainTest.initiateTest1();
        }

        public void changeQuestion(int questionNo)
        {
            if(questionNo==2)
            {
                QuestionText.Text = Properties.strings.T1Q2;
            }
            else if(questionNo==3)
            {
                QuestionText.Text = Properties.strings.T1Q3;
            }
            else if(questionNo==4)
            {
                QuestionText.Text = Properties.strings.T1Q4;
            }
            else if(questionNo==5)
            {
                QuestionText.Text = Properties.strings.T1Q5;
            }
        }
    }
}
