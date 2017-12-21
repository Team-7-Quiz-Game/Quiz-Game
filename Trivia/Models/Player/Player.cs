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
        
        private PlayerType playerType;

        public Player(string name, PlayerType playerType)
        {
            //Guard
            this.name = name;
            this.PlayerType = playerType;
        }

        public string Name => this.name;

        public PlayerType PlayerType { get; private set; }

        public override string ToString()
        {
            return $"{this.PlayerType} {this.Name}";
        }
    }
}
