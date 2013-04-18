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
using System.Windows.Shapes;
using System.Timers;
using System.Windows.Threading;

namespace BTP
{
    /// <summary>
    /// Interaction logic for QuizScreen.xaml
    /// </summary>
    public partial class QuizScreen : Window
    {
        public int chapN;
        public DispatcherTimer timer;
        public DispatcherTimer timer1;
        public int counter;
        public int beepCounter;
        public bool CheckforSign;

        public int counterForQ;
        public int totalNoOfQ;
        public int Score;

        public int fakeCounter;

        public QuizScreen(int x, int counterForQuiz, int totalQuizNo, int _score)
        {
            InitializeComponent();

            counterForQ = counterForQuiz;
            totalNoOfQ = totalQuizNo;

            QuizNo.Text = counterForQ.ToString() + " out of " + totalNoOfQ.ToString();
            score.Text = _score.ToString();

            fakeCounter = new int();
            fakeCounter = 0;

            chapnOText.Text = x.ToString();

            Score = _score;

            a.Visibility = Visibility.Hidden;
            b.Visibility = Visibility.Hidden;
            chapNumberText.Visibility = Visibility.Hidden;
            quizScoreText.Visibility = Visibility.Hidden;

            dot2_down.Visibility = Visibility.Hidden;
            dot2_up.Visibility = Visibility.Hidden;
            chapN = x;
            counter = new int();
            counter = 0;

            beepCounter = new int();
            beepCounter = 0;

            CheckforSign = false;

            timer = new DispatcherTimer();
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);

            timer.Start();

            Random rChap = new Random();
            int nxt = rChap.Next(1, chapN);

            Random rSubChap = new Random();
            int nxtSub = rSubChap.Next(1, 5);


            counterForQ++;
            display(nxt, nxtSub);
            
         }

