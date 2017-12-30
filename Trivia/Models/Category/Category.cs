﻿using System;
using System.Collections.Generic;
using Trivia.Common.Enums;
using Trivia.Contracts;

namespace Trivia.Models.Category
{
    public class Category : ICategory
    {
        private const int MaxQuestionsCount = 5;
        private readonly CategoryType categoryType;
        private IList<IQuestion> easyQuestions;
        private IList<IQuestion> normalQuestions;
        private IList<IQuestion> hardQuestions;
        
        public Category(CategoryType categoryType)
        {
            //Guard
            this.categoryType = categoryType;
            this.easyQuestions = new List<IQuestion>();
            this.normalQuestions = new List<IQuestion>();
            this.hardQuestions = new List<IQuestion>();
        }
        
        public CategoryType CategoryType => this.categoryType;

        public IList<IQuestion> EasyQuestions => CloneQuestions(this.easyQuestions);

        public IList<IQuestion> NormalQuestions => CloneQuestions(this.normalQuestions);

        public IList<IQuestion> HardQuestions => CloneQuestions(this.hardQuestions);

        private void AddEasyQuestion(IQuestion question)
        {
            if (this.easyQuestions.Count > MaxQuestionsCount)
            {
                throw new ArgumentException($"Easy questions per category must be {MaxQuestionsCount}!");
            }

            this.easyQuestions.Add(question);
        }

        private void AddNormalQuestion(IQuestion question)
        {
            if (this.normalQuestions.Count > MaxQuestionsCount)
            {
                throw new ArgumentException($"Normal questions per category must be {MaxQuestionsCount}!");
            }

            this.normalQuestions.Add(question);
        }

        private void AddHardQuestion(IQuestion question)
        {
            if (this.hardQuestions.Count > MaxQuestionsCount)
            {
                throw new ArgumentException($"Hard questions per category must be {MaxQuestionsCount}!");
            }

            this.hardQuestions.Add(question);
        }

        public void AddQuestion(IQuestion question)
        {
            //guard
            switch (question.DifficultyLevel)
            {
                case DifficultyLevel.Easy:
                    this.AddEasyQuestion(question);
                    break;
                case DifficultyLevel.Normal:
                    this.AddNormalQuestion(question);
                    break;
                case DifficultyLevel.Hard:
                    this.AddHardQuestion(question);
                    break;
                default:
                    break;
            }
        }

        private IList<IQuestion> CloneQuestions(IList<IQuestion> listToBeCloned)
        {
            var cloned = new List<IQuestion>();

            foreach (var question in listToBeCloned)
            {
                cloned.Add(question);
            }

            return cloned;
        }
    }
}
