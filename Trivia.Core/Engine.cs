using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Contracts;
using Trivia.Core.Contracts;

namespace Trivia.Core
{
    public class Engine : IEngine
    {
        private static readonly IEngine SingleInstance = new Engine();
        private readonly IFactory factory;
        private static IPlayer player;
        private readonly IList<ICategory> categories;
        
        private Engine()
        {
            this.factory = new Factory();
            this.categories = new List<ICategory>();
        }

        public static IEngine Instance
        {
            get
            {
                return SingleInstance;
            }
        }

        public static IPlayer Player { get => player; private set => player = value; }

        public void Start()
        {
            while (true)
            {
                try
                {
                    //var commandAsString = this.Reader.ReadLine();

                    //if (commandAsString.ToLower() == TerminationCommand.ToLower())
                    //{
                    //    break;
                    //}

                    //this.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    //this.Writer.WriteLine(ex.Message);
                    //this.Writer.WriteLine("####################");
                }
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            //var command = this.Parser.ParseCommand(commandAsString);
            //var parameters = this.Parser.ParseParameters(commandAsString);

            //var executionResult = command.Execute(parameters);
            //this.Writer.WriteLine(executionResult);
            //this.Writer.WriteLine("####################");
        }
    }
}
