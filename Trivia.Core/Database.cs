using System;
using System.Collections.Generic;
using System.Linq;
using Trivia.Common.Enums;
using Trivia.Contracts;
using Trivia.Core.Contracts;

namespace Trivia.Core
{
    public class Database
    {
        private static Database instanceHolder = new Database();
        private IList<ICategory> categories;
        private readonly IFactory factory;

        private Database()
        {
            this.categories = new List<ICategory>();
            this.factory = Factory.Instance;
            this.PopulateCategories();
            this.PopulateQuestions();
        }

        public static Database Instance => instanceHolder;

        public IList<ICategory> Categories => this.categories;

        public IList<IQuestion> GetRandomQuestions(ICategory category, int numOfQuestions)
        {
            var uniqueQuestionsList = new List<IQuestion>();
            var selectedCategory = this.Categories.Single(c => c.CategoryType == category.CategoryType);

            var easyQuestionIndices = GetRandomIndices(selectedCategory.EasyQuestions.Count, numOfQuestions);

            foreach (var index in easyQuestionIndices)
            {
                uniqueQuestionsList.Add(selectedCategory.EasyQuestions[index]);
            }

            var normalQuestionIndices = GetRandomIndices(selectedCategory.NormalQuestions.Count, numOfQuestions);

            foreach (var index in normalQuestionIndices)
            {
                uniqueQuestionsList.Add(selectedCategory.NormalQuestions[index]);
            }

            var hardQuestionIndices = GetRandomIndices(selectedCategory.HardQuestions.Count, numOfQuestions);

            foreach (var index in hardQuestionIndices)
            {
                uniqueQuestionsList.Add(selectedCategory.HardQuestions[index]);
            }

            return uniqueQuestionsList;
        }

        private IList<int> GetRandomIndices(int listCount, int numOfQuestions)
        {
            var listOfUniqueIndices = new List<int>();

            Random rnd = new Random();
            int r;

            while (true)
            {
                r = rnd.Next(listCount);

                if (!listOfUniqueIndices.Contains(r))
                {
                    listOfUniqueIndices.Add(r);
                }

                if (listOfUniqueIndices.Count == numOfQuestions)
                {
                    break;
                }
            }

            return listOfUniqueIndices;
        }

        private void PopulateCategories()
        {
            var Math = factory.CreateCategory(CategoryType.Math);
            this.categories.Add(Math);

            var History = factory.CreateCategory(CategoryType.History);
            this.categories.Add(History);

            var SciFi = factory.CreateCategory(CategoryType.SciFi);
            this.categories.Add(SciFi);

            var Movies = factory.CreateCategory(CategoryType.Movies);
            this.categories.Add(Movies);

            var Literature = factory.CreateCategory(CategoryType.Literature);
            this.categories.Add(Literature);

            var Science = factory.CreateCategory(CategoryType.Science);
            this.categories.Add(Science);

            var Geography = factory.CreateCategory(CategoryType.Geography);
            this.categories.Add(Geography);

            var Random = factory.CreateCategory(CategoryType.Random);
            this.categories.Add(Random);

        }

        private void PopulateQuestions()
        {
            // EASY
            EasyMathQuestions();
            EasyHistoryQuestions();
            EasySciFiQuestions();
            EasyMovieQuestions();
            EasyLiteratureQuestions();
            EasyScienceQuestions();
            EasyGeographyQuestions();
            EasyRandomQuestions();

            // NORMAL
            NormalMathQuestions();
            NormalHistoryQuestions();
            NormalSciFiQuestions();
            NormalMovieQuestions();
            NormalLiteratureQuestions();
            NormalScienceQuestions();
            NormalGeographyQuestions();
            NormalRandomQuestions();

            // HARD
            HardMathQuestions();
            HardHistoryQuestions();
            HardSciFiQuestions();
            HardMovieQuestions();
            HardLiteratureQuestions();
            HardScienceQuestions();
            HardGeographyQuestions();
            HardRandomQuestions();
        }

