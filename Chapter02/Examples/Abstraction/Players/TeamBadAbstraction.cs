using System.Collections.Generic;

namespace Chapter02.Examples.Abstraction.Players
{
    public class TeamBadAbstraction
    {
        public Coach Coach { get; }
        public List<Player> Players { get; }

        public TeamBadAbstraction(Coach coach, List<Player> players)
        {
            Coach = coach;
            Players = players;
        }
    }
}
