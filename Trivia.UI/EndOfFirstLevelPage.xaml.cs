using System.Windows;
using System.Windows.Controls;
using Trivia.Core;
using Trivia.Core.Contracts;

namespace Trivia.UI
{
    /// <summary>
    /// Interaction logic for EndOfEasyLevelPage.xaml
    /// </summary>
    public partial class EndOfFirstLevelPage : Page
    {
        private IEngine engine;
        public EndOfFirstLevelPage(int pointsPlayer, string playerName)
        {
            InitializeComponent();
            engine = Engine.Instance;
            pPoints.Text = pointsPlayer.ToString();
            pNameTB.Text = playerName;
        }

        private void ContinueButton(object sender, RoutedEventArgs e)
        {
            PlayerSecondLevelPage playerSecondLevelPage = new PlayerSecondLevelPage(this.engine);
            this.NavigationService.Navigate(playerSecondLevelPage);
        }
    }
}
