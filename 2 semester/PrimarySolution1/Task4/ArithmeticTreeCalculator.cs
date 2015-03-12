using System;
using System.IO;

namespace Task4
{
    /// <summary>
    /// Static class contains functions that allows to operate with arithmetic tree without object instantiation
    /// </summary>
    public static class ArithmeticTreeCalculator
    {
        /// <summary>
        /// Parse expression in the tree contained in the file and calculate this expression
        /// </summary>
        public static int CalcTree(string filePath)
        {
            var tree = CreateTree(filePath);
            return tree.Calc();
        }

        /// <summary>
        /// Parse expression in the tree contained in the file
        /// </summary>
        public static ArithmeticTree CreateTree(string filePath)
        {
            string inputString = ReadFromFile(filePath);
            inputString = GenerateSubstring(inputString);

            int temp;
            string token = GetToken(inputString);
            if (Int32.TryParse(token, out temp))
            {
                return new Operand(token);
            }
            ArithmeticTree tree = new Operator(token);
            CreateTreeRecursion(ref tree, inputString.Substring(token.Length));
            return tree;
        }

        private static void CreateTreeRecursion(ref ArithmeticTree root, string substring)
        {
            for (var i = 0; i < substring.Length; ++i)
            {
                if (substring[i] != ' ' && substring[i] != ')')
                {
                    if (substring[i] == '(')
                    {
                        string subsubstring = GenerateSubstring(substring);
                        CreateTreeRecursion(ref root, subsubstring);
                        i += subsubstring.Length;
                    }
                    else
                    {
                        string token = GetToken(substring, i);
                        i += token.Length;
                        int temp;
                        if (Int32.TryParse(token, out temp))
                        {
                            root.Add(new Operand(token));
                        }
                        else
                        {
                            ArithmeticTree newItem = new Operator(token);
                            string subsubstring = GenerateSubstring(substring);
                            CreateTreeRecursion(ref newItem, subsubstring);
                            i += subsubstring.Length + 2;
                            root.Add(newItem);
                        }
                    }
                }
            }
        }

        private static string ReadFromFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        private static string GenerateSubstring(string inputString)
        {
            string outputString;
            int openBracket = inputString.IndexOf('(');
            if (openBracket >= 0)
            {
                int closeBracket = inputString.LastIndexOf(')');
                outputString = inputString.Substring(openBracket + 1, closeBracket - openBracket - 1);
                return outputString;
            }
            if (inputString.Trim().Length > 1)
            {
                return inputString.Substring(1);
            }
            return inputString;
        }

        private static string GetToken(string inputString, int startSearchIndex = 0)
        {
            string tempSubstring = inputString.Substring(startSearchIndex);
            int endOfToken = tempSubstring.IndexOf(' ');
            if (endOfToken >= 0)
            {
                return tempSubstring.Substring(0, endOfToken);
            }
            return tempSubstring.Substring(0, tempSubstring.Length);
        }
    }
}