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
        private readonly static IEngine engine = new Engine();
        private readonly IFactory factory;
        private IPlayer player;
        private readonly IDictionary<string, ICategory> categories;
        private readonly DB database;
        
        private Engine()
        {
            this.factory = Factory.Instance;
            this.categories = new Dictionary<string, ICategory>();
            this.database = new DB(this.factory);
        }

        public static IEngine Instance
        {
            get
            {
                return engine;
            }
        }

        public IPlayer Player { get => player; private set => player = value; }
        
        public void CreateCategory(IList<string> categories)
        {
            for (int i = 0; i < categories.Count; i++)
            {
                var categoryName = categories[i];

                if (this.categories.ContainsKey(categoryName))
                {
                    //throw some custom error or something - category already exists
                }

                var categoryType = (CategoryType)Enum.Parse(typeof(CategoryType), categories[i]);

                var categoryToAdd = this.factory.CreateCategory(categoryType);
                this.categories.Add(categoryName, categoryToAdd);
            }
        }

        //TODO
        //private IQuestion GetQuestionFromDb(string categoryName)
        //{

        //}

        private void AddQuestionsToCategory(string categoryNameToAdd, IQuestion questionToAdd)
        {
            if (!this.categories.ContainsKey(categoryNameToAdd))
            {
                //throw some custom error or something - category does not exists
            }

            var category = this.categories[categoryNameToAdd];

            category.AddQuestion(questionToAdd);
        }

        public IPlayer CreateNormalPlayer(string name)
        {
            //guard
            return this.factory.CreateNormalPlayer(name);
        }

        public IPlayer CreateQuizzardPlayer(string name)
        {
            //guard
            return this.factory.CreateQuizzardPlayer(name);
        }

        //FOR QUIZZARD MODE BELLOW

        public IAnswer CreateAnswer(string answerText, bool isCorrect)
        {
            //gurad
            return this.factory.CreateAnswer(answerText, isCorrect);
        }

        public IQuestion CreateNormalQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category)
        {
            //guard
            return this.factory.CreateNormalQuestion(questionText, difficultyLevel, category);
        }

        public IQuestion CreateBonusQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category, int pointsAmplifier)
        {
            //guard
            return this.factory.CreateBonusQuestion(questionText, difficultyLevel, category, pointsAmplifier);
        }

        public IQuestion CreateTimedQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category, int timeForAnswer)
        {
            //guard
            return this.factory.CreateTimedQuestion(questionText, difficultyLevel, category, timeForAnswer);
        }
    }
}
