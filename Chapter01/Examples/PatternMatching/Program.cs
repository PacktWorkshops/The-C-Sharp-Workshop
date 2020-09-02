using System;

namespace PatternMatching
{
    public class Program
    {
        public abstract class Athlete
        {
            public string Name { get; set; }
        }

        public class BasketballPlayer : Athlete
        {
            public BasketballPlayer(string name) => Name = name;
        }

        public class SoccerPlayer : Athlete
        {
            public SoccerPlayer(string name) => Name = name;
        }

        public static string WhatAthleteIsThis(Athlete athlete)
        {
            switch (athlete)
            {
                case BasketballPlayer b: return $"{b.Name} is a basketball player";
                case SoccerPlayer s: return $"{s.Name} is a soccer player";
                default: return "Athlete not found";
            };
        }

        public static void Main()
        {
            var players = new Athlete[]
            {
            new BasketballPlayer("LeBron James"),
            new BasketballPlayer("Kyrie Irving"),
            new SoccerPlayer("Cristiano Ronaldo"),
            };

            foreach (var player in players)
            {
                Console.WriteLine(WhatAthleteIsThis(player));
            }
        }
    }
}
