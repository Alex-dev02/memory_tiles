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
    /// Interaction logic for OptionsMenu.xaml
    /// </summary>
    public partial class OptionsMenuView : Window
    {
        public OptionsMenuView()
        {
            InitializeComponent();
        }

        private void ValidateInput(object sender, RoutedEventArgs e)
        {
            TextBlock height = (TextBlock)FindName("Height");
            TextBlock width = (TextBlock)FindName("Width");
            if (int.Parse(height.Text) % 2 != 0 && int.Parse(width.Text) % 2 != 0)
                MessageBox.Show("Cel putin una dintre proprietati trebuie sa fie un numar par!");
            else
                Close();
        }
    }
}
