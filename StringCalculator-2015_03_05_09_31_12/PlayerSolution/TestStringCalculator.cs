using System;
using System.Collections.Generic;
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
        public void Constructor() {
            //---------------Set up test pack-------------------

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var calculator = CreateCalculator();
            //---------------Test Result -----------------------
            Assert.IsNotNull(calculator);
        }

        [Test]
        public void Add_GivenEmptyString_ShouldReturn0() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result =sut.Add("");

            //---------------Test Result -----------------------
            Assert.AreEqual(0,result);
        }

        [Test]
        public void Add_GivenStringNumber_ShouldIntegerNumber() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add("1");
            //---------------Test Result -----------------------
            Assert.AreEqual(1,result);
        }

        [Test]
        public void Add_GivenStringNumber2_ShouldIntegerNumber() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();       
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add("2");
            //---------------Test Result -----------------------
            Assert.AreEqual(2,result);
        }

        [Test]
        public void Add_GivenStringNumbersSeperatedByComma_ShouldSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add("1,2");
            //---------------Test Result -----------------------
            Assert.AreEqual(3,result);
        }
        [Test]
        public void Add_GivenStringDoubleDigitNumbersSeperatedByComma_ShouldSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add("11,22");
            //---------------Test Result -----------------------
            Assert.AreEqual(33,result);
        }
        [Test]
        public void Add_GivenStringofThreeNumbersSeperatedByComma_ShouldSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add("1,2,3");
            //---------------Test Result -----------------------
            Assert.AreEqual(6,result);
        }
        [Test]
        public void Add_GivenNumberOnNewline_ShouldSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add("1,2\n3");
            //---------------Test Result -----------------------
            Assert.AreEqual(6,result);
        }

        [Test]
        public void Add_GivenNumbersSeperatedByCustomeDelimiter_ShouldSum()
        {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add("//;\n1;2;3");
            //---------------Test Result -----------------------
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_GivenNegativeStringNumber_ShouldThrowNegativesNotAllowedException() {
            //---------------Set up test pack-------------------
            var expected = -1;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var sut = CreateCalculator();
            var exception = Assert.Throws<NegativesNotAllowedException>(() => sut.Add("-1"));
            //---------------Test Result -----------------------
        }
        [Test]
        public void Add_GivenNegativeStringNumbers_ShouldThrowNegativesNotAllowedException() {
            //---------------Set up test pack-------------------
            var expected =new List<int> {-1,-3};
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var sut = CreateCalculator();
            var exception = Assert.Throws<NegativesNotAllowedException>(() => sut.Add("-1,2,-3"));
            //---------------Test Result -----------------------
            CollectionAssert.AreEqual(expected,exception.NegativeNumbers);
        }
        [Test]
        public void Add_GivenStringofThreeNumberwithNumberGreaterthan1000_ShouldNotSumNumberGreaterthan1000()
        {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add("1,2,1001");
            //---------------Test Result -----------------------
            Assert.AreEqual(3, result);
        }
        [Test]
        public void Add_GivenStringofThreeNumberwithNumberWith1000_ShouldSumNumbers()
        {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add("1,2,1000");
            //---------------Test Result -----------------------
            Assert.AreEqual(1003, result);
        }
        [Test]
        public void Add_GivenNumbersSeperatedByCustomeDelimiterofVaryingLength_ShouldSum()
        {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var input = "//[***]\n1***2***3";
            var expected = 6;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Add_GivenNumbersSeperatedByManyCustomeDelimiterofVaryingLength_ShouldSum()
        {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var input = "//[*][%]\n1*2%3";
            var expected = 6;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }




    }
}
