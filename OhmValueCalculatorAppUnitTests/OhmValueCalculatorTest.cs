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

            double value;
            StandardOhmValueCalculator calculator = new StandardOhmValueCalculator();

            value = calculator.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);

            Assert.AreEqual(value.GetType(), typeof(double));
        }

        [TestMethod]
        public void StandardOhmValueCalculator_WithSingleBandInput_ProducesValidResult()
        {
            string bandAColor = "brown";
            string bandBColor = "";
            string bandCColor = "";
            string bandDColor = "";

            double value;
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

            double value;
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

            double value;
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

            double value;
            StandardOhmValueCalculator calculator = new StandardOhmValueCalculator();

            value = calculator.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);

            Assert.AreEqual(23000000, value);
        }

        [TestMethod]
        public void StandardOhmValueCalculator_WithValidInput_ProducesExtremeLimitResult()
        {
            string bandAColor = "white";
            string bandBColor = "white";
            string bandCColor = "white";
            string bandDColor = "";

            double value;
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

            double value;
            StandardOhmValueCalculator calculator = new StandardOhmValueCalculator();

            value = calculator.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);

            Assert.AreEqual(2700000, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Must provide valid bandAColor")]
        public void StandardOhmValueCalculator_CalculateOhmValue_WithInValidInputs_MissingBandA_ThrowsException()
        {
            // setup invalid arguments
            string bandAColor = "";
            string bandBColor = "red";
            string bandCColor = "green";
            string bandDColor = "gold";

            double value;
            StandardOhmValueCalculator calculator = new StandardOhmValueCalculator();

            value = calculator.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);

            // should never reach this assertion
            Assert.IsFalse(true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Must provide valid bandBColor when bandCColor provided")]
        public void StandardOhmValueCalculator_CalculateOhmValue_WithInValidInputs_MissingBandB_HasBandC_ThrowsException()
        {
            // setup invalid arguments
            string bandAColor = "blue";
            string bandBColor = "";
            string bandCColor = "green";
            string bandDColor = "gold";

            double value;
            StandardOhmValueCalculator calculator = new StandardOhmValueCalculator();

            value = calculator.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);

            // should never reach this assertion
            Assert.IsFalse(true);
        }

        [TestMethod]
        public void StandardOhmValueCalculator_CalculateOhmValue_WithValidInputs_ReturnsAccurateThousandthsFractionalResults()
        {
            string bandAColor = "red";
            string bandBColor = "violet";
            string bandCColor = "pink";
            string bandDColor = "gold";

            double value;
            StandardOhmValueCalculator calculator = new StandardOhmValueCalculator();

            value = calculator.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);

            Assert.AreEqual(0.027, value, 0.001);
        }

        [TestMethod]
        public void StandardOhmValueCalculator_CalculateOhmValue_WithValidInputs_ReturnsAccurateHundredthsFractionalResults()
        {
            string bandAColor = "green";
            string bandBColor = "brown";
            string bandCColor = "silver";
            string bandDColor = "gold";

            double value;
            StandardOhmValueCalculator calculator = new StandardOhmValueCalculator();

            value = calculator.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);

            Assert.AreEqual(0.51, value, 0.01);
        }


        [TestMethod]
        public void StandardOhmValueCalculator_CalculateOhmValue_WithValidInputs_ReturnsAccurateTenthsFractionalResults()
        {
            string bandAColor = "orange";
            string bandBColor = "yellow";
            string bandCColor = "gold";
            string bandDColor = "gold";

            double value;
            StandardOhmValueCalculator calculator = new StandardOhmValueCalculator();

            value = calculator.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);

            Assert.AreEqual(3.4, value, 0.1);
        }


    }
}
