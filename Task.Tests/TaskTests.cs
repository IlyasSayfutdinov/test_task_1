using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Task.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTransformer1()
        {
            // arrange
            NumberTransformer transformer1 = new NumberTransformer();
            transformer1.AddRule(3, "fizz");
            transformer1.AddRule(5, "buzz");
            
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            List<string> expected = new List<string> { "1", "2", "fizz", "4", "buzz", "fizz", "7", "8", "fizz", "buzz", "11", "fizz", "13", "14", "fizz-buzz" };

            // actual
            List<string> actual = transformer1.TransformList(numbers);

            // assert
            Console.WriteLine(string.Join(", ", expected));
            Console.WriteLine(string.Join(", ", actual));
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestTransformer2()
        {
            // arrange
            NumberTransformer transformer2 = new NumberTransformer();
            transformer2.AddRule(3, "fizz");
            transformer2.AddRule(5, "buzz");
            transformer2.AddRule(4, "muzz");
            transformer2.AddRule(7, "guzz");
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 60, 105, 420 };
            List<string> expected = new List<string> { "1", "2", "fizz", "muzz", "buzz", "fizz", "guzz", "muzz", "fizz", "buzz", "11", "fizz-muzz", "13", "guzz", "fizz-buzz", "fizz-buzz-muzz", "fizz-buzz-guzz", "fizz-buzz-muzz-guzz" };
            // actual
            List<string> actual = transformer2.TransformList(numbers);

            // assert
            Console.WriteLine(string.Join(", ", expected));
            Console.WriteLine(string.Join(", ", actual));
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestTransformer3()
        {
            // arrange
            NumberTransformer transformer3 = new NumberTransformer();
            transformer3.AddRule(3, "dog");
            transformer3.AddRule(5, "cat");
            transformer3.AddRule(4, "muzz");
            transformer3.AddRule(7, "guzz");
            
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 60, 105, 420 };
            List<string> expected = new List<string> { "1", "2", "dog", "muzz", "cat", "dog", "guzz", "muzz", "dog", "cat", "11", "dog-muzz", "13", "guzz", "good-boy", "good-boy-muzz", "good-boy-guzz", "good-boy-muzz-guzz"};
            // actual
            List<string> actual = transformer3.TransformList(numbers);

            // assert
            Console.WriteLine(string.Join(", ", expected));
            Console.WriteLine(string.Join(", ", actual));
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
