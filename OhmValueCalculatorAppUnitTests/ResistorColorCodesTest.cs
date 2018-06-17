using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OhmValueCalculatorApp.CalculateOhmValue;

namespace OhmValueCalculatorAppUnitTests
{
    [TestClass]
    public class ResistorColorCodesTest
    {
        [TestMethod]
        public void ResistorColorCodes_isValidBandAtoCColor_WithValidInputs_ReturnsTrue()
        {
            ResistorColorCodes resistorColorCodes = new ResistorColorCodes();
            string color = "Red";

            bool result = resistorColorCodes.isValidBandAtoCColor(color);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ResistorColorCodes_isValidBandAtoCColor_IgnoresCaseWithValidInputs_ReturnsTrue()
        {
            ResistorColorCodes resistorColorCodes = new ResistorColorCodes();
            string color = "oRangE";

            bool result = resistorColorCodes.isValidBandAtoCColor(color);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ResistorColorCodes_isValidBandAtoCColor_WithInValidInputs_ReturnsFalse()
        {
            ResistorColorCodes resistorColorCodes = new ResistorColorCodes();
            string color = "Magenta";

            bool result = resistorColorCodes.isValidBandAtoCColor(color);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ResistorColorCodes_isValidBandAtoCColor_WithAnyValidInput_ReturnsTrue()
        {
            ResistorColorCodes resistorColorCodes = new ResistorColorCodes();
            string[] colors = { "pink", "silver", "Gold", "black", "brown", "red", "Orange", "Yellow", "green", "blue", "violet", "gray", "white" };
            bool result;

            foreach (string color in colors)
            {
                result = resistorColorCodes.isValidBandAtoCColor(color);

                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void ResistorColorCodes_isValidToleranceBandColor_WithAnyValidInput_ReturnsTrue()
        {
            ResistorColorCodes resistorColorCodes = new ResistorColorCodes();
            string[] colors = { "silver", "Gold", "brown", "red", "Yellow", "green", "blue", "violet", "gray" };
            bool result;

            foreach (string color in colors)
            {
                result = resistorColorCodes.IsValidToleranceBandColor(color);

                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void ResistorColorCodes_translateColorCodeToDigit_WithAValidInput_ReturnsAccurateDigitRepresentation()
        {
            ResistorColorCodes resistorColorCodes = new ResistorColorCodes();
            string color = "brown";

            double digit = resistorColorCodes.TranslateColorCodeToDigit(color);

            Assert.AreEqual(1, digit);
        }

        [TestMethod]
        public void ResistorColorCodes_translateColorCodeToDigit_WithAnyValidInput_ReturnsDigitRepresentatione()
        {
            ResistorColorCodes resistorColorCodes = new ResistorColorCodes();
            string[] colors = { "pink", "silver", "Gold", "black", "brown", "red", "Orange", "Yellow", "green", "blue", "violet", "gray", "white" };
            double digit;
            double expectedDigit = -3;

            foreach (string color in colors)
            {
                digit = resistorColorCodes.TranslateColorCodeToDigit(color);

                Assert.AreEqual(expectedDigit, digit);

                expectedDigit++;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid band color")]
        public void ResistorColorCodes_translateColorCodeToDigit_WithInValidInput_ThrowsException()
        {
            // setup invalid arguments
            ResistorColorCodes resistorColorCodes = new ResistorColorCodes();
            string color = "beige";

            double digit = resistorColorCodes.TranslateColorCodeToDigit(color);
           
            // should never reach this assertion
            Assert.IsFalse(true);
        }

        
        [TestMethod]
        public void ResistorColorCodes_translateToleranceColor_WithAValidInput_ReturnsAccurateDecimalMultiplier()
        {
            ResistorColorCodes resistorColorCodes = new ResistorColorCodes();
            string color = "gold";

            double digit = resistorColorCodes.TranslateToleranceColor(color);

            Assert.AreEqual(0.05, digit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid tolerance band color")]
        public void ResistorColorCodes_translateToleranceColor_WithInValidInput_ThrowsException()
        {
            // setup invalid arguments
            ResistorColorCodes resistorColorCodes = new ResistorColorCodes();
            string color = "purple";

            double digit = resistorColorCodes.TranslateToleranceColor(color);

            // should never reach this assertion
            Assert.IsFalse(true);
        }

    }
}
