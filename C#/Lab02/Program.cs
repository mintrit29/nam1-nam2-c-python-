using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    class Program
    {
        static void Main(string[] args)
        {
            int S = 1;
            int n;
            Console.WriteLine("Nhap vao n = ");
            n = int.Parse(Console.ReadLine());
            for (int i = 1; i<=n; i++)
            {
                S *= i;
            }
            Console.WriteLine("Gia tri S = {0}", S);
        }
    }
}