        // EASY
        private void EasyMathQuestions()
        {
            var qMText1 = "How many digits are there in total in the number \"pi\"? ";
            var a1 = new[] { "1.2 trillion", "False" };
            var a2 = new[] { "1.9 trillion", "False" };
            var a3 = new[] { "2.7 trillion", "True" };
            var a4 = new[] { "3.4 trillion", "False" };
            CreateQuestion(qMText1, a1, a2, a3, a4, CategoryType.Math, DifficultyLevel.Easy);

            var qMText2 = "How many zeroes are behind the number known as \"Googolplex\"?";
            a1 = new[] { "100", "False" };
            a2 = new[] {"1000", "False" };
            a3 = new[] {"10000", "True" };
            a4 = new[] { "100000", "False" };
            CreateQuestion(qMText2, a1, a2, a3, a4, CategoryType.Math, DifficultyLevel.Easy);

            var qMText3 = "Which type of Mathematics is mostly used in nowadays' world?";
            a1 = new[] {"Applied Mathematics", "True" };
            a2 = new[] {"Mathematical Physics", "False" };
            a3 = new[] {"Combinatorics", "False" };
            a4 = new[] { "Pure Mathematics", "False" };
            CreateQuestion(qMText3, a1, a2, a3, a4, CategoryType.Math, DifficultyLevel.Easy);

            var qMText4 = "Who invented Mathematics?";
            a1 = new[] {"Pythagoras", "False" };
            a2 = new[] {"Plato", "False" };
            a3 = new[] {"Aristotle", "False" };
            a4 = new[] { "Math wasn't invented", "True"};
            CreateQuestion(qMText4, a1, a2, a3, a4, CategoryType.Math, DifficultyLevel.Easy);
        }

        private void EasyHistoryQuestions()
        {
            var qHText1 = "Which was the first civilization to ever arise?";
            var historyQ1 = this.factory.CreateNormalQuestion(qHText1, DifficultyLevel.Easy, CategoryType.History);

            var a1 = this.factory.CreateAnswer("Sumerian", true);
            var a2 = this.factory.CreateAnswer("Egyptian", false);
            var a3 = this.factory.CreateAnswer("Harappan", false);
            var a4 = this.factory.CreateAnswer("Chinese", false);

            AddQuestion(historyQ1, a1, a2, a3, a4);

            var qHText2 = "How many deities has the Egyptian civilization had up to this point in the history of the world?";
            var historyQ2 = this.factory.CreateNormalQuestion(qHText2, DifficultyLevel.Easy, CategoryType.History);

            a1 = this.factory.CreateAnswer("217", false);
            a2 = this.factory.CreateAnswer("904", false);
            a3 = this.factory.CreateAnswer("785", false);
            a4 = this.factory.CreateAnswer("Over 2000", true);

            AddQuestion(historyQ2, a1, a2, a3, a4);

            var qHText3 = "In which region appeared the first civilizations known to this day?";
            var historyQ3 = this.factory.CreateNormalQuestion(qHText3, DifficultyLevel.Easy, CategoryType.History);

            a1 = this.factory.CreateAnswer("Mesopotamia", true);
            a2 = this.factory.CreateAnswer("South America", false);
            a3 = this.factory.CreateAnswer("Southeast Asia", false);
            a4 = this.factory.CreateAnswer("North Africa", false);

            AddQuestion(historyQ3, a1, a2, a3, a4);

            var qHText4 = "Which ruling empire lasted the longest amount of time throughout history";
            var historyQ4 = this.factory.CreateNormalQuestion(qHText4, DifficultyLevel.Easy, CategoryType.History);

            a1 = this.factory.CreateAnswer("Holy Roman Empire", false);
            a2 = this.factory.CreateAnswer("Roman Empire", true);
            a3 = this.factory.CreateAnswer("Ottoman Empire", false);
            a4 = this.factory.CreateAnswer("Kush Empire", false);

            AddQuestion(historyQ4, a1, a2, a3, a4);
        }

