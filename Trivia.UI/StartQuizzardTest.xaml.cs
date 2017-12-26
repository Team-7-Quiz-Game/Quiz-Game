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

namespace LetsGetQuizzical
{
    /// <summary>
    /// Interaction logic for StartQuizzardTest.xaml
    /// </summary>
    public partial class StartQuizzardTest : Page
    {
        public StartQuizzardTest()
        {
            InitializeComponent();
           
        }
        // The buttons will be binded with the answers from the list. Upon clicking on a button 
        bool answerIsCorrect = false;
        private void AnswerAButton(object sender, RoutedEventArgs e)
        {
            answerIsCorrect = false;
        }

        private void AnswerBButton(object sender, RoutedEventArgs e)
        {
            answerIsCorrect = false;
        }

        private void AnswerCButton(object sender, RoutedEventArgs e)
        {
            answerIsCorrect = true;
            if (answerIsCorrect)
            {
                MyPopup.IsOpen = true;
            }
        }

        private void AnswerDButton(object sender, RoutedEventArgs e)
        {
            answerIsCorrect = false;
        }
    }
}
