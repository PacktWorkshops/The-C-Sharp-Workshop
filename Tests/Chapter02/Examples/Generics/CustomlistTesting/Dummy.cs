namespace Tests.Chapter02.Examples.Generics.CustomlistTesting
{
    public class Dummy
    {
        public int A { get; }

        public Dummy(int a)
        {
            A = a;
        }

        protected bool Equals(Dummy other)
        {
            return A == other.A;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Dummy)obj);
        }

        public override int GetHashCode()
        {
            return A;
        }
    }
}