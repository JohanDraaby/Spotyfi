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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Spotyfi.ViewModel;

namespace Spotyfi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*spotyfiEntities _entities = new spotyfiEntities();
            var artist = _entities.artists.Find(1);
            var album = _entities.albums.Find(1);
            var song = _entities.songs.Find(1);

            MessageBox.Show(artist?.ToString());
            MessageBox.Show(album?.ToString());
            MessageBox.Show(song?.ToString());*/



        }

        private void TopBarGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void ButtonPlay_Click(object sender, RoutedEventArgs e)
        {
            // TODO this feels dirty?
            var mwvm = (MainWindowViewModel) this.DataContext;
            mwvm.IsPlaying = !mwvm.IsPlaying;
        }
    }
}
