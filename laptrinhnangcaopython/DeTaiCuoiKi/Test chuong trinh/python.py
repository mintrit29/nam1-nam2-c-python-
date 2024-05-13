import sqlite3
import tkinter as tk
from tkinter import ttk, messagebox

class DoiBong:
    def __init__(self, MaDB, MaSH, TenDoi, NamTL, GiaTriDB):
        self.MaDB = MaDB
        self.MaSH = MaSH
        self.TenDoi = TenDoi
        self.NamTL = NamTL
        self.GiaTriDB = GiaTriDB

class ChuSoHuu:
    def __init__(self, MaSH, HoTen, Email, NganSach):
        self.MaSH = MaSH
        self.HoTen = HoTen
        self.Email = Email
        self.NganSach = NganSach

class CauThu:
    def __init__(self, MaCT, TenCauThu, MaDB, SoAo, ViTri, NgaySinh, QuocTich, ChieuCao, CanNang, GiaTriCT):
        self.MaCT = MaCT
        self.TenCauThu = TenCauThu
        self.MaDB = MaDB
        self.SoAo = SoAo
        self.ViTri = ViTri
        self.NgaySinh = NgaySinh
        self.QuocTich = QuocTich
        self.ChieuCao = ChieuCao
        self.CanNang = CanNang
        self.GiaTriCT = GiaTriCT

class ChuyenDich:
    def __init__(self, MaGD, MaCT, MaDB, LichSu):
        self.MaGD = MaGD
        self.MaCT = MaCT
        self.MaDB = MaDB
        self.LichSu = LichSu

class HienThiCauThu:
    def __init__(self):
        self.conn = sqlite3.connect('bongda.db')  # Kết nối đến cơ sở dữ liệu
        self.cursor = self.conn.cursor()

    def hien_thi(self):
        self.cursor.execute("SELECT * FROM CauThu")
        cau_thu = self.cursor.fetchall()

        if cau_thu:
            print("Danh sách cầu thủ:")
            for ct in cau_thu:
                print(f"""
Mã CT: {ct[0]}
Tên: {ct[1]}
Mã Đội: {ct[2]}
Số áo: {ct[3]}
Vị trí: {ct[4]}
Ngày sinh: {ct[5]}
Quốc tịch: {ct[6]}
Chiều cao: {ct[7]} cm
Cân nặng: {ct[8]} kg
Giá trị: {ct[9]}
""")
        else:
            print("Không có cầu thủ nào trong cơ sở dữ liệu.")

class ThemCauThu:
    def __init__(self):
        self.conn = sqlite3.connect('bongda.db')
        self.cursor = self.conn.cursor()

    def nhap_thong_tin(self):
        while True:
            self.MaCT = input("Nhập mã cầu thủ (hoặc 'q' để thoát): ")
            if self.MaCT == 'q':
                break
            self.TenCauThu = input("Nhập tên cầu thủ: ")
            self.MaDB = input("Nhập mã đội bóng: ")
            self.SoAo = int(input("Nhập số áo: "))
            self.ViTri = input("Nhập vị trí: ")
            self.NgaySinh = input("Nhập ngày sinh (YYYY-MM-DD): ")
            self.QuocTich = input("Nhập quốc tịch: ")
            self.ChieuCao = float(input("Nhập chiều cao (cm): "))
            self.CanNang = float(input("Nhập cân nặng (kg): "))
            self.GiaTriCT = float(input("Nhập giá trị cầu thủ: "))

            self.them_cau_thu()

    def them_cau_thu(self):
        try:
            self.cursor.execute("""
                INSERT INTO CauThu (MaCT, TenCauThu, MaDB, SoAo, ViTri, NgaySinh, QuocTich, ChieuCao, CanNang, GiaTriCT)
                VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
            """, (self.MaCT, self.TenCauThu, self.MaDB, self.SoAo, self.ViTri, self.NgaySinh, self.QuocTich, self.ChieuCao, self.CanNang, self.GiaTriCT))
            self.conn.commit()
            print("Thêm cầu thủ thành công!")
        except sqlite3.Error as e:
            print("Lỗi khi thêm cầu thủ:", e)
            
