using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading;
using System.Globalization;
using System.Windows.Threading;
using System.IO.Ports;
using System.IO;
using System.Collections;
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
        public SerialPort port;
        private String Test2Q1, Test2Q2, Test2Q3;
        private String Test4Q1, Test4Q2, Test4Q3, Test4Q4, Test4Q5;
        private int currentTest =0 ;
        private int currentQuestion = 0;
        private int remainingInCurrentTest;
        DispatcherTimer GeriSayim;
        DispatcherTimer restTimer;
        DispatcherTimer readTimer;
        public FileStream fs ;
        StreamWriter sw;
        ArrayList testValues = new ArrayList();
        public Test()
        {
            InitializeComponent();
            this.FontFamily = new FontFamily("Alata");
            test1=new Test1(this);
            test2=new Test2(this);  
            test3=new Test3(this);  
            test4=new Test4(this);  
            test5=new Test5(this);
            port = new SerialPort();

            port.BaudRate = 9600;
            port.PortName = "COM5";
            port.Open();
            port.Write("Hi, I am trying to talk to you.");

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
                currentQuestion = 0;
                remainingInCurrentTest = 5;
                fs = new FileStream(userName, FileMode.OpenOrCreate, FileAccess.Write);
                sw = new StreamWriter(fs);
                changeTest();
                increment = 0;
                increment1 = 0;
                increment2 = 0.0;
                questionNo.Text = currentQuestion.ToString();
                remaining.Text = "5";
                timerTextBlock.Text = "0";
                timerProgress.Minimum = 0;
                timerProgress.Maximum = 12;
                timerProgress.Value = 100;

            }
        }

        private void changeTest()
        {
            timerProgress.Value = 100;
            currentTest++;
            if(currentTest==1)
            {
               
                currentQuestion = 0;
                remainingInCurrentTest = 5;
                QuestionFrame.NavigationService.Navigate(test1);
                TestName.Text = "Mental Imagery Test";
                testNo.Text = "1";
               

            }
            else if(currentTest==2)
            {
                currentQuestion = 0;
                remainingInCurrentTest = 3;
                QuestionFrame.NavigationService.Navigate(test2);
                TestName.Text = "Rorschach Test";
                testNo.Text = "2";
            }
            else if(currentTest==3)
            {
                currentQuestion = 0;
                remainingInCurrentTest = 6;
                QuestionFrame.NavigationService.Navigate(test3);
                TestName.Text = "Dual N-Back Test";
                testNo.Text = "3";
            }
            else if(currentTest==4)
            {
                currentQuestion = 0;
                remainingInCurrentTest = 5;
                QuestionFrame.NavigationService.Navigate(test4);
                TestName.Text = "Verb Generation Test";
                testNo.Text = "4";
            }
            else if(currentTest==5)
            {
                currentQuestion = 0;
                remainingInCurrentTest = 13;
                QuestionFrame.NavigationService.Navigate(test5);
                TestName.Text = "Go-No/Go Test";
                testNo.Text = "5";
            }
        }
        private double increment = 0;
        private int increment1 = 0;
        private double increment2 = 0.0;
        
        private void readval()
        {
            increment2 = 0;
            readTimer = new DispatcherTimer();
            readTimer.Interval = TimeSpan.FromSeconds(0);
            readTimer.Tick += readTicker;
            readTimer.Start();

        }
        private void dtTicker(object sender, EventArgs e) {


            readval();
            increment += 1;
            timerTextBlock.Text = increment.ToString();
            timerProgress.Value = increment;
            if (currentTest == 1) {
                if (currentQuestion == 1) {
                    timerProgress.Maximum = 12;
                    if (increment == 12) {
                        GeriSayim.Stop();
                        
                        restQuestion();
                    }
                   


                }
                else if (currentQuestion == 2) {
                    timerProgress.Maximum = 12;
                    if (increment == 12) {
                        GeriSayim.Stop();
                       
                        restQuestion();

                    }
                    
                }
                else if (currentQuestion == 3) {
                    timerProgress.Maximum = 15;
                    if (increment == 15) {
                        GeriSayim.Stop();
                        
                        restQuestion();
                    }
                   
                }
                else if (currentQuestion == 4) {
                    timerProgress.Maximum = 20;
                    if (increment == 20) {
                        GeriSayim.Stop();
                        
                        restQuestion();
                    }
                    
                }
                else if (currentQuestion == 5) {
                    timerProgress.Maximum = 26;
                    if (increment == 26) {
                        GeriSayim.Stop();
                        
                        changeTest();
                    }
                    
                }
            }
            else if (currentTest == 2) {
                if (currentQuestion == 1) {
                    timerProgress.Maximum = 20;
                    if (increment == 20) {
                        GeriSayim.Stop();
                        readTimer.Stop();
                        restQuestion();

                    }
                    
                }
                else if (currentQuestion == 2) {
                    timerProgress.Maximum = 20;
                    if (increment == 20) {
                        GeriSayim.Stop();
                        readTimer.Stop();
                        restQuestion();

                    }
                   
                }
                else if (currentQuestion == 3) {
                    timerProgress.Maximum = 20;
                    if (increment == 20) {
                        GeriSayim.Stop();
                        
                        changeTest();
                    }
                    
                }
            }
            else if (currentTest == 3) {
                if (currentQuestion == 1) {
                    timerProgress.Maximum = 10;
                    if(increment == 3) {
                        test3.changePart();
                    }
                    else if(increment == 6) {
                        test3.changePart();
                        test3.ButtonPanel.Visibility = Visibility.Visible;
                    }
                    if (increment == 10) {
                        GeriSayim.Stop();
                        test3.ButtonPanel.Visibility = Visibility.Collapsed;
                        test3.changeQuestion(currentQuestion + 1);
                    }
                }
                else if (currentQuestion == 2) {
                    timerProgress.Maximum = 10;
                    if (increment == 3) {
                        test3.changePart();
                    }
                    else if (increment == 6) {
                        test3.changePart();
                        test3.ButtonPanel.Visibility = Visibility.Visible;
                    }
                    if (increment == 10) {
                        GeriSayim.Stop();
                        test3.ButtonPanel.Visibility = Visibility.Collapsed;
                        test3.changeQuestion(currentQuestion + 1);
                    }
                }
                else if (currentQuestion == 3) {
                    timerProgress.Maximum = 10;
                    if (increment == 3) {
                        test3.changePart();
                    }
                    else if (increment == 6) {
                        test3.changePart();
                        test3.ButtonPanel.Visibility = Visibility.Visible;
                    }
                    if (increment == 10) {
                        GeriSayim.Stop();
                        test3.ButtonPanel.Visibility = Visibility.Collapsed;
                        test3.changeQuestion(currentQuestion + 1);
                    }
                }
                else if (currentQuestion == 4) {
                    timerProgress.Maximum = 10;
                    if (increment == 3) {
                        test3.changePart();
                    }
                    else if (increment == 6) {
                        test3.changePart();
                        test3.ButtonPanel.Visibility = Visibility.Visible;
                    }
                    if (increment == 10) {
                        GeriSayim.Stop();
                        test3.ButtonPanel.Visibility = Visibility.Collapsed;
                        test3.changeQuestion(currentQuestion + 1);
                    }
                }
                else if (currentQuestion == 5) {
                    timerProgress.Maximum = 10;
                    if (increment == 3) {
                        test3.changePart();
                    }
                    else if (increment == 6) {
                        test3.changePart();
                        test3.ButtonPanel.Visibility = Visibility.Visible;
                    }
                    if (increment == 10) {
                        GeriSayim.Stop();
                        test3.ButtonPanel.Visibility = Visibility.Collapsed;
                        test3.changeQuestion(currentQuestion + 1);
                    }
                }
                else if (currentQuestion == 6) {
                    timerProgress.Maximum = 10;
                    if (increment == 3) {
                        test3.changePart();
                    }
                    else if (increment == 6) {
                        test3.changePart();
                        test3.ButtonPanel.Visibility = Visibility.Visible;
                    }
                    if (increment == 10) {
                        GeriSayim.Stop();
                        test3.ButtonPanel.Visibility = Visibility.Collapsed;
                        changeTest();
                    }
                }
            }
            else if (currentTest == 4) {
                if (currentQuestion == 1) {
                    timerProgress.Maximum = 15;
                    if (increment == 15) {
                        Test4Q1 = test4.InputBox.Text;
                        test4.InputBox.Text = "";
                        GeriSayim.Stop();

                        restQuestion();

                    }
                }
                else if (currentQuestion == 2) {
                    timerProgress.Maximum = 15;
                    if (increment == 15) {
                        Test4Q2 = test4.InputBox.Text;
                        test4.InputBox.Text = "";
                        GeriSayim.Stop();
                        restQuestion();

                    }
                }
                else if (currentQuestion == 3) {
                    timerProgress.Maximum = 15;
                    if (increment == 15) {
                        Test4Q3 = test4.InputBox.Text;
                        test4.InputBox.Text = "";

                        GeriSayim.Stop();
                        restQuestion();
                    }
                }
                else if (currentQuestion == 4) {
                    timerProgress.Maximum = 15;
                    if (increment == 15) {
                        Test4Q4 = test4.InputBox.Text;
                        test4.InputBox.Text = "";
                        GeriSayim.Stop();
                        restQuestion();
                    }
                }
                else if (currentQuestion == 5) {
                    timerProgress.Maximum = 15;
                    if (increment == 15) {
                        Test4Q5 = test4.InputBox.Text;
                        test4.InputBox.Text = "";
                        GeriSayim.Stop();
                        changeTest();
                        increment=0;
                    }
                }
            }
            else if (currentTest == 5) {
                if (currentQuestion == 1) {
                    timerProgress.Maximum = 40;
                    if (increment == 3) {
                        GeriSayim.Stop();
                        test5.changeQuestion(currentQuestion + 1);

                    }
                }
                else if (currentQuestion == 2) {
                   
                    if (increment == 5) {
                        GeriSayim.Stop();
                        test5.changeQuestion(currentQuestion + 1);

                    }
                }
                else if (currentQuestion == 3) {
                   
                    if (increment == 8) {
                        GeriSayim.Stop();
                        test5.changeQuestion(currentQuestion + 1);

                    }
                }
                else if (currentQuestion == 4) {
                   
                    if (increment == 12) {
                        GeriSayim.Stop();
                        test5.changeQuestion(currentQuestion + 1);

                    }
                }
                else if (currentQuestion == 5) {
                    
                    if (increment == 15) {
                        GeriSayim.Stop();
                        test5.changeQuestion(currentQuestion + 1);

                    }
                }
                else if (currentQuestion == 6) {
                    
                    if (increment == 20) {
                        GeriSayim.Stop();
                        test5.changeQuestion(currentQuestion + 1);

                    }
                }
                else if (currentQuestion == 7) {
                    
                    if (increment == 24) {
                        GeriSayim.Stop();
                        test5.changeQuestion(currentQuestion + 1);

                    }
                }
                else if (currentQuestion == 8) {
                    
                    if (increment == 27) {
                        GeriSayim.Stop();
                        test5.changeQuestion(currentQuestion + 1);

                    }
                }
                else if (currentQuestion == 9) {
                    
                    if (increment == 29) {
                        GeriSayim.Stop();
                        test5.changeQuestion(currentQuestion + 1);

                    }
                }
                else if (currentQuestion == 10) {
                    
                    if (increment == 32) {
                        GeriSayim.Stop();
                        test5.changeQuestion(currentQuestion + 1);

                    }
                }
                else if (currentQuestion == 11) {
                   
                    if (increment == 34) {
                        GeriSayim.Stop();
                        test5.changeQuestion(currentQuestion + 1);

                    }
                }
                else if (currentQuestion == 12) {
                    
                    if (increment == 37) {
                        GeriSayim.Stop();
                        test5.changeQuestion(currentQuestion + 1);

                    }
                }
                else if (currentQuestion == 13) {
                    
                    if (increment == 40) {
                        GeriSayim.Stop();
                        endTest();
                    }
                }

            }
        }
        private void endTest()
        {
            FirstGrid.Visibility = Visibility.Collapsed;
            ButtonPanel.Visibility = Visibility.Visible;
            skill1P.Value = 55;
            skill1P.Maximum = 100;
            skill1P.Minimum = 0;
            skill2P.Value = 55;
            skill2P.Maximum = 100;
            skill2P.Minimum = 0;
            skill3P.Value = 55;
            skill3P.Maximum = 100;
            skill3P.Minimum = 0;
            skill4P.Value = 55;
            skill4P.Maximum = 100;
            skill4P.Minimum = 0;
            //TODO
            //Verilerin incelenip yüzdelerin ayarlanıp Result sayfasına geçiş burda olacak
        }
        private void readTicker(object sender, EventArgs e)
        {
            // Memoryde yapılacak
            //sw.WriteLine(currentTest + ";" + port.ReadLine());
            //Console.WriteLine(currentTest + ";" + port.ReadLine());
            testValues.Add(currentTest+";"+port.ReadLine());
            
            increment2 += 0.25;
            if (increment2 == 1.0)
            {
                increment2 = 0.0;
                readTimer.Stop();
                
            }
            

            
            
        }
        private void restTicker(object sender, EventArgs e)
        {

           
            increment1++;
            port.ReadExisting();
            timerTextBlock.Text = increment1.ToString();
            if(currentTest == 1)
            {
                timerProgress.Maximum = 5;
                test1.changeToRestTime();
            }
                
            else if(currentTest == 2)
            {
                timerProgress.Maximum = 10;
                test2.changeToRestTime();
            }
                
            
            else if (currentTest == 4)
            {
                timerProgress.Maximum = 5;
                test4.changeToRestTime();
            }
                
            timerProgress.Value = increment1;
            timerProgress.Minimum =0;
           
            if (currentTest == 1 && increment1==5)
            {
                restTimer.Stop();
                increment1 = 0;
                test1.changeQuestion(currentQuestion + 1);
            }
            else if (currentTest == 2 && increment1 == 10) {
                restTimer.Stop();
                increment1 = 10;
                test2.changeQuestion(currentQuestion + 1);
            }
           
            else if (currentTest == 4 && increment1 == 5) {
                restTimer.Stop();
                increment1 = 0;
                test4.changeQuestion(currentQuestion + 1);
            }
  
        }
        private void restQuestion()
        {
            readTimer.Stop();
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
            
     

                
            
        }

        public void initiateTest2()
        {
            //TODO
            //Test 2 sürelerinin ve süreye göre geçişlerin ayarlanması burda olacak.
            //Sorular değiştikçe currentQuestion, remainingInCurrentTest değişmeli
            currentQuestion++;
            remainingInCurrentTest--;
            questionNo.Text = currentQuestion.ToString();
            remaining.Text = remainingInCurrentTest.ToString();

            increment = 0;
            timerProgress.Value = 0;
            timerProgress.Minimum = 0;
            timerProgress.Maximum = 12;
            GeriSayim = new DispatcherTimer();
            GeriSayim.Interval = TimeSpan.FromSeconds(1);
            GeriSayim.Tick += dtTicker;
            GeriSayim.Start();

    
        }

        public void initiateTest3()
        {
            //TODO
            //Test 3 sürelerinin ve süreye göre geçişlerin ayarlanması burda olacak.
            //Sorular değiştikçe currentQuestion, remainingInCurrentTest değişmeli

            currentQuestion++;
            remainingInCurrentTest--;
            questionNo.Text = currentQuestion.ToString();
            remaining.Text = remainingInCurrentTest.ToString();

            increment = 0;
            timerProgress.Value = 0;
            timerProgress.Minimum = 0;
            timerProgress.Maximum = 12;
            GeriSayim = new DispatcherTimer();
            GeriSayim.Interval = TimeSpan.FromSeconds(1);
            GeriSayim.Tick += dtTicker;
            GeriSayim.Start();


        }
        public void initiateTest4()
        {
            //TODO
            //Test 4 sürelerinin ve süreye göre geçişlerin ayarlanması burda olacak.
            //Sorular değiştikçe currentQuestion, remainingInCurrentTest değişmeli

            currentQuestion++;
            remainingInCurrentTest--;
            questionNo.Text = currentQuestion.ToString();
            remaining.Text = remainingInCurrentTest.ToString();

            increment = 0;
            timerProgress.Value = 0;
            timerProgress.Minimum = 0;
            timerProgress.Maximum = 12;
            GeriSayim = new DispatcherTimer();
            GeriSayim.Interval = TimeSpan.FromSeconds(1);
            GeriSayim.Tick += dtTicker;
            GeriSayim.Start();
            increment = 0;

        }
        public void initiateTest5()
        {
            //TODO
            //Test 5 sürelerinin ve süreye göre geçişlerin ayarlanması burda olacak.
            //Sorular değiştikçe currentQuestion, remainingInCurrentTest değişmeli
            currentQuestion++;
            remainingInCurrentTest--;
            
            questionNo.Text = currentQuestion.ToString();
            remaining.Text = remainingInCurrentTest.ToString();

            
            
            timerProgress.Minimum = 0;
            timerProgress.Maximum = 40;
            GeriSayim = new DispatcherTimer();
            GeriSayim.Interval = TimeSpan.FromSeconds(1);
            GeriSayim.Tick += dtTicker;
            GeriSayim.Start();

        }

        private void ReturnBack(object sender, EventArgs e)
        {
            GeriSayim.Stop();
            restTimer.Stop();
            increment = 0;

            /*Uri pageFunctionUri = new Uri("Test.xaml", UriKind.Relative);
            this.NavigationService.Navigate(pageFunctionUri);
            currentTest = 0;
            currentQuestion = 0;*/
            foreach (string item in testValues)
            {
                Console.WriteLine(item);
                sw.WriteLine(item);
            }
            FirstGrid.Visibility = Visibility.Visible;
            ButtonPanel.Visibility = Visibility.Collapsed;
            currentTest = 0;
            currentQuestion = 0;
            QuestionFrame.Visibility = Visibility.Collapsed;
            LeftBar.Visibility = Visibility.Collapsed;
            FirstPage.Visibility = Visibility.Visible;
            TestName.Text = "Test";
        }

    }
}
