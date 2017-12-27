using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.Models.Hint
{
    public abstract class Hint
    {
        private readonly string name;
        private readonly string description;
        private int quantity;

        public Hint(string name, string description, int quantity)
        {
            //guard
            this.name = name;
            this.description = description;
            this.quantity = quantity;
        }

        public string Name => this.name;

        public string Description => this.description;

        public int Quantity { get => this.quantity; set => this.quantity = value; }
    }
}