        private void EasySciFiQuestions()
        {
            var qSFText1 = "Which of the following futuristics weapons is currently a prototype and used in real millitary operations to some extent?";
            var sciFiQ1 = this.factory.CreateNormalQuestion(qSFText1, DifficultyLevel.Easy, CategoryType.SciFi);

            var a1 = this.factory.CreateAnswer("Railgun", true);
            var a2 = this.factory.CreateAnswer("Plasma Rifle", false);
            var a3 = this.factory.CreateAnswer("Gravity Gun", false);
            var a4 = this.factory.CreateAnswer("Laser Rifle", false);

            AddQuestion(sciFiQ1, a1, a2, a3, a4);

            var qSFText2 = "Which of the following technologies is still considered as fictitious for the human race at this point in time?";
            var sciFiQ2 = this.factory.CreateNormalQuestion(qSFText2, DifficultyLevel.Easy, CategoryType.SciFi);

            a1 = this.factory.CreateAnswer("Hyper Drive (FTL)", true);
            a2 = this.factory.CreateAnswer("Nuclear Fusion", false);
            a3 = this.factory.CreateAnswer("Thorium Energy", false);
            a4 = this.factory.CreateAnswer("3D Bio Printing", false);

            AddQuestion(sciFiQ1, a1, a2, a3, a4);

            var qSFText3 = "Which of the following technologies is not inspired by movies?";
            var sciFiQ3 = this.factory.CreateNormalQuestion(qSFText3, DifficultyLevel.Easy, CategoryType.SciFi);

            a1 = this.factory.CreateAnswer("Cell Phones", false);
            a2 = this.factory.CreateAnswer("Holographic Performances", false);
            a3 = this.factory.CreateAnswer("Virtual Reality Devices", false);
            a4 = this.factory.CreateAnswer("Teleportation", true);

            AddQuestion(sciFiQ3, a1, a2, a3, a4);

            var qSFText4 = "Where does the concept of Science-Fiction originate from?";
            var sciFiQ4 = this.factory.CreateNormalQuestion(qSFText4, DifficultyLevel.Easy, CategoryType.SciFi);

            a1 = this.factory.CreateAnswer("Books", false);
            a2 = this.factory.CreateAnswer("Astronomy Theories", false);
            a3 = this.factory.CreateAnswer("Movies", true);
            a4 = this.factory.CreateAnswer("Theories about the future", false);

            AddQuestion(sciFiQ4, a1, a2, a3, a4);
        }

        private void EasyMovieQuestions()
        {
            CreateQuestion("Easy movie question 1", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Movies, DifficultyLevel.Easy);
            CreateQuestion("Easy movie question 2", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Movies, DifficultyLevel.Easy);
            CreateQuestion("Easy movie question 3", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Movies, DifficultyLevel.Easy);
            CreateQuestion("Easy movie question 4", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Movies, DifficultyLevel.Easy);
        }

        private void EasyLiteratureQuestions()
        {
            var qLText1 = "Which of the following authors inspired the following words \"The world's a stage, and we are but the actors.\"?";
            var literatureQ1 = this.factory.CreateNormalQuestion(qLText1, DifficultyLevel.Easy, CategoryType.Literature);

            var a1 = this.factory.CreateAnswer("Mark Twain", false);
            var a2 = this.factory.CreateAnswer("William Shakespeare", true);
            var a3 = this.factory.CreateAnswer("Sir Arthur Conan Doyle", false);
            var a4 = this.factory.CreateAnswer("Doktor Radeva", false);

            AddQuestion(literatureQ1, a1, a2, a3, a4);

            var qLText2 = "Where do Haiku poems originate from?";
            var literatureQ2 = this.factory.CreateNormalQuestion(qLText2, DifficultyLevel.Easy, CategoryType.Literature);

            a1 = this.factory.CreateAnswer("Korea", false);
            a2 = this.factory.CreateAnswer("China", false);
            a3 = this.factory.CreateAnswer("Mongolia", false);
            a4 = this.factory.CreateAnswer("Japan", true);

            AddQuestion(literatureQ2, a1, a2, a3, a4);

            var qLText3 = "Which author augmented the most the profession known as \"acting\" throughout the timespan of human history?";
            var literatureQ3 = this.factory.CreateNormalQuestion(qLText3, DifficultyLevel.Easy, CategoryType.Literature);

            a1 = this.factory.CreateAnswer("Arthur Miller", false);
            a2 = this.factory.CreateAnswer("Anton Chekov", false);
            a3 = this.factory.CreateAnswer("Tennessee Williams", false);
            a4 = this.factory.CreateAnswer("William Shakespeare", true);

            AddQuestion(literatureQ3, a1, a2, a3, a4);

            var qLText4 = "Where does literature originate from?";
            var literatureQ4 = this.factory.CreateNormalQuestion(qLText4, DifficultyLevel.Easy, CategoryType.Literature);

            a1 = this.factory.CreateAnswer("Sumerian Civilization", true);
            a2 = this.factory.CreateAnswer("Egyptian Civilization", false);
            a3 = this.factory.CreateAnswer("Chinese Civilization", false);
            a4 = this.factory.CreateAnswer("Japanese Civilization", false);

            AddQuestion(literatureQ4, a1, a2, a3, a4);
        }

