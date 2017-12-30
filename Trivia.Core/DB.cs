using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Contracts;
using Trivia.Core.Contracts;
using Trivia.Common.Enums;
using Trivia.Models.Question;
using Trivia.Models.Category;

namespace Trivia.Core
{
    public class DB
    {
        private IList<ICategory> categories;
        private readonly IFactory factory;

        public DB(IFactory factory)
        {
            this.categories = new List<ICategory>();
            this.factory = factory;
            this.PopulateCategories();
            this.PopulateQuestions();
        }

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

            // Uncomment when all difficulty questions are implemented

            //var normalQuestionIndices = GetRandomIndices(selectedCategory.NormalQuestions.Count, numOfQuestions);

            //foreach (var index in normalQuestionIndices)
            //{
            //    uniqueQuestionsList.Add(selectedCategory.NormalQuestions[index]);
            //}

            //var hardQuestionIndices = GetRandomIndices(selectedCategory.HardQuestions.Count, numOfQuestions);

            //foreach (var index in hardQuestionIndices)
            //{
            //    uniqueQuestionsList.Add(selectedCategory.HardQuestions[index]);
            //}

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
            // TO DO completed
            // Added categories for all types of questions

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
            // Math questions
            // easy difficulty questions
            var qMText1 = "How many digits are there in total in the number \"pi\"? ";
            var mathQ1 = this.factory.CreateNormalQuestion(qMText1, DifficultyLevel.Easy, CategoryType.Math);

            var a1 = this.factory.CreateAnswer("1.2 trillion", false);
            var a2 = this.factory.CreateAnswer("1.9 trillion", false);
            var a3 = this.factory.CreateAnswer("2.7 trillion", true);
            var a4 = this.factory.CreateAnswer("3.4 trillion", false);

            AddQuestion(mathQ1, a1, a2, a3, a4);

            var qMText2 = "How many zeroes are behind the number known as \"Googolplex\"?";
            var mathQ2 = this.factory.CreateNormalQuestion(qMText2, DifficultyLevel.Easy, CategoryType.Math);

            a1 = this.factory.CreateAnswer("100", false);
            a2 = this.factory.CreateAnswer("1000", false);
            a3 = this.factory.CreateAnswer("10000", true);
            a4 = this.factory.CreateAnswer("100000", false);

            AddQuestion(mathQ2, a1, a2, a3, a4);

            var qMText3 = "Which type of Mathematics is mostly used in nowadays' world?";
            var mathQ3 = this.factory.CreateNormalQuestion(qMText3, DifficultyLevel.Easy, CategoryType.Math);

            a1 = this.factory.CreateAnswer("Applied Mathematics", true);
            a2 = this.factory.CreateAnswer("Mathematical Physics", false);
            a3 = this.factory.CreateAnswer("Combinatorics", false);
            a4 = this.factory.CreateAnswer("Pure Mathematics", false);

            AddQuestion(mathQ3, a1, a2, a3, a4);

            var qMText4 = "Who invented Mathematics?";
            var mathQ4 = this.factory.CreateNormalQuestion(qMText4, DifficultyLevel.Easy, CategoryType.Math);

            a1 = this.factory.CreateAnswer("Pythagoras", false);
            a2 = this.factory.CreateAnswer("Plato", false);
            a3 = this.factory.CreateAnswer("Aristotle", false);
            a4 = this.factory.CreateAnswer("Math wasn't invented", true);

            AddQuestion(mathQ4, a1, a2, a3, a4);
            // History questions
            // easy difficulty questions

            var qHText1 = "Which was the first civilization to ever arise?";
            var historyQ1 = this.factory.CreateNormalQuestion(qHText1, DifficultyLevel.Easy, CategoryType.History);

            a1 = this.factory.CreateAnswer("Sumerian", true);
            a2 = this.factory.CreateAnswer("Egyptian", false);
            a3 = this.factory.CreateAnswer("Harappan", false);
            a4 = this.factory.CreateAnswer("Chinese", false);

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

            // normal difficulty

            var qHText5 = "Which civilization had the longest lasting ruling dynasty?";
            var historyQ5 = this.factory.CreateNormalQuestion(qHText5, DifficultyLevel.Normal, CategoryType.History);

