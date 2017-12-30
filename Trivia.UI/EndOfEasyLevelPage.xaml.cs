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
    /// Interaction logic for EndOfEasyLevelPage.xaml
    /// </summary>
    public partial class EndOfEasyLevelPage : Page
    {
        public EndOfEasyLevelPage(int pointsPlayer)
        {
            InitializeComponent();
            pPoints.Text = pointsPlayer.ToString();
        }

        private void ContinueButton(object sender, RoutedEventArgs e)
        {

        }
    }
}
