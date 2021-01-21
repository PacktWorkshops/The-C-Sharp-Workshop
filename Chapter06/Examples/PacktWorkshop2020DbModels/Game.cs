using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Models
{
    public partial class Game
    {
        public Game()
        {
            GamePeople = new HashSet<GamePerson>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GamePerson> GamePeople { get; set; }
    }
}
