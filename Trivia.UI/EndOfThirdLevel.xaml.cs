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
        public EndOfThirdLevel(int pointsPlayer, string playerName)
        {
            InitializeComponent();
            engine = Engine.Instance;
            pPoints.Text = pointsPlayer.ToString();
            pNameTB.Text = playerName;
        }
    }
}
