using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixProductCalculation;

namespace MatrixProductCalculationTests
{
    [TestClass]
    public class ProductCalculationTests
    {
           int[,] matrix = new int[,] {  {1,6,1,1},
                                         {3,2,3,4},
                                         {0,1,1,1},
                                         {5,2,1,9}};


        [TestMethod]
        public void CalculateHighestProductWithoutOverFlow()
        {
             Assert.AreEqual(36, MatrixProductCalculator.Calculate(matrix, 3, false));
        }

      //  [TestMethod]
        public void CalculateHighestProductWithOverFlow()
        {
            Assert.AreEqual(90, MatrixProductCalculator.Calculate(matrix, 3, true));
        }

       [TestMethod]
        public void CalculateRightProductWithoutOverFlow() {
            Assert.AreEqual(24, MatrixProductCalculator.CalculateRight(matrix, 1, 1, 3, false));
        }

        [TestMethod]
        public void CalculateRightProductWithOverFlow()
        {
            Assert.AreEqual(36, MatrixProductCalculator.CalculateRight(matrix, 1, 2, 3, true));
        }

        [TestMethod]
        public void CalculateDiagonalRightProductWithoutOverFlow()
        {
            Assert.AreEqual(18, MatrixProductCalculator.CalculateDiagonalRight(matrix, 0, 1, 3, false));
        }

        [TestMethod]
        public void CalculateDiagonalRightProductWithOverFlow()
        {
            Assert.AreEqual(15, MatrixProductCalculator.CalculateDiagonalRight(matrix, 1, 2, 3, true));
        }

        [TestMethod]
        public void CalculateDiagonalLeftProductWithoutOverFlow()
        {
            Assert.AreEqual(15, MatrixProductCalculator.CalculateDiagonalLeft(matrix, 1, 2, 3, false));
        }

        [TestMethod]
        public void CalculateDiagonalLeftProductWithOverFlow()
        {
            Assert.AreEqual(18, MatrixProductCalculator.CalculateDiagonalLeft(matrix, 0, 1, 3, true));
        }
    }
}
