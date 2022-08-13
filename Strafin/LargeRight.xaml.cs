using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Timers;
using System.ComponentModel;

namespace Strafin
{

    public partial class LargeRight : Window
    {
        private readonly System.Timers.Timer _timer;
        static public double oldX = 0;
        static public double oldY = 200;
        static public Line? aLine;
        static public int iter = 45;
        static public bool _open;

        public LargeRight()
        {
            InitializeComponent();

            CommandBindings.Add(new CommandBinding(ApplicationCommands.Close,
                new ExecutedRoutedEventHandler(delegate (object sender, ExecutedRoutedEventArgs args) { this.Close(); })));

            _timer = new System.Timers.Timer(2);
            _timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }

        private void DragWindow(object sender, MouseButtonEventArgs args)
        {
            DragMove();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            gamepadUpdate();
        }

        private void gamepadUpdate()
        {
            XInputController gamepad = new XInputController();



            Dispatcher.Invoke(() =>
            {
                if (gamepad.Update())
                {
                    if (iter == 0)
                    {
                        canvas.Children.RemoveRange(3, 30);
                        iter = 30;
                    }
                    else
                    {
                        iter--;
                    }

                    double transformedX = 0 + (gamepad.right_x * 1.6);
                    double transformedY = 200 - (gamepad.right_y * 1.6);

                    Line myLine = new Line();
                    myLine.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
                    myLine.X1 = oldX;
                    myLine.X2 = transformedX;
                    myLine.Y1 = oldY;
                    myLine.Y2 = transformedY;
                    myLine.StrokeThickness = 3;
                    myLine.Uid = "myline";
                    aLine = myLine;

                    oldX = transformedX;
                    oldY = transformedY;

                    canvas.Children.Add(myLine);
                }
                else
                {
                    //btn.Content = "No Controller Connected";
                }
            });
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            var enabled = _timer.Enabled;
            if (enabled)
            {
                btn_start.Content = "Start";
                _timer.Enabled = false;
            }
            else
            {
                btn_start.Content = "Stop";
                _timer.Enabled = true;
            }
        }

        private void Window_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var window = (Window)sender;
            window.Topmost = true;
        }

        void LargeRight_Closing(object sender, CancelEventArgs e)
        {
            _open = false;
        }

    }
}
