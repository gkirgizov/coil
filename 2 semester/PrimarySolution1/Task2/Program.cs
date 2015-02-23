using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyList<int> lst = new LinkedList<int>(55);
            //lst.Add(44);
            //lst.Add(33);

            //HashTable<string> ht = new HashTable<string>(7);
            //ht.Add("first");
            //ht.Add("second");
            //ht.Add("third");
            //ht.Add("fourth");
            //ht.Add("fifth");
            //ht.Add("sixth");
            //ht.Add("seventh");
            //ht.Add("eighth");
            //ht.Add("ninth");
            //ht.Add("ten");
            //ht.Add("eleven");
            //ht.Add("twelve");
            //ht.Add("thirteen");
            //ht.Add("fourteen");

            //ht.Delete("second");
            //ht.Delete("ten");
            //ht.Delete("first");
            //ht.Delete("something");

            //Console.WriteLine(ht.Search("something"));

            string inp = Console.ReadLine();
            MyStack<int> stack = new LinkedStack<int>();
            Console.WriteLine(CalcStack.Calculate(ref inp, stack));
        }
    }
}