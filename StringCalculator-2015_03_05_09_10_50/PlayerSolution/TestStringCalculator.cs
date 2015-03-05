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
        public void Add_GivenNegativeNumber_ShouldThrowException() {
            //---------------Set up test pack-------------------

            var calculator = CreateCalculator();
            List<int> expected = new List<int> {-1};


            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------

            //---------------Test Result -----------------------
            var exception = Assert.Throws<NegativesNotAllowedException>(() => calculator.Add("-1"));
            CollectionAssert.AreEqual(expected,exception.NegativeNumbers);

        }
    }
}
