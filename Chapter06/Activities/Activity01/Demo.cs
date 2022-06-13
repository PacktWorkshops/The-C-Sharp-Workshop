using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter06.Activities.Activity01
{
    public static class Demo
    {
        public static void Run()
        {
            var db = new TruckDispatchDbContext();
            SeedData(db);
            var dispatches = GetAll(db);
            Print(dispatches);
            db.Dispose();
        }

        private static void SeedData(TruckDispatchDbContext db)
        {
            var wasSeeded = db.Trucks.Any();
            if (!wasSeeded)
            {
                var person = new Person { DoB = DateTime.UtcNow, Id = 1, Name = "Stephen King" };
                db.People.Add(person);

                var truck = new Truck() { Id = 1, Brand = "Scania", Model = "R 500 LA6x2HHA", YearOfMaking = 2009 };
                db.Trucks.Add(truck);

                var dispatch = new TruckDispatch()
                {
                    CurrentLocation = "1,1,1",
                    Deadline = DateTime.UtcNow.AddDays(100),
                    Driver = person,
                    Truck = truck
                };
                db.TruckDispatches.Add(dispatch);

                db.SaveChanges();
            }
        }

        private static IEnumerable<TruckDispatch> GetAll(TruckDispatchDbContext db)
        {
            var dispatches = db
                .TruckDispatches
                .Include(td => td.Driver)
                .Include(td => td.Truck)
                .ToList();

            return dispatches;
        }

        private static void Print(IEnumerable<TruckDispatch> truckDispatches)
        {
            foreach (var dispatch in truckDispatches)
            {
                Console.WriteLine($"Dispatch: {dispatch.Id} {dispatch.CurrentLocation} {dispatch.Deadline}");
                Console.WriteLine($"Driver: {dispatch.Driver.Name} {dispatch.Driver.DoB}");
                Console.WriteLine($"Truck: {dispatch.Truck.Brand} {dispatch.Truck.Model} {dispatch.Truck.YearOfMaking}");
            }
        }
    }
}