        private void EasyScienceQuestions()
        {
            var qSciText1 = "How many forces of nature,known to man, exist in the universe?";
            var scienceQ1 = this.factory.CreateNormalQuestion(qSciText1, DifficultyLevel.Easy, CategoryType.Science);

            var a1 = this.factory.CreateAnswer("3", false);
            var a2 = this.factory.CreateAnswer("5", false);
            var a3 = this.factory.CreateAnswer("4", true);
            var a4 = this.factory.CreateAnswer("6", false);

            AddQuestion(scienceQ1, a1, a2, a3, a4);

            var qSciText2 = "How many nuclear processes exist?";
            var scienceQ2 = this.factory.CreateNormalQuestion(qSciText2, DifficultyLevel.Easy, CategoryType.Science);

            a1 = this.factory.CreateAnswer("2", true);
            a2 = this.factory.CreateAnswer("4", false);
            a3 = this.factory.CreateAnswer("9", false);
            a4 = this.factory.CreateAnswer("6", false);

            AddQuestion(scienceQ2, a1, a2, a3, a4);

            var qSciText3 = "What is a quasar?";
            var scienceQ3 = this.factory.CreateNormalQuestion(qSciText3, DifficultyLevel.Easy, CategoryType.Science);

            a1 = this.factory.CreateAnswer("An active black hole", true);
            a2 = this.factory.CreateAnswer("A type of star", true);
            a3 = this.factory.CreateAnswer("Type of galaxy", false);
            a4 = this.factory.CreateAnswer("A particle of dark matter", false);

            AddQuestion(scienceQ3, a1, a2, a3, a4);

            var qSciText4 = "Which one of the following stars has the most amount of mass and energy?";
            var scienceQ4 = this.factory.CreateNormalQuestion(qSciText4, DifficultyLevel.Easy, CategoryType.Science);

            a1 = this.factory.CreateAnswer("Neutron star", false);
            a2 = this.factory.CreateAnswer("Blue star", true);
            a3 = this.factory.CreateAnswer("Red giant", false);
            a4 = this.factory.CreateAnswer("Main sequence star", false);

            AddQuestion(scienceQ4, a1, a2, a3, a4);
        }

        private void EasyGeographyQuestions()
        {
            var qGText1 = "What is the height of Mount Kilimanjaro?";
            var geographyQ1 = this.factory.CreateNormalQuestion(qGText1, DifficultyLevel.Easy, CategoryType.Geography);

            var a1 = this.factory.CreateAnswer("4986", false);
            var a2 = this.factory.CreateAnswer("7120", false);
            var a3 = this.factory.CreateAnswer("6412", false);
            var a4 = this.factory.CreateAnswer("5895", true);

            AddQuestion(geographyQ1, a1, a2, a3, a4);

            var qGText2 = "How many mountains over 8000 meters of height exists on the planet Earth?";
            var geographyQ2 = this.factory.CreateNormalQuestion(qGText2, DifficultyLevel.Easy, CategoryType.Geography);

            a1 = this.factory.CreateAnswer("27", false);
            a2 = this.factory.CreateAnswer("113", false);
            a3 = this.factory.CreateAnswer("14", true);
            a4 = this.factory.CreateAnswer("1", false);

            AddQuestion(geographyQ2, a1, a2, a3, a4);

            var qGText3 = "How many potentially active volcanoes exist worldwide?";
            var geographyQ3 = this.factory.CreateNormalQuestion(qGText3, DifficultyLevel.Easy, CategoryType.Geography);

            a1 = this.factory.CreateAnswer("19", false);
            a2 = this.factory.CreateAnswer("714", false);
            a3 = this.factory.CreateAnswer("Over 2502", false);
            a4 = this.factory.CreateAnswer("1500", true);

            AddQuestion(geographyQ3, a1, a2, a3, a4);

            var qGText4 = "What is the total number of tectonic plates found on our planet until this point?";
            var geographyQ4 = this.factory.CreateNormalQuestion(qGText4, DifficultyLevel.Easy, CategoryType.Geography);

            a1 = this.factory.CreateAnswer("13", false);
            a2 = this.factory.CreateAnswer("32", false);
            a3 = this.factory.CreateAnswer("7", true);
            a4 = this.factory.CreateAnswer("4", false);

            AddQuestion(geographyQ4, a1, a2, a3, a4);
        }

