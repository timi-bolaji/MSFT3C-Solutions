using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Palindrome
{
    class 
        Program
    {
        static List<string> inputList;
        static List<string> curr;
        static void Main(string[] args)
        {
            inputList = File.ReadAllLines("TextFile1.txt").ToList();
            
            foreach (var str in inputList)
            {
                var myMax = new Maxi();
                curr = str.Split(' ').ToList<string>();

                for (int i = 0; i < curr.Count; i++)
                {
                    String sub = clean(curr[i]);

                    if (IsPalindrome(sub))
                    {
                        if (sub.Length > myMax.len)
                        {
                            myMax.len = sub.Length;
                            myMax.i = i;
                            myMax.j = i;
                        }
                    }
                    for (int j = i + 1; j < curr.Count; j++)
                    {
                        sub += clean(curr[j]);
                        if (IsPalindrome(sub))
                        {
                            if (sub.Length > myMax.len)
                            {
                                myMax.len = sub.Length;
                                myMax.i = i;
                                myMax.j = j;
                            }

                        }
                    }
                }
                output(myMax.i, myMax.j);
            }
            Console.WriteLine(inputList.Count);
        }

        private static string clean(string sub)
        {
            sub = sub.ToLower();
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            return rgx.Replace(sub, "");
        }

        public static bool IsPalindrome(string str)
        {
            return str.SequenceEqual(str.Reverse());
        }

        static public void output(int beg, int end)
        {
            var str = "";
            for (int i = beg;  i <= end; i++)
            {
                str += (i==beg?"":" ") + curr[i];
            }
            Console.WriteLine(str.Last<char>());
            Console.WriteLine(str);
        }
    }
    class Maxi
    {
        public int i, j, len;
        public Maxi()
        {
            i = 0;
            j = 0;
            len = 0;
        }
    }
}
