namespace Chapter02.Examples.InheritanceAndPolymorphism.Composition.Compliant;

class TrapTile : Tile
{
    private readonly Trap _trap;

    public TrapTile(Trap trap)
    {
        _trap = trap;
    }

    public void Damage()
    {
        _trap.Damage();
    }
}