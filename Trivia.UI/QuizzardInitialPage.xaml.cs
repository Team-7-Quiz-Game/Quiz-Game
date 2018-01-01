using GroupProject_Test_02;
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
        private string question;
        private string answerACorrect;
        private string answerB;
        private string answerC;
        private string answerD;
        private double multiValue;
        private double timerValue;

        public QuizzardInitialPage()
        {
            InitializeComponent();
            this.engine = Engine.Instance;
            this.player = (QuizzardPlayer)engine.Player;
            QuestionsCount.Text = player.QuizzardQuestions.Count.ToString();
        }
        // We take the question and the four answers as strings when the Quizzard presses on the AddQuestion button
        
        private void AddQuestionButton(object sender, RoutedEventArgs e)
        {
            question = Question.Text;
            answerACorrect = AnswerA.Text; 
            answerB = AnswerB.Text;
            answerC = AnswerC.Text;
            answerD = AnswerD.Text;
            IQuestion q;

            if (rBtnNormal.IsChecked == true)
            {
                q = this.engine.CreateNormalQuestion(question, DifficultyLevel.Easy, CategoryType.Random);
            }
            else if (rBtnBonus.IsChecked == true)
            {
                int multiplyBy = (int)this.multiValue;
                
                Validator.CheckIntRange(multiplyBy, GlobalConstants.MinPointsMultiplier, GlobalConstants.MaxPointsMultiplier, string.Format(GlobalConstants.NumberMustBeBetweenMinAndMax,"Point's multiplier", GlobalConstants.MinPointsMultiplier, GlobalConstants.MaxPointsMultiplier));
                q = this.engine.CreateBonusQuestion(question, DifficultyLevel.Easy, CategoryType.Random, multiplyBy);
            }
            else
            {
                int time = (int)this.timerValue;

                Validator.CheckIntRange(time, GlobalConstants.MinTimeForAnswer, GlobalConstants.MaxTimeForAnswer, string.Format(GlobalConstants.NumberMustBeBetweenMinAndMax, "Question's timer", GlobalConstants.MinTimeForAnswer, GlobalConstants.MaxTimeForAnswer));
                q = this.engine.CreateTimedQuestion(question, DifficultyLevel.Easy, CategoryType.Random, time);
            }

            Validator.CheckIfStringCollectionHasNullOrEmpty(new string[] { question, answerACorrect, answerB, answerC, answerD }, "Quizzard question or answer cannot be null or empty!");

            
            var a1 = this.engine.CreateAnswer(answerACorrect, true);
            var a2 = this.engine.CreateAnswer(answerB, false);
            var a3 = this.engine.CreateAnswer(answerC, false);
            var a4 = this.engine.CreateAnswer(answerD, false);
            q.AddAnswerFluent(a1).AddAnswerFluent(a2).AddAnswerFluent(a3).AddAnswerFluent(a4);

            QuizzardPlayer quizzard = (QuizzardPlayer)engine.Player;
            quizzard.AddQuestion(q);

            QuizzardInitialPage quizzardInitialPage = new QuizzardInitialPage();
            this.NavigationService.Navigate(quizzardInitialPage);
        }

        private void FinishButton(object sender, RoutedEventArgs e)
        {
            var quizzard = (QuizzardPlayer)engine.Player;

            foreach (var question in quizzard.QuizzardQuestions)
            {
                engine.QuizzardQuestions.Add(question);
            }

            QuizzardTestStart startQuizzardTest = new QuizzardTestStart();
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
