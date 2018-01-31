using System.Windows;
using System.Windows.Controls;

namespace Trivia.UI
{
    /// <summary>
    /// Interaction logic for GameStart.xaml
    /// </summary>
    public partial class GameStart : Page
    {        
        public GameStart()
        {
            InitializeComponent();
        }
        private void StartGameButton(object sender, RoutedEventArgs e)
        {       
            // Go to Choose A Player Mode
            PlayerMode playerMode = new PlayerMode();
            this.NavigationService.Navigate(playerMode);
        }
    }
}
