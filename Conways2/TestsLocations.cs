using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;


namespace Conways2
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestFixture]
    public class TestsLocations
    {
        [Test]
        public void Check_For_SameLocation()
        {
            var location = new Location(1, 1);
            var location2 = new Location(1, 1);
            Assert.IsTrue(location.IsSamePosition(location2));
        }
        [Test]
        public void Check_For_DifferentLocations()
        {
            var location = new Location(1, 1);
            var location2 = new Location(1, 2);
            Assert.IsFalse(location.IsSamePosition(location2));
        }
    }
}
