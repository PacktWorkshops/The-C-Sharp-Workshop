using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chapter3;

namespace Chapter3UnitTest
{

    [TestClass]
    public class Exercise05Tests
    {
        [TestMethod]
        public void ElevatorEventArgs_ConstructorSetsProperties()
        {
            const int RequestedFloor = 10;
            const int CurrentFloor = 2;

            // ARRANGE & ACT
            var args = new ElevatorRequestArgs(RequestedFloor, CurrentFloor);
            
            // ASSERT
            Assert.AreEqual(RequestedFloor, args.RequestedFloor);
            Assert.AreEqual(CurrentFloor, args.CurrentFloor);
        }
    }
}
