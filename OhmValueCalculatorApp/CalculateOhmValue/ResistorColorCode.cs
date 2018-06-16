using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OhmValueCalculatorApp.CalculateOhmValue
{

    public class ResistorColorCode
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

        private readonly string[] valueBandColorCodes = { Black, Brown, Red, Orange, Yellow, Green, Blue, Violet, Gray, White };
        private readonly string[] toleranceBandColorCodes = { Silver, Gold, Brown, Red, Yellow, Green, Blue, Violet, Gray };

        //private Dictionary<string, float> toleranceColorCodeDictionary = new Dictionary<string, float>();



        private bool isValidBandColor(string bandColor, string[] bandColorLegend)
        {
            int legendColorIdx;
            string normalizedBandColor = bandColor.ToLower();

            legendColorIdx = Array.IndexOf(bandColorLegend, normalizedBandColor);

            return legendColorIdx != -1;
        }

        public double translateToleranceColor(string bandColor)
        { 
            if ((bandColor.Length > 0) && !isValidToleranceBandColor(bandColor))
            {
                throw new Exception("Invalid tolerance color: " + bandColor);
            }

            switch (bandColor) {
                case "":
                    return 0.2;
                case ResistorColorCode.Silver:
                    return 0.1;
                case ResistorColorCode.Gold:
                    return 0.05;
                case ResistorColorCode.Brown:
                    return 0.01;
                case ResistorColorCode.Red:
                    return 0.02;
                case ResistorColorCode.Green:
                    return 0.005;
                case ResistorColorCode.Blue:
                    return 0.0025;
                case ResistorColorCode.Violet:
                    return 0.001;
                default:
                    return 0.2;
            }

        }

        public bool isValidBandAtoCColor(string bandColor)
        {
            return isValidBandColor(bandColor, valueBandColorCodes);
        }

        public bool isValidToleranceBandColor(string bandColor)
        {
            return isValidBandColor(bandColor, toleranceBandColorCodes);
        }
    }
}