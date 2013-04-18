using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Windows.Navigation;
using Leap;

namespace BTP
{
    /// <summary>
    /// Interaction logic for TutScreen.xaml
    /// </summary>
    public partial class TutScreen : Window
    {
        public int chapN;
        public int subChapN;
        public DispatcherTimer timer;
        public int counter;
        public int beepCounter;
        public bool CheckforSign;

        public SampleListener l;

        public TutScreen(int chapNumber, int subChapNumber)
        {
            
            InitializeComponent();
            HandArrow1.Visibility = Visibility.Visible;
            HandArrow2.Visibility = Visibility.Hidden;
            HandArrow3.Visibility = Visibility.Hidden;
            dot1_down.Visibility = Visibility.Hidden;
            dot1_up.Visibility = Visibility.Hidden;
            chapN = chapNumber;
            subChapN = subChapNumber;

           // MessageBox.Show(subChapN.ToString());
            
            counter = new int();
            counter = 0;

            beepCounter = new int();
            beepCounter = 0;

            CheckforSign = false;

            timer = new DispatcherTimer();
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 6);

            timer.Start();

            string imagePath = "C:/Users/Hiren/Desktop/BTP_WPF/BTP/BTP/data/" + chapN.ToString() + subChapN.ToString() + ".jpg";
            TutImage.Source = new BitmapImage(new Uri(imagePath));

            display(chapN, subChapN);

            ////////////////////////////////////////////////////////////////////////////////////////

            // Create a sample listener and controller
            //SampleListener listener = new SampleListener();
            Controller controller = new Controller();

            // Have the sample listener receive events from the controller
            
            l = new SampleListener();
            controller.AddListener(l);

            //listener.setVar(chapN, subChapN);

            // Keep this process running until Enter is pressed
            //Console.WriteLine("Press Enter to quit...");
            //Console.ReadLine();

            // Remove the sample listener when done
            //controller.RemoveListener(listener);
            //controller.Dispose();

            ////////////////////////////////////////////////////////////////////////////////////////
   
        }

        private void Image_PreviewMouseDown_2(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        public void display(int chp, int indx)
        {
            ChapNoText.Text = chp.ToString();
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
            //throw new NotImplementedException();

            if (counter == 0)
            {
                counter++;
                HandArrow1.Visibility = Visibility.Visible;
                HandArrow2.Visibility = Visibility.Hidden;
                HandArrow3.Visibility = Visibility.Hidden;
                dot1_down.Visibility = Visibility.Hidden;
                dot1_up.Visibility = Visibility.Hidden;
                
            }

            if (counter == 1)
            {
                HandArrow1.Visibility = Visibility.Hidden;
                HandArrow2.Visibility = Visibility.Visible;
                dot1_down.Visibility = Visibility.Hidden;
                dot1_up.Visibility = Visibility.Hidden;
                string videoPath = "C:/Users/Hiren/Desktop/BTP_WPF/BTP/BTP/data/" + chapN.ToString() + subChapN.ToString() +".wmv";
                TutVideo.Source = new Uri(videoPath, UriKind.Relative);
                TutVideo.MediaEnded += TutVideo_MediaEnded;
                counter++;
            }

            if (counter == 3)
            {
                counter++;
            }

            if (counter == 4)
            {
                //if(correct input)
                //dot1_up.Visibility = Visibility.Visible;
                if (CheckforSign)
                {
                    dot1_up.Visibility = Visibility.Visible;
                    dot1_down.Visibility = Visibility.Hidden;
                   timer.Stop();
                   MessageBox.Show("subchapter   "+subChapN.ToString());
                   if (subChapN == 4)
                    {
                        MessageBox.Show("into quiz");
                        QuizScreen q = new QuizScreen(chapN,1, chapN*2, 0);
                        App.Current.MainWindow = q;
                        this.Close();
                        q.Show();
                       
                    }
                    else
                    {
                        MessageBox.Show("into tut");
                        subChapN++;
                        TutScreen t = new TutScreen(chapN, subChapN);
                        App.Current.MainWindow = t;
                        this.Close();
                        t.Show();
                        
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
                        TutScreen t = new TutScreen(chapN, subChapN);
                        App.Current.MainWindow = t;
                        this.Close();
                        t.Show();              
                    }
                    beepCounter++;
                }
            }
     
            
        }

        void TutVideo_MediaEnded(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            counter = 3;
            timer.Interval = new TimeSpan(0, 0, 2);
            HandArrow2.Visibility = Visibility.Hidden;
            HandArrow3.Visibility = Visibility.Visible;
        }

        private void true_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            CheckforSign = true;
            dot1_up.Visibility = Visibility.Visible;
            dot1_down.Visibility = Visibility.Hidden;
        }

