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
        public double calculatedValue;
        public double toleranceValue;
    }
}