class XoaCauThu:
    def __init__(self):
        self.conn = sqlite3.connect('bongda.db')
        self.cursor = self.conn.cursor()

    def xoa_cau_thu(self):
        self.hien_thi = HienThiCauThu()
        self.hien_thi.hien_thi()
        ma_ct = input("Nhập mã cầu thủ để xóa (hoặc 'q' để thoát): ")
        if ma_ct == 'q':
            return

        try:
            self.cursor.execute("DELETE FROM CauThu WHERE MaCT = ?", (ma_ct,))
            self.conn.commit()
            if self.cursor.rowcount > 0:
                print("Xóa cầu thủ thành công!")
            else:
                print("Không tìm thấy cầu thủ với mã CT đó.")
        except sqlite3.Error as e:
            print("Lỗi khi xóa cầu thủ:", e)

class SuaCauThu:
    def __init__(self):
        self.conn = sqlite3.connect('bongda.db')
        self.cursor = self.conn.cursor()

    def sua_cau_thu(self):
        self.hien_thi = HienThiCauThu()
        self.hien_thi.hien_thi()
        ma_ct = input("Nhập mã cầu thủ để sửa (hoặc 'q' để thoát): ")
        if ma_ct == 'q':
            return

        self.cursor.execute("SELECT * FROM CauThu WHERE MaCT = ?", (ma_ct,))
        cau_thu = self.cursor.fetchone()

        if cau_thu:
            # Nhận thông tin mới từ người dùng
            ten_moi = input(f"Nhập tên mới (hiện tại: {cau_thu[1]}): ")
            ma_doi_moi = input(f"Nhập mã đội bóng mới (hiện tại: {cau_thu[2]}): ")
            so_ao_moi = int(input(f"Nhập số áo mới (hiện tại: {cau_thu[3]}): "))
            vi_tri_moi = input(f"Nhập vị trí mới (hiện tại: {cau_thu[4]}): ")
            ngay_sinh_moi = input(f"Nhập ngày sinh mới (YYYY-MM-DD, hiện tại: {cau_thu[5]}): ")
            quoc_tich_moi = input(f"Nhập quốc tịch mới (hiện tại: {cau_thu[6]}): ")
            chieu_cao_moi = float(input(f"Nhập chiều cao mới (cm, hiện tại: {cau_thu[7]}): "))
            can_nang_moi = float(input(f"Nhập cân nặng mới (kg, hiện tại: {cau_thu[8]}): "))
            gia_tri_moi = float(input(f"Nhập giá trị mới (hiện tại: {cau_thu[9]}): "))

            try:
                self.cursor.execute("""
                    UPDATE CauThu
                    SET TenCauThu = ?, MaDB = ?, SoAo = ?, ViTri = ?, NgaySinh = ?, QuocTich = ?, ChieuCao = ?, CanNang = ?, GiaTriCT = ?
                    WHERE MaCT = ?
                """, (ten_moi, ma_doi_moi, so_ao_moi, vi_tri_moi, ngay_sinh_moi, quoc_tich_moi, chieu_cao_moi, can_nang_moi, gia_tri_moi, ma_ct))
                self.conn.commit()
                print("Cập nhật thông tin cầu thủ thành công!")
            except sqlite3.Error as e:
                print("Lỗi khi sửa thông tin cầu thủ:", e)
        else:
            print("Không tìm thấy cầu thủ với mã CT đó.")

    def __del__(self):
        self.conn.close()

class HienThiDoiBong:
    def __init__(self):
        self.conn = sqlite3.connect('bongda.db')
        self.cursor = self.conn.cursor()

    def hien_thi(self):
        self.cursor.execute("SELECT * FROM DoiBong")
        doi_bong = self.cursor.fetchall()

        if doi_bong:
            print("Danh sách đội bóng:")
            for db in doi_bong:
                print(f"""
Mã Đội: {db[0]}
Mã SH: {db[1]}
Tên Đội: {db[2]}
Năm Thành Lập: {db[3]}
Giá Trị: {db[4]}
""")
        else:
            print("Không có đội bóng nào trong cơ sở dữ liệu.")

