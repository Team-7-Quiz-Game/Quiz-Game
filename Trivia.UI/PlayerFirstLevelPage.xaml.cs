using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Trivia.Contracts;
using Trivia.Core;
using Trivia.Core.Contracts;
using Trivia.Models.Player;

namespace Trivia.UI
{
    /// <summary>
    /// Interaction logic for PlayerFirstLevelPage.xaml
    /// </summary>
    public partial class PlayerFirstLevelPage : Page
    {
        private IEngine engine;
        private string playerName;
        private static bool answerA;
        private static bool answerB;
        private static bool answerC;
        private static bool answerD;
        private static int pointsPlayer;
        private static IList<IQuestion> easyQuestions;
        private static int countQuestions = 0;
        private static NormalPlayer currentPlayer;

        public PlayerFirstLevelPage(IEngine engine)
        {
            InitializeComponent();

            this.engine = Engine.Instance;
            playerName = engine.Player.Name;
            currentPlayer = (NormalPlayer)engine.Player;
            pointsPlayer = currentPlayer.Points;
            pNameTB.Text = playerName;
            pPoints.Text = pointsPlayer.ToString();
            easyQuestions = engine.EasyQuestions;
            
            DisplayHints();
            DisplayTextForQuestionAndAnswers(easyQuestions, countQuestions);
        }

        private void AnswerAButton(object sender, RoutedEventArgs e)
        {
            answerA = easyQuestions[countQuestions].Answers[0].IsCorrect;

            if (answerA)
            {
                TakeActionsUponCorrectAnswer();
            }
            else
            {
                TakeActionsUponWrongAnswer();
            }

            DisplayHints();
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
                TakeActionsUponCorrectAnswer();
            }
            else
            {
                TakeActionsUponWrongAnswer();
            }

            DisplayHints();
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
                TakeActionsUponCorrectAnswer();
            }
            else
            {
                TakeActionsUponWrongAnswer();
            }

            DisplayHints();
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
                TakeActionsUponCorrectAnswer();
            }
            else
            {
                TakeActionsUponWrongAnswer();
            }

            DisplayHints();
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

            displayAnswerA.IsEnabled = true;
            displayAnswerB.IsEnabled = true;
            displayAnswerC.IsEnabled = true;
            displayAnswerD.IsEnabled = true;

            displayAnswerA.Content = easyQuestions[countQuestions].Answers[0].ToString();
            displayAnswerB.Content = easyQuestions[countQuestions].Answers[1].ToString();
            displayAnswerC.Content = easyQuestions[countQuestions].Answers[2].ToString();
            displayAnswerD.Content = easyQuestions[countQuestions].Answers[3].ToString();
        }

        private void TakeActionsUponCorrectAnswer()
        {
            currentPlayer.Points += easyQuestions[countQuestions].Points;
            correctAnswer.Visibility = Visibility.Visible;
            skippedAnswer.Visibility = Visibility.Collapsed;
            wrongAnswer.Visibility = Visibility.Collapsed;
            pPoints.Text = currentPlayer.Points.ToString();
        }

        private void TakeActionsUponWrongAnswer()
        {
            correctAnswer.Visibility = Visibility.Collapsed;
            wrongAnswer.Visibility = Visibility.Visible;
            skippedAnswer.Visibility = Visibility.Collapsed;
        }

        private void Hint5050Button(object sender, RoutedEventArgs e)
        {
            this.engine.FiftyFiftyHint.Quantity--;

            Random rnd = new Random();
            int counter = 0;
            int[] uniqueIndices = new int[2];

            while (counter < 2)
            {
                int rNext = rnd.Next(easyQuestions[countQuestions].Answers.Count);

                if (!easyQuestions[countQuestions].Answers[rNext].IsCorrect && !uniqueIndices.Contains(rNext))
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

            currentPlayer.Points += easyQuestions[countQuestions].Points;
            pPoints.Text = currentPlayer.Points.ToString();

            DisplayHints();
            countQuestions++;
            skippedAnswer.Visibility = Visibility.Visible;
            correctAnswer.Visibility = Visibility.Collapsed;
            wrongAnswer.Visibility = Visibility.Collapsed;

            if (countQuestions > easyQuestions.Count - 1)
            {
                EndOfFirstLevelPage endOfFirstLevelPage = new EndOfFirstLevelPage(currentPlayer.Points, playerName);
                this.NavigationService.Navigate(endOfFirstLevelPage);
            }
            else
            {
                DisplayTextForQuestionAndAnswers(easyQuestions, countQuestions);
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
