using System;
using System.CodeDom;
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
        public void Add_EmptyString_Should_Return_0() {
            //---------------Set up test pack-------------------
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
           var  result = calculator.Add("");
            //---------------Test Result -----------------------
            Assert.AreEqual(0,result);
        }
        [Test]
        public void Add_Number_Should_Number() {
            //---------------Set up test pack-------------------
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
           var  result = calculator.Add("1");
            //---------------Test Result -----------------------
            Assert.AreEqual(1,result);
        }
        [Test]
        public void Add_Number2_Should_Number2() {
            //---------------Set up test pack-------------------
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
           var  result = calculator.Add("2");
            //---------------Test Result -----------------------
            Assert.AreEqual(2,result);
        }
        [Test]
        public void Add_Number3_Should_Number3() {
            //---------------Set up test pack-------------------
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
           var  result = calculator.Add("3");
            //---------------Test Result -----------------------
            Assert.AreEqual(3,result);
        }
        [Test]
        public void Add_TwoNumbers_Should_ReturnSum() {
            //---------------Set up test pack-------------------
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
           var  result = calculator.Add("1,2");
            //---------------Test Result -----------------------
            Assert.AreEqual(3,result);
        }
        [Test]
        public void Add_TwoDifferentNumbersA_Should_ReturnSum() {
            //---------------Set up test pack-------------------
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
           var  result = calculator.Add("2,3");
            //---------------Test Result -----------------------
            Assert.AreEqual(5,result);
        }
        [Test]
        public void Add_TwoDifferentNumbersB_Should_ReturnSum() {
            //---------------Set up test pack-------------------
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
           var  result = calculator.Add("3,4");
            //---------------Test Result -----------------------
            Assert.AreEqual(7,result);
        }
        [Test]
        public void Add_ThreeDifferentNumbersA_Should_ReturnSum() {
            //---------------Set up test pack-------------------
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
           var  result = calculator.Add("1,2,3");
            //---------------Test Result -----------------------
            Assert.AreEqual(6,result);
        }

    }
}
