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
using Trivia.Core.Contracts;

namespace Trivia.UI
{
    /// <summary>
    /// Interaction logic for GameStart.xaml
    /// </summary>
    public partial class GameStart : Page
    {
        IEngine engine;
        public GameStart()
        {
            InitializeComponent();
        }
        private void StartGameButton(object sender, RoutedEventArgs e)
        {
            // Upon clicking on the start button, the game engline starts
           
            // Go to Choose A Player Mode
            PlayerMode playerMode = new PlayerMode();
            this.NavigationService.Navigate(playerMode);
        }
    }
}
