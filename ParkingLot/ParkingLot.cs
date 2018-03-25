using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    class ParkingLot : IParkingLot
    {
        private Dictionary<int, Slot> SlotsDictionary;

        private bool _isFull;

        public bool IsFull
        {
            get { return _isFull = SlotsDictionary.Where(s => s.Value.IsAvailable).Count() == 0 ? true : false; }
            private set { _isFull = value; }
        }

        public ParkingLot()
        {
            InitParkingLot();
        }

        public Location FindFreeSlot()
        {
            Location result = null;
            if (!IsFull)
            {
                // take the number of free slot
                int freeSlotId = SlotsDictionary.FirstOrDefault(s => s.Value.IsAvailable).Key;

                lock (SlotsDictionary[freeSlotId])
                {
                    if (SlotsDictionary[freeSlotId].IsAvailable)
                    {
                        // take the slot object
                        Slot foundSlot = SlotsDictionary[freeSlotId];

                        // catch the slot
                        CatchSlot(foundSlot);

                        // take location of found slot
                        result = foundSlot.Location;
                    }
                }
            }

            // found location
            return result;
        }

        private void CatchSlot(Slot slot)
        {
            // update slot object its not avilable at the moment
            slot.CatchSlot();
        }

        // free the first found catch slot
        public Location FreeSomeSlot()
        {
            Location slotLocation = null;
            int amountOfFreeSlots = SlotsDictionary.Where(s => !s.Value.IsAvailable).Count();
            if (amountOfFreeSlots > 0)
            {
                // take the first catch slot on the dictionary in purpose to free it.
                int slotNumber = SlotsDictionary.LastOrDefault(s => !s.Value.IsAvailable).Key;

                lock (SlotsDictionary[slotNumber])
                {
                    if (!SlotsDictionary[slotNumber].IsAvailable)
                    {
                        Slot slot = SlotsDictionary[slotNumber];
                        // let slot know it's free
                        slot.FreeSlot();
                        slotLocation = slot.Location;
                    }

                }
            }
            return slotLocation;
        }

        private void InitParkingLot()
        {
            SlotsDictionary = new Dictionary<int, Slot>
            {
              { 1, new Slot(1,true,1,1) },
              { 2, new Slot(2,true,1,2) },
              { 3, new Slot(3,true,1,3) },
              { 4, new Slot(4,true,1,4) },
              { 5, new Slot(5,true,1,5) },
              { 6, new Slot (6,false,4,1) },
              { 7, new Slot (7,false,4,2) },
              { 8, new Slot (8,false,4,3) },
              { 9, new Slot (9,false,4,4) },
              { 10, new Slot (10,false,4,5) }
            };
        }
    }
}
