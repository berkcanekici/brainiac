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
            test1=new Test1(this);
            test2=new Test2(this);  
            test3=new Test3(this);  
            test4=new Test4(this);  
            test5=new Test5(this);
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
            if(test1!=null)
                test1.setLanguage("en-US");
            if(test2!=null)
                test2.setLanguage("en-US");
            if(test3!=null)
                test3.setLanguage("en-US");
            if(test4!=null)
                test4.setLanguage("en-US");
            if(test5!=null)
                test5.setLanguage("en-US");
        }

        private void TurkishSelected(object sender, RoutedEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("tr-TR");
            test1.setLanguage("tr-TR");
            test2.setLanguage("tr-TR");
            test3.setLanguage("tr-TR");
            test4.setLanguage("tr-TR");
            test5.setLanguage("tr-TR");
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
                currentQuestion = 0;
                remainingInCurrentTest = 5;
            }
            else if(currentTest==2)
            {
                currentQuestion = 0;
                remainingInCurrentTest = 3;
            }
            else if(currentTest==3)
            {
                currentQuestion = 0;
                remainingInCurrentTest = 6;
            }
            else if(currentTest==4)
            {
                currentQuestion = 0;
                remainingInCurrentTest = 5;
            }
            else if(currentTest==5)
            {
                currentQuestion = 0;
                remainingInCurrentTest = 1;
            }
        }

        private void endTest()
        {
            //TODO
            //Verilerin incelenip yüzdelerin ayarlanıp Result sayfasına geçiş burda olacak
        }

        public void initiateTest1()
        {
            //TODO
            //Test 1 sürelerinin ve süreye göre geçişlerin ayarlanması burda olacak.
            //Sorular değiştikçe currentQuestion, remainingInCurrentTest değişmeli

            if (remainingInCurrentTest == -1)
                changeTest();
        }

        public void initiateTest2()
        {
            //TODO
            //Test 2 sürelerinin ve süreye göre geçişlerin ayarlanması burda olacak.
            //Sorular değiştikçe currentQuestion, remainingInCurrentTest değişmeli

            if (remainingInCurrentTest == -1)
                changeTest();
        }

        public void initiateTest3()
        {
            //TODO
            //Test 3 sürelerinin ve süreye göre geçişlerin ayarlanması burda olacak.
            //Sorular değiştikçe currentQuestion, remainingInCurrentTest değişmeli

            if (remainingInCurrentTest == -1)
                changeTest();
        }
        public void initiateTest4()
        {
            //TODO
            //Test 4 sürelerinin ve süreye göre geçişlerin ayarlanması burda olacak.
            //Sorular değiştikçe currentQuestion, remainingInCurrentTest değişmeli

            if (remainingInCurrentTest == -1)
                changeTest();
        }
        public void initiateTest5()
        {
            //TODO
            //Test 5 sürelerinin ve süreye göre geçişlerin ayarlanması burda olacak.
            //Sorular değiştikçe currentQuestion, remainingInCurrentTest değişmeli

            if (remainingInCurrentTest == -1)
                endTest();
        }

    }
}
