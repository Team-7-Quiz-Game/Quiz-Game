using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Common;
using Trivia.Contracts;

namespace Trivia.Models.Question
{
    public class NormalQuestion : Question
    {
        public NormalQuestion(string questionText, DifficultyLevel difficultyLevel, CategoryType category) 
            : base(questionText, difficultyLevel, category, QuestionType.Normal)
        {
            this.Points = (int)DifficultyLevel * 100;
        }
    }
}
