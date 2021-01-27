namespace Chapter02.Examples.InheritanceAndPolymorphism.Composition.Compliant
{
    class Tile
    {
    }

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

    class Motor
    {
        public void Move() { }
    }

    class Trap
    {
        public void Damage() { }
    }
}
