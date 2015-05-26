using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conways2
{
    public class Location
    {
        private readonly int PosX;
        private readonly int PosY;

        public Location(int posX, int posY)
        {
            
            PosX = posX;
            PosY = posY;
        }

        internal int GetPosX()
        {
            return PosX;
        }

        internal int GetPosY()
        {
            return PosY;
        }

     

        internal bool IsSamePosition(Location location2)
        {
            if (GetPosX() != location2.GetPosX()) return false;
            if (GetPosY() != location2.GetPosY()) return false;
            return true;
        }
    }
}
