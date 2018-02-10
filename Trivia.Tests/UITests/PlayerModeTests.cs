using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
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
        public void ClickingGoPlayerButtonShouldCreatePlayerWithProvidedName()
        {
            Window window = app.GetWindow("Let's Get Quizzical", InitializeOption.NoCache);
            var startBtn = window.Get<Button>("StartBtn");
            startBtn.Click();

            var playerBtn = window.Get<Button>("PlayerBtn");
            
            var nameBox = window.Get<TextBox>("pName");
            nameBox.Text = "Pesho";

            var checkedBox = window.Get<CheckBox>("science");
            checkedBox.Click();

            playerBtn.Click();
            var nameBoxTB = window.Get<UIItem>("pNameTB");

            Assert.AreEqual("Pesho", nameBoxTB.Name);
        }

        [TestMethod]
        public void ClickingGoPlayerButtonShouldNotThrowWhenNoCategoriesAreSelected()
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
        public void Test()
        {
            Window window = app.GetWindow("Let's Get Quizzical", InitializeOption.NoCache);
            var startBtn = window.Get<Button>("StartBtn");
            startBtn.Click();

            var playerBtn = window.Get<Button>("PlayerBtn");

            var engineMock = new Mock<IEngine>();

            var playerMode = new PlayerMode(engineMock.Object);
        }
    }
}
