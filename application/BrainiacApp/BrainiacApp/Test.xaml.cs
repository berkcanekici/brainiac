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


namespace BrainiacApp
{
    /// <summary>
    /// Test.xaml etkileşim mantığı
    /// </summary>
    public partial class Test : Page
    {
        private String userName; //Bu username database'e veri atarken kullanılabilir kime ait göstermek için ama database'e veri atarken id de atamak lazım (uid ile)
        private Test1 test1;
        private Test2 test2;
        private Test3 test3;
        private Test4 test4;
        private Test5 test5;
        private int currentTest = 0;
        private int currentQuestion = 0;
        private int remainingInCurrentTest;
        DispatcherTimer GeriSayim;
        DispatcherTimer restTimer;
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
                timerProgress.Value = 100;

            }
        }

        private void changeTest()
        {
            currentTest++;
            if(currentTest==1)
            {
                currentQuestion = 0;
                remainingInCurrentTest = 5;
                QuestionFrame.NavigationService.Navigate(test1);
                TestName.Text = "Mental Imagery Test";
            }
            else if(currentTest==2)
            {
                currentQuestion = 0;
                remainingInCurrentTest = 3;
                QuestionFrame.NavigationService.Navigate(test2);
                TestName.Text = "Rorschach Test";
            }
            else if(currentTest==3)
            {
                currentQuestion = 0;
                remainingInCurrentTest = 6;
                QuestionFrame.NavigationService.Navigate(test3);
                TestName.Text = "Dual N-Back Test";
            }
            else if(currentTest==4)
            {
                currentQuestion = 0;
                remainingInCurrentTest = 5;
                QuestionFrame.NavigationService.Navigate(test4);
                TestName.Text = "Verb Generation Test";
            }
            else if(currentTest==5)
            {
                currentQuestion = 0;
                remainingInCurrentTest = 1;
                QuestionFrame.NavigationService.Navigate(test5);
                TestName.Text = "Go-No/Go Test";
            }
        }
        private int increment = 0;
        private int increment1 = 0;
        private void dtTicker(object sender, EventArgs e)
        {
            increment++;
            timerTextBlock.Text = increment.ToString();
            timerProgress.Value = increment;
            if (currentQuestion == 1)
            {
                timerProgress.Maximum = 12;
                if (increment == 12)
                {
                    GeriSayim.Stop();

                    restQuestion();

                }
            }
            if (currentQuestion == 2)
            {
                timerProgress.Maximum = 12;
                if (increment == 12)
                {
                    GeriSayim.Stop();
                    restQuestion();

                }
            }
            if (currentQuestion == 3)
            {
                timerProgress.Maximum = 15;
                if (increment == 15)
                {
                    GeriSayim.Stop();
                    restQuestion();
                }
            }
            if (currentQuestion == 4)
            {
                timerProgress.Maximum = 20;
                if (increment == 20)
                {
                    GeriSayim.Stop();
                    restQuestion();
                }
            }
            if (currentQuestion == 5)
            {
                timerProgress.Maximum = 26;
                if (increment == 26)
                {
                    GeriSayim.Stop();
                    changeTest();
                }
            }
        }
        private void endTest()
        {
          
            //TODO
            //Verilerin incelenip yüzdelerin ayarlanıp Result sayfasına geçiş burda olacak
        }
        private void restTicker(object sender, EventArgs e)
        {
           
            increment1++;
            timerTextBlock.Text = increment1.ToString();
            test1.changeToRestTime();
            timerProgress.Value = increment1;
            timerProgress.Minimum =0;
            timerProgress.Maximum = 5;
            if (increment1==5)
            {
                restTimer.Stop();
                increment1 = 0;
                
                test1.changeQuestion(currentQuestion + 1);
            }
        }
        private void restQuestion()
        {
            increment1= 0;
            restTimer = new DispatcherTimer();
            restTimer.Interval = TimeSpan.FromSeconds(1);
            restTimer.Tick += restTicker;
            restTimer.Start();
        }
        public void initiateTest1()
        {
            currentQuestion++;
            remainingInCurrentTest--;
            questionNo.Text = currentQuestion.ToString();
            remaining.Text = remainingInCurrentTest.ToString();
            
            increment = 0;
            
            //TODO
            //Test 1 sürelerinin ve süreye göre geçişlerin ayarlanması burda olacak.
            //Sorular değiştikçe currentQuestion, remainingInCurrentTest değişmeli
            //Soruların görünümünü değiştirmek için Test1'e örnek bir changeQuestion methodu yazdım.
            //Ayrıca questionlar arası rest timelar olacak. 1'den 2'ye, 2'den 3'e geçerken vb. Bunun için changeToRestTime diye bir method var 
            //Bu method sadece Rest Time yazısını çıkartıyor sürelerin ayarlamaları yine burdan yapılacak.
            timerProgress.Value = 0;
            timerProgress.Minimum = 0;
            timerProgress.Maximum = 12;
            GeriSayim = new DispatcherTimer();
            GeriSayim.Interval = TimeSpan.FromSeconds(1);
            GeriSayim.Tick += dtTicker;
            GeriSayim.Start();
            
            if (remainingInCurrentTest == 0)
            {
                

            }

                
            
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
