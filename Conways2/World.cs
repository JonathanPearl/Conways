using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Conways2
{
    class World
    {
        private List<Location> _locations = new List<Location>();
       private List <Location> _newLocations = new List<Location>();

        public static World CreateEmpty()
        {
            return new World();
        }
       
        internal  void AddCell(int PosX, int PosY)
        {
            _locations.Add(new Location(PosX,PosY));
        }

        public bool IsEmpty()
        {
            return Count() == 0;
        }

        internal  int Count()
        {
            IEnumerable<Location> noDuplicates = _locations.Distinct(new LocationsEquals());
          return noDuplicates.Count();

        }

        internal void Event()
        {
            foreach (var location in _locations)
            {
                CheckLivingCellsLocations(location, true);
                CheckDeadCellsLocations(location);
            }
            _locations = _newLocations;
        }

 
  

        private void CheckDeadCellsLocations(Location location)
        {
            CheckAdjoiningXLocations(location);
        }

        private void CheckAdjoiningXLocations(Location location)
        {
            int varianceX = -1;
            while (varianceX <= 1)
            {
               
                if (varianceX!=0) CheckAdjoiningYLocations(location, varianceX);
                varianceX += 1;
            }
        }

        private void CheckAdjoiningYLocations(Location location, int varianceX)
        {
            int varianceY = -1;
            while (varianceY <= 1)

            {
                var newlocationCheck =new Location(location.GetPosX()+varianceX,location.GetPosY()+varianceY);
                if (varianceY!=0)
                if (!IsLocationOccupied(newlocationCheck))CheckLivingCellsLocations(newlocationCheck,false);
                varianceY += 1;
            }

        }

        

        private void CheckLivingCellsLocations(Location location, bool isCellAlive)
        {
            var cell = new Cell();
            cell.SetNeighbours(GetNeighbours(location));
            if (cell.WillCellLive(isCellAlive))
            {
                _newLocations.Add(location);
            }
        }

        internal int GetNeighbours(Location location)
        {
            int neighbours = 0;
            foreach (var potentialNeighbourLocation in _locations)
            {
                if (potentialNeighbourLocation.IsSamePosition(location)) continue;

                if (potentialNeighbourLocation.GetPosX() > location.GetPosX()  +1)  continue;
                if (potentialNeighbourLocation.GetPosX() < location.GetPosX() - 1) continue;

                if (potentialNeighbourLocation.GetPosY() > location.GetPosY() + 1) continue;
                if (potentialNeighbourLocation.GetPosY() < location.GetPosY() - 1) continue;
                
                neighbours++;
            }
            return neighbours;
        }

        public bool IsSpecifiedLocationOccupied(int xpos, int ypos, List<Location> currentLocations )
        {
            foreach (var location in currentLocations)
            {
                if (location.GetPosX() == xpos && location.GetPosY() == ypos) return true;

            }
            return false;
        }

        public bool IsLocationOccupied(int xpos, int ypos, List<Location> locations )
        {
            foreach (var location in locations)
            {
                if (location.GetPosX() == xpos && location.GetPosY() == ypos) return true;

            }
            return false;
        }

        private bool IsLocationOccupied(Location locationCheck)
        {
            return IsLocationOccupied(locationCheck.GetPosX(), locationCheck.GetPosY());
        }

        public bool IsLocationOccupied(int xpos, int ypos)
        {
            return IsLocationOccupied(xpos, ypos, _locations);
        }



    }

}
