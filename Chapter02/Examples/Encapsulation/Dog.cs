namespace Chapter02.Examples.Encapsulation
{
    public class Dog
    {
        public string Name {get;}

        private string _owner;
        public string Owner
        {
            get
            {
                return _owner;
            }
            set
            {
                _owner = value;
            }
        }

        public Dog(string name)
        {
            Name = name;
        }

        public void Sit()
        {
            System.Console.WriteLine(Name + " is sitting");
        }

        public void Bark()
        {
            System.Console.WriteLine("Woof woof");
        }
    }
}