using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OhmValueCalculatorApp.Models;

namespace OhmValueCalculatorApp.CalculateOhmValue
{
    public class CalculateOhmValueUseCase
    {
        private ResistorColorCodes resistorColorCode = new ResistorColorCodes();

        private CalculateOhmValueUseCaseResponse response = new CalculateOhmValueUseCaseResponse();

        private bool IsValidRequest(CalculateOhmValueUseCaseRequest request)
        {
            bool bandAColorProvided = request.bandAColor.Length > 1;
            bool bandBColorProvided = request.bandBColor.Length > 1;
            bool bandCColorProvided = request.bandCColor.Length > 1;
            bool toleranceBandProvided = request.toleranceBandColor.Length > 1;

            bool isValid = true;

            // ensure at least band 1 is provided
            if (!bandAColorProvided)
            {
                // send error message
                createErrorResponse("Must provide first band color");
                isValid = false;
            }

            // verify no gap in band colors specified
            if (isValid && bandCColorProvided && !bandBColorProvided)
            {
                createErrorResponse("Can not specify third band without a second");
                isValid = false;
            }

            // verify the band colors provided are valid by consulting with dictionary
            if (isValid && !resistorColorCode.isValidBandAtoCColor(request.bandAColor))
            {
                createErrorResponse("Band A color is invalid. Cannot be " + request.bandAColor + ".");
                isValid = false;
            }

            // test optional band colors
            if (isValid && bandBColorProvided)
            {
                if (!resistorColorCode.isValidBandAtoCColor(request.bandBColor))
                {
                    createErrorResponse("Band B color is invalid. Cannot be " + request.bandBColor + ".");
                    isValid = false;
                }
            }

            if (isValid && bandCColorProvided)
            {
                if (!resistorColorCode.isValidBandAtoCColor(request.bandCColor))
                {
                    createErrorResponse("Band C color is invalid. Cannot be " + request.bandCColor + ".");
                    isValid = false;
                }
            }

            // test tolerance band
            if (isValid && toleranceBandProvided)
            {
                if (!resistorColorCode.IsValidToleranceBandColor(request.toleranceBandColor))
                {
                    createErrorResponse("Tolerance band color is invalid. Cannot be " + request.toleranceBandColor + ".");
                    isValid = false;
                }
            }

            return isValid;
        }

        private void createErrorResponse(string errorMessage)
        {
            response.success = false;
            response.message = errorMessage;
        }

        public CalculateOhmValueUseCaseResponse Execute(CalculateOhmValueUseCaseRequest request)
        {
            // validate the request : if invalid, set response object to invalid and retrn it
            if (!IsValidRequest(request))
            {
                return response;
            }

            StandardOhmValueCalculator calculator = new StandardOhmValueCalculator();
            try
            {
                response.calculatedValue = calculator.CalculateOhmValue(request.bandAColor, request.bandBColor, request.bandCColor, request.toleranceBandColor);
                response.toleranceValue = resistorColorCode.TranslateToleranceColor(request.toleranceBandColor);
                response.success = true;
            }
            catch (Exception e){
                createErrorResponse(e.Message);
            }

            return response;
        }
    }
}