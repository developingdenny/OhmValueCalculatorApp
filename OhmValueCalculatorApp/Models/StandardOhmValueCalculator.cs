using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OhmValueCalculatorApp.CalculateOhmValue;

namespace OhmValueCalculatorApp.Models
{
    public class StandardOhmValueCalculator : IOhmValueCalculator
    {
        const int NOT_FOUND = -1;

        private ResistorColorCodes resistorColorCodes = new ResistorColorCodes();

        public double CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            long firstFigure = 0;
            long secondFigure = 0;
            long decimalMultiplier = 0;
            double toleranceValue = 0;
            double decimalMultiplierScalar = 0;

            double ohmValue;

            bool bandAProvided = bandAColor.Length > 0;
            bool bandBProvided = bandBColor.Length > 0;
            bool bandCProvided = bandCColor.Length > 0;
            bool bandDProvided = bandDColor.Length > 0;

            // validate input scenario
            if (!bandAProvided)
            {
                throw new ArgumentException("Must provide valid bandAColor");
            }

            // band b not provided but band c provided
            if (!bandBProvided && bandCProvided)
            {
                throw new ArgumentException("Must provide valid bandBColor when bandCColor provided");
            }

            // translate each band color to corresponding digits
            firstFigure = resistorColorCodes.translateColorCodeToDigit(bandAColor);
            if (bandBProvided) secondFigure = resistorColorCodes.translateColorCodeToDigit(bandBColor);
            if (bandCProvided) decimalMultiplier = resistorColorCodes.translateColorCodeToDigit(bandCColor);
            if (bandDProvided) toleranceValue = resistorColorCodes.translateToleranceColor(bandDColor);
            
            // run digits through formula to generate result
            if (!bandBProvided)
            {
                return (Int64)firstFigure;
            }

            if (!bandCProvided)
            {
                return (Int64)(firstFigure * 10 + secondFigure);
            }
            
            decimalMultiplierScalar = Math.Pow(10, decimalMultiplier);

            ohmValue = (firstFigure * 10 + secondFigure) * decimalMultiplierScalar;

            return ohmValue;
        }

    }
}