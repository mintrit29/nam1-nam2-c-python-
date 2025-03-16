using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tinhdiemtrungbinh
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap ma so SV: ");
            string maSV = Console.ReadLine();
            Console.Write("Nhap ho ten: ");
            string hoTen = Console.ReadLine();
            Console.Write("Nhap diem trung binh: ");
            float diemTB = float.Parse(Console.ReadLine());
            string xepLoai = "";
            if (diemTB >= 8)
            {
                xepLoai = "Gioi";
            }
            else if (diemTB >= 6.5)
            {
                xepLoai = "Kha";
            }
            else if (diemTB >= 5)
            {
                xepLoai = "Trung binh";
            }
            else
            {
                xepLoai = "Yeu kem";
            }
            Console.WriteLine($"Thong tin sv: \nMSSV: {maSV} \n Ho ten: {hoTen} \nXep loai: {xepLoai}");
        }
    }
}
