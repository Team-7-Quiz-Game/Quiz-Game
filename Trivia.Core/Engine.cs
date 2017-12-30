using System;
using System.Collections.Generic;
using Trivia.Common.Enums;
using Trivia.Contracts;
using Trivia.Core.Contracts;

namespace Trivia.Core
{
    public class Engine : IEngine
    {
        private const int QUESTIONS_PER_LEVEL_COUNT = 2;
        private readonly static IEngine engine = new Engine();
        private readonly IFactory factory;
        private IPlayer player;
        private readonly IDictionary<string, ICategory> categories;
        private readonly DB database;        
        private IList<IQuestion> easyQuestions;
        // TEST
        //private IList<IQuestion> normalQuestions;
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

        public IPlayer Player { get => player; set => player = value; }
        
        public IList<IQuestion> EasyQuestions
        {
            get
            {
                return GetEasyQuestions(categories);
            }
            set
            {
                this.easyQuestions = value;
            }
        }
        // TEST Property
        //public IList<IQuestion> NormalQuestions
        //{
        //    get
        //    {
        //        return GetNormalQuestions(categories);
        //    }
        //    set
        //    {
        //        this.normalQuestions = value;
        //    }
        //}
     
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
                this.GetRandomQuestionsFromDb(categoryToAdd);
            }
        }
        private void GetRandomQuestionsFromDb(ICategory category)
        {
            var questions = this.database.GetRandomQuestions(category, QUESTIONS_PER_LEVEL_COUNT);

            foreach (var question in questions)
            {
                this.AddQuestionsToCategory(category.CategoryType.ToString(), question);
            }
        }

        private void AddQuestionsToCategory(string categoryNameToAdd, IQuestion questionToAdd)
        {
            //guard

            if (!this.categories.ContainsKey(categoryNameToAdd))
            {
                throw new ArgumentException("Category does not exists!");
            }

            var category = this.categories[categoryNameToAdd];

            category.AddQuestion(questionToAdd);
        }
       
        public IList<IQuestion> GetEasyQuestions(IDictionary<string, ICategory> categories)
        {
            this.easyQuestions = new List<IQuestion>();
            foreach (var category in this.categories)
            {
                foreach(var question in category.Value.EasyQuestions)
                {
                    this.easyQuestions.Add(question);
                }
            }
            return this.easyQuestions;
        }
        // TEST
        //public IList<IQuestion> GetNormalQuestions(IDictionary<string, ICategory> categories)
        //{
        //    this.normalQuestions = new List<IQuestion>();
        //    foreach (var category in this.categories)
        //    {
        //        foreach (var question in category.Value.NormalQuestions)
        //        {
        //            this.normalQuestions.Add(question);
        //        }
        //    }
        //    return this.normalQuestions;
        //}
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
