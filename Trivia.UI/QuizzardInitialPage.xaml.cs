using System.Windows;
using System.Windows.Controls;
using Trivia.Common.Enums;
using Trivia.Common.Utils;
using Trivia.Contracts;
using Trivia.Core;
using Trivia.Core.Contracts;
using Trivia.Models.Player;

namespace Trivia.UI
{
    /// <summary>
    /// Interaction logic for QuizzardInitialPage.xaml
    /// </summary>
    public partial class QuizzardInitialPage : Page
    {
        private IEngine engine;
        private QuizzardPlayer player;
        private string questionText;
        private string answerACorrect;
        private string answerB;
        private string answerC;
        private string answerD;
        private double multiValue;
        private double timerValue;

        public QuizzardInitialPage(IEngine engine)
        {
            InitializeComponent();
            this.engine = engine;
            this.player = (QuizzardPlayer)engine.Player;
            QuestionsCount.Text = player.QuizzardQuestions.Count.ToString();
        }
        // We take the question and the four answers as strings when the Quizzard presses on the AddQuestion button
        
        private void AddQuestionButton(object sender, RoutedEventArgs e)
        {
            this.questionText = Question.Text;
            answerACorrect = AnswerA.Text; 
            answerB = AnswerB.Text;
            answerC = AnswerC.Text;
            answerD = AnswerD.Text;
            IQuestion question;

            Validator.CheckIfStringArrayHasNullOrEmpty(new string[] { questionText, answerACorrect, answerB, answerC, answerD }, "Quizzard question or answer cannot be null or empty!");

            if (rBtnNormal.IsChecked == true)
            {
                question = this.engine.CreateNormalQuestion(questionText, DifficultyLevel.Easy, CategoryType.Random);
            }
            else if (rBtnBonus.IsChecked == true)
            {
                int multiplyBy = (int)this.multiValue;
                
                Validator.CheckIntRange(multiplyBy, GlobalConstants.MinPointsMultiplier, GlobalConstants.MaxPointsMultiplier, string.Format(GlobalConstants.NumberMustBeBetweenMinAndMax,"Point's multiplier", GlobalConstants.MinPointsMultiplier, GlobalConstants.MaxPointsMultiplier));
                question = this.engine.CreateBonusQuestion(questionText, DifficultyLevel.Easy, CategoryType.Random, multiplyBy);
            }
            else
            {
                int time = (int)this.timerValue;

                Validator.CheckIntRange(time, GlobalConstants.MinTimeForAnswer, GlobalConstants.MaxTimeForAnswer, string.Format(GlobalConstants.NumberMustBeBetweenMinAndMax, "Question's timer", GlobalConstants.MinTimeForAnswer, GlobalConstants.MaxTimeForAnswer));
                question = this.engine.CreateTimedQuestion(questionText, DifficultyLevel.Easy, CategoryType.Random, time);
            }
            
            var anwerOne = this.engine.CreateAnswer(answerACorrect, true);
            var answerTwo = this.engine.CreateAnswer(answerB, false);
            var answerThree = this.engine.CreateAnswer(answerC, false);
            var answerFour = this.engine.CreateAnswer(answerD, false);
            question.AddAnswerFluent(anwerOne).AddAnswerFluent(answerTwo).AddAnswerFluent(answerThree).AddAnswerFluent(answerFour);

            QuizzardPlayer quizzard = (QuizzardPlayer)engine.Player;
            quizzard.AddQuestion(question);

            QuizzardInitialPage quizzardInitialPage = new QuizzardInitialPage(this.engine);
            this.NavigationService.Navigate(quizzardInitialPage);
        }

        private void FinishButton(object sender, RoutedEventArgs e)
        {
            var quizzard = (QuizzardPlayer)engine.Player;

            if (quizzard.QuizzardQuestions.Count == 0)
            {
                return;
            }

            foreach (var question in quizzard.QuizzardQuestions)
            {
                engine.QuizzardQuestions.Add(question);
            }

            QuizzardTestStart startQuizzardTest = new QuizzardTestStart(this.engine);
            this.NavigationService.Navigate(startQuizzardTest);
        }

        private void SliderBonus_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;
            BonusNum.Text = slider.Value.ToString();
            this.multiValue = slider.Value;
        }

        private void SliderTime_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;
            TimeNum.Text = slider.Value.ToString();
            this.timerValue = slider.Value;
        }
    }
}
