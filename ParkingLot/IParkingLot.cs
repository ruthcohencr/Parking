using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    interface IParkingLot
    {
        Location FindFreeSlot();
        Location FreeSomeSlot();
        bool IsFull { get; }
    }
}
