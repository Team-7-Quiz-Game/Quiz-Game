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
using Trivia.Core;
using Trivia.Models.Question;

namespace Trivia.UI
{
    /// <summary>
    /// Interaction logic for PlayerFirstLevelPage.xaml
    /// </summary>
    public partial class PlayerFirstLevelPage : Page
    {
        string playerName;
        static bool answerA;
        static bool answerB;
        static bool answerC;
        static bool answerD;
        static int pointsPlayer;
        static IList<IQuestion> easyQuestions;
        static int countQuestions = 0;
        static NormalPlayer currentPlayer;

        public PlayerFirstLevelPage(IEngine engine)
        {
            InitializeComponent();

            playerName = engine.Player.Name;
            currentPlayer = (NormalPlayer)engine.Player;
            pointsPlayer = currentPlayer.Points;
            pNameTB.Text = playerName;
            pPoints.Text = pointsPlayer.ToString();
            easyQuestions = engine.EasyQuestions;

            DisplayTextForQuestionAndAnswers(easyQuestions, countQuestions);
        }

        private void AnswerAButton(object sender, RoutedEventArgs e)
        {
            answerA = easyQuestions[countQuestions].Answers[0].IsCorrect;
            if (answerA)
            {
                currentPlayer.Points += 100;
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
            if (countQuestions > easyQuestions.Count - 1)
            {
                EndOfFirstLevelPage endOfFirstLevelPage = new EndOfFirstLevelPage(currentPlayer.Points, playerName);
                this.NavigationService.Navigate(endOfFirstLevelPage);
            }
            else
            {
                DisplayTextForQuestionAndAnswers(easyQuestions, countQuestions);
            }
        }

        private void AnswerBButton(object sender, RoutedEventArgs e)
        {
            answerB = easyQuestions[countQuestions].Answers[1].IsCorrect;
            if (answerB)
            {
                currentPlayer.Points += 100;
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
            if (countQuestions > easyQuestions.Count - 1)
            {
                EndOfFirstLevelPage endOfFirstLevelPage = new EndOfFirstLevelPage(currentPlayer.Points, playerName);
                this.NavigationService.Navigate(endOfFirstLevelPage);
            }
            else
            {
                DisplayTextForQuestionAndAnswers(easyQuestions, countQuestions);
            }

        }

        private void AnswerCButton(object sender, RoutedEventArgs e)
        {
            answerC = easyQuestions[countQuestions].Answers[2].IsCorrect;
            if (answerC)
            {
                currentPlayer.Points += 100;
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
            if (countQuestions > easyQuestions.Count - 1)
            {
                EndOfFirstLevelPage endOfFirstLevelPage = new EndOfFirstLevelPage(currentPlayer.Points, playerName);
                this.NavigationService.Navigate(endOfFirstLevelPage);
            }
            else
            {
                DisplayTextForQuestionAndAnswers(easyQuestions, countQuestions);
            }
        }

        private void AnswerDButton(object sender, RoutedEventArgs e)
        {
            answerD = easyQuestions[countQuestions].Answers[3].IsCorrect;
            if (answerD)
            {
                currentPlayer.Points += 100;
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
            if(countQuestions > easyQuestions.Count - 1)
            {
                EndOfFirstLevelPage endOfFirstLevelPage = new EndOfFirstLevelPage(currentPlayer.Points, playerName);
                this.NavigationService.Navigate(endOfFirstLevelPage);
            }
            else
            {
                DisplayTextForQuestionAndAnswers(easyQuestions, countQuestions);
            }
        }
        private void DisplayTextForQuestionAndAnswers(IList<IQuestion> easyQuestions, int countQuestions)
        {
            displayQuestion.Text = easyQuestions[countQuestions].QuestionText;

            displayAnswerA.Content = easyQuestions[countQuestions].Answers[0].ToString();
            displayAnswerB.Content = easyQuestions[countQuestions].Answers[1].ToString();
            displayAnswerC.Content = easyQuestions[countQuestions].Answers[2].ToString();
            displayAnswerD.Content = easyQuestions[countQuestions].Answers[3].ToString();
        }
    }
}
