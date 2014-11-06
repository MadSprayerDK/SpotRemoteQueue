using System.Windows;

namespace SpotRemoteQueue
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Spotify.Spotify _spotify = null;

        public MainWindow()
        {
            InitializeComponent();
            _spotify = new Spotify.Spotify();
        }


        private void Login_Button_OnClick(object sender, RoutedEventArgs e)
        {
            _spotify.PlaySong("SomeStuff");
        }
    }
}
