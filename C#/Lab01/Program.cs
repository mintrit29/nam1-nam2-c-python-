using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.Write("Nhap vao so nguyen n= ");
            try
            {
                n = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.Write("Ban nhap khong phai so");
                return;
            }

            if (n == 0)
            {
                Console.Write("Khong am, khong duong");
            }
            if (n < 0)
            {
                Console.Write("So am");
            }
            if (n > 0)
            {
                Console.Write("So duong");
            }
            Console.ReadLine();
        }
    }
}
