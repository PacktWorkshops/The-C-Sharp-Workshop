namespace Chapter02.Examples.InheritanceAndPolymorphism;

public class Bar
{
    public string SomethingOfBar { get; }

    // no :base() is needed
    public Bar(string somethingOfBar) 
    {
        SomethingOfBar = somethingOfBar;
    }
}