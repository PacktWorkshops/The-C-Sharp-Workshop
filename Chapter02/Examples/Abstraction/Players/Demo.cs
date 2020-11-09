using System.Collections.Generic;

namespace Chapter02.Examples.Abstraction.Players
{
    public static class Demo
    {
        public static void Run()
        {
            DemoAbstractionThroughBadEncapsulation();
            DemoAbstractionThroughGoodEncapsulation();
        }

        private static void DemoAbstractionThroughBadEncapsulation()
        {
            Coach coach = new Coach("Tobias");
            List<Player> players = new List<Player>();
            TeamBadAbstraction teamBadAbstraction = new TeamBadAbstraction(coach, players);

            Player player = new Player("Luke", "Center");
            teamBadAbstraction.Players.Add(player);

            // We want to remove "Luke"
            int indexOfPlayerToRemove = teamBadAbstraction.Players.FindIndex(p => p.Name == "Luke");
            teamBadAbstraction.Players.RemoveAt(indexOfPlayerToRemove);
        }

        private static void DemoAbstractionThroughGoodEncapsulation()
        {
            Coach coach = new Coach("Tobias");
            Team team = new Team(coach);

            Player player = new Player("Luke", "Center");
            team.Add(player);

            team.Remove("Luke");

            IEnumerable<Player> players = team.Players;
        }
    }
}
