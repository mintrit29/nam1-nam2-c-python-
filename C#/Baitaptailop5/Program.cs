using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitaptailop5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhập chiều dài d: ");
            int d = int.Parse(Console.ReadLine());

            Console.Write("Nhập chiều rộng r: ");
            int r = int.Parse(Console.ReadLine());

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < d; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
