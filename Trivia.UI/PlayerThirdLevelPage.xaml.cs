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
    /// Interaction logic for PlayerThirdLevelPage.xaml
    /// </summary>
    public partial class PlayerThirdLevelPage : Page
    {
        private IEngine engine;
        private string playerName;
        private static bool answerA;
        private static bool answerB;
        private static bool answerC;
        private static bool answerD;
        private static int pointsPlayer;
        private static IList<IQuestion> hardQuestions;
        private static int countQuestions = 0;
        private static NormalPlayer currentPlayer;
        public PlayerThirdLevelPage(IEngine engine)
        {
            InitializeComponent();

            this.engine = Engine.Instance;
            playerName = engine.Player.Name;
            currentPlayer = (NormalPlayer)engine.Player;
            pointsPlayer = currentPlayer.Points;
            pNameTB.Text = playerName;
            pPoints.Text = pointsPlayer.ToString();
            hardQuestions = engine.HardQuestions;

            DisplayTextForQuestionAndAnswers(hardQuestions, countQuestions);
            DisplayHints();
        }

        private void AnswerAButton(object sender, RoutedEventArgs e)
        {
            answerA = hardQuestions[countQuestions].Answers[0].IsCorrect;

            if (answerA)
            {
                currentPlayer.Points += hardQuestions[countQuestions].Points;
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
                currentPlayer.Points += hardQuestions[countQuestions].Points;
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
                currentPlayer.Points += hardQuestions[countQuestions].Points;
                skippedAnswer.Visibility = Visibility.Collapsed;
                correctAnswer.Visibility = Visibility.Visible;
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
                currentPlayer.Points += hardQuestions[countQuestions].Points;
                correctAnswer.Visibility = Visibility.Visible;
                skippedAnswer.Visibility = Visibility.Collapsed;
                wrongAnswer.Visibility = Visibility.Collapsed;
                pPoints.Text = currentPlayer.Points.ToString();
            }
            else
            {
                skippedAnswer.Visibility = Visibility.Collapsed;
                correctAnswer.Visibility = Visibility.Collapsed;
                wrongAnswer.Visibility = Visibility.Visible;
            }

            DisplayHints();
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

            displayAnswerA.IsEnabled = true;
            displayAnswerB.IsEnabled = true;
            displayAnswerC.IsEnabled = true;
            displayAnswerD.IsEnabled = true;

            displayAnswerA.Content = hardQuestions[countQuestions].Answers[0].ToString();
            displayAnswerB.Content = hardQuestions[countQuestions].Answers[1].ToString();
            displayAnswerC.Content = hardQuestions[countQuestions].Answers[2].ToString();
            displayAnswerD.Content = hardQuestions[countQuestions].Answers[3].ToString();
        }

        private void Hint5050Button(object sender, RoutedEventArgs e)
        {
            this.engine.FiftyFiftyHint.Quantity--;

            Random rnd = new Random();
            int counter = 0;
            int[] uniqueIndices = new int[2];

            while (counter < 2)
            {
                int rNext = rnd.Next(hardQuestions[countQuestions].Answers.Count);

                if (!hardQuestions[countQuestions].Answers[rNext].IsCorrect && !uniqueIndices.Contains(rNext))
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

            currentPlayer.Points += hardQuestions[countQuestions].Points;
            pPoints.Text = currentPlayer.Points.ToString();
            DisplayHints();
            countQuestions++;
            skippedAnswer.Visibility = Visibility.Visible;
            correctAnswer.Visibility = Visibility.Collapsed;
            wrongAnswer.Visibility = Visibility.Collapsed;

            if (countQuestions > hardQuestions.Count - 1)
            {
                EndOfThirdLevel endOfThirdLevelPage = new EndOfThirdLevel(currentPlayer.Points, playerName);
                this.NavigationService.Navigate(endOfThirdLevelPage);
            }
            else
            {
                DisplayTextForQuestionAndAnswers(hardQuestions, countQuestions);
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
