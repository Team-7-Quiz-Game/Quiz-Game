using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Common;
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

        private void CreateCategory(string categoryName)
        {
            //if (this.categories.Contains(categoryName))
            //{
            //    return string.Format(CategoryExists, categoryName);
            //}

            //var category = this.factory.CreateCategory(categoryName);
            //this.categories.Add(categoryName, category);

            //return string.Format(CategoryCreated, categoryName);
        }

        private void AddQuestionToCategory(string categoryNameToAdd, IQuestion questionToAdd)
        {
            //if (!this.categories.ContainsKey(categoryNameToAdd))
            //{
            //    return string.Format(CategoryDoesNotExist, categoryNameToAdd);
            //}

            //if (!this.products.ContainsKey(productToAdd))
            //{
            //    return string.Format(ProductDoesNotExist, productToAdd);
            //}

            //var category = this.categories[categoryNameToAdd];
            //var product = this.products[productToAdd];

            //category.AddProduct(product);

            //return string.Format(ProductAddedToCategory, productToAdd, categoryNameToAdd);
        }

        private IAnswer CreateAnswer(string answerText, bool isCorrect)
        {
            //gurad
            return this.factory.CreateAnswer(answerText, isCorrect);
        }

        private IQuestion CreateNormalQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category)
        {
            //guard
            return this.factory.CreateNormalQuestion(questionText, difficultyLevel, category);
        }

        private IQuestion CreateBonusQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category, int pointsAmplifier)
        {
            //guard
            return this.factory.CreateBonusQuestion(questionText, difficultyLevel, category, pointsAmplifier);
        }

        private IQuestion CreateTimedQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category, int timeForAnswer)
        {
            //guard
            return this.factory.CreateTimedQuestion(questionText, difficultyLevel, category, timeForAnswer);
        }

        private IPlayer CreateNormalPlayer(string name)
        {
            //guard
            return this.factory.CreateNormalPlayer(name);
        }

        private IPlayer CreateQuizzardPlayer(string name)
        {
            //guard
            return this.factory.CreateQuizzardPlayer(name);
        }
    }
}
