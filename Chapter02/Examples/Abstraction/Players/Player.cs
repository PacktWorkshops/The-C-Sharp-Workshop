namespace Chapter02.Examples.Abstraction.Players
{
    public class Player : Human
    {
        public string Position { get; }

        public Player(string name, string position) : base(name)
        {
            Position = position;
        }
    }
}
