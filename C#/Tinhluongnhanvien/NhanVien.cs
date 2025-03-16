using System;
using System.Collections.Generic;

namespace BT2OOP
{
    class NhanVien
    {
        //thanh phan du lieu va property
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
        public NhanVien()
        {   MaNV = "3002";
            HoTen = "Van Hoa";
            SoNC = 25;
        }
        public NhanVien(string maNV, string hoTen, int soNC)
        {
            this.MaNV = maNV;
            this.HoTen = hoTen;
            this.SoNC = soNC;
        }
        public NhanVien(NhanVien nv)
        {
            this.MaNV = nv.MaNV;
            this.HoTen = nv.HoTen;
            this.SoNC = nv.SoNC;
        }
        public void Nhap()
        {
            Console.Write("Nhap ma nhan vien: ");
            MaNV = Console.ReadLine();
            Console.Write("Nhap ho ten nhan vien: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhap so ngay cong: ");
            SoNC = int.Parse(Console.ReadLine());
        }
        LinkedList<NhanVien> ListNv = new LinkedList<NhanVien>();
        public void InputListNV(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap thong tin nhan vien thu {0}", i + 1);
                NhanVien nv = new NhanVien();
                nv.Nhap();
                ListNv.AddLast(nv);
            }
        }
        public void OutputListNV(int n)
        {
            foreach (NhanVien nv in ListNv)
            {
                nv.xuat();
            }
        }
        public double TinhLuong()
        {
            return SoNC * NhanVien.LuongNgay;
        }
        public float TinhThuong()
        {
            if (XepLoai == 'A')
                return (float)(TinhLuong() * 5 / 100);
            else if (XepLoai == 'B')
                return (float)(TinhLuong() * 2 / 100);
            else
                return 0;
        }
        public double TongThuNhap()
        {
            return TinhLuong() + TinhThuong();
        }
        public void xuat ()
        {
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}; {5}, {6}", MaNV, HoTen, SoNC, XepLoai, TinhLuong(), TinhThuong() ,TongThuNhap());
        }
       
    }
}
