using System;

using NUnit.Framework;

namespace Conways2
{
    [TestFixture]
    public class TestsCell
    {
        [TestCase(1)]
        [TestCase(0)]
        public void UnderPopulation_Death(int neighbours)
        {
            var cell = new Cell();
            cell.SetNeighbours(neighbours);
            Assert.IsFalse(cell.WillLivingCellStayAlive());
        }

        [TestCase(4)]
        [TestCase(5)]
        public void OverPopulation_Death(int neighbours)
        {
            var cell = new Cell();
            cell.SetNeighbours(neighbours);
            Assert.IsFalse(cell.WillLivingCellStayAlive());
        }

        [TestCase(2)]
        [TestCase(3)]
        public void PerfectBalancePopulation_Lives(int neighbours)
        {
            var cell = new Cell();
            cell.SetNeighbours(neighbours);
            Assert.IsTrue(cell.WillLivingCellStayAlive());
        }

    [TestCase(3)]
        public void DeadCellCorrectRessurectionConditions_Ressurection(int neighbours)
        {
            var cell = new Cell();
            cell.SetNeighbours(neighbours);
            Assert.IsTrue(cell.WillCellLive(false));
        }

        [TestCase(1)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(2)]
        public void DeadCellIncorrectResurrectionConditions_StaysDead(int neighbours)
        {
            var cell = new Cell();
            cell.SetNeighbours(neighbours);
            Assert.IsFalse(cell.WillCellLive(false));
        }

    }
}