        private void EasyRandomQuestions()
        {
            var qRText1 = "Pluto is a";
            var randomQ1 = this.factory.CreateNormalQuestion(qRText1, DifficultyLevel.Easy, CategoryType.Random);

            var a1 = this.factory.CreateAnswer("Planet", false);
            var a2 = this.factory.CreateAnswer("Dwarf Planet", true);
            var a3 = this.factory.CreateAnswer("Exoplanet", false);
            var a4 = this.factory.CreateAnswer("An alien space testicle", false);

            AddQuestion(randomQ1, a1, a2, a3, a4);

            var qRText2 = "Why is it hard for programmers to learn Java? /n \"Because they can't: \"";
            var randomQ2 = this.factory.CreateNormalQuestion(qRText2, DifficultyLevel.Easy, CategoryType.Random);

            a1 = this.factory.CreateAnswer("JavaScript", false);
            a2 = this.factory.CreateAnswer("Use glasses correctly", false);
            a3 = this.factory.CreateAnswer("Use thier Python", false);
            a4 = this.factory.CreateAnswer("C#", true);

            AddQuestion(randomQ2, a1, a2, a3, a4);

            var qRText3 = "How many programming languages exist in today's world";
            var randomQ3 = this.factory.CreateNormalQuestion(qRText3, DifficultyLevel.Easy, CategoryType.Random);

            a1 = this.factory.CreateAnswer("25", false);
            a2 = this.factory.CreateAnswer("96", false);
            a3 = this.factory.CreateAnswer("Over 200", false);
            a4 = this.factory.CreateAnswer("Over 9000", false);

            AddQuestion(randomQ3, a1, a2, a3, a4);

            var qRText4 = "What was Michael Jackson's most prominent stage line?";
            var randomQ4 = this.factory.CreateNormalQuestion(qRText4, DifficultyLevel.Easy, CategoryType.Random);

            a1 = this.factory.CreateAnswer("Shamone-aa", true);
            a2 = this.factory.CreateAnswer("Hee Hee", false);
            a3 = this.factory.CreateAnswer("Oooh Yeah", false);
            a4 = this.factory.CreateAnswer("Ooh Ooh", false);

            AddQuestion(randomQ4, a1, a2, a3, a4);
        }

        // NORMAL
        //todo
        private void NormalMathQuestions()
        {
            CreateQuestion("Normal math question 1", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Math, DifficultyLevel.Normal);
            CreateQuestion("Normal math question 2", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Math, DifficultyLevel.Normal);
            CreateQuestion("Normal math question 3", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Math, DifficultyLevel.Normal);
            CreateQuestion("Normal math question 4", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Math, DifficultyLevel.Normal);
        }

        //todo
        private void NormalHistoryQuestions()
        {
            CreateQuestion("Which civilization had the longest lasting ruling dynasty?", new[] { "Egypt", "False" }, new[] { "China", "False" }, new[] { "Japan", "True" }, new[] { "Rome", "False" }, CategoryType.History, DifficultyLevel.Normal);
            //TODO Rest
            CreateQuestion("Normal history question 2", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.History, DifficultyLevel.Normal);
            CreateQuestion("Normal history question 3", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.History, DifficultyLevel.Normal);
            CreateQuestion("Normal history question 4", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.History, DifficultyLevel.Normal);
        }

        //todo
        private void NormalSciFiQuestions()
        {
            CreateQuestion("Normal sci-fi question 1", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.SciFi, DifficultyLevel.Normal);
            CreateQuestion("Normal sci-fi question 2", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.SciFi, DifficultyLevel.Normal);
            CreateQuestion("Normal sci-fi question 3", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.SciFi, DifficultyLevel.Normal);
            CreateQuestion("Normal sci-fi question 4", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.SciFi, DifficultyLevel.Normal);
        }

        //todo
        private void NormalMovieQuestions()
        {
            CreateQuestion("Normal movie question 1", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Movies, DifficultyLevel.Normal);
            CreateQuestion("Normal movie question 2", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Movies, DifficultyLevel.Normal);
            CreateQuestion("Normal movie question 3", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Movies, DifficultyLevel.Normal);
            CreateQuestion("Normal movie question 4", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Movies, DifficultyLevel.Normal);
        }

        //todo
        private void NormalLiteratureQuestions()
        {
            CreateQuestion("Normal literature question 1", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Literature, DifficultyLevel.Normal);
            CreateQuestion("Normal literature question 2", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Literature, DifficultyLevel.Normal);
            CreateQuestion("Normal literature question 3", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Literature, DifficultyLevel.Normal);
            CreateQuestion("Normal literature question 4", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Literature, DifficultyLevel.Normal);
        }

