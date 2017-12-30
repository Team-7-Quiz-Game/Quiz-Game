using Trivia.Common.Enums;
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
            this.playerType = playerType;
        }

        public string Name => this.name;

        public PlayerType PlayerType => this.playerType;

        public override string ToString()
        {
            return $"{this.PlayerType} {this.Name}";
        }
    }
}
