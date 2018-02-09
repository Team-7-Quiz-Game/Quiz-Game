using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace Trivia.Tests.UITests
{
    [TestClass]
    public class GameStartTests
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
        public void IsStartButtonClicked()
        {
            Window window = app.GetWindow("Let's Get Quizzical", InitializeOption.NoCache);
            var startBtn = window.Get<Button>("StartBtn");
            var test = window.Exists<Label>("ChooseMode");

            startBtn.Click();

            var labelExists = window.Exists<Label>("ChooseMode");
            Assert.IsTrue(labelExists);
        }
    }
}
