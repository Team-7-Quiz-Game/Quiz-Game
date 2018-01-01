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
    /// Interaction logic for PlayerThirdLevelPage.xaml
    /// </summary>
    public partial class PlayerThirdLevelPage : Page
    {
        string playerName;
        static bool answerA;
        static bool answerB;
        static bool answerC;
        static bool answerD;
        static int pointsPlayer;
        static IList<IQuestion> hardQuestions;
        static int countQuestions = 0;
        static NormalPlayer currentPlayer;
        public PlayerThirdLevelPage(IEngine engine)
        {
            InitializeComponent();

            playerName = engine.Player.Name;
            currentPlayer = (NormalPlayer)engine.Player;
            pointsPlayer = currentPlayer.Points;
            pNameTB.Text = playerName;
            pPoints.Text = pointsPlayer.ToString();
            hardQuestions = engine.HardQuestions;

            DisplayTextForQuestionAndAnswers(hardQuestions, countQuestions);
        }

        private void AnswerAButton(object sender, RoutedEventArgs e)
        {
            answerA = hardQuestions[countQuestions].Answers[0].IsCorrect;
            if (answerA)
            {
                currentPlayer.Points += 300;
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
            if (countQuestions > hardQuestions.Count - 1)
            {
                EndOfThirdLevel endOfThirdLevelPage = new EndOfThirdLevel(currentPlayer.Points, playerName);
                this.NavigationService.Navigate(endOfThirdLevelPage);
            }
            else
            {
                DisplayTextForQuestionAndAnswers(hardQuestions, countQuestions);
            }
        }

        private void AnswerBButton(object sender, RoutedEventArgs e)
        {
            answerB = hardQuestions[countQuestions].Answers[1].IsCorrect;

            if (answerB)
            {
                currentPlayer.Points += 300;
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
            if (countQuestions > hardQuestions.Count - 1)
            {
                EndOfThirdLevel endOfThirdLevelPage = new EndOfThirdLevel(currentPlayer.Points, playerName);
                this.NavigationService.Navigate(endOfThirdLevelPage);
            }
            else
            {
                DisplayTextForQuestionAndAnswers(hardQuestions, countQuestions);
            }
        }

        private void AnswerCButton(object sender, RoutedEventArgs e)
        {
            answerC = hardQuestions[countQuestions].Answers[2].IsCorrect;
            if (answerC)
            {
                currentPlayer.Points += 300;
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
            if (countQuestions > hardQuestions.Count - 1)
            {
                EndOfThirdLevel endOfThirdLevelPage = new EndOfThirdLevel(currentPlayer.Points, playerName);
                this.NavigationService.Navigate(endOfThirdLevelPage);
            }
            else
            {
                DisplayTextForQuestionAndAnswers(hardQuestions, countQuestions);
            }
        }

        private void AnswerDButton(object sender, RoutedEventArgs e)
        {
            answerD = hardQuestions[countQuestions].Answers[3].IsCorrect;
            if (answerD)
            {
                currentPlayer.Points += 300;
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
            if (countQuestions > hardQuestions.Count - 1)
            {
                EndOfThirdLevel endOfThirdLevelPage = new EndOfThirdLevel(currentPlayer.Points, playerName);
                this.NavigationService.Navigate(endOfThirdLevelPage);
            }
            else
            {
                DisplayTextForQuestionAndAnswers(hardQuestions, countQuestions);
            }
        }
        private void DisplayTextForQuestionAndAnswers(IList<IQuestion> hardQuestions, int countQuestions)
        {
            displayQuestion.Text = hardQuestions[countQuestions].QuestionText;

            displayAnswerA.Content = hardQuestions[countQuestions].Answers[0].ToString();
            displayAnswerB.Content = hardQuestions[countQuestions].Answers[1].ToString();
            displayAnswerC.Content = hardQuestions[countQuestions].Answers[2].ToString();
            displayAnswerD.Content = hardQuestions[countQuestions].Answers[3].ToString();
        }

        private void Hint5050Button(object sender, RoutedEventArgs e)
        {

        }

        private void SkipQuestionButton(object sender, RoutedEventArgs e)
        {

        }
    }
}
