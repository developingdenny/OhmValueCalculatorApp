using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OhmValueCalculatorApp.CalculateOhmValue
{
    public class CalculateOhmValueResponse
    {
        public bool success;
        public string message;
        public int calculatedValue;
        public double toleranceValue;
    }
}