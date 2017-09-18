using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strict_Credentials
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(findInvalid(5));
        }
        static int findInvalid(int k)
        {
            if ( k == 3)
            {
                return 8;
            }
            if (k==4 )
                return 2 * ((findInvalid(k - 1) * 9 * k) + 1);
            return 
        }
    }
}
