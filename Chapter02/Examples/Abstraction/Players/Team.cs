using System.Collections.Generic;

namespace Chapter02.Examples.Abstraction.Players
{
    // Good abstraction
    public class Team
    {
        public Coach Coach { get; }
        public IEnumerable<Player> Players => _players.Values;

        private Dictionary<string, Player> _players;

        public Team(Coach coach)
        {
            Coach = coach;
            _players = new Dictionary<string, Player>();
        }

        public void Add(Player player)
        {
            _players.Add(player.Name, player);
        }

        public void Remove(string playerName)
        {
            _players.Remove(playerName);
        }
    }
}
