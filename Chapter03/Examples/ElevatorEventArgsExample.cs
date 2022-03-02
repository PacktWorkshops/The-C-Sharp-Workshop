using System;

namespace Chapter03Examples
{
    public class ElevatorEventArgs : System.EventArgs
    {
        public ElevatorEventArgs(int requestedFloor, int currentFloor)
        {
            RequestedFloor = requestedFloor;
            CurrentFloor = currentFloor;
        }

        public int RequestedFloor { get; }
        public int CurrentFloor { get; }
    }

    
}
