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
        public void Add_GivenEmtypString_ShouldShouldReturn0() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var expected = 0;
            var input = "";
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------

            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
          public void Add_GivenStringNumber_ShouldShouldReturnIntegerValue() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var expected = 1;
            var input = "1";
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------

            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
          public void Add_GivenStringNumber2_ShouldShouldReturnIntegerValue() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var expected = 2;
            var input = "2";
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------

            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
          public void Add_GivenStringNumbersSeperatedByComma_ShouldShouldReturnIntegerSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var expected = 3;
            var input = "1,2";
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------

            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
          public void Add_GivenDoubleStringNumbersSeperatedByComma_ShouldShouldReturnIntegerSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var expected = 33;
            var input = "11,22";
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------

            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
          public void Add_GivenThreeStringNumbersSeperatedByComma_ShouldShouldReturnIntegerSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var expected = 6;
            var input = "1,2,3";
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------

            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
          public void Add_GivenThreeStringNumbersSeperatedByCommaWithNumberGreaterThan1000_ShouldNotIncludeNumberInIntegerSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var expected =3;
            var input = "1,2,1001";
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------

            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
          public void Add_GivenThreeStringNumbersSeperatedByCommaWithNumberEqualTo1000_ShouldNotIncludeNumberInIntegerSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var expected =1003;
            var input = "1,2,1000";
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------

            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
          public void Add_GivenThreeStringNumbersSeperatedByNewLine_ShouldShouldReturnIntegerSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var expected = 6;
            var input = "1,2\n3";
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------

            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
          public void Add_GivenThreeStringNumbersSeperatedByCustomDelimiter_ShouldShouldReturnIntegerSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var expected = 6;
            var input = "//;\n1;2;3";
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------

            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
          public void Add_GivenThreeStringNumbersSeperatedByCustomDelimiterofVaryingLength_ShouldShouldReturnIntegerSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var expected = 6;
            var input = "//[***]\n1***2***3";
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------

            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }
        [Test]
          public void Add_GivenThreeStringNumbersSeperatedByCustomDelimiterofVaryingLengthAndType_ShouldShouldReturnIntegerSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var expected = 6;
            var input = "//[*][%]\n1*2%3";
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------

            var result = sut.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,result);
        }

        [Test]
        public void Add_GivenStringNegativeNumber_ShouldThrowException() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var input="-1";
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------

            //---------------Test Result -----------------------
            Assert.Throws<NegativesNotAllowedException>(()=>sut.Add(input));
        }
        [Test]
        public void Add_GivenNegativeNumber_ShouldThrowNegativesNotAllowedException() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var input="-1";
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------

            //---------------Test Result -----------------------
            Assert.Throws<NegativesNotAllowedException>(()=>sut.Add(input));
        }
        [Test]
        public void Add_ListGivenNegativeNumber_ShouldThrowNegativesNotAllowedException() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            List<int> expected=new List<int> {-1,-2};
            var input = "-1,-2,3";
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------

            //---------------Test Result -----------------------
           var exception= Assert.Throws<NegativesNotAllowedException>(()=>sut.Add(input));
            CollectionAssert.AreEqual(expected,exception.NegativeNumbers);
        }
    }
}
