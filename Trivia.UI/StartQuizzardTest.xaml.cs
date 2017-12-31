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

namespace Trivia.UI
{
    /// <summary>
    /// Interaction logic for StartQuizzardTest.xaml
    /// </summary>
    public partial class StartQuizzardTest : Page
    {
        private IEngine engine;

        public StartQuizzardTest()
        {
            InitializeComponent();
            this.engine = Engine.Instance;

            engine.QuizzardQuestions.Shuffle();
            foreach (var question in engine.QuizzardQuestions)
            {
                question.ShuffleAnswers();
            }

            QuestionText.Text = engine.QuizzardQuestions[0].QuestionText;
            AnswerA.Content = engine.QuizzardQuestions[0].Answers[0];
            AnswerB.Content = engine.QuizzardQuestions[0].Answers[1];
            AnswerC.Content = engine.QuizzardQuestions[0].Answers[2];
            AnswerD.Content = engine.QuizzardQuestions[0].Answers[3];
        }
        // The buttons will be binded with the answers from the list. Upon clicking on a button 

        private void AnswerAButton(object sender, RoutedEventArgs e)
        {
            //Check if answer is correct 
            //if yes add points
            //if no do not add points 
            //then remove this question from engine.QuizzardQuestions
            //then check if there are any other questions left
            //if no load end screen
            //if yes proceed to the same page
        }

        private void AnswerBButton(object sender, RoutedEventArgs e)
        {
            //Check if answer is correct 
            //if yes add points
            //if no do not add points 
            //then remove this question from engine.QuizzardQuestions 
            //then check if there are any other questions left
            //if no load end screen
            //if yes proceed to the same page
        }

        private void AnswerCButton(object sender, RoutedEventArgs e)
        {
            //Check if answer is correct 
            //if yes add points
            //if no do not add points 
            //then remove this question from engine.QuizzardQuestions 
            //then check if there are any other questions left
            //if no load end screen
            //if yes proceed to the same page
        }

        private void AnswerDButton(object sender, RoutedEventArgs e)
        {
            //Check if answer is correct 
            //if yes add points
            //if no do not add points 
            //then remove this question from engine.QuizzardQuestions 
            //then check if there are any other questions left
            //if no load end screen
            //if yes proceed to the same page
        }
    }
}
