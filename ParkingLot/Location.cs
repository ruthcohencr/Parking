using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    class Location
    {
        private int _row;
        private int _col;

        public Location(int row, int col)
        {
            _row = row;
            _col = col;
        }

        public override string ToString()
        {
            return $" row number {_row}, col number {_col}";
        }
    }
}
