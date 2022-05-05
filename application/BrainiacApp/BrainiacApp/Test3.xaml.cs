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

namespace BrainiacApp {
    /// <summary>
    /// Test3.xaml etkileşim mantığı
    /// </summary>
    public partial class Test3 : Page {
        private Test mainTest;
        private int[] Results;
        private int counter;
        private int currentPart;
        private int currentTest;

        public Test3(Test main) {
            InitializeComponent();
            Results = new int[6];
            counter = 0;
            currentTest = 0;
            currentPart = 0;
            mainTest = main;
            this.FontFamily = new FontFamily("Alata");
            setLanguage("en-Us");
        }
        public void setLanguage(String lang) {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(lang);
            T3Info1.Text = Properties.strings.T3Info1;
            T3Info2.Text = Properties.strings.T3Info2;
            T3Info3.Text = Properties.strings.T3Info3;
            T3Info4.Text = Properties.strings.T3Info4;
            T3Info5.Text = Properties.strings.T3Info5;
            //QuestionText.Text = Properties.strings.T2Q;
        }
        private void StartTest3(object sender, RoutedEventArgs e) {
            Introduction.Visibility = Visibility.Collapsed;
            QuestionPanel.Visibility = Visibility.Visible;
            A2.Content = "H";
            mainTest.initiateTest3();
        }
        public void changeToRestTime() {
            QuestionPanel.Visibility = Visibility.Collapsed;
        }

        public void changeQuestion(int questionNo) {
            counter++;
            if (questionNo == 2) {
                QuestionPanel.Visibility = Visibility.Visible;
                A1.Content = "";
                B2.Content = "M";
                mainTest.initiateTest3();
            }
            if (questionNo == 3) {
                QuestionPanel.Visibility = Visibility.Visible;
                C3.Content = "";
                B3.Content = "X";
                mainTest.initiateTest3();
            }
            if (questionNo == 4) {
                QuestionPanel.Visibility = Visibility.Visible;
                B3.Content = "";
                A1.Content = "A";
                mainTest.initiateTest3();
            }
            if (questionNo == 5) {
                QuestionPanel.Visibility = Visibility.Visible;
                A2.Content = "";
                B2.Content = "F";
                mainTest.initiateTest3();
            }
            if (questionNo == 6) {
                QuestionPanel.Visibility = Visibility.Visible;
                B2.Content = "";
                A2.Content = "I";
                mainTest.initiateTest3();
            }
        }

        public void changePart() {
            resetTiles();
            currentPart++;
            if(currentTest == 0) {
                if(currentPart == 1) {
                    A2.Content = "";
                    C3.Content = "D";
                }
                else if(currentPart == 2) {
                    C3.Content = "";
                    A1.Content = "H";
                    currentPart = 0;
                    currentTest++;
                }
            }
            else if(currentTest == 1) {

                if (currentPart == 1) {
                    B2.Content = "";
                    C1.Content = "K";
                }
                else if (currentPart == 2) {
                    C1.Content = "";
                    C3.Content = "D";
                    currentPart = 0;
                    currentTest++;
                }
            }
            else if (currentTest == 2) {

                if (currentPart == 1) {
                    B3.Content = "";
                    C1.Content = "Y";
                }
                else if (currentPart == 2) {
                    C1.Content = "";
                    B3.Content = "X";
                    currentPart = 0;
                    currentTest++;
                }
            }
            else if (currentTest == 3) {

                if (currentPart == 1) {
                    A1.Content = "";
                    C3.Content = "D";
                }
                else if (currentPart == 2) {
                    C3.Content = "";
                    A2.Content = "A";
                    currentPart = 0;
                    currentTest++;
                }
            }
            else if (currentTest == 4) {

                if (currentPart == 1) {
                    B2.Content = "";
                    C3.Content = "L";
                }
                else if (currentPart == 2) {
                    C3.Content = "";
                    B2.Content = "D";
                    currentPart = 0;
                    currentTest++;
                }
            }
            else if (currentTest == 5) {

                if (currentPart == 1) {
                    A2.Content = "";
                    B1.Content = "P";
                }
                else if (currentPart == 2) {
                    B1.Content = "";
                    A2.Content = "I";
                    currentPart = 0;
                    currentTest++;
                }
            }

        }

        private void resetTiles() {
            A1.Content = "";
            A2.Content = "";
            A3.Content = "";
            B1.Content = "";
            B2.Content = "";
            B3.Content = "";
            C1.Content = "";
            C2.Content = "";
            C3.Content = "";
        }

        private void InputBox_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void A2_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void BothMatch(object sender, RoutedEventArgs e) {
            Results[counter] = 1;
        }
        private void NoMatch(object sender, RoutedEventArgs e) {
            Results[counter] = 2;
        }
        private void LetterMatch(object sender, RoutedEventArgs e) {
            Results[counter] = 3;
        }
        private void SquareMatch(object sender, RoutedEventArgs e) {
            Results[counter] = 4;
        }
    }
}
