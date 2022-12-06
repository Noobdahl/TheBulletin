using System.Windows;

namespace TheBulletin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SignInWindow signInWindow = new();
            signInWindow.Show();
            this.Close();
        }
    }
}