class ThemDoiBong:
    def __init__(self):
        self.conn = sqlite3.connect('bongda.db')
        self.cursor = self.conn.cursor()

    def nhap_thong_tin(self):
        while True:
            self.MaDB = input("Nhập mã đội bóng (hoặc 'q' để thoát): ")
            if self.MaDB == 'q':
                break
            self.MaSH = input("Nhập mã sở hữu: ")
            self.TenDoi = input("Nhập tên đội: ")
            self.NamTL = int(input("Nhập năm thành lập: "))
            self.GiaTriDB = float(input("Nhập giá trị đội bóng: "))

            self.them_doi_bong()

    def them_doi_bong(self):
        try:
            self.cursor.execute("""
                INSERT INTO DoiBong (MaDB, MaSH, TenDoi, NamTL, GiaTriDB)
                VALUES (?, ?, ?, ?, ?)
            """, (self.MaDB, self.MaSH, self.TenDoi, self.NamTL, self.GiaTriDB))
            self.conn.commit()
            print("Thêm đội bóng thành công!")
        except sqlite3.Error as e:
            print("Lỗi khi thêm đội bóng:", e)

class XoaDoiBong:
    def __init__(self):
        self.conn = sqlite3.connect('bongda.db')
        self.cursor = self.conn.cursor()

    def xoa_doi_bong(self):
        self.hien_thi = HienThiDoiBong()
        self.hien_thi.hien_thi()
        ma_db = input("Nhập mã đội bóng để xóa (hoặc 'q' để thoát): ")
        if ma_db == 'q':
            return

        try:
            self.cursor.execute("DELETE FROM DoiBong WHERE MaDB = ?", (ma_db,))
            self.conn.commit()
            if self.cursor.rowcount > 0:
                print("Xóa đội bóng thành công!")
            else:
                print("Không tìm thấy đội bóng với mã đó.")
        except sqlite3.Error as e:
            print("Lỗi khi xóa đội bóng:", e)

class SuaDoiBong:
    def __init__(self):
        self.conn = sqlite3.connect('bongda.db')
        self.cursor = self.conn.cursor()

    def sua_doi_bong(self):
        self.hien_thi = HienThiDoiBong()
        self.hien_thi.hien_thi()
        ma_db = input("Nhập mã đội bóng để sửa (hoặc 'q' để thoát): ")
        if ma_db == 'q':
            return

        self.cursor.execute("SELECT * FROM DoiBong WHERE MaDB = ?", (ma_db,))
        doi_bong = self.cursor.fetchone()

        if doi_bong:
            # Nhận thông tin mới từ người dùng
            ma_sh_moi = input(f"Nhập mã số hữu mới (hiện tại: {doi_bong[1]}): ")
            ten_doi_moi = input(f"Nhập tên đội mới (hiện tại: {doi_bong[2]}): ")
            nam_tl_moi = int(input(f"Nhập năm thành lập mới (hiện tại: {doi_bong[3]}): "))
            gia_tri_moi = float(input(f"Nhập giá trị mới (hiện tại: {doi_bong[4]}): "))

            try:
                self.cursor.execute("""
                    UPDATE DoiBong
                    SET MaSH = ?, TenDoi = ?, NamTL = ?, GiaTriDB = ?
                    WHERE MaDB = ?
                """, (ma_sh_moi, ten_doi_moi, nam_tl_moi, gia_tri_moi, ma_db))
                self.conn.commit()
                print("Cập nhật thông tin đội bóng thành công!")
            except sqlite3.Error as e:
                print("Lỗi khi sửa thông tin đội bóng:", e)
        else:
            print("Không tìm thấy đội bóng với mã đó.")

