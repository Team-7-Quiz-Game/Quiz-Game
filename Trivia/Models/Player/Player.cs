using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Common;
using Trivia.Contracts;

namespace Trivia.Models.Player
{
    public abstract class Player : IPlayer
    {
        private readonly string name;
        private int points;
        private int correctAnswers;
        private int wrongAnswers;

        public Player(string name, PlayerType playerType)
        {
            //Guard
            this.name = name;
            this.PlayerType = playerType;
            this.correctAnswers = 0;
            this.wrongAnswers = 0;
        }

        public string Name => this.name;

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

        public int WrongAnswers => this.wrongAnswers;

        public int CorrectAnswers => this.correctAnswers;

        public PlayerType PlayerType { get; private set; }

        public override string ToString()
        {
            return $"{this.Name} - {this.Points} pts.";
        }
    }
}