            a1 = this.factory.CreateAnswer("Egypt", false);
            a2 = this.factory.CreateAnswer("China", false);
            a3 = this.factory.CreateAnswer("Japan", true);
            a4 = this.factory.CreateAnswer("Rome", false);

            AddQuestion(historyQ5, a1, a2, a3, a4);

            // Sci-Fi
            // easy difficulty
            var qSFText1 = "Which of the following futuristics weapons is currently a prototype and used in real millitary operations to some extent?";
            var sciFiQ1 = this.factory.CreateNormalQuestion(qSFText1, DifficultyLevel.Easy, CategoryType.SciFi);

            a1 = this.factory.CreateAnswer("Railgun", true);
            a2 = this.factory.CreateAnswer("Plasma Rifle", false);
            a3 = this.factory.CreateAnswer("Gravity Gun", false);
            a4 = this.factory.CreateAnswer("Laser Rifle", false);

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

            // Movies
            // easy

            var qMoText1 = "In which year was the first movie ever filmed?";
            var moviesQ1 = this.factory.CreateNormalQuestion(qMoText1, DifficultyLevel.Easy, CategoryType.Movies);

            a1 = this.factory.CreateAnswer("1904", false);
            a2 = this.factory.CreateAnswer("1883", false);
            a3 = this.factory.CreateAnswer("1888", true);
            a4 = this.factory.CreateAnswer("1897", false);

            AddQuestion(moviesQ1, a1, a2, a3, a4);

            var qMoText2 = "The first movie directed had which one of the following genres:";
            var moviesQ2 = this.factory.CreateNormalQuestion(qMoText2, DifficultyLevel.Easy, CategoryType.Movies);

            a1 = this.factory.CreateAnswer("Drama", false);
            a2 = this.factory.CreateAnswer("Action", false);
            a3 = this.factory.CreateAnswer("Sound Film", false);
            a4 = this.factory.CreateAnswer("Indie Film", true);

            AddQuestion(moviesQ2, a1, a2, a3, a4);

            var qMoText3 = "What is the name of the first actor in movie history?";
            var moviesQ3 = this.factory.CreateNormalQuestion(qMoText3, DifficultyLevel.Easy, CategoryType.Movies);

            a1 = this.factory.CreateAnswer("Florence Lawrence", true);
            a2 = this.factory.CreateAnswer("Scott Smith", false);
            a3 = this.factory.CreateAnswer("Holly Wood", false);
            a4 = this.factory.CreateAnswer("Last Vegan", false);
            // Last Vegan mi hrumna ot Las Vegas kato ime, ne znam zashto, dobyr komentar, chao
            AddQuestion(moviesQ3, a1, a2, a3, a4);

            var qMoText4 = "What is the name of the first camera ever used in filming?";
            var moviesQ4 = this.factory.CreateNormalQuestion(qMoText4, DifficultyLevel.Easy, CategoryType.Movies);

            a1 = this.factory.CreateAnswer("Canon", false);
            a2 = this.factory.CreateAnswer("Divex", false);
            a3 = this.factory.CreateAnswer("Kodak", true);
            a4 = this.factory.CreateAnswer("Flash", false);

            AddQuestion(moviesQ4, a1, a2, a3, a4);

            // Literature
            // le easy

            var qLText1 = "Which of the following authors inspired the following words \"The world's a stage, and we are but the actors.\"?";
            var literatureQ1 = this.factory.CreateNormalQuestion(qLText1, DifficultyLevel.Easy, CategoryType.Literature);

            a1 = this.factory.CreateAnswer("Mark Twain", false);
            a2 = this.factory.CreateAnswer("William Shakespeare", true);
            a3 = this.factory.CreateAnswer("Sir Arthur Conan Doyle", false);
            a4 = this.factory.CreateAnswer("Doktor Radeva", false);

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

            // Science
            // ez

            var qSciText1 = "How many forces of nature,known to man, exist in the universe?";
            var scienceQ1 = this.factory.CreateNormalQuestion(qSciText1, DifficultyLevel.Easy, CategoryType.Science);

            a1 = this.factory.CreateAnswer("3", false);
            a2 = this.factory.CreateAnswer("5", false);
            a3 = this.factory.CreateAnswer("4", true);
            a4 = this.factory.CreateAnswer("6", false);

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
            // Geography questions
            // easy questions

