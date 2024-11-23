using DesktopApp.Views;
using System.Windows;

namespace DesktopApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LoadLoginView();
        }

        private void LoadLoginView()
        {
            LoginView view = new LoginView(this);
            MainFrame.Content = view;
        }
    }
}