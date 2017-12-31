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
using Trivia.Contracts;
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
        static IList<IQuestion> normalQuestions;
        static int countQuestions = 0;
        static bool answerA;
        static bool answerB;
        static bool answerC;
        static bool answerD;
        static NormalPlayer currentPlayer;

        public PlayerSecondLevelPage(IEngine engine)
        {
            InitializeComponent();
            playerName = engine.Player.Name;
            currentPlayer = (NormalPlayer)engine.Player;
            pNameTB.Text = playerName;
            pointsPlayer = currentPlayer.Points;
            pPoints.Text = pointsPlayer.ToString();
            normalQuestions = engine.NormalQuestions;

            DisplayTextForQuestionAndAnswers(normalQuestions, countQuestions);
        }

        private void DisplayTextForQuestionAndAnswers(IList<IQuestion> normalQuestions, int countQuestions)
        {
            displayQuestion.Text = normalQuestions[countQuestions].QuestionText;

            displayAnswerA.Content = normalQuestions[countQuestions].Answers[0].ToString();
            displayAnswerB.Content = normalQuestions[countQuestions].Answers[1].ToString();
            displayAnswerC.Content = normalQuestions[countQuestions].Answers[2].ToString();
            displayAnswerD.Content = normalQuestions[countQuestions].Answers[3].ToString();
        }

        private void AnswerAButton(object sender, RoutedEventArgs e)
        {
            answerA = normalQuestions[countQuestions].Answers[0].IsCorrect;
            if (answerA)
            {
                currentPlayer.Points += 200;
                correctAnswer.Visibility = Visibility.Visible;
                wrongAnswer.Visibility = Visibility.Collapsed;
                pPoints.Text = currentPlayer.Points.ToString();
            }
            else
            {
                correctAnswer.Visibility = Visibility.Collapsed;
                wrongAnswer.Visibility = Visibility.Visible;
            }
            countQuestions++;
            if (countQuestions > normalQuestions.Count - 1)
            {
                EndOfSecondLevelPage endOfSecondLevelPage = new EndOfSecondLevelPage(currentPlayer.Points, playerName);
                this.NavigationService.Navigate(endOfSecondLevelPage);
            }
            else
            {
                DisplayTextForQuestionAndAnswers(normalQuestions, countQuestions);
            }
        }

        private void AnswerBButton(object sender, RoutedEventArgs e)
        {
            answerB = normalQuestions[countQuestions].Answers[1].IsCorrect;
            if (answerB)
            {
                currentPlayer.Points += 200;
                correctAnswer.Visibility = Visibility.Visible;
                wrongAnswer.Visibility = Visibility.Collapsed;
                pPoints.Text = currentPlayer.Points.ToString();
            }
            else
            {
                correctAnswer.Visibility = Visibility.Collapsed;
                wrongAnswer.Visibility = Visibility.Visible;
            }
            countQuestions++;
            if (countQuestions > normalQuestions.Count - 1)
            {
                EndOfSecondLevelPage endOfSecondLevelPage = new EndOfSecondLevelPage(currentPlayer.Points, playerName);
                this.NavigationService.Navigate(endOfSecondLevelPage);
            }
            else
            {
                DisplayTextForQuestionAndAnswers(normalQuestions, countQuestions);
            }
        }

        private void AnswerCButton(object sender, RoutedEventArgs e)
        {
            answerC = normalQuestions[countQuestions].Answers[2].IsCorrect;
            if (answerC)
            {
                currentPlayer.Points += 200;
                correctAnswer.Visibility = Visibility.Visible;
                wrongAnswer.Visibility = Visibility.Collapsed;
                pPoints.Text = currentPlayer.Points.ToString();
            }
            else
            {
                correctAnswer.Visibility = Visibility.Collapsed;
                wrongAnswer.Visibility = Visibility.Visible;
            }
            countQuestions++;
            if (countQuestions > normalQuestions.Count - 1)
            {
                EndOfSecondLevelPage endOfSecondLevelPage = new EndOfSecondLevelPage(currentPlayer.Points, playerName);
                this.NavigationService.Navigate(endOfSecondLevelPage);
            }
            else
            {
                DisplayTextForQuestionAndAnswers(normalQuestions, countQuestions);
            }
        }

        private void AnswerDButton(object sender, RoutedEventArgs e)
        {
            answerD = normalQuestions[countQuestions].Answers[3].IsCorrect;
            if (answerD)
            {
                currentPlayer.Points += 200;
                correctAnswer.Visibility = Visibility.Visible;
                wrongAnswer.Visibility = Visibility.Collapsed;
                pPoints.Text = currentPlayer.Points.ToString();
            }
            else
            {
                correctAnswer.Visibility = Visibility.Collapsed;
                wrongAnswer.Visibility = Visibility.Visible;
            }
            countQuestions++;
            if (countQuestions > normalQuestions.Count - 1)
            {
                EndOfSecondLevelPage endOfSecondLevelPage = new EndOfSecondLevelPage(currentPlayer.Points, playerName);
                this.NavigationService.Navigate(endOfSecondLevelPage);
            }
            else
            {
                DisplayTextForQuestionAndAnswers(normalQuestions, countQuestions);
            }
        }
    }
}
