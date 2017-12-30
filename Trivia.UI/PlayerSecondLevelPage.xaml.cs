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
using Trivia.Models.Player;

namespace Trivia.UI
{
    /// <summary>
    /// Interaction logic for PlayerSecondLevelPage.xaml
    /// </summary>
    public partial class PlayerSecondLevelPage : Page
    {
        string playerName;
        static int pointsPlayer;
        public PlayerSecondLevelPage(IEngine engine)
        {
            InitializeComponent();
            playerName = engine.Player.Name;
            NormalPlayer currentPlayer = (NormalPlayer)engine.Player;
            pNameTB.Text = playerName;
            pointsPlayer = currentPlayer.Points;
            pPoints.Text = pointsPlayer.ToString();
        }
    }
}
