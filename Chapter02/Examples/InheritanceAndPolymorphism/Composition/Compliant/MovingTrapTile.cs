namespace Chapter02.Examples.InheritanceAndPolymorphism.Composition.Compliant;

class MovingTrapTile : Tile
{
    private readonly Motor _motor;
    private readonly Trap _trap;

    public MovingTrapTile(Motor motor, Trap trap)
    {
        _motor = motor;
        _trap = trap;
    }

    public void Move()
    {
        _motor.Move();
    }

    public void Damage()
    {
        _trap.Damage();
    }
}