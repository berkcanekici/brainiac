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
    /// Test.xaml etkileşim mantığı
    /// </summary>
    public partial class Test : Page
    {
        private String userName;
        private Test1 test1;
        private Test2 test2;
        private Test3 test3;
        private Test4 test4;
        private Test5 test5;
        private int currentTest = 0;
        private int currentQuestion = 0;
        private int remainingInCurrentTest;

        public Test()
        {
            InitializeComponent();
            this.FontFamily = new FontFamily("Alata");
            test1=new Test1();
            test2=new Test2();  
            test3=new Test3();  
            test4=new Test4();  
            test5=new Test5();
        }

        private void NameTextboxClicked(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= NameTextboxClicked;
        }

        private void EnglishSelected(object sender, RoutedEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
        }

        private void TurkishSelected(object sender, RoutedEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("tr-TR");
        }

        private void OnStart(object sender, RoutedEventArgs e)
        {
            if(NameEnterBox.Text!=String.Empty)
            {
                userName = NameEnterBox.Text;
                FirstPage.Visibility = Visibility.Collapsed;
                LeftBar.Visibility = Visibility.Visible;
                QuestionFrame.Visibility = Visibility.Visible;
                changeTest();
                QuestionFrame.NavigationService.Navigate(test1);
            }
        }

        private void changeTest()
        {
            //TODO
            currentTest++;
            if(currentTest==1)
            {

            }
            else if(currentTest==2)
            {

            }
            else if(currentTest==3)
            {

            }
            else if(currentTest==4)
            {

            }
            else if(currentTest==5)
            {

            }
        }

    }
}
