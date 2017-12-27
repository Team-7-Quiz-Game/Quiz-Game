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

namespace Trivia.UI
{
    /// <summary>
    /// Interaction logic for PlayerMode.xaml
    /// </summary>
    public partial class PlayerMode : Page
    {
        public PlayerMode()
        {
            InitializeComponent();
            // We put the checked by the user categories in a list.
            checkedCategories = new List<string>();
        }

        List<string> checkedCategories;
        private void Check_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cbox = sender as CheckBox;
            string s = cbox.Content as string;

            if ((bool)cbox.IsChecked)
                checkedCategories.Add(s);
            else
                checkedCategories.Remove(s);
        }
        // Button for the Regular Player Page. It takes the checked categories.
        // We define a name variable that will take when the user presses the button either Go, Player or Go, Quizzard
        string name;
        private void GoPayer(object sender, RoutedEventArgs e) 
        {
            name = Name.Text;
            string checkList = string.Join(",", checkedCategories.ToArray());
            //new normal player
            // new list category
            // foreach checkedCategories parse and add to categorList
            // Game game = new Game(player, categoryList)
            // start engine with game
        }
        // Button for the Quizzard Page.
        private void GoQuizzard(object sender, RoutedEventArgs e) 
        {
            name = Name.Text;
            QuizzardInitialPage quizzardInitialPage = new QuizzardInitialPage();
            this.NavigationService.Navigate(quizzardInitialPage);
        }
    }
}
