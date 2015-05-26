using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;

namespace Conways2
{
    class Cell
    {
        private int _neighbours;

        internal void SetNeighbours(int neighbours)
        {
            _neighbours = neighbours;
        }

        internal bool WillLivingCellStayAlive()
        {
            if (_neighbours <= 1) return false;
            if (_neighbours >= 4) return false;
            return true;
        }

        internal bool WillCellLive(bool isCellLiving)
        {
            if (!isCellLiving)
            {
                return WillDeadCellComeAlive();
            }

            return WillLivingCellStayAlive();
        }

        private bool WillDeadCellComeAlive()
        {
            if (_neighbours != 3) return false;
            return true;
        }
    }
}
