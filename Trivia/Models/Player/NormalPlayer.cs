using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Common;

namespace Trivia.Models.Player
{
    public class NormalPlayer : Player
    {
        private int points;
        private int correctAnswers;
        private int wrongAnswers;

        public NormalPlayer(string name) 
            : base(name, PlayerType.Player)
        {
            this.correctAnswers = 0;
            this.wrongAnswers = 0;
        }

        public int Points
        {
            get
            {
                return this.points;
            }
            set
            {
                //Guard
                this.points += value;
            }
        }

        public int WrongAnswers { get => this.wrongAnswers; set => this.wrongAnswers += value; }

        public int CorrectAnswers { get => this.correctAnswers; set => this.correctAnswers += value; }

        public override string ToString()
        {
            return base.ToString() + $" {this.Points} pts";
        }
    }
}
