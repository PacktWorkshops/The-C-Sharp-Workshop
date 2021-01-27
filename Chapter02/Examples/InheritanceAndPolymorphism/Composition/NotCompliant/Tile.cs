namespace Chapter02.Examples.InheritanceAndPolymorphism.Composition.NotCompliant
{
    class Tile
    {
    }

    class MovingTile : Tile
    {
        public void Move() {}
    }

    class TrapTile : Tile
    {
        public void Damage() {}
    }

    //class MovingTrapTile : ?
}
