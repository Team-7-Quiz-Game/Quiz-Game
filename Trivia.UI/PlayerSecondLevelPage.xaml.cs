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
using Trivia.Core;
using Trivia.Core.Contracts;
using Trivia.Models.Player;

namespace Trivia.UI
{
    /// <summary>
    /// Interaction logic for PlayerSecondLevelPage.xaml
    /// </summary>
    public partial class PlayerSecondLevelPage : Page
    {
        private IEngine engine;
        private string playerName;
        private static int pointsPlayer;
        private static IList<IQuestion> normalQuestions;
        private static int countQuestions = 0;
        private static bool answerA;
        private static bool answerB;
        private static bool answerC;
        private static bool answerD;
        static NormalPlayer currentPlayer;

        public PlayerSecondLevelPage(IEngine engine)
        {
            InitializeComponent();

            this.engine = Engine.Instance;
            playerName = engine.Player.Name;
            currentPlayer = (NormalPlayer)engine.Player;
            pNameTB.Text = playerName;
            pointsPlayer = currentPlayer.Points;
            pPoints.Text = pointsPlayer.ToString();
            normalQuestions = engine.NormalQuestions;

            DisplayTextForQuestionAndAnswers(normalQuestions, countQuestions);
            DisplayHints();
        }

        private void DisplayTextForQuestionAndAnswers(IList<IQuestion> normalQuestions, int countQuestions)
        {
            displayQuestion.Text = normalQuestions[countQuestions].QuestionText;

            displayAnswerA.IsEnabled = true;
            displayAnswerB.IsEnabled = true;
            displayAnswerC.IsEnabled = true;
            displayAnswerD.IsEnabled = true;

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
                currentPlayer.Points += normalQuestions[countQuestions].Points;
                correctAnswer.Visibility = Visibility.Visible;
                skippedAnswer.Visibility = Visibility.Collapsed;
                wrongAnswer.Visibility = Visibility.Collapsed;
                pPoints.Text = currentPlayer.Points.ToString();
            }
            else
            {
                correctAnswer.Visibility = Visibility.Collapsed;
                skippedAnswer.Visibility = Visibility.Collapsed;
                wrongAnswer.Visibility = Visibility.Visible;
            }

            DisplayHints();
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
                currentPlayer.Points += normalQuestions[countQuestions].Points;
                correctAnswer.Visibility = Visibility.Visible;
                skippedAnswer.Visibility = Visibility.Collapsed;
                wrongAnswer.Visibility = Visibility.Collapsed;
                pPoints.Text = currentPlayer.Points.ToString();
            }
            else
            {
                correctAnswer.Visibility = Visibility.Collapsed;
                skippedAnswer.Visibility = Visibility.Collapsed;
                wrongAnswer.Visibility = Visibility.Visible;
            }

            DisplayHints();
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
                currentPlayer.Points += normalQuestions[countQuestions].Points;
                correctAnswer.Visibility = Visibility.Visible;
                skippedAnswer.Visibility = Visibility.Collapsed;
                wrongAnswer.Visibility = Visibility.Collapsed;
                pPoints.Text = currentPlayer.Points.ToString();
            }
            else
            {
                correctAnswer.Visibility = Visibility.Collapsed;
                skippedAnswer.Visibility = Visibility.Collapsed;
                wrongAnswer.Visibility = Visibility.Visible;
            }

            DisplayHints();
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
                currentPlayer.Points += normalQuestions[countQuestions].Points;
                correctAnswer.Visibility = Visibility.Visible;
                wrongAnswer.Visibility = Visibility.Collapsed;
                skippedAnswer.Visibility = Visibility.Collapsed;
                pPoints.Text = currentPlayer.Points.ToString();
            }
            else
            {
                correctAnswer.Visibility = Visibility.Collapsed;
                wrongAnswer.Visibility = Visibility.Visible;
                skippedAnswer.Visibility = Visibility.Collapsed;
            }

            DisplayHints();
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

        private void Hint5050Button(object sender, RoutedEventArgs e)
        {
            this.engine.FiftyFiftyHint.Quantity--;

            Random rnd = new Random();
            int counter = 0;
            int[] uniqueIndices = new int[2];

            while (counter < 2)
            {
                int rNext = rnd.Next(normalQuestions[countQuestions].Answers.Count);

                if (!normalQuestions[countQuestions].Answers[rNext].IsCorrect && !uniqueIndices.Contains(rNext))
                {
                    uniqueIndices[counter] = rNext;
                    counter++;

                    switch (rNext)
                    {
                        case 0:
                            displayAnswerA.IsEnabled = false;
                            break;
                        case 1:
                            displayAnswerB.IsEnabled = false;
                            break;
                        case 2:
                            displayAnswerC.IsEnabled = false;
                            break;
                        case 3:
                            displayAnswerD.IsEnabled = false;
                            break;
                        default: throw new ArgumentException("Invalid answer index!");
                    }
                }
            }

            FiftyBtn.IsEnabled = false;
            DisplayHints(false);
        }

        private void SkipQuestionButton(object sender, RoutedEventArgs e)
        {
            this.engine.SkipQuestionHint.Quantity--;

            currentPlayer.Points += normalQuestions[countQuestions].Points;
            pPoints.Text = currentPlayer.Points.ToString();
            DisplayHints();
            countQuestions++;
            skippedAnswer.Visibility = Visibility.Visible;
            correctAnswer.Visibility = Visibility.Collapsed;
            wrongAnswer.Visibility = Visibility.Collapsed;

            if (countQuestions > normalQuestions.Count - 1)
            {
                EndOfSecondLevelPage endOfSecondLevelPage = new EndOfSecondLevelPage(currentPlayer.Points, playerName);
                this.NavigationService.Navigate(endOfSecondLevelPage);
            }
            else
            {
                DisplayTextForQuestionAndAnswers(normalQuestions, countQuestions);
            }

            DisplayHints();
        }

        private void DisplayHints(bool fiftyIsEnabled = true)
        {
            HintSkipQuestion.Text = this.engine.SkipQuestionHint.Quantity.ToString();
            Hint5050.Text = this.engine.FiftyFiftyHint.Quantity.ToString();

            if (this.engine.SkipQuestionHint.Quantity == 0)
            {
                SkipBtn.IsEnabled = false;
            }

            if (this.engine.FiftyFiftyHint.Quantity == 0)
            {
                FiftyBtn.IsEnabled = false;
                fiftyIsEnabled = false;
            }

            if (fiftyIsEnabled)
            {
                FiftyBtn.IsEnabled = true;
            }
        }
    }
}
