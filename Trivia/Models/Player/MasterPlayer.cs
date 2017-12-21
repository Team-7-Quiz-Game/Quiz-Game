using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Contracts;
using Trivia.Common;

namespace Trivia.Models.Player
{
    public class MasterPlayer : Player
    {
        private IList<IQuestion> quizzardQuestions;

        public MasterPlayer(string name)
            : base(name, PlayerType.Quizzard)
        {
        }

        public int QuestionsCount => this.quizzardQuestions.Count;

        public void CreateQuestion(IQuestion question)
        {
            quizzardQuestions.Add(question);
        }

        public void RemoveQuestion(IQuestion question)
        {
            quizzardQuestions.Remove(question);
        }
    }
}
