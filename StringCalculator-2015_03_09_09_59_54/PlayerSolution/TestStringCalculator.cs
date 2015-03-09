using System;
using System.Collections.Generic;
using System.Globalization;
using Engine;
using Katarai.StringCalculator.Interfaces;
using NUnit.Framework;

namespace PlayerStringKata
{
    public class TestStringCalculator : ITestPack<IStringCalculator>
    {
        public Func<IStringCalculator> CreateSUT { get; set; }

		[SetUp]
        public void SetupTest()
        {
            CreateSUT = () => new StringCalculator();
        }
		
		private IStringCalculator CreateCalculator()
		{
			return CreateSUT();
		}
		
        /// <summary>
        /// This is a sample test that shows how the StringCalculator 
        /// should be created in future tests. 
        /// </summary>
        [Test]
        public void Constructor()
        {
            //---------------Set up test pack-------------------

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var calculator = CreateCalculator();
            //---------------Test Result -----------------------
            Assert.IsNotNull(calculator);
        }

        [Test]
        public void Add_GivenEmtryString_ShouldReturn0() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var expected = 0;
            var input = "";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
            var result = sut.Add(input);
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenStringNumber_ShouldReturnIntegerValue() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var expected = 1;
            var input = "1";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
            var result = sut.Add(input);
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenStringNumber2_ShouldReturnIntegerValue() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var expected = 2;
            var input = "2";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
            var result = sut.Add(input);
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenStringNumbersSeperatedByComma_ShouldSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var expected = 3;
            var input = "1,2";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
            var result = sut.Add(input);
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenStringDoubleDigitNumbersSeperatedByComma_ShouldSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var expected = 33;
            var input = "11,22";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
            var result = sut.Add(input);
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenStringThreeNumbersSeperatedByComma_ShouldSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var expected =6;
            var input = "1,2,3";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
            var result = sut.Add(input);
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenStringThreeNumbersSeperatedByCommaAndNewLine_ShouldSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var expected =6;
            var input = "1,2\n3";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
            var result = sut.Add(input);
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenStringThreeNumbersSeperatedByCustomeDelimiter_ShouldSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var expected =6;
            var input = "//;\n1;2;3";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
            var result = sut.Add(input);
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenNegativeNumber_ShouldThrowException() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var input = "-1";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------

            Assert.Throws<NegativesNotAllowedException>(() => sut.Add(input));

        }
        [Test]
        public void Add_GivenNegativeNumberListwithOneNumeber_ShouldThrowException() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var input = "-1";
            var expected = new List<int> {-1};  
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------

            var exception =Assert.Throws<NegativesNotAllowedException>(() => sut.Add(input));
            CollectionAssert.AreEqual(expected,exception.NegativeNumbers);

        }
        [Test]
        public void Add_GivenNegativeNumberListwitMoreThanhOneNumeber_ShouldThrowException() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var input = "-1,-2,3";
            var expected = new List<int> {-1,-2};  
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------

            var exception =Assert.Throws<NegativesNotAllowedException>(() => sut.Add(input));
            CollectionAssert.AreEqual(expected,exception.NegativeNumbers);

        }
        [Test]
        public void Add_GivenStringThreeNumberswithaNumbergreaterthana1000SeperatedByComma_ShouldNotSumNumberGreaterThan1000()
        {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var expected = 3;
            var input = "1,2,1001";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
            var result = sut.Add(input);
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Add_GivenStringThreeNumberswithaNumbergreaterlessthanEqualToa1000SeperatedByComma_ShouldSumAllNumbers()
        {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var expected = 1003;
            var input = "1,2,1000";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
            var result = sut.Add(input);
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Add_GivenStringThreeNumbersSeperatedByCustomeDelimiterofVaryingLength_ShouldSum()
        {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var expected = 6;
            var input = "//[***]\n1***2***3";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
            var result = sut.Add(input);
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Add_GivenStringThreeNumbersSeperatedByCustomeDelimiterofVaryingLengthandType_ShouldSum()
        {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var expected = 6;
            var input = "//[*][%]\n1*2%3";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
            var result = sut.Add(input);
            Assert.AreEqual(expected, result);
        }


    }
}
