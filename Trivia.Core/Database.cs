using System;
using System.Collections.Generic;
using System.Linq;
using Trivia.Common.Enums;
using Trivia.Contracts;
using Trivia.Core.Contracts;

namespace Trivia.Core
{
    public class Database : IDatabase
    {
        private IList<ICategory> categories;
        private readonly IFactory factory;

        public Database(IFactory factory)
        {
            this.factory = factory;
            this.categories = new List<ICategory>();
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

            AddQuestion(sciFiQ2, a1, a2, a3, a4);

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
            CreateQuestion("In the movie 'The Wizard of Oz', what did the Scarecrow want from the wizard?", new[] { "Brain", "True" }, new[] { "Heart", "False" }, new[] { "Eyes", "False" }, new[] { "Soul", "False" }, CategoryType.Movies, DifficultyLevel.Easy);
            CreateQuestion("In what year was the original 'Jurassic Park' film released?", new[] { "1991", "False" }, new[] { "1993", "True" }, new[] { "1992", "False" }, new[] { "1980", "False" }, CategoryType.Movies, DifficultyLevel.Easy);
            CreateQuestion("What planet is the superhero, 'Superman', from?", new[] { "Pluto", "False" }, new[] { "Mars", "False" }, new[] { "Krypton", "True" }, new[] { "Jupiter", "False" }, CategoryType.Movies, DifficultyLevel.Easy);
            CreateQuestion("What city is the home of Batman?", new[] { "New York", "False" }, new[] { "Chicago", "False" }, new[] { "Gotham City", "True" }, new[] { "Quebec City", "False" }, CategoryType.Movies, DifficultyLevel.Easy);
        }

