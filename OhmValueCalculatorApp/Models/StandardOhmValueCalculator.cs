using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OhmValueCalculatorApp.Models
{
    public class StandardOhmValueCalculator : IOhmValueCalculator
    {
        private const string Silver = "silver";
        private const string Gold = "gold";
        private const string Black = "black";
        private const string Brown = "brown";
        private const string Red = "red";
        private const string Orange = "orange";
        private const string Yellow = "yellow";
        private const string Green = "green";
        private const string Blue = "blue";
        private const string Violet = "violet";
        private const string Gray = "gray";
        private const string White = "white";

        private string[] valueBandColorCodes = new string[] { Black, Brown, Red, Orange, Yellow, Green, Blue, Violet, Gray, White };
        private string[] toleranceBandColorCodes = new string[] { Silver, Gold, Brown, Red, Yellow, Green, Blue, Violet, Gray };

        private Boolean isEmptyBandColor(string bandColor)
        {
            return bandColor == "";
        }

        //private Boolean isValidBandColor(string bandColor, string[] bandColorLegend)
        //{
        //    int legendColorIdx;
        //    string normalizedBandColor = bandColor.ToLower();

        //    legendColorIdx = Array.IndexOf(valueBandColorCodes, normalizedBandColor);

        //    return legendColorIdx != -1;
        //}

        private int translateColorCodeToDigit(string bandColor)
        {
            string normalizedBandColor = bandColor.ToLower();
            int digit;

            // find the index of the normalized color and return it.
            digit = Array.IndexOf(valueBandColorCodes, normalizedBandColor);

            return digit;
        }

        public int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            int firstFigure;
            int secondFigure;
            int decimalMultiplier;
            int toleranceValue;
            double decimalMultiplierScalar;

            // translate each band color to corresponding digits
            firstFigure = translateColorCodeToDigit(bandAColor);
            secondFigure = translateColorCodeToDigit(bandBColor);
            decimalMultiplier = translateColorCodeToDigit(bandCColor);
            toleranceValue = translateColorCodeToDigit(bandDColor);

            if (secondFigure == -1)
            {
                return firstFigure;
            }

            if (decimalMultiplier == -1)
            {
                return firstFigure * 10 + secondFigure;
            }

            // run digits through a formula to generate result
            decimalMultiplierScalar = Math.Pow(10, decimalMultiplier);

            return (firstFigure * 10 + secondFigure) * Convert.ToInt32(decimalMultiplierScalar);
        }

    }
}