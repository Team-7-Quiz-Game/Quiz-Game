using System;
using System.Collections.Generic;
using Trivia.Common.Enums;
using Trivia.Common.Exceptions;
using Trivia.Common.Utils;
using Trivia.Contracts;
using Trivia.Core.Contracts;
using Trivia.Models.Hint;

namespace Trivia.Core
{
    public class Engine : IEngine
    {
        private readonly static IEngine engine = new Engine();
        private readonly Database database;
        private readonly IFactory factory;
        private IPlayer player;
        private readonly IDictionary<string, ICategory> categories;
        private IList<IQuestion> easyQuestions;
        private IList<IQuestion> normalQuestions;
        private IList<IQuestion> hardQuestions;
        private IList<IQuestion> quizzardQuestions;
        private Hint fiftyFifty;
        private Hint skipQuestion;

        private Engine()
        {
            this.factory = Factory.Instance;
            this.database = Database.Instance;
            this.categories = new Dictionary<string, ICategory>();
            this.easyQuestions = new List<IQuestion>();
            this.normalQuestions = new List<IQuestion>();
            this.hardQuestions = new List<IQuestion>();
            this.quizzardQuestions = new List<IQuestion>();
            this.fiftyFifty = this.CreateFiftyFiftyHint();
            this.skipQuestion = this.CreateSkipQuestionHint();
        }

        public static IEngine Instance => engine;

        public IPlayer Player { get => player; set => player = value; }

        public IList<IQuestion> EasyQuestions => this.GetEasyQuestions();

        public IList<IQuestion> NormalQuestions => this.GetNormalQuestions();

        public IList<IQuestion> HardQuestions => this.GetHardQuestions();

        public IList<IQuestion> QuizzardQuestions => this.quizzardQuestions;

        public Hint FiftyFiftyHint => this.fiftyFifty;

        public Hint SkipQuestionHint => this.skipQuestion;

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

            var questions = this.database.GetRandomQuestions(category, GlobalConstants.QuestionsPerDifficultyLevel);

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

        public IList<IQuestion> GetEasyQuestions()
        {
            foreach (var category in this.categories)
            {
                foreach (var question in category.Value.EasyQuestions)
                {
                    question.ShuffleAnswers();
                    this.easyQuestions.Add(question);
                }
            }

            return this.easyQuestions;
        }

        public IList<IQuestion> GetNormalQuestions()
        {
            foreach (var category in this.categories)
            {
                foreach (var question in category.Value.NormalQuestions)
                {
                    question.ShuffleAnswers();
                    this.normalQuestions.Add(question);
                }
            }

            return this.normalQuestions;
        }

        public IList<IQuestion> GetHardQuestions()
        {
            foreach (var category in this.categories)
            {
                foreach (var question in category.Value.HardQuestions)
                {
                    question.ShuffleAnswers();
                    this.hardQuestions.Add(question);
                }
            }

            return this.hardQuestions;
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
            this.CheckQuizzardCreateQuestionsParams(questionText, difficultyLevel, category);

            return this.factory.CreateNormalQuestion(questionText, difficultyLevel, category);
        }

        public IQuestion CreateBonusQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category, int pointsMultiplier)
        {
            this.CheckQuizzardCreateQuestionsParams(questionText, difficultyLevel, category);
            Validator.CheckIntRange(pointsMultiplier, GlobalConstants.MinPointsMultiplier, GlobalConstants.MaxPointsMultiplier, string.Format(GlobalConstants.NumberMustBeBetweenMinAndMax, "Points amplifier", GlobalConstants.MinPointsMultiplier, GlobalConstants.MaxPointsMultiplier));

            return this.factory.CreateBonusQuestion(questionText, difficultyLevel, category, pointsMultiplier);
        }

        public IQuestion CreateTimedQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category, int timeForAnswer)
        {
            this.CheckQuizzardCreateQuestionsParams(questionText, difficultyLevel, category);
            Validator.CheckIntRange(timeForAnswer, GlobalConstants.MinTimeForAnswer, GlobalConstants.MaxTimeForAnswer, string.Format(GlobalConstants.NumberMustBeBetweenMinAndMax, "Time for answer", GlobalConstants.MinTimeForAnswer, GlobalConstants.MaxTimeForAnswer));

            return this.factory.CreateTimedQuestion(questionText, difficultyLevel, category, timeForAnswer);
        }

        private void CheckQuizzardCreateQuestionsParams(string questionText, DifficultyLevel difficultyLevel, CategoryType category)
        {
            Validator.CheckIfStringIsNullOrEmpty(questionText, string.Format(GlobalConstants.StringCannotBeNullOrEmpty, "Question's text"));
            Validator.CheckIfNull(difficultyLevel, string.Format(GlobalConstants.ObjectCannotBeNull, "Difficulty level"));
            Validator.CheckIfNull(category, string.Format(GlobalConstants.ObjectCannotBeNull, "Category"));
        }

        public Hint CreateFiftyFiftyHint(int quantity = GlobalConstants.DefaultHintQuantity)
        {
            Validator.CheckIfIntNegative(quantity, string.Format(GlobalConstants.NumberCannotBeNegative, "Hint quantity"));

            return this.factory.CreateFiftyFiftyHint(quantity);
        }

        public Hint CreateSkipQuestionHint(int quantity = GlobalConstants.DefaultHintQuantity)
        {
            Validator.CheckIfIntNegative(quantity, string.Format(GlobalConstants.NumberCannotBeNegative, "Hint quantity"));

            return this.factory.CreateSkipQuestionHint(quantity);
        }
    }
}