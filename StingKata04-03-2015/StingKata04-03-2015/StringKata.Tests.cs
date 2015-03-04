using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StingKata04_03_2015
{
   [TestFixture]
   public class StringKata
    {
       [Test]
       public void Add_GivenEmptyString_ShouldReturn0() {
           //---------------Set up test pack-------------------
           
           Kata kata=new Kata();
           //---------------Assert Precondition----------------
           var result = kata.Add("");
           //---------------Execute Test ----------------------

           //---------------Test Result -----------------------
           Assert.AreEqual(0,result);
       }
       [Test]
       public void Add_GivenNumber_ShouldReturnIntegerNumber() {
           //---------------Set up test pack-------------------
           
           Kata kata=new Kata();
           //---------------Assert Precondition----------------
           var result = kata.Add("1");
           //---------------Execute Test ----------------------

           //---------------Test Result -----------------------
           Assert.AreEqual(1,result);
       }
       [Test]
       public void Add_GivenNumberPartA_ShouldReturnIntegerNumber() {
           //---------------Set up test pack-------------------
           
           Kata kata=new Kata();
           //---------------Assert Precondition----------------
           var result = kata.Add("2");
           //---------------Execute Test ----------------------

           //---------------Test Result -----------------------
           Assert.AreEqual(2,result);
       }
       [Test]
       public void Add_GivenTwoNumbersSeperatedByComma_ShouldReturnSum() {
           //---------------Set up test pack-------------------
           
           Kata kata=new Kata();
           //---------------Assert Precondition----------------
           var result = kata.Add("1,2");
           //---------------Execute Test ----------------------

           //---------------Test Result -----------------------
           Assert.AreEqual(3,result);
       }
       [Test]
       public void Add_GivenTwoNumbersSeperatedByCommaPartA_ShouldReturnSum() {
           //---------------Set up test pack-------------------
           
           Kata kata=new Kata();
           //---------------Assert Precondition----------------
           var result = kata.Add("11,22");
           //---------------Execute Test ----------------------

           //---------------Test Result -----------------------
           Assert.AreEqual(33,result);
       }
       [Test]
       public void Add_GivenTwoNumbersSeperatedByNewline_ShouldReturnSum() {
           //---------------Set up test pack-------------------
           
           Kata kata=new Kata();
           //---------------Assert Precondition----------------
           var result = kata.Add("1,2\n3");
           //---------------Execute Test ----------------------

           //---------------Test Result -----------------------
           Assert.AreEqual(6,result);
       }
       [Test]
       public void Add_GivenNumbersGreaterThan1000_ShouldNotIncludeNumbers() {
           //---------------Set up test pack-------------------
           
           Kata kata=new Kata();
           //---------------Assert Precondition----------------
           var result = kata.Add("1,2,1002");
           //---------------Execute Test ----------------------

           //---------------Test Result -----------------------
           Assert.AreEqual(3,result);
       }
       [Test]
       public void Add_GivenNumbersGreaterThan1000PartA_ShouldNotIncludeNumbers() {
           //---------------Set up test pack-------------------
           
           Kata kata=new Kata();
           //---------------Assert Precondition----------------
           var result = kata.Add("1,2,1000");
           //---------------Execute Test ----------------------

           //---------------Test Result -----------------------
           Assert.AreEqual(1003,result);
       }
       [Test]
       public void Add_GivenTwoNumbersSeperatedByCustomeDelimiter_ShouldReturnSum() {
           //---------------Set up test pack-------------------
           
           Kata kata=new Kata();
           //---------------Assert Precondition----------------
           var result = kata.Add("//;\n1;2;3");
           //---------------Execute Test ----------------------

           //---------------Test Result -----------------------
           Assert.AreEqual(6,result);
       }
       [Test]
       public void Add_GivenTwoNumbersSeperatedByCustomeDelimiterWithVaryingLength_ShouldReturnSum() {
           //---------------Set up test pack-------------------
           
           Kata kata=new Kata();
           //---------------Assert Precondition----------------
           var result = kata.Add("//[***]\n1***2***3");
           //---------------Execute Test ----------------------

           //---------------Test Result -----------------------
           Assert.AreEqual(6,result);
       }
       [Test]
       public void Add_GivenTwoNumbersSeperatedByVaryingCustomeDelimiterWithVaryingLength_ShouldReturnSum() {
           //---------------Set up test pack-------------------
           
           Kata kata=new Kata();
           //---------------Assert Precondition----------------
           var result = kata.Add("//[*][%]\n1*2%3");
           //---------------Execute Test ----------------------

           //---------------Test Result -----------------------
           Assert.AreEqual(6,result);
       }
       [Test]
       public void Add_GivenNegativeNumber_ShouldThrowException() {
           //---------------Set up test pack-------------------
           
           Kata kata=new Kata();
         List<int> expected =new List<int>() {-1};
           ;
           //---------------Assert Precondition----------------
          
           //---------------Execute Test ----------------------

           //---------------Test Result -----------------------
            var exception= Assert.Throws<NegativesNotAllowed>(()=>kata.Add("-1"));
           CollectionAssert.AreEqual(expected,exception.negativenumbers);

       }
       [Test]
       public void Add_GivenNegativeNumberList_ShouldThrowException() {
           //---------------Set up test pack-------------------
           
           Kata kata=new Kata();
         List<int> expected =new List<int>() {-1,-2,-4};
           ;
           //---------------Assert Precondition----------------
          
           //---------------Execute Test ----------------------

           //---------------Test Result -----------------------
            var exception= Assert.Throws<NegativesNotAllowed>(()=>kata.Add("-1,2,-2,-4"));
           CollectionAssert.AreEqual(expected,exception.negativenumbers);

       }






    }
}
