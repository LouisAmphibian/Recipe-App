using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Recipe_App__WPF_
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Method to make the window draggable
        private void WindowMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMiniize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLaunch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearchRecipe_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
