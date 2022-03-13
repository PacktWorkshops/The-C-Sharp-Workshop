namespace Chapter02.Examples.InheritanceAndPolymorphism.Composition.Compliant;

class MovingTile : Tile
{
    private readonly Motor _motor;

    public MovingTile(Motor motor)
    {
        _motor = motor;
    }

    public void Move()
    {
        _motor.Move();
    }
}