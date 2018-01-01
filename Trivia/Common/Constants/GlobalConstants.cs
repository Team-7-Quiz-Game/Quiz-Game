using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.Common.Utils
{
    public class GlobalConstants
    {
        public const int MaxAnswersPerQuestion = 4;
        public const int MaxQuestionsInCategory = 10;

        public const int MinPointsAmplifier = 2;
        public const int MaxPointsAmplifier = 10;

        public const int MinTimeForAnswer = 6;
        public const int MaxTimeForAnswer = 10;

        public const int QuestionsPerLevelCount = 2;

        public const string NumberCannotBeNegative = "{0} cannot be negative!";

        public const string MaxAnswersPerQuestionErrorMessage = "A question cannot have more than {0} answers!";
        public const string MaxQuestionsInCategoryErrorMessage = "{0} category cannot have more than {1} questions!";

        public const string StringCannotBeNullOrEmpty = "{0} cannot be null or empty!";
        public const string ObjectCannotBeNull = "{0} cannot be null!";
        public const string CategoryNotFound = "{0} category not found!";

        public const string QuestionAlreadyAddedMessage = "{0} already added!";
        public const string CategoryAlreadyExists = "{0} category already created!";

        public const string NumberMustBeBetweenMinAndMax = "{0} must be between {1} and {2}!";
    }
}
