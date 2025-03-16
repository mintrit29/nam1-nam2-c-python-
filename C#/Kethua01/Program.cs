using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kethua01
{
    public class NhanVien
    {
        string ma, ten;
        int NamVL, SoNgayNghi;
        double HSL;

        public NhanVien()
        {
            ma = "NV01";
            ten = "Ho ten SV";
            NamVL = 2006;
            SoNgayNghi = 1;
            HSL = 3.0;
        }
        public NhanVien(string maso, string hoten, double hsLuong)
        {
            ma = maso;
            ten = hoten;
            HSL = hsLuong;
            NamVL = DateTime.Today.Year;
            SoNgayNghi = 0;
        }
        public NhanVien(string ma, string ten, int nvl, int nghi, double hsluong)
        {
            this.ma = ma;
            this.ten = ten;
            this.NamVL = nvl;
            this.SoNgayNghi = nghi;
            this.HSL = hsluong;
        }

        static int LuongCoBan = 1150;
        public double PhuCapThamNien()
        {
            int thamnien = DateTime.Today.Year - NamVL;
            if (thamnien >= 5)
                return thamnien * NhanVien.LuongCoBan / 100.0;
            return 0;
        }
        public char XepLoai()
        {
            if (SoNgayNghi <= 1) return 'A';
            if (SoNgayNghi <= 3) return 'B';
            return 'C';
        }
        public double Luong()
        {
            double hsThiDua = 0.5;
            char x1 = XepLoai();
            if (x1 == 'A') hsThiDua = 1.0;
            if (x1 == 'B') hsThiDua = 0.75;
            return NhanVien.LuongCoBan * HSL * hsThiDua * PhuCapThamNien();
        }
    }
}
