using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Contracts;
using Trivia.Common.Enums;
using Trivia.Common.Utils;

namespace Trivia.Models.Player
{
    public class QuizzardPlayer : Player
    {
        private IList<IQuestion> quizzardQuestions;

        public QuizzardPlayer(string name)
            : base(name, PlayerType.Quizzard)
        {
            this.quizzardQuestions = new List<IQuestion>();
        }

        public IList<IQuestion> QuizzardQuestions => quizzardQuestions.Clone();

        public int QuestionsCount => this.quizzardQuestions.Count;

        public void CreateQuestion(IQuestion question)
        {
            Validator.CheckIfNull(question, string.Format(GlobalConstants.ObjectCannotBeNull, "Question"));

            quizzardQuestions.Add(question);
        }

        public void RemoveQuestion(IQuestion question)
        {
            Validator.CheckIfNull(question, string.Format(GlobalConstants.ObjectCannotBeNull, "Question"));

            if (!this.quizzardQuestions.Contains(question))
            {
                throw new ArgumentException("Question not found!");
            }

            quizzardQuestions.Remove(question);
        }
    }
}