            var qGText1 = "What is the height of Mount Kilimanjaro?";
            var geographyQ1 = this.factory.CreateNormalQuestion(qGText1, DifficultyLevel.Easy, CategoryType.Geography);

            a1 = this.factory.CreateAnswer("4986", false);
            a2 = this.factory.CreateAnswer("7120", false);
            a3 = this.factory.CreateAnswer("6412", false);
            a4 = this.factory.CreateAnswer("5895", true);

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

            var qGText5 = "How high is the highest volcano found on Mars up to this point in human history?";
            var geographyQ5 = this.factory.CreateNormalQuestion(qGText5, DifficultyLevel.Normal, CategoryType.Geography);

            a1 = this.factory.CreateAnswer("21.2 km", true);
            a2 = this.factory.CreateAnswer("16.1 km", false);
            a3 = this.factory.CreateAnswer("18.2 km", false);
            a4 = this.factory.CreateAnswer("19.6 km", false);

            AddQuestion(geographyQ5, a1, a2, a3, a4);

            // random
            // easy

            var qRText1 = "Pluto is a";
            var randomQ1 = this.factory.CreateNormalQuestion(qRText1, DifficultyLevel.Easy, CategoryType.Random);

            a1 = this.factory.CreateAnswer("Planet", false);
            a2 = this.factory.CreateAnswer("Dwarf Planet", true);
            a3 = this.factory.CreateAnswer("Exoplanet", false);
            a4 = this.factory.CreateAnswer("An alien space testicle", false);

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

            // normal

            var qRText5 = "What does one get, after getting bitten by a zombie during the winter";
            var randomQ5 = this.factory.CreateNormalQuestion(qRText5, DifficultyLevel.Easy, CategoryType.Random);

            a1 = this.factory.CreateAnswer("An infection", false);
            a2 = this.factory.CreateAnswer("He turns into a zombie", false);
            a3 = this.factory.CreateAnswer("Candy", false);
            a4 = this.factory.CreateAnswer("Frostbite", true);

            AddQuestion(randomQ5, a1, a2, a3, a4);

            var qRText6 = "Complete the following sentence: \"If your uncle Jack was stuck on the roof, would you help your uncle Jack...?\"";
            var randomQ6 = this.factory.CreateNormalQuestion(qRText6, DifficultyLevel.Normal, CategoryType.Random);

            a1 = this.factory.CreateAnswer("\"get down\"", false);
            a2 = this.factory.CreateAnswer("\"climb down\"", false);
            a3 = this.factory.CreateAnswer("\"fly\"", false);
            a4 = this.factory.CreateAnswer("\"off\"", true);

            AddQuestion(randomQ6, a1, a2, a3, a4);

            var qRText7 = "How does one annex the capital of Macedonia?";
            var randomQ7 = this.factory.CreateNormalQuestion(qRText7, DifficultyLevel.Normal, CategoryType.Random);

            a1 = this.factory.CreateAnswer("With an army", false);
            a2 = this.factory.CreateAnswer("Using albanians", false);
            a3 = this.factory.CreateAnswer("With a spear(s kopie)", true);
            a4 = this.factory.CreateAnswer("Manipulating gypsy revolts", true);

            AddQuestion(randomQ7, a1, a2, a3, a4);

            var qRText8 = "What is the name of a Spanish person that lost his car?";
            var randomQ8 = this.factory.CreateNormalQuestion(qRText8, DifficultyLevel.Normal, CategoryType.Random);

            a1 = this.factory.CreateAnswer("Juan Carlos", true);
            a2 = this.factory.CreateAnswer("Julio", false);
            a3 = this.factory.CreateAnswer("Antonio", false);
            a4 = this.factory.CreateAnswer("Banderas", false);

            AddQuestion(randomQ8, a1, a2, a3, a4);

            // very many hard

            var qRText9 = "How many mexicans does it take to change a light bulb?";
            var randomQ9 = this.factory.CreateNormalQuestion(qRText9, DifficultyLevel.Normal, CategoryType.Random);

            a1 = this.factory.CreateAnswer("Juan Carlos", true);
            a2 = this.factory.CreateAnswer("Julio", false);
            a3 = this.factory.CreateAnswer("Antonio", false);
            a4 = this.factory.CreateAnswer("Banderas", false);

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
            // ===TODO - REPEAT above template for all questions==
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
