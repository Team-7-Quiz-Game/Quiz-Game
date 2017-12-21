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
        private void GoPayer(object sender, RoutedEventArgs e) 
        {
            string checkList = string.Join(",", checkedCategories.ToArray()); 
        }
        // Button for the Quizzard Page. For the moment it directs the user to a TEST page.
        private void GoQuizzard(object sender, RoutedEventArgs e) 
        {
            NextPage nextPage = new NextPage();
            this.NavigationService.Navigate(nextPage);
        }
    }
}
