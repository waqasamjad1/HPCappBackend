using System;
using Xunit;
using HPCapp.BL;

namespace HPCapp.UnitTest
{
    public class ShipProcessorUnitTest
    {
        [Fact]
        public void Test_InValidShipId()
        {
            var shipProcessor = new ShipProcessor();
            Assert.Throws<ArgumentNullException>(() => shipProcessor.ShipIDDetails(new Models.ShipDetail()));
        }

        [Fact]
        public void Test_ValidShipId()
        {
            var shipProcessor = new ShipProcessor();
            Assert.True(shipProcessor.ShipIDDetails(new Models.ShipDetail{ id = new Guid("77e38601-18ef-450c-abea-b1f4c2af6465")}));
        }

        [Fact]
        public void Test_InValidShipCode()
        {
            var shipProcessor = new ShipProcessor();
            Assert.True(shipProcessor.ShipCodeDetails(new Models.ShipDetail { code = "1111-1123-11" }));
        }
    }
}
