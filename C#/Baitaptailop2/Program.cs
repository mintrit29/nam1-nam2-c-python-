using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitaptailop2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap so KW tieu thu: ");
            int kw = int.Parse(Console.ReadLine());
            double Tongtien = TienDienPhaiTra(kw);
            Console.WriteLine("Tien dien phai tra: " + Tongtien + "$");
        }
        static double TienDienPhaiTra(int kw)
        {
            double Tiendien = 0;
            if (kw <= 100)
            {
                Tiendien = kw * 5;
            }
            else if (kw <= 150)
            {
                Tiendien = 100 * 5 + (kw - 100) * 7;
            }
            else if (kw <= 200)
            {
                Tiendien = 100 * 5 + 50 * 7 + (kw - 150) * 10;
            }
            else if (kw <= 300)
            {
                Tiendien = 100 * 5 + 50 * 7 + 50 * 10 + (kw - 200) * 15;
            }
            else
            {
                Tiendien = 100 * 5 + 50 * 7 + 50 * 10 + 100 * 15 + (kw - 300) * 20;
            }
                return Tiendien;
        }
    }
}
