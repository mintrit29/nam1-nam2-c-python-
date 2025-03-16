using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitaptailop1
{
    class Program
    {
        static void Main(string[] args)
        {
            int thanhtien = 0;
            int soluong = 0;
            int dongia = 0;
            int tongtien = 0;
            Console.WriteLine("Nhap vao so luong = ");
            soluong = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap vao don gia = ");
            dongia = int.Parse(Console.ReadLine());
            thanhtien = soluong * dongia;

            if (thanhtien > 100000)
            {
                tongtien = thanhtien - thanhtien * 3 / 100;
            }
            else
            {
                tongtien = thanhtien;
            }
            Console.WriteLine("So tien phai tra = {0}", tongtien);
        }
    }
}
