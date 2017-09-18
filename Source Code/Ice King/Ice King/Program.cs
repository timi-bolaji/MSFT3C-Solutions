using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ice_King
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputData = File.ReadAllLines("input.txt").ToList<string>();
            for (int cur = 0; cur < inputData.Count; cur++)
            {
                Max myMax = new Max(0, 0, 0);
                List<string> curStrInput = inputData[cur].Split(' ').ToList<string>();
                int[] curInput = new int[curStrInput.Count];
                for (int i = 0; i < curStrInput.Count; i++)
                {
                    curInput[i] = Convert.ToInt32(curStrInput[i]);
                }
                curStrInput = null;
                // input done
                // List<int> areas = new List<int>();
                for (int i = 0; i < curInput.Length; i++)
                {
                    for (int j = i+1; j < curInput.Length; j++)
                    {
                        int curArea = min(curInput[i], curInput[j]) * (j - i);
                        if (curArea > myMax.area)
                        {
                            myMax.i = i;
                            myMax.j = j;
                            myMax.area = curArea;
                        }
                        
                    }
                }
                Console.WriteLine("{0} {1} {2}", myMax.area, myMax.i, myMax.j);
            }
        }

        static int min(int a, int b)
        {
            return (a < b) ? a : b;
        }
    }
    public class Max
    {
        public int i = 0, j = 0;
        public int area;
        public Max(int ci, int cj, int carea)
        {
            i = ci;
            j = cj;
            area = carea;
        }
    }
}
