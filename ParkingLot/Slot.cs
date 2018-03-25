using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    class Slot: ISlot
    {
        public int Id { get; private set; }
        public bool IsAvailable { get; private set; }
        public Location Location { get; private set; }

        // location
        public Slot(int id, bool isAvailable, int row, int col)
        {
            Id = id;
            IsAvailable = isAvailable;
            Location = new Location(row, col);
        }

        public void FreeSlot()
        {
            this.IsAvailable = true;
        }

        public void CatchSlot()
        {
            this.IsAvailable = false;
        }
    }
}
