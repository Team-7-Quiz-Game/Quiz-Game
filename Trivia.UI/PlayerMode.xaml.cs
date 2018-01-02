using GroupProject_Test_02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
        private List<string> checkedCategories;
        public PlayerMode()
        {
            engine = Engine.Instance;
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
            QuizzardInitialPage quizzardInitialPage = new QuizzardInitialPage();
            this.NavigationService.Navigate(quizzardInitialPage);
        }
    }
}
