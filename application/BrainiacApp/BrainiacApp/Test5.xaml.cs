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
using System.Diagnostics;

namespace BrainiacApp {
    /// <summary>
    /// Test5.xaml etkileşim mantığı
    /// </summary>
    /// 
    public struct Result {
        public float msResult;
        public bool isCorrect;
        public bool isGo;
    }
public partial class Test5 : Page {
        private Test mainTest;
        Stopwatch stopWatch;
        
        private int counter;
        public Result[] Results;
        DateTime dt;
        long msBefore, msAfter;
        public Test5(Test main) {
            InitializeComponent();
            Results = new Result[13];
            Results[0].msResult = 3000;
            Results[0].isCorrect = false;
            Results[0].isGo = true;
            Results[1].msResult = 2000;
            Results[1].isCorrect = false;
            Results[1].isGo = true;
            Results[2].msResult = 3000;
            Results[2].isCorrect = false;
            Results[2].isGo = true;
            Results[3].msResult = 4000;
            Results[3].isCorrect = true;
            Results[3].isGo = false;
            Results[4].msResult = 3000;
            Results[4].isCorrect = false;
            Results[4].isGo = true;
            Results[5].msResult = 5000;
            Results[5].isCorrect = true;
            Results[5].isGo = false;
            Results[6].msResult = 4000;
            Results[6].isCorrect = false;
            Results[6].isGo = true;
            Results[7].msResult = 3000;
            Results[7].isCorrect = false;
            Results[7].isGo = true;
            Results[8].msResult = 2000;
            Results[8].isCorrect = true;
            Results[8].isGo = false;
            Results[9].msResult = 3000;
            Results[9].isCorrect = false;
            Results[9].isGo = true;
            Results[10].msResult = 2000;
            Results[10].isCorrect = false;
            Results[10].isGo = true;
            Results[11].msResult = 3000;
            Results[11].isCorrect = true;
            Results[11].isGo = false;
            Results[12].msResult = 3000;
            Results[12].isCorrect = false;
            Results[12].isGo = true;

            counter = 0;
            mainTest = main;
            this.FontFamily = new FontFamily("Alata");
            setLanguage("en-Us");
        }

        public void setLanguage(String lang) {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(lang);
            T5Info1.Text = Properties.strings.T5Info1;
            T5Info2.Text = Properties.strings.T5Info2;
            T5Info3.Text = Properties.strings.T5Info3;
            //QuestionText.Text = Properties.strings.T5Q1;
        }
        private void StartTest5(object sender, RoutedEventArgs e) {
            Introduction.Visibility = Visibility.Collapsed;
            QuestionPanel.Visibility = Visibility.Visible;
            GoButton_.Visibility = Visibility.Visible;
            stopWatch = new Stopwatch();
            stopWatch.Start();
            mainTest.initiateTest5();
        }