        //todo
        private void NormalScienceQuestions()
        {
            CreateQuestion("Normal science question 1", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Science, DifficultyLevel.Normal);
            CreateQuestion("Normal science question 2", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Science, DifficultyLevel.Normal);
            CreateQuestion("Normal science question 3", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Science, DifficultyLevel.Normal);
            CreateQuestion("Normal science question 4", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Science, DifficultyLevel.Normal);
        }

        //todo
        private void NormalGeographyQuestions()
        {
            CreateQuestion("How high is the highest volcano found on Mars up to this point in human history?", new[] { "21.2 km", "True" }, new[] { "16.1 km", "False" }, new[] { "18.2 km", "False" }, new[] { "19.6 km", "False" }, CategoryType.Geography, DifficultyLevel.Normal);
            //TODO Rest
            CreateQuestion("Normal geography question 2", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Geography, DifficultyLevel.Normal);
            CreateQuestion("Normal geography question 3", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Geography, DifficultyLevel.Normal);
            CreateQuestion("Normal geography question 4", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Geography, DifficultyLevel.Normal);
        }

        private void NormalRandomQuestions()
        {
            AnswerHolder an1;
            AnswerHolder an2;
            AnswerHolder an3;
            AnswerHolder an4;

            an1.text = "An infection";
            an1.isCorrect = false;
            an2.text = "He turns into a zombie";
            an2.isCorrect = false;
            an3.text = "Candy";
            an3.isCorrect = false;
            an4.text = "Frostbite";
            an4.isCorrect = true;
            var qRText5 = "What does one get, after getting bitten by a zombie during the winter";
            CreateQuestion(qRText5, an1, an2, an3, an4, CategoryType.Random, DifficultyLevel.Normal);

            an1.text = "\"get down\"";
            an1.isCorrect = false;
            an2.text = "\"climb down\"";
            an2.isCorrect = false;
            an3.text = "\"fly\"";
            an3.isCorrect = false;
            an4.text = "\"off\"";
            an4.isCorrect = true;
            var qRText6 = "Complete the following sentence: \"If your uncle Jack was stuck on the roof, would you help your uncle Jack...?\"";
            CreateQuestion(qRText6, an1, an2, an3, an4, CategoryType.Random, DifficultyLevel.Normal);

            an1.text = "With an army";
            an1.isCorrect = false;
            an2.text = "Using albanians";
            an2.isCorrect = false;
            an3.text = "With a spear(s kopie)";
            an3.isCorrect = false;
            an4.text = "Manipulating gypsy revolts";
            an4.isCorrect = true;
            var qRText7 = "How does one annex the capital of Macedonia?";
            CreateQuestion(qRText7, an1, an2, an3, an4, CategoryType.Random, DifficultyLevel.Normal);

            an1.text = "Juan Carlos";
            an1.isCorrect = true;
            an2.text = "Julio";
            an2.isCorrect = false;
            an3.text = "Antonio";
            an3.isCorrect = false;
            an4.text = "Banderas";
            an4.isCorrect = false;
            var qRText8 = "What is the name of a Spanish person that lost his car?";
            CreateQuestion(qRText8, an1, an2, an3, an4, CategoryType.Random, DifficultyLevel.Normal);
        }

        // HARD
        //todo
        private void HardMathQuestions()
        {
            CreateQuestion("Hard math question 1", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Math, DifficultyLevel.Hard);
            CreateQuestion("Hard math question 2", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Math, DifficultyLevel.Hard);
            CreateQuestion("Hard math question 3", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Math, DifficultyLevel.Hard);
            CreateQuestion("Hard math question 4", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Math, DifficultyLevel.Hard);
        }

        //todo
        private void HardHistoryQuestions()
        {
            CreateQuestion("Hard history question 1", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.History, DifficultyLevel.Hard);
            CreateQuestion("Hard history question 2", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.History, DifficultyLevel.Hard);
            CreateQuestion("Hard history question 3", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.History, DifficultyLevel.Hard);
            CreateQuestion("Hard history question 4", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.History, DifficultyLevel.Hard);
        }

