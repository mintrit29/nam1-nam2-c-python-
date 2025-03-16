using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demonhapten
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input Ho va ten:");
            string fullname = Console.ReadLine();
            Console.WriteLine("Input nam sinh:");
            int age = 2025 - Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ho va ten: " + fullname + "; " + "Tuoi: " + age);
            Console.WriteLine($"Ho va ten: {fullname}; Tuoi: {age}");
            Console.WriteLine("Ho va ten: {0}; Tuoi: {1}", fullname, age);
        }
    }
}
