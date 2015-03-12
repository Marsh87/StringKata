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
        public void Add_GivenEmptyString_Return0() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var input = "";
            var expected = 0;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            ;
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenNumberString_ReturnIntegerValue() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var input = "1";
            var expected = 1;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            ;
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenNumberString2_ReturnIntegerValue() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var input = "2";
            var expected = 2;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            ;
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenNumberSeperatedByComma_ReturnSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var input = "1,2";
            var expected = 3;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            ;
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenDoubleNumberSeperatedByComma_ReturnSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var input = "11,22";
            var expected = 33;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            ;
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenThreeNumbersSeperatedByComma_ReturnSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var input = "1,2,3";
            var expected = 6;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            ;
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenThreeNumbersSeperatedByCommawithNumberGreaterThan1000_ReturnSumNotIncludeNumberGreaterThan1000()
        {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var input = "1,2,1001";
            var expected = 3;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            ;
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Add_GivenThreeNumbersSeperatedByCommawithNumberEqualTo1000_ReturnSum()
        {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var input = "1,2,1000";
            var expected = 1003;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            ;
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_GivenThreeNumbersSeperatedByNewLine_ReturnSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var input = "1,2\n3";
            var expected = 6;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            ;
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenThreeNumbersSeperatedByCustomDelimiter_ReturnSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var input = "//;\n1;2;3";
            var expected = 6;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            ;
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenThreeNumbersSeperatedByCustomDelimiterofVaryingLenght_ReturnSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var input = "//[***]\n1***2***3";
            var expected = 6;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            ;
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenThreeNumbersSeperatedByCustomDelimiterofVaryingLenghtandType_ReturnSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var input = "//[*][%]\n1*2%3";
            var expected = 6;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            ;
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }

        [Test]
        public void Add_GivenNegativeNumber_ShouldThrowException() {

            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------

            //---------------Test Result -----------------------
            Assert.Throws<NegativesNotAllowedException>(()=>sut.Add("-1"));
        }
        [Test]
        public void Add_GivenNegativeNumberList_ShouldThrowException() {

            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            List<int> expected=new List<int>(){-1};
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------

            //---------------Test Result -----------------------
           var exception= Assert.Throws<NegativesNotAllowedException>(()=>sut.Add("-1"));
            CollectionAssert.AreEqual(expected,exception.NegativeNumbers); 
        }
        [Test]
        public void Add_GivenNegativeNumbersList_ShouldThrowException() {

            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            List<int> expected=new List<int>(){-1,-2};
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------

            //---------------Test Result -----------------------
           var exception= Assert.Throws<NegativesNotAllowedException>(()=>sut.Add("-1,-2"));
            CollectionAssert.AreEqual(expected,exception.NegativeNumbers); 
        }
    }
}
