using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using Trivia.Core.Contracts;
using Trivia.UI;

namespace Trivia.Tests.UITests
{
    [TestClass]
    public class PlayerModeTests
    {
        private Application app;

        [TestInitialize]
        public void Start()
        {
            app = Application.Launch("Trivia.UI.exe");
        }

        [TestCleanup]
        public void End()
        {
            app.Close();
        }

        [TestMethod]
        public void GoPlayerButtonShouldExist()
        {
            Window window = app.GetWindow("Let's Get Quizzical", InitializeOption.NoCache);
            var startBtn = window.Get<Button>("StartBtn");
            startBtn.Click();

            Assert.IsTrue(window.Exists<Button>("PlayerBtn"));
        }

        [TestMethod]
        public void ScienceCheckBoxShouldExist()
        {
            Window window = app.GetWindow("Let's Get Quizzical", InitializeOption.NoCache);
            var startBtn = window.Get<Button>("StartBtn");
            startBtn.Click();

            Assert.IsTrue(window.Exists<CheckBox>("science"));
        }

        [TestMethod]
        public void HistoryCheckBoxShouldExist()
        {
            Window window = app.GetWindow("Let's Get Quizzical", InitializeOption.NoCache);
            var startBtn = window.Get<Button>("StartBtn");
            startBtn.Click();

            Assert.IsTrue(window.Exists<CheckBox>("history"));
        }

        [TestMethod]
        public void GeographyCheckBoxShouldExist()
        {
            Window window = app.GetWindow("Let's Get Quizzical", InitializeOption.NoCache);
            var startBtn = window.Get<Button>("StartBtn");
            startBtn.Click();

            Assert.IsTrue(window.Exists<CheckBox>("geography"));
        }

        [TestMethod]
        public void SciFiCheckBoxShouldExist()
        {
            Window window = app.GetWindow("Let's Get Quizzical", InitializeOption.NoCache);
            var startBtn = window.Get<Button>("StartBtn");
            startBtn.Click();

            Assert.IsTrue(window.Exists<CheckBox>("sciFi"));
        }

        [TestMethod]
        public void MathCheckBoxShouldExist()
        {
            Window window = app.GetWindow("Let's Get Quizzical", InitializeOption.NoCache);
            var startBtn = window.Get<Button>("StartBtn");
            startBtn.Click();

            Assert.IsTrue(window.Exists<CheckBox>("math"));
        }

        [TestMethod]
        public void MoviesCheckBoxShouldExist()
        {
            Window window = app.GetWindow("Let's Get Quizzical", InitializeOption.NoCache);
            var startBtn = window.Get<Button>("StartBtn");
            startBtn.Click();

            Assert.IsTrue(window.Exists<CheckBox>("movies"));
        }

        [TestMethod]
        public void LiteratureCheckBoxShouldExist()
        {
            Window window = app.GetWindow("Let's Get Quizzical", InitializeOption.NoCache);
            var startBtn = window.Get<Button>("StartBtn");
            startBtn.Click();

            Assert.IsTrue(window.Exists<CheckBox>("literature"));
        }

        [TestMethod]
        public void RandomCheckBoxShouldExist()
        {
            Window window = app.GetWindow("Let's Get Quizzical", InitializeOption.NoCache);
            var startBtn = window.Get<Button>("StartBtn");
            startBtn.Click();

            Assert.IsTrue(window.Exists<CheckBox>("random"));
        }

        [TestMethod]
        public void GoQuizzardButtonShouldExist()
        {
            Window window = app.GetWindow("Let's Get Quizzical", InitializeOption.NoCache);
            var startBtn = window.Get<Button>("StartBtn");
            startBtn.Click();

            Assert.IsTrue(window.Exists<Button>("QuizzardBtn"));
        }

        [TestMethod]
        public void GoPlayerButtonClickShouldCreatePlayerWithProvidedName()
        {
            Window window = app.GetWindow("Let's Get Quizzical", InitializeOption.NoCache);
            var startBtn = window.Get<Button>("StartBtn");
            startBtn.Click();

            var playerBtn = window.Get<Button>("PlayerBtn");
            
            var nameBox = window.Get<TextBox>("pName");

            nameBox.Text = "Pesho";
            Thread.Sleep(200);

            var checkedBox = window.Get<CheckBox>("science");
            checkedBox.Click();

            playerBtn.Click();
            var nameBoxTB = window.Get<UIItem>("pNameTB");

            Assert.AreEqual("Pesho", nameBoxTB.Name);
        }

        [TestMethod]
        public void GoPlayerButtonClickShouldNotThrowWhenNoCategoriesAreSelected()
        {
            Window window = app.GetWindow("Let's Get Quizzical", InitializeOption.NoCache);
            var startBtn = window.Get<Button>("StartBtn");
            startBtn.Click();

            var playerBtn = window.Get<Button>("PlayerBtn");

            playerBtn.Click();

            var labelExists = window.Exists<Label>("ChooseMode");

            Assert.IsTrue(labelExists);
        }

        [TestMethod]
        public void GoPlayerButtonClickShouldDoNothingWhenNameIsEmpty()
        {
            Window window = app.GetWindow("Let's Get Quizzical", InitializeOption.NoCache);
            var startBtn = window.Get<Button>("StartBtn");
            startBtn.Click();

            var nameBox = window.Get<TextBox>("pName");
            nameBox.Text = "";
            Thread.Sleep(200);

            var playerBtn = window.Get<Button>("PlayerBtn");
            var checkedBox = window.Get<CheckBox>("science");
            checkedBox.Click();

            playerBtn.Click();

            var labelExists = window.Exists<Label>("ChooseMode");

            Assert.IsTrue(labelExists);
        }

        [TestMethod]
        public void GoPlayerButtonClickShouldDoNothingWhenNameIsEmptyAndNameShouldNotBeEmptyAnymore()
        {
            Window window = app.GetWindow("Let's Get Quizzical", InitializeOption.NoCache);
            var startBtn = window.Get<Button>("StartBtn");
            startBtn.Click();

            var nameBox = window.Get<TextBox>("pName");
            var defaultName = nameBox.Text;
            nameBox.Text = "";
            Thread.Sleep(200);

            var playerBtn = window.Get<Button>("PlayerBtn");
            var checkedBox = window.Get<CheckBox>("science");
            checkedBox.Click();

            playerBtn.Click();

            Assert.AreEqual(defaultName, nameBox.Text);
        }
    }
}
