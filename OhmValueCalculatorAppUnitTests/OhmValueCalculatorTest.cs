using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OhmValueCalculatorApp.Models;

namespace OhmValueCalculatorAppUnitTests
{
    [TestClass]
    public class OhmValueCalculatorTest
    {
        [TestMethod]
        public void StandardOhmValueCalculator_CalculateOhmValue_WithValidInputs_ReturnsInteger()
        {
            string bandAColor = "brown";
            string bandBColor = "black";
            string bandCColor = "yellow";
            string bandDColor = "gold";

            int value;
            StandardOhmValueCalculator calculator = new StandardOhmValueCalculator();

            value = calculator.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);

            Assert.AreEqual(value.GetType(), typeof(int));
        }

        [TestMethod]
        public void StandardOhmValueCalculator_WithSingleBandInput_ProducesValidResult()
        {
            string bandAColor = "brown";
            string bandBColor = "";
            string bandCColor = "";
            string bandDColor = "";

            int value;
            StandardOhmValueCalculator calculator = new StandardOhmValueCalculator();

            value = calculator.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);

            Assert.IsNotNull(value);
            Assert.AreEqual(1, value);
        }

        [TestMethod]
        public void StandardOhmValueCalculator_WithTwoBandInput_ProducesValidResult()
        {
            string bandAColor = "gray";
            string bandBColor = "white";
            string bandCColor = "";
            string bandDColor = "";

            int value;
            StandardOhmValueCalculator calculator = new StandardOhmValueCalculator();

            value = calculator.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);

            Assert.AreEqual(89, value);
        }

        [TestMethod]
        public void StandardOhmValueCalculator_WithThreeBandInput_ProducesValidResult()
        {
            string bandAColor = "yellow";
            string bandBColor = "black";
            string bandCColor = "brown";
            string bandDColor = "";

            int value;
            StandardOhmValueCalculator calculator = new StandardOhmValueCalculator();

            value = calculator.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);

            Assert.AreEqual(400, value);
        }

        [TestMethod]
        public void StandardOhmValueCalculator_WithFourBandInput_ProducesValidResult()
        {
            string bandAColor = "red";
            string bandBColor = "orange";
            string bandCColor = "blue";
            string bandDColor = "";

            int value;
            StandardOhmValueCalculator calculator = new StandardOhmValueCalculator();

            value = calculator.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);

            Assert.AreEqual(23000000, value);
        }

        [TestMethod]
        public void StandardOhmValueCalculator_WithValidInput_ProducesExtremeLimitResult()
        {
            string bandAColor = "white";
            string bandBColor = "white";
            string bandCColor = "gray";
            string bandDColor = "";

            int value;
            StandardOhmValueCalculator calculator = new StandardOhmValueCalculator();

            value = calculator.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);

            Assert.AreEqual(99000000000, value);
        }

        [TestMethod]
        public void StandardOhmValueCalculator_CalculateOhmValue_WithValidInputs_ReturnsAccurateResults()
        {
            string bandAColor = "red";
            string bandBColor = "violet";
            string bandCColor = "green";
            string bandDColor = "gold";

            int value;
            StandardOhmValueCalculator calculator = new StandardOhmValueCalculator();

            value = calculator.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);

            Assert.AreEqual(2700000, value);
        }

    }
}
