using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Common;

namespace Trivia.Models.Hint
{
    public abstract class Hint
    {
        private string description;
        private readonly HintType type;
        private int quantity;

        public Hint(int quantity, HintType type)
        {
            //guard
            this.type = type;
            this.quantity = quantity;
        }

        public HintType Name => this.type;

        public string Description { get => this.description; protected set => this.description = value; }

        public int Quantity { get => this.quantity; set => this.quantity = value; }
    }
}
