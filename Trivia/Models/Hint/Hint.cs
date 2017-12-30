using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Common.Enums;
using Trivia.Common.Utils;

namespace Trivia.Models.Hint
{
    public abstract class Hint
    {
        private string description;
        private readonly HintType type;
        private int quantity;

        public Hint(int quantity, HintType type)
        {
            Validator.CheckIfNull(type, string.Format(GlobalConstants.ObjectCannotBeNull, "Hint type"));
            Validator.CheckIfIntNegative(quantity, string.Format(GlobalConstants.NumberCannotBeNegative, "Hint quantity"));

            this.type = type;
            this.quantity = quantity;
        }

        public HintType Name => this.type;

        public string Description { get => this.description; protected set => this.description = value; }

        public int Quantity { get => this.quantity; set => this.quantity = value; }
    }
}