        public void display(int chp, int indx)
        {
             switch (chp)
            {
                case 1:
                    switch (indx)
                    {
                        case 1:
                            textDisplay.Text = "A";
                            break;
                        case 2:
                            textDisplay.Text = "B";
                            break;
                        case 3:
                            textDisplay.Text = "C";
                            break;
                        case 4:
                            textDisplay.Text = "D";
                            break;
                        //other similar cases
                    }
                    break;
                case 2:
                    switch (indx)
                    {
                        case 1:
                            textDisplay.Text = "E";
                            break;
                        case 2:
                            textDisplay.Text = "F";
                            break;
                        case 3:
                            textDisplay.Text = "G";
                            break;
                        case 4:
                            textDisplay.Text = "H";
                            break;
                        //other similar cases
                    }
                    break;
                case 3:
                    switch (indx)
                    {
                        case 1:
                            textDisplay.Text = "I";
                            break;
                        case 2:
                            textDisplay.Text = "J";
                            break;
                        case 3:
                            textDisplay.Text = "K";
                            break;
                        case 4:
                            textDisplay.Text = "L";
                            break;
                        //other similar cases
                    }
                    break;
                case 4:
                    switch (indx)
                    {
                        case 1:
                            textDisplay.Text = "M";
                            break;
                        case 2:
                            textDisplay.Text = "N";
                            break;
                        case 3:
                            textDisplay.Text = "O";
                            break;
                        case 4:
                            textDisplay.Text = "P";
                            break;
                        //other similar cases
                    }
                    break;
                case 5:
                    switch (indx)
                    {
                        case 1:
                            textDisplay.Text = "Q";
                            break;
                        case 2:
                            textDisplay.Text = "R";
                            break;
                        case 3:
                            textDisplay.Text = "S";
                            break;
                        case 4:
                            textDisplay.Text = "T";
                            break;
                        //other similar cases
                    }
                    break;
                case 6:
                    switch (indx)
                    {
                        case 1:
                            textDisplay.Text = "U";
                            break;
                        case 2:
                            textDisplay.Text = "V";
                            break;
                        case 3:
                            textDisplay.Text = "W";
                            break;
                        case 4:
                            textDisplay.Text = "X";
                            break;
                        //other similar cases
                    }
                    break;
                case 7:
                    switch (indx)
                    {
                        case 1:
                            textDisplay.Text = "Y";
                            break;
                        case 2:
                            textDisplay.Text = "Z";
                            break;
                    }
                    break;
                //other similar cases
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            //if(correct input)
            //dot2_up.Visibility = Visibility.Visible;
            if(CheckforSign)
            {
                Score += 20;
                timer.Stop();
                MessageBox.Show(counterForQ.ToString());
                if (counterForQ == totalNoOfQ)
                {
                    MessageBox.Show("into quiz");
                    QuizScreen q = new QuizScreen(chapN, counterForQ, totalNoOfQ, Score);
                    App.Current.MainWindow = q;
                    this.Close();
                    q.Show();

                }
                else
                {

                    timer1 = new DispatcherTimer();
                    timer1.Tick += timer1_Tick;
                    timer1.Interval = new TimeSpan(0, 0, 1);

                    timer1.Start();

                }
            }
            else
            {
                if (beepCounter == 0)
                {
                    beep1.Source = new BitmapImage(new Uri("C:/Users/Hiren/Desktop/BTP_WPF/BTP/BTP/images/test1.png"));
                }
                else if (beepCounter == 1)
                {
                    beep2.Source = new BitmapImage(new Uri("C:/Users/Hiren/Desktop/BTP_WPF/BTP/BTP/images/test1.png"));
                }
                else if (beepCounter == 2)
                {
                    beep3.Source = new BitmapImage(new Uri("C:/Users/Hiren/Desktop/BTP_WPF/BTP/BTP/images/test1.png"));
                }
                else if (beepCounter == 3)
                {
                    beep4.Source = new BitmapImage(new Uri("C:/Users/Hiren/Desktop/BTP_WPF/BTP/BTP/images/test1.png"));
                }
                else if (beepCounter == 4)
                {
                    beep5.Source = new BitmapImage(new Uri("C:/Users/Hiren/Desktop/BTP_WPF/BTP/BTP/images/test1.png"));
                }
                else if (beepCounter == 5)
                {
                    beep6.Source = new BitmapImage(new Uri("C:/Users/Hiren/Desktop/BTP_WPF/BTP/BTP/images/test1.png"));
                }
                else if (beepCounter == 6)
                {
                    beep7.Source = new BitmapImage(new Uri("C:/Users/Hiren/Desktop/BTP_WPF/BTP/BTP/images/test1.png"));
                }
                else if (beepCounter == 7)
                {
                    beep8.Source = new BitmapImage(new Uri("C:/Users/Hiren/Desktop/BTP_WPF/BTP/BTP/images/test1.png"));
                }
                else if (beepCounter == 8)
                {
                    Score -= 10;
                    timer.Stop();
                    MessageBox.Show(counterForQ.ToString());
                    if (counterForQ == totalNoOfQ)
                    {
                        MessageBox.Show("into quiz");
                        QuizScreen q = new QuizScreen(chapN, counterForQ, totalNoOfQ, Score);
                        App.Current.MainWindow = q;
                        this.Close();
                        q.Show();

                    }
                    else
                    {

                        timer1 = new DispatcherTimer();
                        timer1.Tick += timer1_Tick;
                        timer1.Interval = new TimeSpan(0, 0, 1);

                        timer1.Start();


                    }
                }
                beepCounter++;
            }
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            MessageBox.Show("Sdfsdfsdfdsf");

            if (fakeCounter == 0)
            {

                a.Visibility = Visibility.Visible;
                b.Visibility = Visibility.Visible;
                chapNumberText.Visibility = Visibility.Visible;
                quizScoreText.Visibility = Visibility.Visible;

                score_.Visibility = Visibility.Hidden;
                score.Visibility = Visibility.Hidden;
                quizNo_.Visibility = Visibility.Hidden;
                QuizNo.Visibility = Visibility.Hidden;
                textDisplay.Visibility = Visibility.Hidden;
                beep1.Visibility = Visibility.Hidden;
                beep2.Visibility = Visibility.Hidden;
                beep3.Visibility = Visibility.Hidden;
                beep4.Visibility = Visibility.Hidden;
                beep5.Visibility = Visibility.Hidden;
                beep6.Visibility = Visibility.Hidden;
                beep7.Visibility = Visibility.Hidden;
                beep8.Visibility = Visibility.Hidden;

                dot2.Visibility = Visibility.Hidden;
                dot2_down.Visibility = Visibility.Hidden;
                dot2_up.Visibility = Visibility.Hidden;

                chapNumberText.Text = chapN.ToString();
                quizScoreText.Text = Score.ToString();

                timer1.Interval = new TimeSpan(0, 0, 5);
                fakeCounter++;
            }
            else
            {
                

                timer1.Stop();
                MessageBox.Show("into tut");
                chapN++;
                TutScreen t = new TutScreen(chapN, 1);
                App.Current.MainWindow = t;
                this.Close();
                t.Show();
            }
        }

        private void true_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            CheckforSign = true;
            dot2_up.Visibility = Visibility.Visible;
            dot2_down.Visibility = Visibility.Hidden;
        }

        private void false_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (CheckforSign == false)
            {
                CheckforSign = false;
                dot2_down.Visibility = Visibility.Visible;
            }
        }

        private void Image_PreviewMouseDown_1(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
