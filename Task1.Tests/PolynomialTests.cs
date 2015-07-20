using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1.Library;

namespace Task1.Tests
{
    [TestClass]
    public class PolynomialTests
    {
        [TestMethod]
        public void Ctor_GivenSingleNonZeroNumber_ReturnsPolynomialOfDegreeZero()
        {
            var poly = new Polynomial(46);
            Assert.AreEqual(0, poly.Degree);
        }

        [TestMethod]
        public void Ctor_GivenZeroArguments_ReturnsPolynomialOfSomeDegree()
        {
            var poly = new Polynomial();
            Assert.AreEqual(Double.NegativeInfinity, poly.Degree);
        }

        [TestMethod]
        public void Ctor_GivenMultipleCoefficients_ReturnsPolynomialWithSameCoefficients()
        {
            double[] coeffs = { 1, 2, 3, 4 };
            var poly = new Polynomial(1, 2, 3, 4);
            for (int i = 0; i < poly.Degree; i++)
            {
                Assert.AreEqual(coeffs[i], poly[i]);
            }
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_GivenNull_ThrowsArgumentNullException()
        {
            double[] array = null;
            var poly = new Polynomial(array);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexer_GivenNegativeValue_ThrowsArgumentOutOfRange()
        {
            var poly = new Polynomial(1, 5, 2, 9);
            double _ = poly[-3];
        }

        [TestMethod]
        public void Indexer_GivenValuesOverDegree_ReturnsZero()
        {
            var poly = new Polynomial(1, 5, 2, 9);
            Assert.AreEqual(0, poly[30]);
        }

        [TestMethod]
        public void Equals_GivenSamePolynomial_ReturnsTrue()
        {
            var poly = new Polynomial(5, 8, 5);
            Assert.IsTrue(poly.Equals(new Polynomial(5, 8, 5)));
        }

        [TestMethod]
        public void Equals_GivenNull_ReturnsFalse()
        {
            var poly = new Polynomial(5, 8, 5);
            Assert.IsFalse(poly.Equals(null));
        }

        [TestMethod]
        public void Clone_GivenClone_ReturnsTrue()
        {
            var poly = new Polynomial(5, 8, 5);
            var polyClone = poly.Clone();
            Assert.AreEqual(poly, polyClone);
        }

        [TestMethod]
        public void Clone_GivenZeroArgument_ReturnsTrue()
        {
            var poly = new Polynomial();
            var polyClone = poly.Clone();
            Assert.AreEqual(poly, polyClone);
        }

        [TestMethod]
        public void ToString_GivenPolynomialWithPositiveCoeffs_ReturnsString()
        {
            var poly = new Polynomial(5, 8, 5);
            var polyString = "5x^2+8x+5";
            Assert.AreEqual(polyString, poly.ToString());
        }

        [TestMethod]
        public void ToString_GivenPolynomialWithNegativeCoeffs_ReturnsString()
        {
            var poly = new Polynomial(-5, -8, -5);
            var polyString = "-5x^2-8x-5";
            Assert.AreEqual(polyString, poly.ToString());
        }

        [TestMethod]
        public void GetHashCode_GivenEqualsPolynomial_ReturnsTheSamrResult()
        {
            var poly1 = new Polynomial(-5, -8, -5);
            var poly2 = new Polynomial(-5, -8, -5);
            Assert.AreEqual(poly1.GetHashCode(), poly2.GetHashCode());
        }

        [TestMethod]
        public void Add_GivenTwoPolynomials_ReturnsSum()
        {
            var result = new Polynomial(3, 5, 2);
            var poly1 = new Polynomial(2, 7, 9);
            var poly2 = new Polynomial(1, -2, -7);
            Assert.AreEqual(result, poly1 + poly2);
        }
        [TestMethod]
        public void Add_GivenTwoPolynomialsNotTheSameDegree_ReturnsSum()
        {
            var result = new Polynomial(3, 5, 2, 1);
            var poly1 = new Polynomial(2, 7, 9, 1);
            var poly2 = new Polynomial(1, -2, -7);
            Assert.AreEqual(result, poly1 + poly2);
        }

        [TestMethod]
        public void Add_GivenPolynomialAndNumber_ReturnsSum()
        {
            var result = new Polynomial(6, 5, 2);
            var number = 3;
            var poly = new Polynomial(3, 5, 2);
            Assert.AreEqual(result, poly + number);
        }

        [TestMethod]
        public void Difference_GivenTwoPolynomials_ReturnsDifference()
        {
            var result = new Polynomial(3, 5, 2, 1);
            var poly1 = new Polynomial(2, 7, 9, 1);
            var poly2 = new Polynomial(1, -2, -7);
            Assert.AreEqual(poly2, result - poly1);
        }
        [TestMethod]
        public void Difference_GivenTwoPolynomialsNotTheSameDegree_ReturnsDifference()
        {
            var result = new Polynomial(3, 5, 2, 1);
            var poly1 = new Polynomial(2, 7, 9, 1);
            var poly2 = new Polynomial(1, -2, -7);
            Assert.AreEqual(poly1, result - poly2);
        }

        [TestMethod]
        public void Difference_GivenPolynomialAndNumber_ReturnsDifference()
        {
            var result = new Polynomial(6, 5, 2);
            var number = 3;
            var poly = new Polynomial(3, 5, 2);
            Assert.AreEqual(poly, result - number);
        }

        [TestMethod]
        public void Multiplication_GivenPolynomialAndNumber_ReturnsMultiplication()
        {
            var result = new Polynomial(9, 15, 6);
            var number = 3;
            var poly = new Polynomial(3, 5, 2);
            Assert.AreEqual(result, poly * number);
        }

        [TestMethod]
        public void Division_GivenPolynomialAndNumber_ReturnsDivision()
        {
            var result = new Polynomial(9, 15, 6);
            var number = 3;
            var poly = new Polynomial(3, 5, 2);
            Assert.AreEqual(poly, result / number);
        }

        [TestMethod]
        public void EqualsSign_GivenTwoSamePolynomials_ReturnsTrue()
        {
            var poly1 = new Polynomial(3, 5, 2);
            var poly2 = new Polynomial(3, 5, 2);
            Assert.IsTrue(poly1 == poly2);
        }

        [TestMethod]
        public void EqualsSign_GivenTwoNotTheSamePolynomials_ReturnsFalse()
        {
            var poly1 = new Polynomial(3, 5, 2);
            var poly2 = new Polynomial(3, 4, 2);
            Assert.IsFalse(poly1 == poly2);
        }

        [TestMethod]
        public void NotEqualsSign_GivenTwoSamePolynomials_ReturnsFalse()
        {
            var poly1 = new Polynomial(3, 5, 2);
            var poly2 = new Polynomial(3, 5, 2);
            Assert.IsFalse(poly1 != poly2);
        }

        [TestMethod]
        public void NotEqualsSign_GivenTwoNotTheSamePolynomials_ReturnsTrue()
        {
            var poly1 = new Polynomial(3, 4, 2);
            var poly2 = new Polynomial(3, 5, 2);
            Assert.IsTrue(poly1 != poly2);
        }
    }
}
