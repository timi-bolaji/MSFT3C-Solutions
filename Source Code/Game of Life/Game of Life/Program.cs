using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Game_of_Life
{
    class Program
    {
        static List<List<char>> grid = new List<List<char>>();
        static List<List<char>> tempGrid = new List<List<char>>();
        static void Main(string[] args)
        {
            List<string> inputData = File.ReadAllLines("input.txt").ToList<string>();
            string[] vars = inputData[0].Split(' ');
            int H = Convert.ToInt32(vars[0]);
            int W = Convert.ToInt32(vars[1]);
            int T = Convert.ToInt32(vars[2]);
            // grid = new List<List<char>>();
            
            for (int cur = 0; cur < H; cur++)
            {
                grid.Add(new List<char>());
                for (int j = 0; j < W; j++)
                {
                    grid[cur].Add(inputData[cur + 1][j]);
                }
            }

            //for (int i = 0; i < H; i++)
            //{
            //    for (int j = 0; j < W; j++)
            //    {
            //        if (j == W - 1)
            //            Console.WriteLine(grid[i][j]);
            //        else
            //            Console.Write(grid[i][j]);
            //    }
            //}

            for (int itr = 0; itr < T; itr++)
            {
                //Console.WriteLine();
                for (int i = 0; i < H; i++)
                {
                    tempGrid.Add(new List<char>());
                    for (int j = 0; j < W; j++)
                    {
                        tempGrid[i].Add(grid[i][j]);
                    }
                }

                for (int i = 0; i < H; i++)
                {
                    for (int j = 0; j < W; j++)
                    {
                        int maleNo = 0;
                        int femaleNo = 0;
                        countNeighbors(i, j, ref maleNo, ref femaleNo);
                        // Console.WriteLine(maleNo);
                        if (grid[i][j] == '.')
                        {
                            if (((maleNo + femaleNo) == 3) && (maleNo != 0))
                            {
                                tempGrid[i][j] = (femaleNo == 1) ? '*' : '#';
                                //Console.WriteLine(maleNo);
                            }
                        }

                        else if (grid[i][j] == '*')
                        {
                            if (maleNo > 3 || maleNo < 2)
                            {
                                tempGrid[i][j] = '.';
                            }
                        }
                        else if (grid[i][j] == '#')
                        {
                            if (femaleNo > 3 || femaleNo < 2)
                            {
                                tempGrid[i][j] = '.';
                            }
                        }
                    }
                }
                // grid = new List<List<char>>();
                for (int i = 0; i < H; i++)
                {
                    for (int j = 0; j < W; j++)
                    {
                        grid[i][j] = tempGrid[i][j];
                    }
                }
            }

               // Console.WriteLine();
                for (int i = 0; i < H; i++)
                {
                    for (int j = 0; j < W; j++)
                    {
                        if (j == W - 1)
                            Console.WriteLine(grid[i][j]);
                        else
                            Console.Write(grid[i][j]);
                    }
                }
            
            Console.ReadKey();
        }
        static void countNeighbors(int i, int j, ref int male, ref int female)
        {
            int m = 0, f = 0;
            // Console.WriteLine(grid[i][j]);
            // Console.WriteLine(grid[i - 1][j]);
            try
            {
                if (grid[i - 1][j] == '#')
                    m++;
                if (grid[i - 1][j] == '*')
                    f++;
            }
            catch (Exception)
            {
            }

            try
            {
                if (grid[i + 1][j] == '#')
                    m++;
                if (grid[i + 1][j] == '*')
                    f++;
            }
            catch (Exception)
            {
            }

            try
            {
                if (grid[i][j-1] == '#')
                    m++;
                if (grid[i][j-1] == '*')
                    f++;
            }
            catch (Exception)
            {
            }

            try
            {
                if (grid[i][j+1] == '#')
                    m++;
                if (grid[i][j+1] == '*')
                    f++;
            }
            catch (Exception)
            {
            }
            male = m;
            female = f;
        }
    }
}
