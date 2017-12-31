using System;
using System.Collections.Generic;
using Trivia.Common.Enums;
using Trivia.Common.Exceptions;
using Trivia.Common.Utils;
using Trivia.Contracts;
using Trivia.Core.Contracts;

namespace Trivia.Core
{
    public class Engine : IEngine
    {
        private const int QuestionsPerLevelCount = 2;
        private readonly static IEngine engine = new Engine();
        private readonly Database database;
        private readonly IFactory factory;
        private IPlayer player;
        private readonly IDictionary<string, ICategory> categories;
        private IList<IQuestion> easyQuestions;
        // TEST
        private IList<IQuestion> normalQuestions;

        private Engine()
        {
            this.factory = Factory.Instance;
            this.database = Database.Instance;
            this.categories = new Dictionary<string, ICategory>();
            this.easyQuestions = new List<IQuestion>();
            this.normalQuestions = new List<IQuestion>();
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
        public IList<IQuestion> NormalQuestions
        {
            get
            {
                return GetNormalQuestions(categories);
            }
            set
            {
                this.normalQuestions = value;
            }
        }

        public void CreateCategory(IList<string> categories)
        {
            Validator.CheckIfNull(categories, string.Format(GlobalConstants.ObjectCannotBeNull, "List of categories"));

            for (int i = 0; i < categories.Count; i++)
            {
                var categoryName = categories[i];

                if (this.categories.ContainsKey(categoryName))
                {
                    throw new CategoryAlreadyExistsException(string.Format(GlobalConstants.CategoryAlreadyExists, categoryName));
                }

                var categoryType = (CategoryType)Enum.Parse(typeof(CategoryType), categories[i]);

                var categoryToAdd = this.factory.CreateCategory(categoryType);
                this.categories.Add(categoryName, categoryToAdd);
                this.GetRandomQuestionsFromDb(categoryToAdd);
            }
        }

        private void GetRandomQuestionsFromDb(ICategory category)
        {
            Validator.CheckIfNull(category, string.Format(GlobalConstants.ObjectCannotBeNull, "Category"));

            var questions = this.database.GetRandomQuestions(category, QuestionsPerLevelCount);

            foreach (var question in questions)
            {
                this.AddQuestionsToCategory(category.CategoryType.ToString(), question);
            }
        }

        private void AddQuestionsToCategory(string categoryNameToAdd, IQuestion questionToAdd)
        {
            Validator.CheckIfNull(questionToAdd, string.Format(GlobalConstants.ObjectCannotBeNull, "Question"));
            Validator.CheckIfStringIsNullOrEmpty(categoryNameToAdd, string.Format(GlobalConstants.StringCannotBeNullOrEmpty, "Category name"));

            if (!this.categories.ContainsKey(categoryNameToAdd))
            {
                throw new CategoryDoesNotExistException(string.Format(GlobalConstants.CategoryNotFound, categoryNameToAdd));
            }

            var category = this.categories[categoryNameToAdd];

            category.AddQuestion(questionToAdd);
        }
       
        public IList<IQuestion> GetEasyQuestions(IDictionary<string, ICategory> categories)
        {
            Validator.CheckIfNull(categories, string.Format(GlobalConstants.ObjectCannotBeNull, "Dictionary of categories"));

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
        public IList<IQuestion> GetNormalQuestions(IDictionary<string, ICategory> categories)
        {
            Validator.CheckIfNull(categories, string.Format(GlobalConstants.ObjectCannotBeNull, "Dictionary of categories"));

            foreach (var category in this.categories)
            {
                foreach (var question in category.Value.NormalQuestions)
                {
                    this.normalQuestions.Add(question);
                }
            }
            return this.normalQuestions;
        }

        public IPlayer CreateNormalPlayer(string name)
        {
            Validator.CheckIfStringIsNullOrEmpty(name, string.Format(GlobalConstants.StringCannotBeNullOrEmpty, "Player name"));

            return this.factory.CreateNormalPlayer(name);
        }

        public IPlayer CreateQuizzardPlayer(string name)
        {
            Validator.CheckIfStringIsNullOrEmpty(name, string.Format(GlobalConstants.StringCannotBeNullOrEmpty, "Quizzard name"));

            return this.factory.CreateQuizzardPlayer(name);
        }

        //FOR QUIZZARD MODE BELLOW

        public IAnswer CreateAnswer(string answerText, bool isCorrect)
        {
            Validator.CheckIfStringIsNullOrEmpty(answerText, string.Format(GlobalConstants.StringCannotBeNullOrEmpty, "Answer"));

            return this.factory.CreateAnswer(answerText, isCorrect);
        }

        public IQuestion CreateNormalQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category)
        {
            this.CheckQuizzardCreateQuestions(questionText, difficultyLevel, category);

            return this.factory.CreateNormalQuestion(questionText, difficultyLevel, category);
        }

        public IQuestion CreateBonusQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category, int pointsAmplifier)
        {
            this.CheckQuizzardCreateQuestions(questionText, difficultyLevel, category);
            Validator.CheckIntRange(pointsAmplifier, GlobalConstants.MinPointsAmplifier, GlobalConstants.MaxPointsAmplifier, string.Format(GlobalConstants.NumberMustBeBetweenMinAndMax, "Points amplifier", GlobalConstants.MinPointsAmplifier, GlobalConstants.MaxPointsAmplifier));

            return this.factory.CreateBonusQuestion(questionText, difficultyLevel, category, pointsAmplifier);
        }

        public IQuestion CreateTimedQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category, int timeForAnswer)
        {
            this.CheckQuizzardCreateQuestions(questionText, difficultyLevel, category);
            Validator.CheckIntRange(timeForAnswer, GlobalConstants.MinTimeForAnswer, GlobalConstants.MaxTimeForAnswer, string.Format(GlobalConstants.NumberMustBeBetweenMinAndMax, "Time for answer", GlobalConstants.MinTimeForAnswer, GlobalConstants.MaxTimeForAnswer));

            return this.factory.CreateTimedQuestion(questionText, difficultyLevel, category, timeForAnswer);
        }
        
        private void CheckQuizzardCreateQuestions(string questionText, DifficultyLevel difficultyLevel, CategoryType category)
        {
            Validator.CheckIfStringIsNullOrEmpty(questionText, string.Format(GlobalConstants.StringCannotBeNullOrEmpty, "Question's text"));
            Validator.CheckIfNull(difficultyLevel, string.Format(GlobalConstants.ObjectCannotBeNull, "Difficulty level"));
            Validator.CheckIfNull(category, string.Format(GlobalConstants.ObjectCannotBeNull, "Category"));
        }
    }
}
