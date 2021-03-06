﻿using System;
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
    /// Interaction logic for QuizzardTestTimedQuestion.xaml
    /// </summary>
    public partial class QuizzardTestTimedQuestion : Page
    {
        private IEngine engine;
        private static bool answerA;
        private static bool answerB;
        private static bool answerC;
        private static bool answerD;
        private static int countQuestions = 0;
        private static int points;

        public QuizzardTestTimedQuestion(IEngine engine)
        {
            InitializeComponent();
            this.engine = engine;

            engine.QuizzardQuestions.Shuffle();
            foreach (var question in engine.QuizzardQuestions)
            {
                question.ShuffleAnswers();
            }
            DisplayTextForQuestionAndAnswers(engine.QuizzardQuestions, countQuestions);
        }
        // TODO: Implement time logic

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
