using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving
{
    class Program
    {
        static void Main(string[] args)
        {
            ////No. 1
            //GetWeightedString();

            ////No. 2
            //GetHighestPoliandrome();

            //No. 3
            BalanceBracket();
        }

        #region No 1
        static void GetWeightedString()
        {
            string input = "abbcccd";
            int[] queries = { 1, 3, 9, 8 };
            List<string> output = GetString(input, queries);
            Console.WriteLine(string.Join(", ", output));
            Console.ReadLine();
        }

        static List<string> GetString(string input, int[] queries)
        {
            List<string> result = new List<string>();
            Dictionary<string, int> WeightedStrings = new Dictionary<string, int>();

            int i = 0;
            while (i < input.Length)
            {
                int j = i;
                while (j < input.Length && input[j] == input[i])
                {
                    string substring = input.Substring(i, j - i + 1);
                    int weight = (j - i + 1) * (input[i] - 'a' + 1);
                    WeightedStrings[substring] = weight;
                    j++;
                }
                i = j;
            }

            foreach (int item in queries)
            {
                if (WeightedStrings.ContainsValue(item))
                {
                    result.Add("Yes");
                }
                else
                {
                    result.Add("No");
                }
            }

            return result;
        }

        #endregion No 1

        #region No 2
        static void GetHighestPoliandrome()
        {
            string input = "3943";
            int k = 1;
            string result = FindHighestPalindrome(input.ToCharArray(), 0, input.Length - 1, k);
            Console.WriteLine("Output: " + result);
            Console.ReadLine();
        }

        static string FindHighestPalindrome(char[] charArray, int left, int right, int k)
        {
            if (left > right)
            {
                return new string(charArray);
            }

            if (charArray[left] != charArray[right])
            {
                charArray[left] = charArray[right] = (char)Math.Max(charArray[left], charArray[right]);
                k--; 
            }

            string result = FindHighestPalindrome(charArray, left + 1, right - 1, k);

            if (k > 0 && left < right)
            {
                charArray[left] = charArray[right] = '9';
                string tempResult = FindHighestPalindrome(charArray, left + 1, right - 1, k - 2);
                if (tempResult != "-1" && int.Parse(tempResult) > int.Parse(result))
                {
                    result = tempResult;
                }
            }

            if (k < 0 || result == "-1")
            {
                return "-1";
            }

            return result;
        }
        #endregion No 2

        #region No 3
        static void BalanceBracket()
        {
            string input1 = "{[()]}";
            string input2 = "{[(])}";
            string input3 = "{(([])[])[]}";

            Console.WriteLine(CheckBalancedBracket(input1)); 
            Console.WriteLine(CheckBalancedBracket(input2)); 
            Console.WriteLine(CheckBalancedBracket(input3)); 
            Console.ReadLine();
        }
        static string CheckBalancedBracket(string input)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> bracketPairs = new Dictionary<char, char>
        {
            { '(', ')' },
            { '{', '}' },
            { '[', ']' }
        };

            foreach (char bracket in input)
            {
                if (bracketPairs.ContainsKey(bracket))
                {
                    stack.Push(bracket);
                }
                else if (bracketPairs.ContainsValue(bracket))
                {
                    if (stack.Count == 0 || bracket != bracketPairs[stack.Pop()])
                    {
                        return "NO";
                    }
                }
            }

            return stack.Count == 0 ? "YES" : "NO";
        }
        #endregion No 3
    }
}
