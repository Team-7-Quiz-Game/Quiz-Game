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
            //Add checkbox for difficulty level
            //Add checkboxes for question type = normal/bonus/timed

            Validator.CheckIfStringCollectionHasNullOrEmpty(new string[] { question, answerACorrect, answerB, answerC, answerD }, "Quizzard question or answer cannot be null or empty!");

            var q = this.engine.CreateNormalQuestion(question, Common.Enums.DifficultyLevel.Normal, Common.Enums.CategoryType.Random);
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

            StartQuizzardTest startQuizzardTest = new StartQuizzardTest();
            this.NavigationService.Navigate(startQuizzardTest);
        }
    }
}
