using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Trivia.Models.Player;
using Trivia;

namespace Trivia.UI
{
    /// <summary>
    /// Interaction logic for PlayerFirstLevelPage.xaml
    /// </summary>
    public partial class PlayerFirstLevelPage : Page
    {
        string playerName;
        public PlayerFirstLevelPage(NormalPlayer player)
        {
            InitializeComponent();

            playerName = player.Name;
            int pointsPlayer = player.Points;
            pNameTB.Text = playerName;
        }      
        private void AnswerAButton(object sender, RoutedEventArgs e)
        {
     
        }

        private void AnswerBButton(object sender, RoutedEventArgs e)
        {

        }

        private void AnswerCButton(object sender, RoutedEventArgs e)
        {

        }

        private void AnswerDButton(object sender, RoutedEventArgs e)
        {

        }
    }
}
