using System;
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
        public void Add_Empty_String_Returns0()
        {
            //---------------Set up test pack-------------------

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var calculator = CreateCalculator();
            //---------------Test Result -----------------------
            var result = calculator.Add("");

            Assert.AreEqual(0,result);
        }
        [Test]
        public void Add_Number_String_IntegerValue()
        {
            //---------------Set up test pack-------------------

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var calculator = CreateCalculator();
            //---------------Test Result -----------------------
            var result = calculator.Add("1");

            Assert.AreEqual(1,result);
        }
        [Test]
        public void Add_NumberA_String_IntegerValue()
        {
            //---------------Set up test pack-------------------

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var calculator = CreateCalculator();
            //---------------Test Result -----------------------
            var result = calculator.Add("2");

            Assert.AreEqual(2,result);
        }
        [Test]
        public void Add_NumberB_String_IntegerValue()
        {
            //---------------Set up test pack-------------------

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var calculator = CreateCalculator();
            //---------------Test Result -----------------------
            var result = calculator.Add("3");

            Assert.AreEqual(3,result);
        }
        [Test]
        public void Add_Numbers_String_ReturnSum()
        {
            //---------------Set up test pack-------------------

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var calculator = CreateCalculator();
            //---------------Test Result -----------------------
            var result = calculator.Add("1,2");

            Assert.AreEqual(3,result);
        }
        [Test]
        public void Add_NumbersA_String_ReturnSum()
        {
            //---------------Set up test pack-------------------

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var calculator = CreateCalculator();
            //---------------Test Result -----------------------
            var result = calculator.Add("2,3");

            Assert.AreEqual(5,result);
        }

    }
}
