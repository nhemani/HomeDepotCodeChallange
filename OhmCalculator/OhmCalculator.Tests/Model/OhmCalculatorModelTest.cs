using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OhmCalculator.Tests.Model
{
    [TestClass]
    public class OhmValueCalculatorTest
    {
        [TestMethod]
        public void ValidInputs()
        {
            var model1 = new OhmCalculator.Models.OhmValueCalculator();
            var result = model1.CalculateOhmValue("1", "1", "1", "1");
            Assert.IsNotNull(result);
            Assert.AreEqual(11, result, "Result should be 11");

        }

        [TestMethod]
        public void InvalidInput1()
        {
                 var model1 = new OhmCalculator.Models.OhmValueCalculator();
                var result = model1.CalculateOhmValue("a", "1", "1", "1");
                Assert.AreEqual(0, result, "This should return zero value");
                

        }

        [TestMethod]
        public void InvalidInput2()
        {
            var model1 = new OhmCalculator.Models.OhmValueCalculator();
            var result = model1.CalculateOhmValue("2", "a", "1", "1");
            Assert.AreEqual(0, result, "This should return zero value");


        }

        [TestMethod]
        public void InvalidInput3()
        {
            var model1 = new OhmCalculator.Models.OhmValueCalculator();
            var result = model1.CalculateOhmValue("2", "2", "a", "1");
            Assert.AreEqual(0, result, "This should return zero value");


        }
    }
}
