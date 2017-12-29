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
using Trivia.Contracts;
using Trivia.Core.Contracts;
using Trivia.Models.Category;

namespace Trivia.UI
{
    /// <summary>
    /// Interaction logic for PlayerFirstLevelPage.xaml
    /// </summary>
    public partial class PlayerFirstLevelPage : Page
    {
        string playerName;
        public PlayerFirstLevelPage(IEngine engine)
        {
            InitializeComponent();

            playerName = engine.Player.Name;
            NormalPlayer currentPlayer = (NormalPlayer)engine.Player;
            int pointsPlayer = currentPlayer.Points;
            pNameTB.Text = playerName;
            pPoints.Text = pointsPlayer.ToString();
            var easyQuestions = engine.EasyQuestions;

            foreach (var question in easyQuestions)
            {
                displayQuestion.Text = question.QuestionText;
                
                displayAnswerA.Content = question.Answers[0].ToString();
                displayAnswerB.Content = question.Answers[1].ToString();
                displayAnswerC.Content = question.Answers[2].ToString();
                displayAnswerD.Content = question.Answers[3].ToString();
                //Button button = new Button(); 
                //button.Content = question.Answers[0].ToString();
                //displayAnswer.Content = question.Answers[0].ToString();

            }
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
