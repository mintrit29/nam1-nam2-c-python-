using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhanvien
{
    class Nhanvien
    {
        string maNV;
        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }

        string hoTen;
        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        int soNC;
        public int SoNC
        {
            get { return soNC; }
            set
            {
                if (value < 10)
                {
                    Console.WriteLine("Du lieu sai");
                    soNC = 10;
                }
                else soNC = value;
            }
        }

        public char XepLoai
        {
            get
            {
                if (SoNC >= 26)
                    return 'A';
                else if (SoNC >= 22)
                    return 'B';
                else
                    return 'C';
            }
        }

        public static double LuongNgay = 200000;
        public Nhanvien()
        {
            MaNV = "3002";
            HoTen = "Nguyen Van A";
            SoNC = 15;
        }

        public Nhanvien(string maNV, string hoTen, int soNC)
        {
            this.MaNV = maNV;
            this.HoTen = hoTen;
            this.SoNC = soNC;
        }
        public Nhanvien(Nhanvien nv)
        {
            this.MaNV = nv.MaNV;
            this.HoTen = nv.HoTen;
            this.SoNC = nv.SoNC;
        }

        public void Nhap()
        {
            Console.Write("Nhap ma so: ");
            MaNV = Console.ReadLine();
            Console.Write("Nhap ho ten: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhap so ngay cong: ");
            SoNC = int.Parse(Console.ReadLine());
        }

        public double TinhLuong()
        {
            return SoNC * Nhanvien.LuongNgay;
        }

        public double TinhThuong()
        {
            if (XepLoai == 'A')
                return TinhLuong() * 5 / 100;
            else if (XepLoai == 'B')
                return TinhLuong() * 2 / 100;
            else return 0;
        }
        public void Xuat()
        {
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}",

            MaNV, HoTen, SoNC, XepLoai, TinhLuong(), TinhThuong());

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Nhanvien nhanVien1 = new Nhanvien();
            Console.WriteLine("-- Thong tin nhan vien 1: --");
            nhanVien1.Xuat();
            Nhanvien nhanVien2 = new Nhanvien();
            Console.WriteLine("Moi nhap thong tin nhan vien 2: ");
            nhanVien2.Nhap();
            Console.WriteLine("-- Thong tin nhan vien 2: --");
            nhanVien2.Xuat();
            Nhanvien nhanVien3 = new Nhanvien("NV003", "Tran Hoang Anh", 25);
            Console.WriteLine("-- Thong tin nhan vien 3: --");
            nhanVien3.Xuat();
            Nhanvien nhanVien4 = new Nhanvien("NV004", "Tran Hoa", 1);
            Console.WriteLine("-- Thong tin nhan vien 4: --");
            nhanVien4.Xuat();
            Console.ReadLine();
        }
    }
}
