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
using Trivia.Contracts;
using Trivia.Models;

namespace LetsGetQuizzical
{
    /// <summary>
    /// Interaction logic for QuizzardInitialPage.xaml
    /// </summary>
    public partial class QuizzardInitialPage : Page
    {
        public QuizzardInitialPage()
        {
            InitializeComponent();
        }
        // We take the question and the four answers as strings when the Quizzard presses on the AddQuestion button
        string question;
        string answerA;
        string answerB;
        string answerC;
        string answerD;
        private void AddQuestionButton(object sender, RoutedEventArgs e)
        {
            question = Question.Text;
            answerA = AnswerA.Text;
            answerB = AnswerB.Text;
            answerC = AnswerC.Text;
            answerD = AnswerD.Text;
        }
    }
}
