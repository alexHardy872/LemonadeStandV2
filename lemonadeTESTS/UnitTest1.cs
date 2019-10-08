using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LemonadeStandV2;

namespace lemonadeTESTS
{
    [TestClass]
    public class LemonadeStandUnitTests
    {
        [TestMethod]
        public void MoreThan10Lemons_ReturnMaximum100() 
        {
            // Arrange
            Customer customer = new Customer("clear",50,1);
            int lemonsIn = 12;
            double result;
            double expectedResult = 100;
            // Act
            result = customer.CalculateLemonsFactor(lemonsIn);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void LemonsIn_ReturnMidFactor50()
        {
            // Arrange
            Customer customer = new Customer("clear", 50, 1);
            int lemonsIn = 5;
            double result;
            double expectedResult = 50;
            // Act
            result = customer.CalculateLemonsFactor(lemonsIn);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }


        [TestMethod]
        public void LessThan0Lemons_ReturnMinimum0()
        {
            // Arrange
            Customer customer = new Customer("clear", 50, 1);
            int lemonsIn = -2;
            double result;
            double expectedResult = 0;
            // Act
            result = customer.CalculateLemonsFactor(lemonsIn);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void RecipePerfect_Return100() 
        {
            // Arrange
            Customer customer = new Customer("clear", 50, 1);
            int lemonsIn = 10;
            int sugarIn = 10;
            int iceCubes = 5;
            double result;
            double expectedResult = 100;
            // Act
            result = customer.CombineRecipeeFactors(lemonsIn, sugarIn, iceCubes);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void RecipeFlawLemons0_Return0() 
        {
            // Arrange
            Customer customer = new Customer("clear", 50, 1);
            int lemonsIn = 0;
            int sugarIn = 10;
            int iceCubes = 5;
            double result;
            double expectedResult = 0;
            // Act
            result = customer.CombineRecipeeFactors(lemonsIn, sugarIn, iceCubes);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void MidRecipe0_Return50() 
        {
            // Arrange
            Customer customer = new Customer("clear", 100, 1);
            int lemonsIn = 5;
            int sugarIn = 5;
            int iceCubes = 5;
            double result;
            double expectedResult = 50;
            // Act
            result = customer.CombineRecipeeFactors(lemonsIn, sugarIn, iceCubes);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }


        [TestMethod]
        public void MaxIceFactor_Return100() 
        {
            // Arrange
            Customer customer = new Customer("clear", 55, 1);
            int iceCubes = 5;
            double result;
            double expectedResult = 100;
            // Act
            result = customer.CalculateIceFactor(iceCubes);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void MinIceFactor_Return0() 
        {
            // Arrange
            Customer customer = new Customer("clear", 100, 1);
            int iceCubes = 0;
            double result;
            double expectedResult = 0;
            // Act
            result = customer.CalculateIceFactor(iceCubes);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void MidIceFactor_Return80() 
        {
            // Arrange
            Customer customer = new Customer("clear", 70, 1);
            int iceCubes = 5;
            double result;
            double expectedResult = 80;
            // Act
            result = customer.CalculateIceFactor(iceCubes);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TempAndWeatherMax_Return100()
        {
            // Arrange
            Customer customer = new Customer("clear", 70, 1);
            int iceCubes = 5;
            double result;
            double expectedResult = 100;
            // Act
            result = customer.CalculateTempAndWeatherFactors(iceCubes);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }













    }
}
