﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Common;
using Trivia.Contracts;

namespace Trivia.Models.Question
{
    public class BonusQuestion : Question
    {
        public BonusQuestion(string questionText, IList<IAnswer> answers, int points, DifficultyLevel difficultyLevel, CategoryType category)
            : base(questionText, answers, points, difficultyLevel, category)
        {
        }
    }
}
