using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OhmValueCalculatorApp.CalculateOhmValue
{

    public class ResistorColorCodes
    {
        private const string Pink = "pink";
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

        private const string EMPTY_STRING = "";

        private readonly string[] valueBandColorCodes = { Pink, Silver, Gold, Black, Brown, Red, Orange, Yellow, Green, Blue, Violet, Gray, White };
        private readonly string[] toleranceBandColorCodes = { Silver, Gold, Brown, Red, Yellow, Green, Blue, Violet, Gray };

        readonly Dictionary<string, int> ValueBandColorCodeDictionary = new Dictionary<string, int>()
        {
            {Pink, -3 },
            {Silver, -2 },
            {Gold, -1 },
            {Black, 0 },
            {Brown, 1 },
            {Red, 2 },
            {Orange, 3 },
            {Yellow,4 },
            {Green, 5 },
            {Blue,6 },
            {Violet, 7 },
            {Gray, 8 },
            {White, 9 },
        };

        readonly Dictionary<string, double> ToleranceBandColorCodeDictionary = new Dictionary<string, double>()
        {
            {EMPTY_STRING, 0.2 },
            {Silver, 0.1 },
            {Gold, 0.05 },
            {Brown, 0.01 },
            {Red, 0.02 },
            {Green, 0.005 },
            {Blue, 0.0025 },
            {Violet, 0.001 },
            {Gray, 0.0005 }
        };



        private bool isValidBandColor(string bandColor, string[] bandColorLegend)
        {
            int legendColorIdx;
            string normalizedBandColor = bandColor.ToLower();

            legendColorIdx = Array.IndexOf(bandColorLegend, normalizedBandColor);

            return legendColorIdx != -1;
        }

        public bool isValidBandAtoCColor(string bandColor)
        {
            return isValidBandColor(bandColor, valueBandColorCodes);
        }

        public bool isValidToleranceBandColor(string bandColor)
        {
            return isValidBandColor(bandColor, toleranceBandColorCodes);
        }

        public int translateColorCodeToDigit(string bandColor)
        {
            string normalizedBandColor = bandColor.ToLower();
            int digit;

            try
            {
                digit = ValueBandColorCodeDictionary[normalizedBandColor];
            }
            catch (KeyNotFoundException e)
            {
                throw new ArgumentException("Invalid band color");
            }

            return digit;

        }

        public double translateToleranceColor(string bandColor)
        {
            double toleranceValue;
            string normalizedBandColor = bandColor.ToLower();

            try
            {
                toleranceValue = ToleranceBandColorCodeDictionary[normalizedBandColor];
            }
            catch (KeyNotFoundException e)
            {
                throw new ArgumentException("Invalid tolerance band color");
            }

            return toleranceValue;

        }

    }
}