using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Trivia.Core;
using Trivia.Core.Contracts;
using Trivia.Models.Player;

namespace Trivia.UI
{
    /// <summary>
    /// Interaction logic for PlayerMode.xaml
    /// </summary>
    public partial class PlayerMode : Page
    {
        private IEngine engine;
        private string name;
        private IList<string> checkedCategories;

        public PlayerMode(IEngine engine)
        {
            this.engine = engine;
            InitializeComponent();
            // We put the checked by the user categories in a list.
            checkedCategories = new List<string>();
        }
        
        private void Check_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cbox = sender as CheckBox;
            string s = cbox.Content as string;

            if ((bool)cbox.IsChecked)
            {
                checkedCategories.Add(s);
            }
            else
            {
                checkedCategories.Remove(s);
            }
        }
        // Button for the Regular Player Page. It takes the checked categories.
        // We define a name variable that will take when the user presses the button either Go, Player or Go, Quizzard

        private void GoPlayer(object sender, RoutedEventArgs e)
        {
            name = pName.Text;

            if (this.checkedCategories.Count == 0)
            {
                return;
            }

            this.engine.CreateCategory(checkedCategories);
    
            var player = engine.CreateNormalPlayer(name);
            this.engine.Player = (NormalPlayer)player;
            PlayerFirstLevelPage firstLevelPagePlayer = new PlayerFirstLevelPage(this.engine);
            this.NavigationService.Navigate(firstLevelPagePlayer);
        }

        // Button for the Quizzard Page.
        private void GoQuizzard(object sender, RoutedEventArgs e)
        {
            name = pName.Text;
            var player = engine.CreateQuizzardPlayer(name);
            this.engine.Player = (QuizzardPlayer)player;
            QuizzardInitialPage quizzardInitialPage = new QuizzardInitialPage(this.engine);
            this.NavigationService.Navigate(quizzardInitialPage);
        }
    }
}
