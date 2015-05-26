using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conways2
{
    public class LocationsEquals : IEqualityComparer<Location>
    {
        public bool Equals(Location left, Location right)
        {
            if ((object) left == null && (object) right == null)
            {
                return true;
            }
            if ((object) left == null || (object) right == null)
            {
                return false;
            }
            return left.GetPosX() == right.GetPosX() && left.GetPosY() == right.GetPosY();
        }

        public int GetHashCode(Location location)
        {
            int hashPosX = location.GetPosX() == null ? 0 : location.GetPosX().GetHashCode();
            int hashPosY = location.GetPosY() == null ? 0 : location.GetPosY().GetHashCode();
            return hashPosX ^ hashPosY;
        }
    }
}
