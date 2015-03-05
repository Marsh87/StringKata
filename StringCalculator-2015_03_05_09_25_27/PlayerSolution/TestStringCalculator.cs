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
        public void Constructor() {
            //---------------Set up test pack-------------------

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var calculator = StringCalculator;
            //---------------Test Result -----------------------
            Assert.IsNotNull(calculator);
        }

        [Test]
        public void Add_GivenEmptyString_ShouldReturn0() {
            //---------------Set up test pack-------------------
            var sut = StringCalculator.Add("");
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------

            //---------------Test Result -----------------------
            Assert.AreEqual(0,sut);
        }
        [Test]
        public void Add_GivenNumber_ShouldReturnIntegerNumber() {
            //---------------Set up test pack-------------------
            var sut = StringCalculator.Add("1");
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------

            //---------------Test Result -----------------------
            Assert.AreEqual(1,sut);
        }
        [Test]
        public void Add_GivenNumberPartA_ShouldReturnIntegerNumber() {
            //---------------Set up test pack-------------------
            var sut = StringCalculator.Add("2");
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------

            //---------------Test Result -----------------------
            Assert.AreEqual(2,sut);
        }

        private IStringCalculator StringCalculator {
            get {
                var calculator = CreateCalculator();
                return calculator;
            }
        }
    }
}