        private void false_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (CheckforSign == false)
            {
                CheckforSign = false;
                dot1_down.Visibility = Visibility.Visible;
            }
        }

        private void Image_PreviewMouseDown_1(object sender, MouseButtonEventArgs e)
        {
            timer.Stop();
            LeapScreen t = new LeapScreen();
            App.Current.MainWindow = t;
            this.Close();
            t.Show();  
        }

    }

    public class SampleListener : Listener
    {
        private Object thisLock = new Object();

        private Leap.Frame lastFrame;
        private int stateM;
        private int stateN;
        private int stateT;
        public bool changeStatusVar;

        private int chapN;
        private int subChapN;

        private void SafeWriteLine(String line)
        {
            lock (thisLock)
            {
                Console.WriteLine(line);
            }
        }

        public override void OnInit(Controller controller)
        {
            SafeWriteLine("Initialized");

            stateM = new int();
            stateN = new int();
            stateT = new int();

            stateN = 0;
            stateM = 0;
            stateT = 0;

            changeStatusVar = false;

            chapN = new int();
            subChapN = new int();

            chapN = 1;
            subChapN = 1;
        }

        public void setVar(int C, int S)
        {
            chapN = C;
            subChapN = S;
        }

        public override void OnConnect(Controller controller)
        {
            SafeWriteLine("Connected");
        }

        public override void OnDisconnect(Controller controller)
        {
            SafeWriteLine("Disconnected");
        }

        public override void OnExit(Controller controller)
        {
            SafeWriteLine("Exited");
        }

        public override void OnFrame(Controller controller)
        {
            
            // Get the most recent frame and report some basic information
            Leap.Frame frame = controller.Frame();

            switch (chapN)
            {
                case 1:
                    switch (subChapN)
                    {
                        case 1:
                            changeStatusVar = lookForA(frame);
                            if (changeStatusVar)
                            {
                                MessageBox.Show("DOne");
                            }
                            break;
                        case 2:
                            changeStatusVar = lookForB(frame);
                            break;
                        case 3:
                            changeStatusVar = lookForC(frame);
                            break;
                        case 4:
                            changeStatusVar = lookForD(frame);
                            break;
                        //other similar cases
                    }
                    break;
                case 2:
                    switch (subChapN)
                    {
                        case 1:
                            changeStatusVar = lookForE(frame);
                            break;
                        case 2:
                            changeStatusVar = lookForF(frame);
                            break;
                        case 3:
                            changeStatusVar = lookForG(frame);
                            break;
                        case 4:
                            changeStatusVar = lookForH(frame);
                            break;
                        //other similar cases
                    }
                    break;
                case 3:
                    switch (subChapN)
                    {
                        case 1:
                            changeStatusVar = lookForI(frame);
                            break;
                        case 2:
                            changeStatusVar = lookForJ(frame);
                            break;
                        case 3:
                            changeStatusVar = lookForK(frame);
                            break;
                        case 4:
                            changeStatusVar = lookForL(frame);
                            break;
                        //other similar cases
                    }
                    break;
                case 4:
                    switch (subChapN)
                    {
                        case 1:
                            changeStatusVar = lookForM(frame);
                            break;
                        case 2:
                            changeStatusVar = lookForN(frame);
                            break;
                        case 3:
                            changeStatusVar = lookForO(frame);
                            break;
                        case 4:
                            changeStatusVar = lookForP(frame);
                            break;
                        //other similar cases
                    }
                    break;
                case 5:
                    switch (subChapN)
                    {
                        case 1:
                            changeStatusVar = lookForQ(frame);
                            break;
                        case 2:
                            changeStatusVar = lookForR(frame);
                            break;
                        case 3:
                            changeStatusVar = lookForS(frame);
                            break;
                        case 4:
                            changeStatusVar = lookForT(frame);
                            break;
                        //other similar cases
                    }
                    break;
                case 6:
                    switch (subChapN)
                    {
                        case 1:
                            changeStatusVar = lookForU(frame);
                            break;
                        case 2:
                            changeStatusVar = lookForV(frame);
                            break;
                        case 3:
                            changeStatusVar = lookForW(frame);
                            break;
                        case 4:
                            changeStatusVar = lookForX(frame);
                            break;
                        //other similar cases
                    }
                    break;
                case 7:
                    switch (subChapN)
                    {
                        case 1:
                            changeStatusVar = lookForY(frame);
                            break;
                        case 2:
                            changeStatusVar = lookForZ(frame);
                            break;
                    }
                    break;
                //other similar cases
            }

        }

        float[] getScreenProjection(Pointable pointable, Controller controller)
        {
            float[] xy = new float[2];

            Screen screen = controller.CalibratedScreens[0];//   .calibratedScreens().get(0);
            Leap.Vector point = pointable.TipPosition - screen.BottomLeftCorner;// hand.pointables().get(0).tipPosition().minus(screen.bottomLeftCorner());
            Leap.Vector xAxis = screen.HorizontalAxis;// screen.horizontalAxis();
            Leap.Vector yAxis = screen.VerticalAxis;//.verticalAxis();

            Leap.Vector xProj = xAxis * (xAxis.Dot(point) / xAxis.MagnitudeSquared);//  xAxis.times(xAxis.dot(point)/xAxis.magnitudeSquared()); 
            Leap.Vector yProj = yAxis * (yAxis.Dot(point) / yAxis.MagnitudeSquared);//yAxis.times(yAxis.dot(point)/yAxis.magnitudeSquared()); 


            float xLeap = xProj.Magnitude;
            float yLeap = yProj.Magnitude;

            float x = screen.WidthPixels * xLeap / xAxis.Magnitude;// screen.widthPixels() * xLeap/xAxis.magnitude();
            float y = screen.HeightPixels - screen.HeightPixels * yLeap / yAxis.Magnitude;// screen.heightPixels() - screen.heightPixels() * yLeap/yAxis.magnitude();
            SafeWriteLine("X: " + x + ", Y: " + y);

            xy[0] = x;
            xy[1] = y;

            return xy;
        }

        Boolean lookForA(Leap.Frame frame)
        {
            if (frame.Hands[0].Fingers.Count == 1)
            {
                //SafeWriteLine(frame.Hands[0].Fingers[0].Direction.AngleTo(frame.Hands[0].Direction).ToString());
                //SafeWriteLine(frame.Hands[0].Direction.ToString());
                //SafeWriteLine((frame.Hands[0].Fingers[0].Direction.x - frame.Hands[0].Direction.x).ToString());
                if ((frame.Hands[0].Fingers[0].Direction.x - frame.Hands[0].Direction.x) < (-0.10))
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        Boolean lookForB(Leap.Frame frame)
        {
            if (frame.Hands[0].Fingers.Count == 1)
            {
                //SafeWriteLine(frame.Hands[0].Fingers[0].Length.ToString()+"   "+frame.Hands[0].SphereRadius.ToString());
                if (frame.Hands[0].Fingers[0].Length < (frame.Hands[0].SphereRadius / 2 + 2))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        Boolean lookForC(Leap.Frame frame)
        {
            if (frame.Hands[0].Fingers.Count == 2)
            {
                Hand hand = frame.Hands[0];
                //SafeWriteLine(hand.Fingers[0].Direction.AngleTo(hand.Fingers[1].Direction).ToString()+"  "+hand.Fingers[0].Direction.AngleTo(hand.Direction).ToString()+"  "+hand.Fingers[1].Direction.AngleTo(hand.Direction).ToString());
                if ((hand.Fingers[0].Direction.AngleTo(hand.Fingers[1].Direction) > (0.20)) && (hand.Fingers[0].Direction.AngleTo(hand.Fingers[1].Direction) < (0.70)))
                {
                    if ((hand.Fingers[0].Direction.AngleTo(hand.Direction) > (0.5)) && (hand.Fingers[0].Direction.AngleTo(hand.Direction) < (0.90)))
                    {
                        if ((hand.Fingers[1].Direction.AngleTo(hand.Direction) > (0.3)) && (hand.Fingers[1].Direction.AngleTo(hand.Direction) < (0.7)))
                        {
                            return true;
                        }
                        return false;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }

        Boolean lookForD(Leap.Frame frame)
        {
            if (frame.Hands[0].Fingers.Count == 1)
            {
                SafeWriteLine(frame.Hands[0].Fingers[0].Length.ToString() + "  " + frame.Hands[0].SphereRadius.ToString());
                if ((frame.Hands[0].Fingers[0].Length < (frame.Hands[0].SphereRadius + 20)) && (frame.Hands[0].Fingers[0].Length > (frame.Hands[0].SphereRadius - 0)))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        Boolean lookForE(Leap.Frame frame)
        {
            if (frame.Hands.Count == 1)
            {
                if (frame.Hands[0].Fingers.Count == 0)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        Boolean lookForF(Leap.Frame frame)
        {
            Hand hand = frame.Hands[0];
            if (hand.Fingers.Count == 3)
            {
                return true;
                FingerList fingers = hand.Fingers;
                if (!fingers.Empty)
                {
                    // Calculate the hand's average finger tip position
                    Leap.Vector avgPos = Leap.Vector.Zero;
                    Finger lastFinger;
                    lastFinger = hand.Fingers[0];
                    foreach (Finger finger in fingers)
                    {
                        if (lastFinger.TipPosition.x < finger.TipPosition.x)
                        {
                            lastFinger = finger;
                        }
                        avgPos += finger.Direction;
                    }
                    avgPos /= fingers.Count;
                    SafeWriteLine(avgPos.AngleTo(hand.Direction).ToString());
                    if ((avgPos.AngleTo(hand.Direction) > 0.010) && (avgPos.AngleTo(hand.Direction) < 0.4))
                    {
                        // SafeWriteLine(lastFinger.Direction.AngleTo(hand.Direction).ToString());
                        if ((lastFinger.Direction.AngleTo(hand.Direction) > 0.12) && (lastFinger.Direction.AngleTo(hand.Direction) < 0.3))
                            return true;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }

        Boolean lookForG(Leap.Frame frame)
        {
            Hand hand = frame.Hands[0];
            if (hand.Fingers.Count == 2)
            {
                //SafeWriteLine(hand.Fingers[0].Direction.x.ToString() + "  " + hand.Fingers[0].Direction.y.ToString() + "  " + hand.Fingers[0].Direction.z.ToString() + "  " + hand.Fingers[1].Direction.x.ToString() + "  " + hand.Fingers[1].Direction.y.ToString() + "  " + hand.Fingers[1].Direction.z.ToString());
                return true;
            }
            return false;
        }

        Boolean lookForH(Leap.Frame frame)
        {
            Hand hand = frame.Hands[0];
            if (hand.Fingers.Count == 1)
            {
                //SafeWriteLine(hand.Fingers[0].Direction.x.ToString() + "  " + hand.Fingers[0].Direction.y.ToString() + "  " + hand.Fingers[0].Direction.z.ToString() + "  " + hand.Fingers[1].Direction.x.ToString() + "  " + hand.Fingers[1].Direction.y.ToString() + "  " + hand.Fingers[1].Direction.z.ToString());
                return true;
            }
            return false;
        }

        Boolean lookForI(Leap.Frame frame)
        {

            Hand hand = frame.Hands[0];
            if (hand.Fingers.Count == 1)
            {
                //SafeWriteLine(hand.Fingers[0].Direction.x.ToString() + "  " + hand.Fingers[0].Direction.y.ToString() + "  " + hand.Fingers[0].Direction.z.ToString() + "  " + hand.Fingers[1].Direction.x.ToString() + "  " + hand.Fingers[1].Direction.y.ToString() + "  " + hand.Fingers[1].Direction.z.ToString());
                return true;
            }
            return false;
        }

        Boolean lookForJ(Leap.Frame frame)
        {
            return false;
        }

        Boolean lookForK(Leap.Frame frame)
        {

            Hand hand = frame.Hands[0];
            if (hand.Fingers.Count == 2)
            {
                SafeWriteLine(hand.Fingers[0].Direction.AngleTo(hand.Fingers[1].Direction).ToString());
                if ((hand.Fingers[0].Direction.AngleTo(hand.Fingers[1].Direction) < 0.35) && (hand.Fingers[0].Direction.AngleTo(hand.Fingers[1].Direction) > 0.1))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        Boolean lookForL(Leap.Frame frame)
        {

            Hand hand = frame.Hands[0];
            if (hand.Fingers.Count == 2)
            {
                SafeWriteLine(hand.Fingers[0].Direction.AngleTo(hand.Fingers[1].Direction).ToString());
                if ((hand.Fingers[0].Direction.AngleTo(hand.Fingers[1].Direction) < 1.2) && (hand.Fingers[0].Direction.AngleTo(hand.Fingers[1].Direction) > 0.7))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        Boolean lookForM(Leap.Frame frame)
        {
            Hand hand = frame.Hands[0];
            if (stateM == 0)
            {
                SafeWriteLine("0");
                if (hand.Fingers.Count == 4 && frame.Hands.Count == 1)
                {
                    stateM = 1;
                    return false;
                }
                return false;
            }
            else if (stateM == 1)
            {
                SafeWriteLine("1 ");
                if (hand.Fingers.Count == 3 && frame.Hands.Count == 1)
                {
                    stateM = 2;
                    return false;
                }
                else if (hand.Fingers.Count == 2)
                {
                    stateM = 0;
                }
                else if (hand.Fingers.Count == 1)
                {
                    stateM = 0;
                }
                return false;
            }
            else if (stateM == 2)
            {
                SafeWriteLine("2 ");
                if (hand.Fingers.Count == 0 && frame.Hands.Count == 1)
                {
                    //SafeWriteLine(hand.Fingers[0].Direction.AngleTo(hand.Direction).ToString());
                    return true;
                }
                else if (hand.Fingers.Count > 3)
                {
                    stateM = 0;
                }

                return false;
            }


            return false;
        }

        Boolean lookForN(Leap.Frame frame)
        {

            return false;
        }

        Boolean lookForO(Leap.Frame frame)
        {

            return false;
        }

        Boolean lookForP(Leap.Frame frame)
        {

            Hand hand = frame.Hands[0];
            if (hand.Fingers.Count == 2)
            {
                //SafeWriteLine(hand.Fingers[0].Direction.x.ToString() + "  " + hand.Fingers[0].Direction.y.ToString() + "  " + hand.Fingers[0].Direction.z.ToString() + "  " + hand.Fingers[1].Direction.x.ToString() + "  " + hand.Fingers[1].Direction.y.ToString() + "  " + hand.Fingers[1].Direction.z.ToString());
                return true;
            }
            return false;
        }

        Boolean lookForQ(Leap.Frame frame)
        {

            return false;
        }

        Boolean lookForR(Leap.Frame frame)
        {

            return false;
        }

        Boolean lookForS(Leap.Frame frame)
        {
            if (frame.Hands.Count == 1)
            {
                if (frame.Hands[0].Fingers.Count == 0)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        Boolean lookForT(Leap.Frame frame)
        {

            return false;
        }

        Boolean lookForU(Leap.Frame frame)
        {
            Hand hand = frame.Hands[0];
            if (hand.Fingers.Count == 1)
            {
                return true;
            }
            return false;
        }

        Boolean lookForV(Leap.Frame frame)
        {
            Hand hand = frame.Hands[0];
            if (hand.Fingers.Count == 2)
            {
                //SafeWriteLine(hand.Fingers[0].Direction.AngleTo(hand.Fingers[1].Direction).ToString());
                if (hand.Fingers[0].Direction.AngleTo(hand.Fingers[1].Direction) < 0.35)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        Boolean lookForW(Leap.Frame frame)
        {
            Hand hand = frame.Hands[0];
            if (hand.Fingers.Count == 3)
            {
                SafeWriteLine(hand.Fingers[2].Direction.AngleTo(hand.Fingers[1].Direction).ToString());
                if (hand.Fingers[0].Direction.AngleTo(hand.Fingers[1].Direction) < 0.35)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        Boolean lookForX(Leap.Frame frame)
        {
            Hand hand = frame.Hands[0];
            if (hand.Fingers.Count == 1)
            {
                //SafeWriteLine(hand.Fingers[0].Direction.AngleTo(hand.Direction).ToString());
                if (hand.Fingers[0].Direction.AngleTo(hand.Direction) > 0.7)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        Boolean lookForY(Leap.Frame frame)
        {
            if (frame.Hands[0].Fingers.Count == 2)
            {
                //SafeWriteLine(frame.Hands[0].Fingers[0].Direction.AngleTo(frame.Hands[0].Fingers[1].Direction).ToString());
                if ((frame.Hands[0].Fingers[0].Direction.AngleTo(frame.Hands[0].Fingers[1].Direction)) > 0.6)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        Boolean lookForZ(Leap.Frame frame)
        {

            return false;
        }
    }
}
