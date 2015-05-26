using NUnit.Framework;

namespace Conways2
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestFixture]
    public class WorldTests
    {
        [Test]
        public void ALoneCell_HasNoNeighbours()
        {
            var world = new World();
            var location = new Location(1, 1);
            world.AddCell(5, 1);
            Assert.AreEqual(world.GetNeighbours(location), 0);
        }

        [Test]
        public void SameLocation_CantBeNeighbourToItself()
        {
            var world = new World();
            var location = new Location(1, 1);
            world.AddCell(1, 1);
            Assert.AreEqual(world.GetNeighbours(location), 0);
        }
        
        [TestCase(0, 0)]
        [TestCase(1, 0)]
        [TestCase(2, 0)]
        [TestCase(0, 1)]
        [TestCase(2, 1)]
        [TestCase(0, 2)]
        [TestCase(1, 2)]
        [TestCase(2, 2)]
        public void AdjoiningLocations_AreNeighboursToCell(int xPosCell, int yPosCell)
        {
            var world = new World();
            var location = new Location(1, 1);
            world.AddCell(xPosCell, yPosCell);
            Assert.AreEqual(world.GetNeighbours(location), 1);
        }
        
        [Test]
        public void TwoAdjoiningLocations_AreNeighboursToCell()
        {
            var world = new World();
            var location = new Location(1, 1);
            world.AddCell(2, 0);
            world.AddCell(1, 0);
            Assert.AreEqual(world.GetNeighbours(location), 2);
        }

        [Test]
        public void AnEmptyWorldWithNoCells_HasNoNeighboursToALocation()
        {
            var world = new World();
            var location = new Location(1, 1);
            Assert.AreEqual(world.GetNeighbours(location), 0);
        }

        [Test]
        public void WorldWithSingleCell_OnEvent_BecomesEmpty() // DeadWorld Scenario 1
        {
            var world = World.CreateEmpty();
            world.AddCell(1, 1);  
  
            world.Event();  

            Assert.That(world.IsEmpty(),Is.True);
        }

        [Test]
        public void WorldWithTwoNeighbouringCells_OnEvent_BecomesEmpty() // DeadWorld Scenario 2
        {
            var world = new World();
            world.AddCell(1, 1);
            world.AddCell(1, 2);

            world.Event();
            
            Assert.That(world.IsEmpty(), Is.True);
        }

       

        [Test]
        public void Static_Beehive()
        {
            var world = new World();

            world.AddCell(3, 2);
            world.AddCell(4, 2);
            world.AddCell(2, 3);
            world.AddCell(5, 3);
            world.AddCell(3, 4);
            world.AddCell(4, 4);
           
            world.Event();

           Assert.AreEqual(world.Count(), 6);
           Assert.IsTrue(world.IsLocationOccupied(3, 2));
           Assert.IsTrue(world.IsLocationOccupied(2, 3));
           Assert.IsTrue(world.IsLocationOccupied(5, 3));
           Assert.IsTrue(world.IsLocationOccupied(3, 4));
           Assert.IsTrue(world.IsLocationOccupied(4, 4));
            
        }

          [Test]
        public void Static_Block()
        {
            var world = new World();

            world.AddCell(2, 2);
            world.AddCell(2, 3);
            world.AddCell(3, 2);
            world.AddCell(3, 3);

            world.Event();

            Assert.AreEqual(world.Count(), 4);
            Assert.IsTrue(world.IsLocationOccupied(2, 2));
            Assert.IsTrue(world.IsLocationOccupied(2, 3));
            Assert.IsTrue(world.IsLocationOccupied(3, 2));
            Assert.IsTrue(world.IsLocationOccupied(3, 3));
        }

        [Test]
        public void Static_Loaf()
        {
            var world = new World();

            world.AddCell(2, 2);
            world.AddCell(2, 3);
            world.AddCell(3, 1);
            world.AddCell(3, 4);
            world.AddCell(4, 2);
            world.AddCell(4, 4);
            world.AddCell(5, 3);

            world.Event();

            Assert.AreEqual(world.Count(), 7);
            Assert.IsTrue(world.IsLocationOccupied(2, 2));
            Assert.IsTrue(world.IsLocationOccupied(2, 3));
            Assert.IsTrue(world.IsLocationOccupied(3, 1));
            Assert.IsTrue(world.IsLocationOccupied(3, 4));
            Assert.IsTrue(world.IsLocationOccupied(4, 2));
            Assert.IsTrue(world.IsLocationOccupied(4, 4));
            Assert.IsTrue(world.IsLocationOccupied(5, 3));
        }

        [Test]
        public void Oscillator_Blinker()
          {
              var world = new World();

              world.AddCell(1, 0);
              world.AddCell(1, 1);
              world.AddCell(1, 2);

              world.Event();
             
            Assert.AreEqual(world.Count(), 3); 
            Assert.IsTrue(world.IsLocationOccupied(0,1));
            Assert.IsTrue(world.IsLocationOccupied(1,1));
            Assert.IsTrue(world.IsLocationOccupied(2,1));
          }
       

       

     

   
    }
}

