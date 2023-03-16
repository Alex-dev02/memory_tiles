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
    /// Interaction logic for MainMenuView.xaml
    /// </summary>
    public partial class MainMenuView : Window
    {
        public MainMenuView()
        {
            InitializeComponent();
        }
        private void NewGameView(object sender, RoutedEventArgs e)
        {
            GameView gameView = new GameView();
            gameView.Show();
            Close();
        }
        private void StatisticsView(object sender, RoutedEventArgs e)
        {
            StatisticsView statisticsView = new StatisticsView();
            statisticsView.Show();
        }
        private void OptionsMenuView(object sender, RoutedEventArgs e)
        {
            OptionsMenuView optionsMenuView = new OptionsMenuView();
            optionsMenuView.Show();
        }
        private void HelpMessage(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Moise Ionut-Alex\n10LF212\nInformatica");
        }
        private void CloseApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
