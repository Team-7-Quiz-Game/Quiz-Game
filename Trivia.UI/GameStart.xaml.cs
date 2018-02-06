using Autofac;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Trivia.Core.Contracts;

namespace Trivia.UI
{
    /// <summary>
    /// Interaction logic for GameStart.xaml
    /// </summary>
    public partial class GameStart : Page
    {        
        public GameStart()
        {
            InitializeComponent();
        }
        private void StartGameButton(object sender, RoutedEventArgs e)
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            var engine = container.Resolve<IEngine>();

            // Go to Choose A Player Mode
            PlayerMode playerMode = new PlayerMode(engine);
            this.NavigationService.Navigate(playerMode);
        }
    }
}