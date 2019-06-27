using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Minimized;
            }
            else if (this.WindowState == WindowState.Minimized)
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void TopBarGrid_Loaded(object sender, RoutedEventArgs e)
        {

            Thread randomImageThread = new Thread(() =>
            {

                Random rng = new Random();

                while (true)
                {
                    
                    UpdateImageSource($"https://picsum.photos/100/32?random={rng.Next(0,100)}");

                    
                    Thread.Sleep(2500);
                }

            });

            randomImageThread.Start();


        }

        private delegate void StringArgReturningVoidDelegate(string str);

        private void UpdateImageSource(string source)
        {
            if (!Dispatcher.CheckAccess()) // CheckAccess returns true if you're on the dispatcher thread
            {
                Dispatcher.Invoke(new StringArgReturningVoidDelegate(UpdateImageSource), source);
                return;
            }
            RandomImage.Source = new BitmapImage(new Uri(source));
        }

        


    }
}
