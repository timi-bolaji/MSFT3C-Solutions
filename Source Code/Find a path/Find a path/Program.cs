using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Find_a_path
{
    class Program
    {
        static List<List<int>> inpArray;
        static void Main(string[] args)
        {
            List<string> inputData = File.ReadAllLines("input.txt").ToList<string>();
            int testNum = Convert.ToInt32(inputData[0]);

            for (int cur = 0; cur < testNum; cur++)
            {
                int lineNum = lin(cur);
                int n = Convert.ToInt32(inputData[lineNum - 1]);
                int x = Convert.ToInt32(inputData[lineNum]);
                int y = Convert.ToInt32(inputData[lineNum + 1]);

                List<List<string>> inpStrArray = new List<List<string>>();
                inpStrArray.Add(inputData[lineNum + 2].Split(' ').ToList<string>());
                inpStrArray.Add(inputData[lineNum + 3].Split(' ').ToList<string>());

                inpArray = new List<List<int>>();
                inpArray.Add(new List<int>());
                inpArray.Add(new List<int>());

                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        inpArray[i].Add(Convert.ToInt32(inpStrArray[i][j]));
                    }
                }
                // Input reading done.
                Point start = new Point(0,0);
                for (int i = 0; i < x; i++)
                {
                    int j = inpArray[i].IndexOf(1);
                    if (j != -1)
                        start = new Point(i, j);
                }

                Console.WriteLine(FindPath(start, 1, n));

            }
        }
        static int lin(int n)
        {
            return n * 6 + 3;
        }
        static string FindPath(Point curr, int k, int n)
        {
            if (k == n)
                return true.ToString().ToLower();
            try
            {
                if (inpArray[curr.i + 1][curr.j] == k + 1)
                    return FindPath(new Point(curr.i+1, curr.j), k + 1, n);
            }
            catch (Exception)
            {

                
            }

            try
            {
                if (inpArray[curr.i - 1][curr.j] == k + 1)
                    return FindPath(new Point(curr.i-1, curr.j), k + 1, n);
            }
            catch (Exception)
            {

                
            }

            try
            {
                if (inpArray[curr.i][curr.j + 1] == k + 1)
                    return FindPath(new Point(curr.i, curr.j+1), k + 1, n);
            }
            catch (Exception)
            {

                
            }

            try
            {
                if (inpArray[curr.i][curr.j - 1] == k + 1)
                    return FindPath(new Point(curr.i, curr.j-1), k + 1, n);
            }
            catch (Exception)
            {

                
            }
            return "false";
        }
    }

    public class Point
    {
        public int i;
        public int j;
        public Point(int ax, int ay)
        {
            i = ax;
            j = ay;
        }
    }

}
