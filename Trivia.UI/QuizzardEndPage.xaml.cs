using System.Windows.Controls;

namespace Trivia.UI
{
    /// <summary>
    /// Interaction logic for QuizzardEndPage.xaml
    /// </summary>
    public partial class QuizzardEndPage : Page
    {
        public QuizzardEndPage(int points)
        {
            InitializeComponent();
            score.Text = points.ToString();
        }
    }
}
