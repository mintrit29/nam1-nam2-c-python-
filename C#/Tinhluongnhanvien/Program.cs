using System;

namespace BT2OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            /*NhanVien nhanVien1 = new NhanVien();
            Console.WriteLine("Nhan vien 1: ");
            nhanVien1.xuat();

            NhanVien nhanVien2 = new NhanVien();
            Console.WriteLine(" Nhap thong tin nhan vien 2: ");
            nhanVien2.Nhap();
            Console.WriteLine("Nhan vien 2: ");
            nhanVien2.xuat();

            NhanVien nhanVien3 = new NhanVien("NV003", "Tran Hoang Anh", 11);
            Console.WriteLine("-- Thong tin nhan vien 3: --");
            nhanVien3.xuat();

            NhanVien nhanVien4 = new NhanVien("NV004", "Tran Hoa", 1);
            Console.WriteLine("-- Thong tin nhan vien 4: --");
            nhanVien4.xuat();
            Console.ReadLine();*/
            NhanVien nhanVien = new NhanVien();
            nhanVien.InputListNV(3);
            nhanVien.OutputListNV(3);
         
        }
    }
}
