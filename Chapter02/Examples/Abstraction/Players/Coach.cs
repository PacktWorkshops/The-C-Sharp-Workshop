namespace Chapter02.Examples.Abstraction.Players
{
    public class Coach : Human
    {
        public bool IsMain { get; }
        // ...and more relevant info

        public Coach(string name) : base(name)
        {
        }
    }
}