        private void EasyLiteratureQuestions()
        {
            var qLText1 = "Who wrote \"The Great Gatsby\"?";
            var literatureQ1 = this.factory.CreateNormalQuestion(qLText1, DifficultyLevel.Easy, CategoryType.Literature);

            var a1 = this.factory.CreateAnswer("Mark Twain", false);
            var a2 = this.factory.CreateAnswer("F. Scott Fitzgerald", true);
            var a3 = this.factory.CreateAnswer("Sir Arthur Conan Doyle", false);
            var a4 = this.factory.CreateAnswer("Ernest Hemingway", false);

            AddQuestion(literatureQ1, a1, a2, a3, a4);

            var qLText2 = "Where do Haiku poems originate from?";
            var literatureQ2 = this.factory.CreateNormalQuestion(qLText2, DifficultyLevel.Easy, CategoryType.Literature);

            a1 = this.factory.CreateAnswer("Korea", false);
            a2 = this.factory.CreateAnswer("China", false);
            a3 = this.factory.CreateAnswer("Mongolia", false);
            a4 = this.factory.CreateAnswer("Japan", true);

            AddQuestion(literatureQ2, a1, a2, a3, a4);

            var qLText3 = "Which one of the following is not a symbolist poet?";
            var literatureQ3 = this.factory.CreateNormalQuestion(qLText3, DifficultyLevel.Easy, CategoryType.Literature);

            a1 = this.factory.CreateAnswer("Paul Verlaine", false);
            a2 = this.factory.CreateAnswer("Arthur Rimbaud", false);
            a3 = this.factory.CreateAnswer("Raul Brandão", false);
            a4 = this.factory.CreateAnswer("Jacques Prévert", true);

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
            var qSciText1 = "How many forces of nature, known to man, exist in the universe?";
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

            var qGText2 = "How many mountains over 8000 meters of height exist on the planet Earth?";
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

            var qRText2 = "Why is it hard for programmers to learn Java? \n \"Because they can't: \"";
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
        private void NormalMathQuestions()
        {
            CreateQuestion("Find the value of x, if x = (2 × 3) + 11?", new[] { "55", "False" }, new[] { "24", "False" }, new[] { "17", "True" }, new[] { "45", "False" }, CategoryType.Math, DifficultyLevel.Normal);
            CreateQuestion("What is the smallest three digit number?", new[] { "101", "False" }, new[] { "100", "True" }, new[] { "999", "False" }, new[] { "111", "False" }, CategoryType.Math, DifficultyLevel.Normal);
            CreateQuestion("If a number has an even number or zero at its unit place, the number is always divisible by...?", new[] { "4", "False" }, new[] { "5", "False" }, new[] { "10", "False" }, new[] { "2", "True" }, CategoryType.Math, DifficultyLevel.Normal);
            CreateQuestion("20 is divisible by...?", new[] { "1", "True" }, new[] { "3", "False" }, new[] { "7", "False" }, new[] { "None of these", "False" }, CategoryType.Math, DifficultyLevel.Normal);
        }

        private void NormalHistoryQuestions()
        {
            CreateQuestion("Which civilization had the longest lasting ruling dynasty?", new[] { "Egypt", "False" }, new[] { "China", "False" }, new[] { "Japan", "True" }, new[] { "Rome", "False" }, CategoryType.History, DifficultyLevel.Normal);
            CreateQuestion("What is the name of the scandal that forced US President Richard Nixon to resign?", new[] { "Vietnam", "False" }, new[] { "Panama papers", "False" }, new[] { "Checkers", "False" }, new[] { "Watergate", "True" }, CategoryType.History, DifficultyLevel.Normal);
            CreateQuestion("What 1969 computer milestone would radically alter the course of human history?", new[] { "The creation of the Internet", "True" }, new[] { "Creation of the first online porn site", "False" }, new[] { "The invention of the iPod", "False" }, new[] { "The first PC", "False" }, CategoryType.History, DifficultyLevel.Normal);
            CreateQuestion("What series of wars saw European Christians invading the middle east to retake the Holy Land?", new[] { "Punic Wars", "False" }, new[] { "The French Revolution", "False" }, new[] { "The Great Migration", "False" }, new[] { "The Crusades", "True" }, CategoryType.History, DifficultyLevel.Normal);
        }

        private void NormalSciFiQuestions()
        {
            CreateQuestion("Leonardo DiCaprio plays this character in 'Inception', a film that explores shared dreaming?", new[] { "Arthur", "False" }, new[] { "Carter", "False" }, new[] { "Dom", "False" }, new[] { "Cobb", "True" }, CategoryType.SciFi, DifficultyLevel.Normal);
            CreateQuestion("What color is Leeloo's hair in 'The Fifth Element'?", new[] { "Red", "False" }, new[] { "Pink", "False" }, new[] { "Orange", "True" }, new[] { "Yellow", "False" }, CategoryType.SciFi, DifficultyLevel.Normal);
            CreateQuestion("The name of the ship in 'Alien' is?", new[] { "Explorer", "False" }, new[] { "Nostromo", "True" }, new[] { "Ranger 3", "False" }, new[] { "Prometeus", "False" }, CategoryType.SciFi, DifficultyLevel.Normal);
            CreateQuestion("What derogotory term do humans use for the aliens in 'District 9'?", new[] { "Prawns", "True" }, new[] { "Shrimp", "False" }, new[] { "Crab people", "False" }, new[] { "Buggers", "False" }, CategoryType.SciFi, DifficultyLevel.Normal);
        }

        private void NormalMovieQuestions()
        {
            CreateQuestion("Which movies are Bellatrix from?", new[] { "Harry Potter", "True" }, new[] { "Lord of the Rings", "False" }, new[] { "Pirates of the Carribbean", "False" }, new[] { "Star Wars", "False" }, CategoryType.Movies, DifficultyLevel.Normal);
            CreateQuestion("In Wreck-it Ralph, which arcade game is King Candy in?", new[] { "Pac-man", "False" }, new[] { "Turbo", "False" }, new[] { "Sugar Rush", "True" }, new[] { "Fix-it Felix Jr", "False" }, CategoryType.Movies, DifficultyLevel.Normal);
            CreateQuestion("In Lord of the Rings, who is the king of Rohan?", new[] { "Denethor", "False" }, new[] { "Theoden", "True" }, new[] { "Legolas", "False" }, new[] { "Gandalf", "False" }, CategoryType.Movies, DifficultyLevel.Normal);
            CreateQuestion("In Harry Potter, what is Dumbledore's first name?", new[] { "Albus", "True" }, new[] { "Severus", "False" }, new[] { "Voldemort", "False" }, new[] { "Arthur", "False" }, CategoryType.Movies, DifficultyLevel.Normal);
        }

        private void NormalLiteratureQuestions()
        {
            CreateQuestion("Which Bronte sister wrote Jane Eyre?", new[] { "Branwell Bronte", "False" }, new[] { "Charlotte Bronte", "True" }, new[] { "Anne Bronte", "False" }, new[] { "Emily Bronte", "False" }, CategoryType.Literature, DifficultyLevel.Normal);
            CreateQuestion("Which novel was famous for depicting a dystopian society that burned any books that were found?", new[] { "Harry Potter", "False" }, new[] { "Catch-22", "False" }, new[] { "Fahrenheit 451", "True" }, new[] { "King Kong", "False" }, CategoryType.Literature, DifficultyLevel.Normal);
            CreateQuestion("In which country is Don Quixote set?", new[] { "England", "False" }, new[] { "Spain", "True" }, new[] { "Bulgaria", "False" }, new[] { "China", "False" }, CategoryType.Literature, DifficultyLevel.Normal);
            CreateQuestion("Which Shakespearean tragedy features a Scottish kingdom?", new[] { "Macbeth", "True" }, new[] { "King Lear", "False" }, new[] { "Othello", "False" }, new[] { "Hamlet", "False" }, CategoryType.Literature, DifficultyLevel.Normal);
        }

        private void NormalScienceQuestions()
        {
            CreateQuestion("Who invented the vaccine against rabies?", new[] { "Pasteur", "True" }, new[] { "Nobody", "False" }, new[] { "Galilee", "False" }, new[] { "Mendeleïev", "False" }, CategoryType.Science, DifficultyLevel.Normal);
            CreateQuestion("Which kind of waves are used to make and receive cellphone calls?", new[] { "Radio waves", "True" }, new[] { "Visible light waves", "False" }, new[] { "Gravity waves", "False" }, new[] { "Sound waves", "False" }, CategoryType.Science, DifficultyLevel.Normal);
            CreateQuestion("What does a light-year measure?", new[] { "Brightness", "False" }, new[] { "Distance", "True" }, new[] { "Time ", "False" }, new[] { "Weight", "False" }, CategoryType.Science, DifficultyLevel.Normal);
            CreateQuestion("Which of these elements is needed to make nuclear energy and nuclear weapons?", new[] { "Sodium chloride", "False" }, new[] { "Uranium", "True" }, new[] { "Nitrogen", "False" }, new[] { "Carbone dioxide", "False" }, CategoryType.Science, DifficultyLevel.Normal);
        }

        private void NormalGeographyQuestions()
        {
            CreateQuestion("How high is the highest volcano found on Mars up to this point in human history?", new[] { "21.2 km", "True" }, new[] { "16.1 km", "False" }, new[] { "18.2 km", "False" }, new[] { "19.6 km", "False" }, CategoryType.Geography, DifficultyLevel.Normal);
            CreateQuestion("On which continent is Tripoli located?", new[] { "Europe", "False" }, new[] { "Africa", "True" }, new[] { "Asia", "False" }, new[] { "America", "False" }, CategoryType.Geography, DifficultyLevel.Normal);
            CreateQuestion("What is the name given to the active volcano located in Sicily?", new[] { "Mount Etna", "True" }, new[] { "Pompeii", "False" }, new[] { "Python", "False" }, new[] { "Sinabung", "False" }, CategoryType.Geography, DifficultyLevel.Normal);
            CreateQuestion("What is the biggest country by area in North America?", new[] { "United States of America", "False" }, new[] { "Mexico", "False" }, new[] { "Canada", "True" }, new[] { "Panama", "False" }, CategoryType.Geography, DifficultyLevel.Normal);
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
        private void HardMathQuestions()
        {
            CreateQuestion("10^-2 means...?", new[] { "centi", "True" }, new[] { "milli", "False" }, new[] { "micro", "False" }, new[] { "nano", "False" }, CategoryType.Math, DifficultyLevel.Hard);
            CreateQuestion("All natural numbers and 0 are called the... numbers?", new[] { "prime", "False" }, new[] { "whole", "True" }, new[] { "integer", "False" }, new[] { "rational", "False" }, CategoryType.Math, DifficultyLevel.Hard);
            CreateQuestion("8x1^0 is equal to...?", new[] { "-1", "False" }, new[] { "0", "False" }, new[] { "1", "True" }, new[] { "8", "False" }, CategoryType.Math, DifficultyLevel.Hard);
            CreateQuestion("The wages of 10 workers for a six-day week is $ 1200. What are the one day’s wages of 4 workers?", new[] { "40$", "False" }, new[] { "80$", "True" }, new[] { "24$", "False" }, new[] { "50$", "False" }, CategoryType.Math, DifficultyLevel.Hard);
        }

        private void HardHistoryQuestions()
        {
            CreateQuestion("What Roman Emperor made Christianity legal and ended the persecution of Christians?", new[] { "Napoleon", "False" }, new[] { "Constantine", "True" }, new[] { "Julius Ceasar", "False" }, new[] { "Nero", "False" }, CategoryType.History, DifficultyLevel.Hard);
            CreateQuestion("What's the name of the famous battle where Napoleon Bonaparte was finally defeated?", new[] { "Battle of Waterloo", "True" }, new[] { "Battle of the Alamo", "False" }, new[] { "Battle of the Bulge", "False" }, new[] { "Battle Bunker Hill", "False" }, CategoryType.History, DifficultyLevel.Hard);
            CreateQuestion("In World War II, what country was not a member of the Axis Powers?", new[] { "Soviet Union", "True" }, new[] { "Japan", "False" }, new[] { "Germany", "False" }, new[] { "Italy", "False" }, CategoryType.History, DifficultyLevel.Hard);
            CreateQuestion("Chairman Mao Zedong lead what faction in the Chinese Civil War?", new[] { "Communists", "True" }, new[] { "Confederates", "False" }, new[] { "Nationalists", "False" }, new[] { "Protestants", "False" }, CategoryType.History, DifficultyLevel.Hard);
        }

        private void HardSciFiQuestions()
        {
            CreateQuestion("Robert De Niro, Jonathan Pryce, and Bob Hoskins all appear in this 1985 sci-fi satire?", new[] { "Spaceballs", "False" }, new[] { "Brazil", "True" }, new[] { "Time Bandits", "False" }, new[] { "Innerspace", "False" }, CategoryType.SciFi, DifficultyLevel.Hard);
            CreateQuestion("Who plays Khan in 'Star Trek II: The Wrath of Khan'?", new[] { "Harry Belafonte", "False" }, new[] { "Christopher Walken", "False" }, new[] { "Terance Stamp", "False" }, new[] { "Ricardo Montalban", "True" }, CategoryType.SciFi, DifficultyLevel.Hard);
            CreateQuestion("How many humans does Schwarzenegger kill in 'Terminator 2: Judgment Day'?", new[] { "0", "True" }, new[] { "3", "False" }, new[] { "5", "False" }, new[] { "15", "False" }, CategoryType.SciFi, DifficultyLevel.Hard);
            CreateQuestion("Which sci-fi movie did Steven Spielberg NOT direct?", new[] { "Minority Report", "False" }, new[] { "A.I. Artificial Intelligence", "False" }, new[] { "Blade Runner", "True" }, new[] { "War of the worlds", "False" }, CategoryType.SciFi, DifficultyLevel.Hard);
        }

        private void HardMovieQuestions()
        {
            CreateQuestion("How was second Indiana Jones movie called \"Indiana Jones and...\"?", new[] { "The Last Crusade", "False" }, new[] { "The Raiders of the Lost Ark", "False" }, new[] { "The Kingdom of the Crystal Skull", "False" }, new[] { "The Temple of Doom", "True" }, CategoryType.Movies, DifficultyLevel.Hard);
            CreateQuestion("In Cloudy With a Chance of Meatballs 2, what type of food is is Berry?", new[] { "Blueberry", "False" }, new[] { "Strawberry", "True" }, new[] { "Blackberry", "False" }, new[] { "Raspberry", "False" }, CategoryType.Movies, DifficultyLevel.Hard);
            CreateQuestion("In the Hunger Games, what district is Thresh from?", new[] { "11", "True" }, new[] { "4", "False" }, new[] { "6", "False" }, new[] { "10", "False" }, CategoryType.Movies, DifficultyLevel.Hard);
            CreateQuestion("In The Lego Movie, what day of the week was President Business giving out free tacos?", new[] { "Wednesday", "False" }, new[] { "Saturday", "False" }, new[] { "Monday", "False" }, new[] { "Tuesday", "True" }, CategoryType.Movies, DifficultyLevel.Hard);
        }

        private void HardLiteratureQuestions()
        {
            CreateQuestion("Which of these epic poems was written by the most famous blind Greek of all time, Homer?", new[] { "Antigone", "False" }, new[] { "Odyssey", "True" }, new[] { "Iliad", "False" }, new[] { "Phocais", "False" }, CategoryType.Literature, DifficultyLevel.Hard);
            CreateQuestion("Which transcendentalist author penned Walden?", new[] { "Jones Very", "False" }, new[] { "Ralph Waldo Emerson", "False" }, new[] { "Margaret Fuller", "False" }, new[] { "Henry David Thoreau", "True" }, CategoryType.Literature, DifficultyLevel.Hard);
            CreateQuestion("What is the name of the narrator in Moby Dick?", new[] { "Ishmael", "True" }, new[] { "Captain Ahab", "False" }, new[] { "Simon", "False" }, new[] { "Ginger Beard", "False" }, CategoryType.Literature, DifficultyLevel.Hard);
            CreateQuestion("Which famed author wrote The Picture of Dorian Gray?", new[] { "James Joyce", "False" }, new[] { "Oscar Wilde", "True" }, new[] { "Mark Twain", "False" }, new[] { "Edgar Allen Poe", "False" }, CategoryType.Literature, DifficultyLevel.Hard);
        }

        private void HardScienceQuestions()
        {
            CreateQuestion("What is an object in space that has an icy core with a tail of gas and dust that extends millions of miles?", new[] { "A star", "False" }, new[] { "A comet ", "True" }, new[] { "An asteroide", "False" }, new[] { "A moon", "False" }, CategoryType.Science, DifficultyLevel.Hard);
            CreateQuestion("The loudness of a sound is determined by what property of a sound wave?", new[] { "Frequency", "False" }, new[] { "Wavelenght", "False" }, new[] { "Velocity or rate of rage", "False" }, new[] { "Amplitude or height", "True" }, CategoryType.Science, DifficultyLevel.Hard);
            CreateQuestion("Which of these people developed the polio vaccine?", new[] { "Marie Curie", "False" }, new[] { "Isaac Newton", "False" }, new[] { "Albert Einstein", "False" }, new[] { "Jonas Salk", "True" }, CategoryType.Science, DifficultyLevel.Hard);
            CreateQuestion("Which of these terms is defined as the study of how the positions of stars and planets can influence human behavior?", new[] { "Astrology", "True" }, new[] { "Astronomy", "False" }, new[] { "Metrology", "False" }, new[] { "Alchemistry", "False" }, CategoryType.Science, DifficultyLevel.Hard);
        }

        private void HardGeographyQuestions()
        {
            CreateQuestion("Which state borders the east side of Texas and has a coastline on the Gulf of Mexico?", new[] { "New Mexico", "False" }, new[] { "Alabama", "False" }, new[] { "California", "False" }, new[] { "Louisiana", "True" }, CategoryType.Geography, DifficultyLevel.Hard);
            CreateQuestion("Which country has the longest coastline in the world?", new[] { "Russia", "False" }, new[] { "Australia", "False" }, new[] { "Canada", "True" }, new[] { "France", "False" }, CategoryType.Geography, DifficultyLevel.Hard);
            CreateQuestion("What is highest waterfall in the world?", new[] { "Raiskoto Praskalo", "False" }, new[] { "Victoria Falls", "False" }, new[] { "Niagara Falls", "False" }, new[] { "Angel Falls", "True" }, CategoryType.Geography, DifficultyLevel.Hard);
            CreateQuestion("Which river flows through the Grand Canyon?", new[] { "Colorado River", "True" }, new[] { "Mississippi River", "False" }, new[] { "Savannah River", "False" }, new[] { "Housatonic River", "False" }, CategoryType.Geography, DifficultyLevel.Hard);
        }

        private void HardRandomQuestions()
        {
            var qRText9 = "What is the name of the island prison where, Nelson Mandela was imprisioned?";
            var randomQ9 = this.factory.CreateNormalQuestion(qRText9, DifficultyLevel.Hard, CategoryType.Random);

            var a1 = this.factory.CreateAnswer("Robben Island", true);
            var a2 = this.factory.CreateAnswer("Rikers Island", false);
            var a3 = this.factory.CreateAnswer("Penal Colony Island", false);
            var a4 = this.factory.CreateAnswer("Seal Island", false);

            AddQuestion(randomQ9, a1, a2, a3, a4);

            var qRText10 = "What does an angry russian say when his internet stops?";
            var randomQ10 = this.factory.CreateNormalQuestion(qRText10, DifficultyLevel.Hard, CategoryType.Random);

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
            a4 = this.factory.CreateAnswer("Denser, stronger muscle tissue", false);

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
            a4 = this.factory.CreateAnswer("Bonjour", false);

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
