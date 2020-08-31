using System;

namespace Chapter3
{
    public class ElevatorRequestArgs : EventArgs
    {
        public ElevatorRequestArgs(int requestedFloor, int currentFloor)
        {
            RequestedFloor = requestedFloor;
            CurrentFloor = currentFloor;
        }

        public int RequestedFloor{ get; }
        public int CurrentFloor { get; }
    }
}
