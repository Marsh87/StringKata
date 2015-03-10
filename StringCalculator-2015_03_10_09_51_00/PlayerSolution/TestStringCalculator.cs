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
        public void Add_GivenEmptyString_ShouldReturn0() {
            //---------------Set up test pack-------------------
            var expected = 0;
            var input = "";
            var sut = CreateCalculator();


            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenStringNumber_ShouldReturnIntegerValue() {
            //---------------Set up test pack-------------------
            var expected = 1;
            var input = "1";
            var sut = CreateCalculator();


            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenStringNumber2_ShouldReturnIntegerValue() {
            //---------------Set up test pack-------------------
            var expected = 2;
            var input = "2";
            var sut = CreateCalculator();


            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenTwoStringNumberSeperatedByComma_ShouldReturnSum() {
            //---------------Set up test pack-------------------
            var expected = 3;
            var input = "1,2";
            var sut = CreateCalculator();


            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenDoubleDigitTwoStringNumberSeperatedByComma_ShouldReturnSum() {
            //---------------Set up test pack-------------------
            var expected = 33;
            var input = "11,22";
            var sut = CreateCalculator();


            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenThreeNumberSeperatedByComma_ShouldReturnSum() {
            //---------------Set up test pack-------------------
            var expected =6;
            var input = "1,2,3";
            var sut = CreateCalculator();


            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenThreeNumberSeperatedByNewline_ShouldReturnSum() {
            //---------------Set up test pack-------------------
            var expected =6;
            var input = "1,2\n3";
            var sut = CreateCalculator();


            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenThreeNumberSeperatedByCustomDelimiter_ShouldReturnSum() {
            //---------------Set up test pack-------------------
            var expected =6;
            var input = "//;\n1;2;3";
            var sut = CreateCalculator();


            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenNegativeNumber_ShouldThrowException() {
            //---------------Set up test pack-------------------
            var input = "-1";
            var sut = CreateCalculator();


            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------

            Assert.Throws<NegativesNotAllowedException>(() => sut.Add(input));
        }
        [Test]
        public void Add_GivenNegativeNumberList_ShouldThrowException() {
            //---------------Set up test pack-------------------
            List<int> expected=new List<int>(){-1};
            var input = "-1";
            var sut = CreateCalculator();


            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------

            var exception=Assert.Throws<NegativesNotAllowedException>(() => sut.Add(input));
            CollectionAssert.AreEqual(expected,exception.NegativeNumbers);
        }
        [Test]
        public void Add_GivenNegativeNumbersList_ShouldThrowException() {
            //---------------Set up test pack-------------------
            List<int> expected=new List<int>(){-1,-2};
            var input = "-1,-2,3";
            var sut = CreateCalculator();


            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------

            var exception=Assert.Throws<NegativesNotAllowedException>(() => sut.Add(input));
            CollectionAssert.AreEqual(expected,exception.NegativeNumbers);
        }
        [Test]
        public void Add_GivenThreeNumberSeperatedByCommawithNumberGreater1000_ShouldNotReturnSum()
        {
            //---------------Set up test pack-------------------
            var expected =3;
            var input = "1,2,1001";
            var sut = CreateCalculator();


            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Add_GivenThreeNumberSeperatedByCommawithNumberEqualTo1000_ShouldNotReturnSum()
        {
            //---------------Set up test pack-------------------
            var expected =1003;
            var input = "1,2,1000";
            var sut = CreateCalculator();


            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Add_GivenThreeNumberSeperatedByCustomDelimiterofVaryingLength_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            var expected = 6;
            var input = "//[***]\n1***2***3";
            var sut = CreateCalculator();


            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Add_GivenThreeNumberSeperatedByCustomDelimiterofVaryingLengthandType_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            var expected = 6;
            var input = "//[*][%]\n1*2%3";
            var sut = CreateCalculator();


            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }



    }
}
