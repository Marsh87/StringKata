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
            //---------------Arrange-------------------
            
            //---------------Act----------------------
            var calculator = CreateCalculator();
            //---------------Assert-----------------------
            Assert.IsNotNull(calculator);
        }

        [Test]
        public void Add_GivenEmptyString_ShouldReturn0() {
            //---------------Set up test pack-------------------
            var input = "";
            var expected = 0;
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
            var input = "1";
            var expected = 1;
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
            var input = "2";
            var expected = 2;
            var sut = CreateCalculator();

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenStringNumbersSeperatedByComma_ShouldReturnIntegerValue() {
            //---------------Set up test pack-------------------
            var input = "1,2";
            var expected = 3;
            var sut = CreateCalculator();

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenDoubleDigitsStringNumbersSeperatedByComma_ShouldReturnIntegerValue() {
            //---------------Set up test pack-------------------
            var input = "11,22";
            var expected = 33;
            var sut = CreateCalculator();

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenThreeNumbersSeperatedByComma_ShouldReturnIntegerValue() {
            //---------------Set up test pack-------------------
            var input = "1,2,3";
            var expected = 6;
            var sut = CreateCalculator();

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenThreeNumberswithNumberGreaterThan1000_ShouldNotReturnSumWithNumberGreaterThan1000() {
            //---------------Set up test pack-------------------
            var input = "1,2,1001";
            var expected = 3;
            var sut = CreateCalculator();

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenThreeNumberswithNumbeEqualThan1000_ShouldNotReturnSumWithNumberEqual1000() {
            //---------------Set up test pack-------------------
            var input = "1,2,1000";
            var expected = 1003;
            var sut = CreateCalculator();

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenThreeNumbersSeperatedByNewLine_ShouldReturnIntegerValue() {
            //---------------Set up test pack-------------------
            var input = "1,2\n3";
            var expected = 6;
            var sut = CreateCalculator();

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenThreeNumbersSeperatedByCustomDelimiter_ShouldReturnIntegerValue() {
            //---------------Set up test pack-------------------
            var input = "//;\n1;2;3";
            var expected = 6;
            var sut = CreateCalculator();

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenThreeNumbersSeperatedByCustomDelimiterofVaryingLength_ShouldReturnIntegerValue() {
            //---------------Set up test pack-------------------
            var input = "//[***]\n1***2***3";
            var expected = 6;
            var sut = CreateCalculator();

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenThreeNumbersSeperatedByCustomDelimiterofVaryingLengthandType_ShouldReturnIntegerValue() {
            //---------------Set up test pack-------------------
            var input = "//[*][%]\n1*2%3";
            var expected = 6;
            var sut = CreateCalculator();

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenNegativeNumber_ShouldThrowNegativesNotAllowedException() {
            //---------------Set up test pack-------------------
            var input = "-1";
           
            var sut = CreateCalculator();

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
            Assert.Throws<NegativesNotAllowedException>(()=>sut.Add(input));
        }
        [Test]
        public void Add_GivenNegativeNumberList_ShouldThrowNegativesNotAllowedException() {
            //---------------Set up test pack-------------------
            var input = "-1";
           List<int> expected=new List<int>(){-1};
            var sut = CreateCalculator();

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
           var exception= Assert.Throws<NegativesNotAllowedException>(()=>sut.Add(input));
            CollectionAssert.AreEqual(expected,exception.NegativeNumbers);
        }
        [Test]
        public void Add_GivenNegativeNumberList_ShouldThrowNegativesMotAllowedException() {
            //---------------Set up test pack-------------------
            var input = "-1,-2";
           List<int> expected=new List<int>(){-1,-2};
            var sut = CreateCalculator();

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
           var exception= Assert.Throws<NegativesNotAllowedException>(()=>sut.Add(input));
            CollectionAssert.AreEqual(expected,exception.NegativeNumbers);
        }

    }
}