class TimKiemCauThu:
    def __init__(self):
        self.conn = sqlite3.connect('bongda.db')
        self.cursor = self.conn.cursor()

    def tim_kiem(self):
        print("Tùy chọn tìm kiếm:")
        print("1. Tìm kiếm theo tên")
        print("2. Tìm kiếm theo vị trí")
        print("3. Tìm kiếm theo quốc tịch")
        lua_chon = input("Nhập lựa chọn của bạn: ")

        if lua_chon == '1':
            ten_cau_thu = input("Nhập tên cầu thủ: ")
            self.tim_theo_ten(ten_cau_thu)
        elif lua_chon == '2':
            vi_tri = input("Nhập vị trí: ")
            self.tim_theo_vi_tri(vi_tri)
        elif lua_chon == '3':
            quoc_tich = input("Nhập quốc tịch: ")
            self.tim_theo_quoc_tich(quoc_tich)
        else:
            print("Lựa chọn không hợp lệ.")

    def tim_theo_ten(self, ten_cau_thu):
        self.cursor.execute("SELECT * FROM CauThu WHERE TenCauThu LIKE ?", ('%' + ten_cau_thu + '%',))
        cau_thu = self.cursor.fetchall()
        self.hien_thi_ket_qua(cau_thu)

    def tim_theo_vi_tri(self, vi_tri):
        self.cursor.execute("SELECT * FROM CauThu WHERE ViTri = ?", (vi_tri,))
        cau_thu = self.cursor.fetchall()
        self.hien_thi_ket_qua(cau_thu)

    def tim_theo_quoc_tich(self, quoc_tich):
        self.cursor.execute("SELECT * FROM CauThu WHERE QuocTich = ?", (quoc_tich,))
        cau_thu = self.cursor.fetchall()
        self.hien_thi_ket_qua(cau_thu)

    def hien_thi_ket_qua(self, cau_thu):
        if cau_thu:
            print("Kết quả tìm kiếm:")
            for ct in cau_thu:
                print(f"""
Mã CT: {ct[0]}
Tên: {ct[1]}
Mã Đội: {ct[2]}
Số áo: {ct[3]}
Vị trí: {ct[4]}
Ngày sinh: {ct[5]}
Quốc tịch: {ct[6]}
Chiều cao: {ct[7]} cm
Cân nặng: {ct[8]} kg
Giá trị: {ct[9]}
""")
        else:
            print("Không tìm thấy cầu thủ nào phù hợp.")

class SapXepCauThu:
    def __init__(self):
        self.conn = sqlite3.connect('bongda.db')
        self.cursor = self.conn.cursor()

    def sap_xep(self):
        print("Tùy chọn sắp xếp:")
        print("1. Sắp xếp theo giá trị tăng dần")
        print("2. Sắp xếp theo giá trị giảm dần")
        lua_chon = input("Nhập lựa chọn của bạn: ")

        if lua_chon == '1':
            self.sap_xep_tang_dan()
        elif lua_chon == '2':
            self.sap_xep_giam_dan()
        else:
            print("Lựa chọn không hợp lệ.")

    def sap_xep_tang_dan(self):
        self.cursor.execute("SELECT * FROM CauThu ORDER BY GiaTriCT ASC")
        cau_thu = self.cursor.fetchall()
        self.hien_thi_ket_qua(cau_thu)

    def sap_xep_giam_dan(self):
        self.cursor.execute("SELECT * FROM CauThu ORDER BY GiaTriCT DESC")
        cau_thu = self.cursor.fetchall()
        self.hien_thi_ket_qua(cau_thu)

    def hien_thi_ket_qua(self, cau_thu):
        if cau_thu:
            print("Danh sách cầu thủ đã sắp xếp:")
            for ct in cau_thu:
                print(f"""
Mã CT: {ct[0]}
Tên: {ct[1]}
Mã Đội: {ct[2]}
Số áo: {ct[3]}
Vị trí: {ct[4]}
Ngày sinh: {ct[5]}
Quốc tịch: {ct[6]}
Chiều cao: {ct[7]} cm
Cân nặng: {ct[8]} kg
Giá trị: {ct[9]}
""")
        else:
            print("Không tìm thấy cầu thủ nào.")



#them_cau_thu = ThemCauThu()
#them_cau_thu.nhap_thong_tin()
#xoa_cau_thu = XoaCauThu()
#xoa_cau_thu.xoa_cau_thu()
#sua_cau_thu = SuaCauThu()
#sua_cau_thu.sua_cau_thu()

#them_doi_bong = ThemDoiBong()
#them_doi_bong.nhap_thong_tin()
#xoa_doi_bong = XoaDoiBong()
#xoa_doi_bong.xoa_doi_bong()
#sua_doi_bong = SuaDoiBong()
#sua_doi_bong.sua_doi_bong()

#tim_kiem_cau_thu = TimKiemCauThu()
#tim_kiem_cau_thu.tim_kiem()

#sap_xep_cau_thu = SapXepCauThu()
#sap_xep_cau_thu.sap_xep()