namespace Chapter02.Examples.Solid.LiskovSubstitutionPrinciple
{
    class Car
    {
        public object Body { get; set; }

        public virtual void Move()
        {
            // Moving
        }
    }
}
