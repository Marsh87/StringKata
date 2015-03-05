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
        public void Add_Empty_String_Returns_0()
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
        public void Add_Numeric_String_Returns_IntegerValue()
        {
            //---------------Set up test pack-------------------

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var calculator = CreateCalculator();
            //---------------Test Result -----------------------
            var result = calculator.Add("1");
            Assert.AreEqual(1,result);
        }
        //[Test]
        //public void Add_Two_Numbers_ReturnSum()
        //{
        //    //---------------Set up test pack-------------------

        //    //---------------Assert Precondition----------------

        //    //---------------Execute Test ----------------------
        //    var calculator = CreateCalculator();
        //    //---------------Test Result -----------------------
        //    var result = calculator.Add("1,2");
        //    Assert.AreEqual(3,result);
        //}

        //[Test]
        //public void Add_GivenTwoDoubleDigitNumbers_ShouldReturnSum() {
        //    //---------------Set up test pack-------------------
        //    var calculator = CreateCalculator();
        //    //---------------Assert Precondition----------------

        //    //---------------Execute Test ----------------------
        //    var result = calculator.Add("12,12");
        //    //---------------Test Result -----------------------
        //    Assert.AreEqual(24,result);
        //}

    }
}