        public void changeQuestion(int questionNo) {

            if (questionNo == 2) {
                NoGoText.Visibility = Visibility.Collapsed;
                GoText.Visibility = Visibility.Collapsed;
                NoGoButton_.Visibility = Visibility.Collapsed;
                GoButton_.Visibility = Visibility.Visible;
                stopWatch = new Stopwatch();
                stopWatch.Start();
                mainTest.initiateTest5();
            }
            else if (questionNo == 3) {
                NoGoText.Visibility = Visibility.Collapsed;
                GoText.Visibility = Visibility.Collapsed;
                NoGoButton_.Visibility = Visibility.Collapsed;
                GoButton_.Visibility = Visibility.Visible;
                stopWatch = new Stopwatch();
                stopWatch.Start();
                mainTest.initiateTest5();
            }
            else if (questionNo == 4) {
                NoGoText.Visibility = Visibility.Collapsed;
                GoText.Visibility = Visibility.Collapsed;
                GoButton_.Visibility = Visibility.Collapsed;
                NoGoButton_.Visibility = Visibility.Visible;
                stopWatch = new Stopwatch();
                stopWatch.Start();
                mainTest.initiateTest5();
            }
            else if (questionNo == 5) {
                NoGoText.Visibility = Visibility.Collapsed;
                GoText.Visibility = Visibility.Collapsed; NoGoText.Visibility = Visibility.Collapsed;
                NoGoButton_.Visibility = Visibility.Collapsed;
                GoButton_.Visibility = Visibility.Visible;
                stopWatch = new Stopwatch();
                stopWatch.Start();
                mainTest.initiateTest5();
            }
            else if (questionNo == 6) {
                NoGoText.Visibility = Visibility.Collapsed;
                GoText.Visibility = Visibility.Collapsed;
                GoButton_.Visibility = Visibility.Collapsed;
                NoGoButton_.Visibility = Visibility.Visible;
                stopWatch = new Stopwatch();
                stopWatch.Start();
                mainTest.initiateTest5();
            }
            else if (questionNo == 7) {
                NoGoText.Visibility = Visibility.Collapsed;
                GoText.Visibility = Visibility.Collapsed;
                NoGoButton_.Visibility = Visibility.Collapsed;
                GoButton_.Visibility = Visibility.Visible;
                stopWatch = new Stopwatch();
                stopWatch.Start();
                mainTest.initiateTest5();
            }
            else if (questionNo == 8) {
                NoGoText.Visibility = Visibility.Collapsed;
                GoText.Visibility = Visibility.Collapsed;
                NoGoButton_.Visibility = Visibility.Collapsed;
                GoButton_.Visibility = Visibility.Visible;
                stopWatch = new Stopwatch();
                stopWatch.Start();
                mainTest.initiateTest5();
            }
            else if (questionNo == 9) {
                NoGoText.Visibility = Visibility.Collapsed;
                GoText.Visibility = Visibility.Collapsed;
                GoButton_.Visibility = Visibility.Collapsed;
                NoGoButton_.Visibility = Visibility.Visible;
                stopWatch = new Stopwatch();
                stopWatch.Start();
                mainTest.initiateTest5();
            }
            else if (questionNo == 10) {
                NoGoText.Visibility = Visibility.Collapsed;
                GoText.Visibility = Visibility.Collapsed;
                NoGoButton_.Visibility = Visibility.Collapsed;
                GoButton_.Visibility = Visibility.Visible;
                stopWatch = new Stopwatch();
                stopWatch.Start();
                mainTest.initiateTest5();
            }
            else if (questionNo == 11) {
                NoGoText.Visibility = Visibility.Collapsed;
                GoText.Visibility = Visibility.Collapsed;
                NoGoButton_.Visibility = Visibility.Collapsed;
                GoButton_.Visibility = Visibility.Visible;
                stopWatch = new Stopwatch();
                stopWatch.Start();
                mainTest.initiateTest5();
            }
            else if (questionNo == 12) {
                NoGoText.Visibility = Visibility.Collapsed;
                GoText.Visibility = Visibility.Collapsed;
                GoButton_.Visibility = Visibility.Collapsed;
                NoGoButton_.Visibility = Visibility.Visible;
                stopWatch = new Stopwatch();
                stopWatch.Start();
                mainTest.initiateTest5();
            }
            else if (questionNo == 13) {
                NoGoText.Visibility = Visibility.Collapsed;
                GoText.Visibility = Visibility.Collapsed;
                NoGoButton_.Visibility = Visibility.Collapsed;
                GoButton_.Visibility = Visibility.Visible;
                stopWatch = new Stopwatch();
                stopWatch.Start();
                mainTest.initiateTest5();
            }
        }

        public void changeToRestTime() {
            QuestionText.Visibility = Visibility.Collapsed;
        }

        public void GoButton(object sender, RoutedEventArgs e) {
            stopWatch.Stop();
            GoButton_.Visibility = Visibility.Collapsed;
            GoText.Visibility = Visibility.Visible;
            Results[counter].msResult = stopWatch.Elapsed.Milliseconds;
            Results[counter].isGo = true;
            Results[counter].isCorrect = true;
            counter++;
        }

        public void NoGoButton(object sender, RoutedEventArgs e) {
            stopWatch.Stop();
            NoGoButton_.Visibility = Visibility.Collapsed;
            NoGoText.Visibility = Visibility.Visible;
            Results[counter].msResult = stopWatch.Elapsed.Milliseconds;
            Results[counter].isGo = false;
            Results[counter].isCorrect = false;
            counter++;
        }
    }
}
