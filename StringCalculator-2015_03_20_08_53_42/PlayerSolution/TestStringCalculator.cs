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
        public void Add_GivenEmptyString_ShouldRetrurn0() {
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
        public void Add_GivenStringNumber_ShouldRetrurnIntegerValue() {
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
        public void Add_GivenNegativeStringNumber_ShoulThrowNegativesNotAllowedException() {
            //---------------Set up test pack-------------------
            var input = "-1";
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
            
            Assert.Throws<NegativesNotAllowedException>(()=> sut.Add(input));
        }
        [Test]
        public void Add_GivenNegativeStringNumberList_ShoulThrowNegativesNotAllowedException() {
            //---------------Set up test pack-------------------
            var input = "-1";
            List<int> expected=new List<int>(){-1};
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
            
           var exception= Assert.Throws<NegativesNotAllowedException>(()=> sut.Add(input));
            CollectionAssert.AreEqual(expected,exception.NegativeNumbers);
        }
        [Test]
        public void Add_GivenNegativeStringNumbersList_ShoulThrowNegativesNotAllowedException() {
            //---------------Set up test pack-------------------
            var input = "-1,-2";
            List<int> expected=new List<int>(){-1,-2};
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
            
           var exception= Assert.Throws<NegativesNotAllowedException>(()=> sut.Add(input));
            CollectionAssert.AreEqual(expected,exception.NegativeNumbers);
        }

        [Test]
        public void Add_GivenStringNumbersSeperatedByComma_ShouldRetrurnIntegerValue() {
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
        public void Add_GivenThreeStringNumbersSeperatedByComma_ShouldRetrurnIntegerValue() {
            //---------------Set up test pack-------------------
            var expected = 6;
            var input = "1,2,3";
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenThreeStringNumbersSeperatedByCommaWithNumberGreaterThan1000_ShouldNotRetrurnSumWithNumber() {
            //---------------Set up test pack-------------------
            var expected = 3;
            var input = "1,2,1001";
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenThreeStringNumbersSeperatedByCommaWithNumberLessThan1000_ShouldNotRetrurnSumWithNumber() {
            //---------------Set up test pack-------------------
            var expected = 1003;
            var input = "1,2,1000";
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenThreeStringNumbersSeperatedByNewLine_ShouldRetrurnIntegerValue() {
            //---------------Set up test pack-------------------
            var expected = 6;
            var input = "1,2\n3";
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenThreeStringNumbersSeperatedByCustomDelimiter_ShouldRetrurnIntegerValue() {
            //---------------Set up test pack-------------------
            var expected = 6;
            var input = "//;\n1;2;3";
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenThreeStringNumbersSeperatedByCustomDelimiterofVaryingLength_ShouldRetrurnIntegerValue() {
            //---------------Set up test pack-------------------
            var expected = 6;
            var input = "//[***]\n1***2***3";
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void Add_GivenThreeStringNumbersSeperatedByCustomDelimiterofVaryingLengthAndType_ShouldRetrurnIntegerValue() {
            //---------------Set up test pack-------------------
            var expected = 6;
            var input = "//[*][%]\n1*2%3";
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }

    }
}