        //todo
        private void HardSciFiQuestions()
        {
            CreateQuestion("Hard sci-fi question 1", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.SciFi, DifficultyLevel.Hard);
            CreateQuestion("Hard sci-fi question 2", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.SciFi, DifficultyLevel.Hard);
            CreateQuestion("Hard sci-fi question 3", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.SciFi, DifficultyLevel.Hard);
            CreateQuestion("Hard sci-fi question 4", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.SciFi, DifficultyLevel.Hard);
        }

        //todo
        private void HardMovieQuestions()
        {
            CreateQuestion("Hard movie question 1", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Movies, DifficultyLevel.Hard);
            CreateQuestion("Hard movie question 2", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Movies, DifficultyLevel.Hard);
            CreateQuestion("Hard movie question 3", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Movies, DifficultyLevel.Hard);
            CreateQuestion("Hard movie question 4", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Movies, DifficultyLevel.Hard);
        }

        //todo
        private void HardLiteratureQuestions()
        {
            CreateQuestion("Hard literature question 1", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Literature, DifficultyLevel.Hard);
            CreateQuestion("Hard literature question 2", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Literature, DifficultyLevel.Hard);
            CreateQuestion("Hard literature question 3", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Literature, DifficultyLevel.Hard);
            CreateQuestion("Hard literature question 4", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Literature, DifficultyLevel.Hard);
        }

        //todo
        private void HardScienceQuestions()
        {
            CreateQuestion("Hard science question 1", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Science, DifficultyLevel.Hard);
            CreateQuestion("Hard science question 2", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Science, DifficultyLevel.Hard);
            CreateQuestion("Hard science question 3", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Science, DifficultyLevel.Hard);
            CreateQuestion("Hard science question 4", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Science, DifficultyLevel.Hard);
        }

        //todo
        private void HardGeographyQuestions()
        {
            CreateQuestion("Hard geography question 1", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Geography, DifficultyLevel.Hard);
            CreateQuestion("Hard geography question 2", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Geography, DifficultyLevel.Hard);
            CreateQuestion("Hard geography question 3", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Geography, DifficultyLevel.Hard);
            CreateQuestion("Hard geography question 4", new[] { "a1", "True" }, new[] { "a2", "False" }, new[] { "a3", "False" }, new[] { "a4", "False" }, CategoryType.Geography, DifficultyLevel.Hard);
        }

        private void HardRandomQuestions()
        {
            var qRText9 = "How many mexicans does it take to change a light bulb?";
            var randomQ9 = this.factory.CreateNormalQuestion(qRText9, DifficultyLevel.Normal, CategoryType.Random);

            var a1 = this.factory.CreateAnswer("Juan Carlos", true);
            var a2 = this.factory.CreateAnswer("Julio", false);
            var a3 = this.factory.CreateAnswer("Antonio", false);
            var a4 = this.factory.CreateAnswer("Banderas", false);

            AddQuestion(randomQ9, a1, a2, a3, a4);

            var qRText10 = "What does an angry russian say when his internet stops?";
            var randomQ10 = this.factory.CreateNormalQuestion(qRText10, DifficultyLevel.Normal, CategoryType.Random);

            a1 = this.factory.CreateAnswer("Davai", false);
            a2 = this.factory.CreateAnswer("Suka", false);
            a3 = this.factory.CreateAnswer("Blyat", false);
            a4 = this.factory.CreateAnswer("Inter?Net!", true);

            AddQuestion(randomQ10, a1, a2, a3, a4);

            var qRText11 = "What is the name of the most famous Japanese businessman?";
            var randomQ11 = this.factory.CreateNormalQuestion(qRText11, DifficultyLevel.Hard, CategoryType.Random);

            a1 = this.factory.CreateAnswer("Narekata Sigosushi", false);
            a2 = this.factory.CreateAnswer("Nasakoto Yakata", true);
            a3 = this.factory.CreateAnswer("Kradesi Parata", false);
            a4 = this.factory.CreateAnswer("Krosheto Srykata", false);

            AddQuestion(randomQ11, a1, a2, a3, a4);

            var qRText12 = "What is considered as the most significant benefit from making the gym a part of one's life?";
            var randomQ12 = this.factory.CreateNormalQuestion(qRText12, DifficultyLevel.Hard, CategoryType.Random);

            a1 = this.factory.CreateAnswer("Healthy metabolism", false);
            a2 = this.factory.CreateAnswer("Discipline and consistency", true);
            a3 = this.factory.CreateAnswer("Good looking body", false);
            a4 = this.factory.CreateAnswer("Denser and stronger muscle tissuejhu", false);

            AddQuestion(randomQ12, a1, a2, a3, a4);

            var qRText13 = "How many mexicans does it take to change a light bulb?";
            var randomQ13 = this.factory.CreateNormalQuestion(qRText13, DifficultyLevel.Hard, CategoryType.Random);

            a1 = this.factory.CreateAnswer("Three", false);
            a2 = this.factory.CreateAnswer("Four", false);
            a3 = this.factory.CreateAnswer("Two", false);
            a4 = this.factory.CreateAnswer("Juan", true);

            AddQuestion(randomQ13, a1, a2, a3, a4);

            var qRText14 = "What is the favorite type of alcohol of skiers?";
            var randomQ14 = this.factory.CreateNormalQuestion(qRText14, DifficultyLevel.Hard, CategoryType.Random);

            a1 = this.factory.CreateAnswer("Vodka", false);
            a2 = this.factory.CreateAnswer("Tequila", false);
            a3 = this.factory.CreateAnswer("WhiSki", true);
            a4 = this.factory.CreateAnswer("Kornbrause", false);

            AddQuestion(randomQ14, a1, a2, a3, a4);

            var qRText15 = "What do you say to a person named Dimitar when you meet him for the first time?";
            var randomQ15 = this.factory.CreateNormalQuestion(qRText15, DifficultyLevel.Hard, CategoryType.Random);

            a1 = this.factory.CreateAnswer("Hello", false);
            a2 = this.factory.CreateAnswer("Willkommen", false);
            a3 = this.factory.CreateAnswer("Nice to Mitio", true);
            a4 = this.factory.CreateAnswer("Denser and stronger muscle tissuejhu", false);

            AddQuestion(randomQ15, a1, a2, a3, a4);
        }

