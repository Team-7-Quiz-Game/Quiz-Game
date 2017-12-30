using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Contracts;
using Trivia.Common.Enums;

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

        public IList<IQuestion> QuizzardQuestions => this.CloneQuestions();

        public int QuestionsCount => this.quizzardQuestions.Count;

        public void CreateQuestion(IQuestion question)
        {
            //guard
            quizzardQuestions.Add(question);
        }

        public void RemoveQuestion(IQuestion question)
        {
            //guard
            quizzardQuestions.Remove(question);
        }

        private IList<IQuestion> CloneQuestions()
        {
            var cloned = new List<IQuestion>();

            foreach (var question in quizzardQuestions)
            {
                cloned.Add(question);
            }

            return cloned;
        }
    }
}
