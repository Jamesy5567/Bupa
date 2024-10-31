using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BupaApp.Tests.Tests
{
    [TestClass]
    public class Vehicle
    {
        private readonly Moq<IVehicleRepository> _vehicle;
        public Vehicle(IVehicleRepository vehicle)
        {
            _vehicle = vehicle;
        }

        [Test]
        public async void GetVehicleAsync_ReturnList()
        {
            var result = await _vehicle.GetVehicle("CU16XFT");

            Assert.IsNotNull(result);
        }
    }
}