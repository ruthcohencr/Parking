using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {

            IParkingLot parkingLot = new ParkingLot();
            Task t1 = Task.Run(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("new car arrived... is waiting to get a location to some parking");
                    if (!parkingLot.IsFull)
                    {
                        Console.WriteLine(parkingLot.FindFreeSlot().ToString());
                    }
                    else
                    {
                        Console.WriteLine("sorry, no parking slots at this time, please try latter...");
                    }
                }
            });

            Task t2 = Task.Run(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"some car left the parking lot, here is the location: " +
                        $"{parkingLot.FreeSomeSlot()}");
                    
                }
            });

            Console.ReadLine();

        }
    }
}