        private void CreateQuestion(string text, string[] answer1, string[] answer2, string[] answer3, string[] answer4, CategoryType type, DifficultyLevel level)
        {
            IQuestion q = null;

            switch (level)
            {
                case DifficultyLevel.Easy:
                    q = this.factory.CreateNormalQuestion(text, DifficultyLevel.Easy, type);
                    break;
                case DifficultyLevel.Normal:
                    q = this.factory.CreateNormalQuestion(text, DifficultyLevel.Normal, type);
                    break;
                case DifficultyLevel.Hard:
                    q = this.factory.CreateNormalQuestion(text, DifficultyLevel.Hard, type);
                    break;
                default:
                    break;
            }

            var a1 = this.factory.CreateAnswer(answer1[0], bool.Parse(answer1[1]));
            var a2 = this.factory.CreateAnswer(answer2[0], bool.Parse(answer2[1]));
            var a3 = this.factory.CreateAnswer(answer3[0], bool.Parse(answer3[1]));
            var a4 = this.factory.CreateAnswer(answer4[0], bool.Parse(answer4[1]));

            AddQuestion(q, a1, a2, a3, a4);
        }

        private void CreateQuestion(string text, AnswerHolder answer1, AnswerHolder answer2, AnswerHolder answer3, AnswerHolder answer4, CategoryType type, DifficultyLevel level)
        {
            IQuestion q = null;

            switch (level)
            {
                case DifficultyLevel.Easy:
                    q = this.factory.CreateNormalQuestion(text, DifficultyLevel.Easy, type);
                    break;
                case DifficultyLevel.Normal:
                    q = this.factory.CreateNormalQuestion(text, DifficultyLevel.Normal, type);
                    break;
                case DifficultyLevel.Hard:
                    q = this.factory.CreateNormalQuestion(text, DifficultyLevel.Hard, type);
                    break;
                default:
                    break;
            }

            var a1 = this.factory.CreateAnswer(answer1.text, answer1.isCorrect);
            var a2 = this.factory.CreateAnswer(answer2.text, answer2.isCorrect);
            var a3 = this.factory.CreateAnswer(answer3.text, answer3.isCorrect);
            var a4 = this.factory.CreateAnswer(answer4.text, answer4.isCorrect);

            AddQuestion(q, a1, a2, a3, a4);
        }

        private void AddQuestion(IQuestion question, IAnswer answer1, IAnswer answer2, IAnswer answer3, IAnswer answer4)
        {
            question.AddAnswer(answer1);
            question.AddAnswer(answer2);
            question.AddAnswer(answer3);
            question.AddAnswer(answer4);

            this.categories.Single(x => x.CategoryType == question.CategoryType).AddQuestion(question);
        }

    }
}
