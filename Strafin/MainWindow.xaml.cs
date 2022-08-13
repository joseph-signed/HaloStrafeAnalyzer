using System.Windows;
using System.Windows.Input;

namespace Strafin
{

    public partial class MainWindow : Window
    {   
        public MainWindow()
        {
            InitializeComponent();

            CommandBindings.Add(new CommandBinding(ApplicationCommands.Close,
                new ExecutedRoutedEventHandler(delegate (object sender, ExecutedRoutedEventArgs args) { this.Close(); })));
        }

        private void DragWindow(object sender, MouseButtonEventArgs args)
        {
            DragMove();
        }

        private void btn_LeftStick_Big_Click(object sender, RoutedEventArgs e)
        {
            if (LargeLeft._open == false)
            {
                LargeLeft win = new LargeLeft();
                win.Show();
                LargeLeft._open = true;
            }
            else
            {
                MessageBox.Show("Window is already opened");
            }
        }

        private void btn_LeftStick_Small_Click(object sender, RoutedEventArgs e)
        {
            if (SmallLeft._open == false)
            {
                SmallLeft win = new SmallLeft();
                win.Show();
                SmallLeft._open = true;
            }
            else
            {
                MessageBox.Show("Window is already opened");
            }
        }

        private void btn_RightStick_Small_Click(object sender, RoutedEventArgs e)
        {
            if (SmallRight._open == false)
            {
                SmallRight win = new SmallRight();
                win.Show();
                SmallRight._open = true;
            }
            else
            {
                MessageBox.Show("Window is already opened");
            }
        }

        private void btn_RightStick_Big_Click(object sender, RoutedEventArgs e)
        {
            if (LargeRight._open == false)
            {
                LargeRight win = new LargeRight();
                win.Show();
                LargeRight._open = true;
            }
            else
            {
                MessageBox.Show("Window is already opened");
            }
        }
    }
}



