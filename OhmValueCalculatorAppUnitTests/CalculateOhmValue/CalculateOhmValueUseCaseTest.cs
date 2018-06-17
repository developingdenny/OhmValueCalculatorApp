using Microsoft.VisualStudio.TestTools.UnitTesting;
using OhmValueCalculatorApp.CalculateOhmValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmValueCalculatorApp.CalculateOhmValue.Tests
{
    [TestClass()]
    public class CalculateOhmValueUseCaseTest
    {
        [TestMethod()]
        public void CalculateOhmValueUseCase_ExecuteTest_WithValidInputs_ProducesSuccessResponseWithAccurateResults()
        {
            CalculateOhmValueUseCaseRequest request = new CalculateOhmValueUseCaseRequest();
            CalculateOhmValueUseCase calculateUseCase = new CalculateOhmValueUseCase();
            CalculateOhmValueUseCaseResponse response;

            // set up request
            request.bandAColor = "red";

            // execute use case
            response = calculateUseCase.Execute(request);

            // assert response matching expectations for requested scenario
            Assert.IsTrue(response.success);
            Assert.IsNotNull(response.calculatedValue);
            Assert.IsNotNull(response.toleranceValue);
            Assert.AreNotEqual(0, response.calculatedValue);
            Assert.AreNotEqual(0, response.toleranceValue);
            Assert.IsNull(response.message);
        }

        [TestMethod()]
        public void CalculateOhmValueUseCase_ExecuteTest_WithCompleteSetOfValidInputs_ProducesSuccessResponseWithAccurateResults()
        {
            CalculateOhmValueUseCaseRequest request = new CalculateOhmValueUseCaseRequest();
            CalculateOhmValueUseCase calculateUseCase = new CalculateOhmValueUseCase();
            CalculateOhmValueUseCaseResponse response;

            // set up request
            request.bandAColor = "red";
            request.bandBColor = "white";
            request.bandCColor = "blue";
            request.toleranceBandColor = "gold";

            // execute use case
            response = calculateUseCase.Execute(request);

            // assert response matching expectations for requested scenario
            Assert.IsTrue(response.success);
            Assert.IsNotNull(response.calculatedValue);
            Assert.IsNotNull(response.toleranceValue);
            Assert.AreNotEqual(0, response.calculatedValue);
            Assert.AreNotEqual(0, response.toleranceValue);
            Assert.IsNull(response.message);
        }

        [TestMethod()]
        public void CalculateOhmValueUseCase_ExecuteTest_WithInvalidInputs_ProducesFailureResponseWithMessage()
        {
            CalculateOhmValueUseCaseRequest request = new CalculateOhmValueUseCaseRequest();
            CalculateOhmValueUseCase calculateUseCase = new CalculateOhmValueUseCase();
            CalculateOhmValueUseCaseResponse response;

            // set up request
            request.bandAColor = "red";
            request.bandBColor = "";
            request.bandCColor = "blue";
            request.toleranceBandColor = "gold";

            // execute use case
            response = calculateUseCase.Execute(request);

            // assert response matching expectations for requested scenario
            Assert.IsFalse(response.success);
            Assert.IsNotNull(response.calculatedValue);
            Assert.IsNotNull(response.toleranceValue);
            Assert.AreEqual(0, response.calculatedValue);
            Assert.AreEqual(0, response.toleranceValue);
            Assert.IsNotNull(response.message);
        }

        [TestMethod()]
        public void CalculateOhmValueUseCase_ExecuteTest_WithInvalidInputs_BandGap_ProducesFailureResponseWithAccurateDescriptiveMessage()
        {
            CalculateOhmValueUseCaseRequest request = new CalculateOhmValueUseCaseRequest();
            CalculateOhmValueUseCase calculateUseCase = new CalculateOhmValueUseCase();
            CalculateOhmValueUseCaseResponse response;

            // set up request
            request.bandAColor = "red";
            request.bandBColor = "";
            request.bandCColor = "blue";
            request.toleranceBandColor = "gold";

            // execute use case
            response = calculateUseCase.Execute(request);

            // assert response matching expectations for requested scenario
            Assert.IsFalse(response.success);
            Assert.IsNotNull(response.message);
            Assert.AreEqual("Can not specify third band without a second", response.message);
        }

        [TestMethod()]
        public void CalculateOhmValueUseCase_ExecuteTest_WithInvalidInputs_NoBandA_ProducesFailureResponseWithAccurateDescriptiveMessage()
        {
            CalculateOhmValueUseCaseRequest request = new CalculateOhmValueUseCaseRequest();
            CalculateOhmValueUseCase calculateUseCase = new CalculateOhmValueUseCase();
            CalculateOhmValueUseCaseResponse response;

            // set up request
            request.bandAColor = "";
            request.bandBColor = "red";
            request.bandCColor = "blue";
            request.toleranceBandColor = "gold";

            // execute use case
            response = calculateUseCase.Execute(request);

            // assert response matching expectations for requested scenario
            Assert.IsFalse(response.success);
            Assert.IsNotNull(response.message);
            Assert.AreEqual("Must provide first band color", response.message);
        }

        [TestMethod()]
        public void CalculateOhmValueUseCase_ExecuteTest_WithInvalidInputs_InvalidBandA_ProducesFailureResponseWithAccurateDescriptiveMessage()
        {
            CalculateOhmValueUseCaseRequest request = new CalculateOhmValueUseCaseRequest();
            CalculateOhmValueUseCase calculateUseCase = new CalculateOhmValueUseCase();
            CalculateOhmValueUseCaseResponse response;

            // set up request
            request.bandAColor = "purple";
            request.bandBColor = "red";
            request.bandCColor = "blue";
            request.toleranceBandColor = "gold";

            // execute use case
            response = calculateUseCase.Execute(request);

            // assert response matching expectations for requested scenario
            Assert.IsFalse(response.success);
            Assert.IsNotNull(response.message);
            Assert.AreEqual("Band A color is invalid. Cannot be purple.", response.message);
        }

        [TestMethod()]
        public void CalculateOhmValueUseCase_ExecuteTest_WithInvalidInputs_InvalidBandB_ProducesFailureResponseWithAccurateDescriptiveMessage()
        {
            CalculateOhmValueUseCaseRequest request = new CalculateOhmValueUseCaseRequest();
            CalculateOhmValueUseCase calculateUseCase = new CalculateOhmValueUseCase();
            CalculateOhmValueUseCaseResponse response;

            // set up request
            request.bandAColor = "brown";
            request.bandBColor = "ultraviolet";
            request.bandCColor = "blue";
            request.toleranceBandColor = "gold";

            // execute use case
            response = calculateUseCase.Execute(request);

            // assert response matching expectations for requested scenario
            Assert.IsFalse(response.success);
            Assert.IsNotNull(response.message);
            Assert.AreEqual("Band B color is invalid. Cannot be ultraviolet.", response.message );
        }

        [TestMethod()]
        public void CalculateOhmValueUseCase_ExecuteTest_WithInvalidInputs_InvalidBandC_ProducesFailureResponseWithAccurateDescriptiveMessage()
        {
            CalculateOhmValueUseCaseRequest request = new CalculateOhmValueUseCaseRequest();
            CalculateOhmValueUseCase calculateUseCase = new CalculateOhmValueUseCase();
            CalculateOhmValueUseCaseResponse response;

            // set up request
            request.bandAColor = "brown";
            request.bandBColor = "red";
            request.bandCColor = "tan";
            request.toleranceBandColor = "gold";

            // execute use case
            response = calculateUseCase.Execute(request);

            // assert response matching expectations for requested scenario
            Assert.IsFalse(response.success);
            Assert.IsNotNull(response.message);
            Assert.AreEqual("Band C color is invalid. Cannot be tan.", response.message);
        }

        [TestMethod()]
        public void CalculateOhmValueUseCase_ExecuteTest_WithInvalidInputs_InvalidToleranceBand_ProducesFailureResponseWithAccurateDescriptiveMessage()
        {
            CalculateOhmValueUseCaseRequest request = new CalculateOhmValueUseCaseRequest();
            CalculateOhmValueUseCase calculateUseCase = new CalculateOhmValueUseCase();
            CalculateOhmValueUseCaseResponse response;

            // set up request
            request.bandAColor = "brown";
            request.bandBColor = "red";
            request.bandCColor = "blue";
            request.toleranceBandColor = "wisteria";

            // execute use case
            response = calculateUseCase.Execute(request);

            // assert response matching expectations for requested scenario
            Assert.IsFalse(response.success);
            Assert.IsNotNull(response.message);
            Assert.AreEqual("Tolerance band color is invalid. Cannot be wisteria.", response.message);
        }
    }
}