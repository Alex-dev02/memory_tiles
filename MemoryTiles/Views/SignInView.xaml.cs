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

namespace MemoryTiles.Views
{
    /// <summary>
    /// Interaction logic for SignInView.xaml
    /// </summary>
    public partial class SignInView : Window
    {
        public SignInView()
        {
            InitializeComponent();
        }

        private void CloseApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void MainMenuView(object sender, RoutedEventArgs e)
        {
            MainMenuView mainMenuView = new MainMenuView();
            mainMenuView.Show();
            Close();
        }
        private void CreateUserView(object sender, RoutedEventArgs e)
        {
            CreateUserView createUserView = new CreateUserView();
            createUserView.Show();
            Close();
        }
    }
}
