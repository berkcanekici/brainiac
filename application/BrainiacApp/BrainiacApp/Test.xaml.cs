using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading;
using System.Globalization;
using System.Windows.Threading;
using System.IO.Ports;
using System.IO;
using System.Collections;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using FireSharp;
using Microsoft.Win32;


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
        private int currentTest = 0 ;
        private int currentQuestion = 0;
        private int remainingInCurrentTest;
        DispatcherTimer GeriSayim;
        DispatcherTimer restTimer;
        DispatcherTimer readTimer;
        int counter = 0;
        public FileStream fs ;
        StreamWriter sw;
        ArrayList testValues = new ArrayList();
        FirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "wFPZXKJfk6QvvVwmiGuDkIHGYB40Q3YxG86QcZFI",
            BasePath = "https://brainiacapp-df827-default-rtdb.firebaseio.com/"
        };
        FirebaseClient client;
        int lineCounter = 0;
        public Test()
        {
            InitializeComponent();
            this.FontFamily = new FontFamily("Alata");
            client = new FirebaseClient(ifc);

            test1=new Test1(this);
            test2=new Test2(this);  
            test3=new Test3(this);  
            test4=new Test4(this);  
            test5=new Test5(this);

            string[] ports = null;

            ports = System.IO.Ports.SerialPort.GetPortNames();

            if (ports != null)
            {
                for(int i = 0;i < ports.Length;i++)
                    PortComboBox.Items.Add(ports[i]);
            }
            port = new SerialPort();

            

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
                


                port.BaudRate = 9600;
                port.PortName = PortComboBox.Text;
                port.Open();
                port.Write("Hi, I am trying to talk to you.");

                userName = NameEnterBox.Text;
                FirstPage.Visibility = Visibility.Collapsed;
                LeftBar.Visibility = Visibility.Visible;
                QuestionFrame.Visibility = Visibility.Visible;
                currentQuestion = 0;
                remainingInCurrentTest = 5;
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
                client.DeleteAsync("Data");
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
                        currentTest++;
                        endTest();
                    }
                }

            }
        }
        private void endTest() {
            fs = new FileStream(userName, FileMode.OpenOrCreate, FileAccess.Write);
            sw = new StreamWriter(fs);
            for (int i = 0; i < testValues.Count - 3; i++)
			{
                //MessageBox.Show(testValues[i].ToString());
                sw.WriteLine(testValues[i]);
			}
            sw.Close();
            fs.Close();

            
            // BURAK
            Console.WriteLine("Testing smth.");
            // 1) Create Process Info
            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Users\serdi\mne-python\1.0.3_0\python.exe";
            // 2) Provide script and arguments
            var script = @"C:\Users\serdi\Desktop\final\brainiac-main\application\BrainiacApp\BrainiacApp\user_mean.py";
            var fileName = userName; // userName olacak çünkü hardco.
            psi.Arguments = $"\"{script}\" \"{fileName}\"";
            // 3) Process configuration
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            // 4) Execute process and get output
            var errors = "";
            var results = "";

            using (var process = Process.Start(psi)) {
                errors = process.StandardError.ReadToEnd();
                results = process.StandardOutput.ReadToEnd();
            }

            // 5) Display output
            Console.WriteLine("ERRORS:");
            Console.WriteLine(errors);
            Console.WriteLine();
            Console.WriteLine("Results:");
            Console.WriteLine(results);
            //MessageBox.Show(errors);

            string[] resultSplit = results.Split('\n');
            double[] resultsInt = new double[4];
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            resultsInt[0] = Convert.ToDouble(resultSplit[2], provider);
            resultsInt[1] = Convert.ToDouble(resultSplit[4], provider);
            resultsInt[2] = Convert.ToDouble(resultSplit[6], provider);
            resultsInt[3] = Convert.ToDouble(resultSplit[8], provider);

            /*MessageBox.Show(resultSplit[2]);
            MessageBox.Show(resultSplit[4]);
            MessageBox.Show(resultSplit[6]);
            MessageBox.Show(resultSplit[8]);*/
            resultsInt[0] += 5;
            if (test3.Results[0] == 3)
                resultsInt[1] += 1.5f;
            else
                resultsInt[1] -= 1.5f;
            if (test3.Results[1] == 2)
                resultsInt[1] += 1.5f;
            else
                resultsInt[1] -= 1.5f;
            if (test3.Results[2] == 1)
                resultsInt[1] += 1.5f;
            else
                resultsInt[1] -= 1.5f;
            if (test3.Results[3] == 3)
                resultsInt[1] += 1.5f;
            else
                resultsInt[1] -= 1.5f;
            if (test3.Results[4] == 4)
                resultsInt[1] += 1.5f;
            else
                resultsInt[1] -= 1.5f;
            if (test3.Results[5] == 1)
                resultsInt[1] += 1.5f;
            else
                resultsInt[1] -= 1.5f;

            if (Test4Q1.Length == 0)
                resultsInt[2] -= 2;
            else
                resultsInt[2] += 2;
            if (Test4Q2.Length == 0)
                resultsInt[2] -= 2;
            else
                resultsInt[2] += 2;
            if (Test4Q3.Length == 0)
                resultsInt[2] -= 2;
            else
                resultsInt[2] += 2;
            if (Test4Q4.Length == 0)
                resultsInt[2] -= 2;
            else
                resultsInt[2] += 2;
            if (Test4Q5.Length == 0)
                resultsInt[2] -= 2;
            else
                resultsInt[2] += 2;

            if (test5.Results[0].isCorrect) {
                if (test5.Results[0].isGo)
                    resultsInt[3] += (3000 - test5.Results[0].msResult) * 0.0002f;
                else
                    resultsInt[3] += 1f;
            }
            else
                resultsInt[3] += -1f;
            if (test5.Results[1].isCorrect) {
                if (test5.Results[1].isGo)
                    resultsInt[3] += (2000 - test5.Results[1].msResult) * 0.0002f;
                else
                    resultsInt[3] += 1f;
            }
            else
                resultsInt[3] += -1f;
            if (test5.Results[2].isCorrect) {
                if (test5.Results[2].isGo)
                    resultsInt[3] += (3000 - test5.Results[2].msResult) * 0.0002f;
                else
                    resultsInt[3] += 1f;
            }
            else
                resultsInt[3] += -1f;
            if (test5.Results[3].isCorrect) {
                if (test5.Results[3].isGo)
                    resultsInt[3] += (4000 - test5.Results[3].msResult) * 0.0002f;
                else
                    resultsInt[3] += 1f;
            }
            else
                resultsInt[3] += -1f;
            if (test5.Results[4].isCorrect) {
                if (test5.Results[4].isGo)
                    resultsInt[3] += (3000 - test5.Results[4].msResult)  * 0.0002f;
                else
                    resultsInt[3] += 1f;
            }
            else
                resultsInt[3] += -1f;
            if (test5.Results[5].isCorrect) {
                if (test5.Results[5].isGo)
                    resultsInt[3] += (5000 - test5.Results[5].msResult) * 0.0002f;
                else
                    resultsInt[3] += 1f;
            }
            else
                resultsInt[3] += -1f;
            if (test5.Results[6].isCorrect) {
                if (test5.Results[6].isGo)
                    resultsInt[3] += (4000 - test5.Results[6].msResult) * 0.0002f;
                else
                    resultsInt[3] += 1f;
            }
            else
                resultsInt[3] += -1f;
            if (test5.Results[7].isCorrect) {
                if (test5.Results[7].isGo)
                    resultsInt[3] += (3000 - test5.Results[7].msResult) * 0.0002f;
                else
                    resultsInt[3] += 1f;
            }
            else
                resultsInt[3] += -1f;
            if (test5.Results[8].isCorrect) {
                if (test5.Results[8].isGo)
                    resultsInt[3] += (2000 - test5.Results[8].msResult) * 0.0002f;
                else
                    resultsInt[3] += 1f;
            }
            else
                resultsInt[3] += -1f;
            if (test5.Results[9].isCorrect) {
                if (test5.Results[9].isGo)
                    resultsInt[3] += (3000 - test5.Results[9].msResult) * 0.0002f;
                else
                    resultsInt[3] += 1f;
            }
            else
                resultsInt[3] += -1f;
            if (test5.Results[10].isCorrect) {
                if (test5.Results[10].isGo)
                    resultsInt[3] += (2000 - test5.Results[10].msResult) * 0.0002f;
                else
                    resultsInt[3] += 1f;
            }
            else
                resultsInt[3] += -1f;
            if (test5.Results[11].isCorrect) {
                if (test5.Results[11].isGo)
                    resultsInt[3] += (3000 - test5.Results[11].msResult) * 0.0002f;
                else
                    resultsInt[3] += 1f;
            }
            else
                resultsInt[3] += -1f;
            if (test5.Results[12].isCorrect) {
                if (test5.Results[12].isGo)
                    resultsInt[3] += (3000 - test5.Results[12].msResult) * 0.0002f;
                else
                    resultsInt[3] += 1f;
            }
            else
                resultsInt[3] += -1f;
            //MessageBox.Show("gelidm0");
            int[] finalResults = new int[4];
            finalResults[0] = (int)resultsInt[0];
            finalResults[1] = (int)resultsInt[1];
            finalResults[2] = (int)resultsInt[2];
            finalResults[3] = (int)resultsInt[3];
            for(int i = 0;i < 4;i++)
                //MessageBox.Show(finalResults[i].ToString());

            //MessageBox.Show("gelidm1");
            if (finalResults[0] > 100)
                finalResults[0] = 100;
            if (finalResults[1] > 100)
                finalResults[1] = 100;
            if (finalResults[2] > 100)
                finalResults[2] = 100;
            if (finalResults[3] > 100)
                finalResults[3] = 100;

            skill1Res.Text = "According to our test, your skill level is %" + finalResults[0].ToString() + ". To test this we have observed your \nvisual cortex during related tasks. The activation levels can be found in the graph. \nAccording to our findings, you are above average at this skill.If you want to learn more \nabout what that means, you can check About Skills.";
            skill2Res.Text = "According to our test, your skill level is %" + finalResults[1].ToString() + ". To test this we have observed your \npreforontal cortex during related tasks. The activation levels can be found in the graph. \nAccording to our findings, you are above average at this skill.If you want to learn more \nabout what that means, you can check About Skills.";
            skill3Res.Text = "According to our test, your skill level is %" + finalResults[2].ToString() + ". To test this we have observed your \nfrontopolar cortex during related tasks. The  activation levels can be found in the graph. \nAccording to our findings, you are above average at this skill.If you want to learn more \nabout what that means, you can check About Skills.";
            skill4Res.Text = "According to our test, your skill level is %" + finalResults[3].ToString() + ". To test this we have observed your \nfrontal cortex during related tasks. The activation levels can be found in the graph. \nAccording to our findings, you are above average at this skill.If you want to learn more \nabout what that means, you can check About Skills.";

            //MessageBox.Show("gelidm2");

            FirstGrid.Visibility = Visibility.Collapsed;
            ButtonPanel.Visibility = Visibility.Visible;
            skill1PText.Text = finalResults[0].ToString();
            skill1P.Value = finalResults[0];
            skill1P.Maximum = 100;
            skill1P.Minimum = 0;
            skill2PText.Text = finalResults[1].ToString();
            skill2P.Value = finalResults[1];
            skill2P.Maximum = 100;
            skill2P.Minimum = 0;
            skill3PText.Text = finalResults[2].ToString();
            skill3P.Value = finalResults[2];
            skill3P.Maximum = 100;
            skill3P.Minimum = 0;
            skill4PText.Text = finalResults[3].ToString();
            skill4P.Value = finalResults[3];
            skill4P.Maximum = 100;
            skill4P.Minimum = 0;
            //MessageBox.Show("gelidm3");
            /*
            //TODO
            //Verilerin incelenip yüzdelerin ayarlanıp Result sayfasına geçiş burda olacak
            Console.WriteLine("Testing MNE.");
            // 1) Create Process Info
            var psi2 = new ProcessStartInfo();
            psi2.FileName = @"C:\Users\serdi\mne-python\1.0.3_0\python.exe";

            // 2) Provide script and arguments
            var script2 = @"C:\Users\serdi\Desktop\final\brainiac-main\application\BrainiacApp\BrainiacApp\code.py";
            var fileName2 = userName; //userName olacak, burası değişmeli

            psi2.Arguments = $"\"{script2}\" \"{fileName2}\"";

            // 3) Process configuration
            psi2.UseShellExecute = false;
            psi2.CreateNoWindow = true;
            psi2.RedirectStandardOutput = true;
            psi2.RedirectStandardError = true;

            // 4) Execute process and get output
            var errors2 = "";
            var results2 = "";

            using (var process2 = Process.Start(psi2))
            {
                errors2 = process2.StandardError.ReadToEnd();
                results2 = process2.StandardOutput.ReadToEnd();
                process2.WaitForExit();
            }
       

            // 5) Display output
            Console.WriteLine("ERRORS:");
            Console.WriteLine(errors2);
            Console.WriteLine();
            Console.WriteLine("Results:");
            Console.WriteLine(results2);*/
        }
        private void readTicker(object sender, EventArgs e)
        {
            // Memoryde yapılacak
            //sw.WriteLine(currentTest + ";" + port.ReadLine());
            //Console.WriteLine(currentTest + ";" + port.ReadLine());

            String dataString = currentTest.ToString() + ";" + port.ReadLine();
            String path = "Data/" + "A";
            if (currentTest != 0 && currentTest != 6)
            {
                if(counter%10==0)
                    client.SetAsync(path, dataString);
                
                
                testValues.Add(dataString);
                lineCounter++;
                counter++;
            }
            
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
            //port.ReadExisting();
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
            
            /*FirstGrid.Visibility = Visibility.Visible;
            ButtonPanel.Visibility = Visibility.Collapsed;
            currentTest = 0;
            currentQuestion = 0;
            QuestionFrame.Visibility = Visibility.Collapsed;
            LeftBar.Visibility = Visibility.Collapsed;
            FirstPage.Visibility = Visibility.Visible;
            TestName.Text = "Test";*/
        }


    }
}
