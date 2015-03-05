using System;
using System.Collections.Generic;
using System.Runtime;
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
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------
            var result = sut.Add("");
            //---------------Execute Test ----------------------

            //---------------Test Result -----------------------

            Assert.AreEqual(0,result);
        }
        [Test]
        public void Add_GivenNumber_ShouldReturnNumber() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------
            var result = sut.Add("1");
            //---------------Execute Test ----------------------

            //---------------Test Result -----------------------

            Assert.AreEqual(1,result);
        }
        [Test]
        public void Add_GivenNumberPartA_ShouldReturnNumber() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------
            var result = sut.Add("2");
            //---------------Execute Test ----------------------

            //---------------Test Result -----------------------

            Assert.AreEqual(2,result);
        }

        [Test]
        public void Add_GivenNumberSeperatedByAComma_ShouldReturnSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------
            var result = sut.Add("1,2");
            //---------------Execute Test ----------------------

            //---------------Test Result -----------------------
            Assert.AreEqual(3,result);
        }
        [Test]
        public void Add_GivenNumberSeperatedByACommaPartA_ShouldReturnSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------
            var result = sut.Add("11,22");
            //---------------Execute Test ----------------------

            //---------------Test Result -----------------------
            Assert.AreEqual(33,result);
        }
        [Test]
        public void Add_GivenNumbersSeperatedByACommaPartA_ShouldReturnSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------
            var result = sut.Add("1,2,3");
            //---------------Execute Test ----------------------

            //---------------Test Result -----------------------
            Assert.AreEqual(6,result);
        }
        [Test]
        public void Add_GivenNumbersSeperatedByNewLine_ShouldReturnSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------
            var result = sut.Add("1,2\n3");
            //---------------Execute Test ----------------------

            //---------------Test Result -----------------------
            Assert.AreEqual(6,result);
        }
        [Test]
        public void Add_GivenNumbersSeperatedByCustomeDelimiter_ShouldReturnSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------
            var result = sut.Add("//;\n1;2");
            //---------------Execute Test ----------------------

            //---------------Test Result -----------------------
            Assert.AreEqual(3,result);
        }
        [Test]
        public void Add_GivenNumbersSeperatedByCustomDelimiterofvaryinglength_ShouldReturnSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------
            var result = sut.Add("//[***]\n1***2***3");
            //---------------Execute Test ----------------------

            //---------------Test Result -----------------------
            Assert.AreEqual(6,result);
        }
       
        [Test]
        public void Add_GivenNegativeNumber_ShouldThrowException() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var expected = new List<int>() {-2};

            //---------------Assert Precondition----------------
            

            //---------------Execute Test ----------------------

            //---------------Test Result -----------------------
            var exception = Assert.Throws<StringCalculator.NegativesNOTAllowed>(() => sut.Add("1,-2,3") );
            CollectionAssert.AreEqual(expected,exception.NegativeNumbers);

        }
        [Test]
        public void Add_GivenNegativeNumbers_ShouldThrowException() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            var expected = new List<int>() {-2,-3,-4};

            //---------------Assert Precondition----------------
            

            //---------------Execute Test ----------------------

            //---------------Test Result -----------------------
            var exception = Assert.Throws<StringCalculator.NegativesNOTAllowed>(() => sut.Add("1,-2,-3,-4") );
            CollectionAssert.AreEqual(expected,exception.NegativeNumbers);

        }

        [Test]
        public void Add_GivenNumberbiggerthan100_ShouldNotAddtoSum() {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------
            var result = sut.Add("1,2,3,1001");
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------

            //---------------Test Result -----------------------
            Assert.AreEqual(6, result);
        }
        [Test]
        public void Add_GivenNumbersSeperatedByCustomDelimiterofVaryingLengthandType_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            var sut = CreateCalculator();
            //---------------Assert Precondition----------------
            var result = sut.Add("//[*][%]\n1*2%3");
            //---------------Execute Test ----------------------

            //---------------Test Result -----------------------
            Assert.AreEqual(6, result);
        }

    }
}
