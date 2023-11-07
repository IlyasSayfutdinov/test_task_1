using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    using System;
    using System.Collections.Generic;

    public class NumberTransformer
    {
        private Dictionary<int, string> rules = new Dictionary<int, string>();

        public void AddRule(int divisor, string replacement)
        {
            rules[divisor] = replacement;
        }

        public string Transform(int number)
        {
            string result = "";

            foreach (var rule in rules)
            {
                if (number % rule.Key == 0)
                {
                    if (result != "") result += "-";
                    result += rule.Value;
                }
            }

            if (result == "")
            {
                result = number.ToString();
            }

            return result;
        }


        public List<string> TransformList(List<int> numbers)
        {
            List<string> transformedNumbers = new List<string>();

            foreach (var number in numbers)
            {
                string TransformedNumber = Transform(number);

                // Костыль для 3го задания
                TransformedNumber = TransformedNumber.Replace("dog-cat", "good-boy");

                transformedNumbers.Add(TransformedNumber);
            }

            return transformedNumbers;
        }


    }


    class Task
    {
        static void Main(string[] args)
        {
            NumberTransformer transformer1 = new NumberTransformer();
            transformer1.AddRule(3, "fizz");
            transformer1.AddRule(5, "buzz");

            NumberTransformer transformer2 = new NumberTransformer();
            transformer2.AddRule(3, "fizz");
            transformer2.AddRule(5, "buzz");
            transformer2.AddRule(7, "guzz");
            transformer2.AddRule(4, "muzz");

            NumberTransformer transformer3 = new NumberTransformer();
            transformer3.AddRule(3, "dog");
            transformer3.AddRule(5, "cat");
            transformer3.AddRule(7, "guzz");
            transformer3.AddRule(4, "muzz");

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 60, 105, 420 };

            List<string> transformedNumbers = transformer3.TransformList(numbers);

            Console.WriteLine(string.Join(", ", transformedNumbers));

            Console.ReadLine();
        }
    }

}
