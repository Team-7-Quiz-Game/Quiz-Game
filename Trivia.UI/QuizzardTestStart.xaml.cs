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
using System.Windows.Threading;
using Trivia.Common.Enums;
using Trivia.Common.Utils;
using Trivia.Contracts;
using Trivia.Core;
using Trivia.Core.Contracts;
using Trivia.Models.Question;

namespace Trivia.UI
{
    /// <summary>
    /// Interaction logic for StartQuizzardTest.xaml
    /// </summary>
    public partial class QuizzardTestStart : Page
    {
        private IEngine engine;
        private static bool answerA;
        private static bool answerB;
        private static bool answerC;
        private static bool answerD;
        private static int countQuestions = 0;
        private static int points;
        private int timer;
        private DispatcherTimer dispatcherTimer;

        public QuizzardTestStart()
        {
            InitializeComponent();
            this.engine = Engine.Instance;

            engine.QuizzardQuestions.Shuffle();

            foreach (var question in engine.QuizzardQuestions)
            {
                question.ShuffleAnswers();
            }

            DisplayTextForQuestionAndAnswers(engine.QuizzardQuestions, countQuestions);
            DisplayQuestionType();
        }

        private void DisplayQuestionType()
        {
            switch (engine.QuizzardQuestions[countQuestions].QuestionType)
            {
                case QuestionType.Normal:
                    BonusType.Visibility = Visibility.Hidden;
                    BonusPoints.Visibility = Visibility.Hidden;
                    TimeType.Visibility = Visibility.Hidden;
                    SecondsTimer.Visibility = Visibility.Hidden;
                    break;
                case QuestionType.Timed:
                    TimeType.Visibility = Visibility.Visible;
                    SecondsTimer.Visibility = Visibility.Visible;

                     TimedQuestion timeQuestion = engine.QuizzardQuestions[countQuestions] as TimedQuestion;
                    this.timer = timeQuestion.Time;
                    SecondsTimer.Text = this.timer.ToString();

                    this.dispatcherTimer = new DispatcherTimer();
                    this.dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                    this.dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                    this.dispatcherTimer.Start();

                    BonusType.Visibility = Visibility.Hidden;
                    BonusPoints.Visibility = Visibility.Hidden;
                    break;
                case QuestionType.Bonus:
                    BonusType.Visibility = Visibility.Visible;
                    BonusQuestion bonusQuestion = engine.QuizzardQuestions[countQuestions] as BonusQuestion;
                    BonusPoints.Text = $"x{bonusQuestion.PointsMultiplier}";
                    BonusPoints.Visibility = Visibility.Visible;

                    TimeType.Visibility = Visibility.Hidden;
                    SecondsTimer.Visibility = Visibility.Hidden;
                    break;
                default:
                    break;
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            --this.timer;
            SecondsTimer.Text = this.timer.ToString();
            if (this.timer <= 0)
            {
                this.dispatcherTimer.Stop();
                countQuestions++;

                correctAnswer.Visibility = Visibility.Collapsed;
                wrongAnswer.Visibility = Visibility.Visible;

                if (countQuestions > engine.QuizzardQuestions.Count - 1)
                {
                    QuizzardEndPage endOfQuizzardTest = new QuizzardEndPage(points);
                    this.NavigationService.Navigate(endOfQuizzardTest);
                }
                else
                {
                    DisplayQuestionType();
                    DisplayTextForQuestionAndAnswers(engine.QuizzardQuestions, countQuestions);
                }
            }
        }

        // The buttons will be binded with the answers from the list. Upon clicking on a button
        private void AnswerAButton(object sender, RoutedEventArgs e)
        {
            answerA = engine.QuizzardQuestions[countQuestions].Answers[0].IsCorrect;

            if (answerA)
            {
                points += engine.QuizzardQuestions[countQuestions].Points;
                correctAnswer.Visibility = Visibility.Visible;
                wrongAnswer.Visibility = Visibility.Collapsed;
                pPoints.Text = points.ToString();
            }
            else
            {
                correctAnswer.Visibility = Visibility.Collapsed;
                wrongAnswer.Visibility = Visibility.Visible;
            }

            countQuestions++;

            if (countQuestions > engine.QuizzardQuestions.Count - 1)
            {
                QuizzardEndPage endOfQuizzardTest = new QuizzardEndPage(points);
                this.NavigationService.Navigate(endOfQuizzardTest);
            }
            else
            {
                DisplayQuestionType();
                DisplayTextForQuestionAndAnswers(engine.QuizzardQuestions, countQuestions);
            }
        }
        private void AnswerBButton(object sender, RoutedEventArgs e)
        {
            answerB = engine.QuizzardQuestions[countQuestions].Answers[1].IsCorrect;

            if (answerB)
            {
                points += engine.QuizzardQuestions[countQuestions].Points;
                correctAnswer.Visibility = Visibility.Visible;
                wrongAnswer.Visibility = Visibility.Collapsed;
                pPoints.Text = points.ToString();
            }
            else
            {
                correctAnswer.Visibility = Visibility.Collapsed;
                wrongAnswer.Visibility = Visibility.Visible;
            }

            countQuestions++;

            if (countQuestions > engine.QuizzardQuestions.Count - 1)
            {
                QuizzardEndPage endOfQuizzardTest = new QuizzardEndPage(points);
                this.NavigationService.Navigate(endOfQuizzardTest);
            }
            else
            {
                DisplayQuestionType();
                DisplayTextForQuestionAndAnswers(engine.QuizzardQuestions, countQuestions);
            }
        }

        private void AnswerCButton(object sender, RoutedEventArgs e)
        {
            answerC = engine.QuizzardQuestions[countQuestions].Answers[2].IsCorrect;

            if (answerC)
            {
                points += engine.QuizzardQuestions[countQuestions].Points;
                correctAnswer.Visibility = Visibility.Visible;
                wrongAnswer.Visibility = Visibility.Collapsed;
                pPoints.Text = points.ToString();
            }
            else
            {
                correctAnswer.Visibility = Visibility.Collapsed;
                wrongAnswer.Visibility = Visibility.Visible;
            }

            countQuestions++;

            if (countQuestions > engine.QuizzardQuestions.Count - 1)
            {
                QuizzardEndPage endOfQuizzardTest = new QuizzardEndPage(points);
                this.NavigationService.Navigate(endOfQuizzardTest);
            }
            else
            {
                DisplayQuestionType();
                DisplayTextForQuestionAndAnswers(engine.QuizzardQuestions, countQuestions);
            }
        }

        private void AnswerDButton(object sender, RoutedEventArgs e)
        {
            answerD = engine.QuizzardQuestions[countQuestions].Answers[3].IsCorrect;

            if (answerD)
            {
                points += engine.QuizzardQuestions[countQuestions].Points;
                correctAnswer.Visibility = Visibility.Visible;
                wrongAnswer.Visibility = Visibility.Collapsed;
                pPoints.Text = points.ToString();
            }
            else
            {
                correctAnswer.Visibility = Visibility.Collapsed;
                wrongAnswer.Visibility = Visibility.Visible;
            }

            countQuestions++;

            if (countQuestions > engine.QuizzardQuestions.Count - 1)
            {
                QuizzardEndPage endOfQuizzardTest = new QuizzardEndPage(points);
                this.NavigationService.Navigate(endOfQuizzardTest);
            }
            else
            {
                DisplayQuestionType();
                DisplayTextForQuestionAndAnswers(engine.QuizzardQuestions, countQuestions);
            }
        }

        private void DisplayTextForQuestionAndAnswers(IList<IQuestion> quizzardQuestions, int countQuestions)
        {
            QuestionText.Text = engine.QuizzardQuestions[countQuestions].QuestionText;
            AnswerA.Content = engine.QuizzardQuestions[countQuestions].Answers[0];
            AnswerB.Content = engine.QuizzardQuestions[countQuestions].Answers[1];
            AnswerC.Content = engine.QuizzardQuestions[countQuestions].Answers[2];
            AnswerD.Content = engine.QuizzardQuestions[countQuestions].Answers[3];
        }
    }
}
