using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OhmValueCalculatorApp.Models;

namespace OhmValueCalculatorApp.CalculateOhmValue
{
    public class CalculateOhmValueUseCase
    {
        private ResistorColorCode resistorColorCode = new ResistorColorCode();

        private CalculateOhmValueResponse response = new CalculateOhmValueResponse();

        private bool IsValidRequest(CalculateOhmValueRequest request)
        {
            bool bandAColorProvided = request.bandAColor.Length > 1;
            bool bandBColorProvided = request.bandBColor.Length > 1;
            bool bandCColorProvided = request.bandCColor.Length > 1;
            bool toleranceBandProvided = request.toleranceBandColor.Length > 1;


            // ensure at least band 1 is provided
            if (!bandAColorProvided)
            {
                // send error message
                createErrorResponse("Must provide first band color");
                return false;
            }

            // verify no gap in band colors specified
            if (bandCColorProvided && !bandBColorProvided)
            {
                createErrorResponse("Can not specify third band without a second");
                return false;
            }


            // verify the band colors provided are valid by consulting with dictionary
            if (!resistorColorCode.isValidBandAtoCColor(request.bandAColor))
            {
                createErrorResponse("Band A color is invalid. Cannot be " + request.bandAColor);
                return false;
            }

            // test optional band colors
            if (bandBColorProvided)
            {
                if (!resistorColorCode.isValidBandAtoCColor(request.bandAColor))
                {
                    createErrorResponse("Band B color is invalid. Cannot be " + request.bandBColor);
                    return false;
                }
            }

            if (bandCColorProvided)
            {
                if (!resistorColorCode.isValidBandAtoCColor(request.bandCColor))
                {
                    createErrorResponse("Band C color is invalid. Cannot be " + request.bandCColor);
                    return false;
                }
            }

            // test tolerance band
            if (toleranceBandProvided)
            {
                if (!resistorColorCode.isValidToleranceBandColor(request.toleranceBandColor))
                {
                    createErrorResponse("Tolerance band color is invalid. Cannot be " + request.toleranceBandColor);
                    return false;
                }
            }

            // if any of these fail, form an Error response object and return it

            return true;
        }

        private void createErrorResponse(string errorMessage)
        {
            response.success = false;
            response.message = errorMessage;
        }

        public CalculateOhmValueResponse execute(CalculateOhmValueRequest request)
        {
            // use the standard calculator to execute the calcuation

            // validate the request : if invalid, set response object to invalid and retrn it
            if (!IsValidRequest(request))
            {
                return response;
            }

            StandardOhmValueCalculator calculator = new StandardOhmValueCalculator();
            try
            {
                response.calculatedValue = calculator.CalculateOhmValue(request.bandAColor, request.bandBColor, request.bandCColor, request.toleranceBandColor);
                response.toleranceValue = resistorColorCode.translateToleranceColor(request.toleranceBandColor);
                response.success = true;
            }
            catch (Exception e){
                createErrorResponse(e.Message);
            }

            return response;
        }
    }
}