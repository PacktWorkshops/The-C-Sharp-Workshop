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

        // Under the hood:
        //private readonly string _name;
        //public string get_Name()
        //{
        //    return _owner;
        //}

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