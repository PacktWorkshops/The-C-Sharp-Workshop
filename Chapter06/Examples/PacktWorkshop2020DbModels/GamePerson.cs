using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Models
{
    public partial class GamePerson
    {
        public int PersonId { get; set; }
        public int GameId { get; set; }

        public virtual Game Game { get; set; }
        public virtual Person Person { get; set; }
    }
}
