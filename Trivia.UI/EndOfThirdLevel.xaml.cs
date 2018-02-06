using System.Windows.Controls;
using Trivia.Core;
using Trivia.Core.Contracts;

namespace Trivia.UI
{
    /// <summary>
    /// Interaction logic for EndOfThirdLevel.xaml
    /// </summary>
    public partial class EndOfThirdLevel : Page
    {
        private IEngine engine;
        public EndOfThirdLevel(IEngine engine, int pointsPlayer, string playerName)
        {
            InitializeComponent();
            this.engine = engine;
            pPoints.Text = pointsPlayer.ToString();
            pNameTB.Text = playerName;
        }
    }
}
