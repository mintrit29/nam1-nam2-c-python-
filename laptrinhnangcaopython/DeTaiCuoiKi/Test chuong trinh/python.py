import sqlite3
import tkinter as tk
from tkinter import ttk, messagebox

class DoiBong:
    def __init__(self, MaDB, TenDoi, NamTL, GiaTriDB):
        self.MaDB = MaDB
        self.TenDoi = TenDoi
        self.NamTL = NamTL
        self.GiaTriDB = GiaTriDB

class CauThu:
    def __init__(self, MaCT, TenCauThu, MaDB, TenDoi, SoAo, ViTri, NgaySinh, QuocTich, ChieuCao, CanNang, GiaTriCT):
        self.MaCT = MaCT
        self.TenCauThu = TenCauThu
        self.MaDB = MaDB
        self.TenDoi = TenDoi
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
    def __init__(self, ma_db):
        self.conn = sqlite3.connect('bongda.db')
        self.cursor = self.conn.cursor()
        self.ma_db = ma_db

    def hien_thi(self):
        self.cursor.execute("SELECT * FROM CauThu WHERE MaDB = ?", (self.ma_db,))
        cau_thu = self.cursor.fetchall()

        if cau_thu:
            print("Danh sách cầu thủ:")
            for ct in cau_thu:
                print(f"""
Mã CT: {ct[0]}
Tên: {ct[1]}
Mã Đội: {ct[2]}
Tên Đội: {ct[3]}
Số áo: {ct[4]}
Vị trí: {ct[5]}
Ngày sinh: {ct[6]}
Quốc tịch: {ct[7]}
Chiều cao: {ct[8]} cm
Cân nặng: {ct[9]} kg
Giá trị: {ct[10]}
""")
        else:
            print("Không có cầu thủ nào trong cơ sở dữ liệu.")

class ThemCauThu:
    def __init__(self, ma_db, ten_db):
        self.conn = sqlite3.connect('bongda.db')
        self.cursor = self.conn.cursor()
        self.ma_db = ma_db
        self.ten_db = ten_db

    def nhap_thong_tin(self):
        while True:
            self.MaCT = input("Nhập mã cầu thủ (hoặc 'q' để thoát): ")
            if self.MaCT == 'q':
                break
            self.TenCauThu = input("Nhập tên cầu thủ: ")
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
                INSERT INTO CauThu (MaCT, TenCauThu, MaDB, TenDoi, SoAo, ViTri, NgaySinh, QuocTich, ChieuCao, CanNang, GiaTriCT)
                VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
            """, (self.MaCT, self.TenCauThu, self.ma_db, self.ten_db, self.SoAo, self.ViTri, self.NgaySinh, self.QuocTich, self.ChieuCao, self.CanNang, self.GiaTriCT))
            self.conn.commit()
            print("Thêm cầu thủ thành công!")
        except sqlite3.Error as e:
            print("Lỗi khi thêm cầu thủ:", e)

class XoaCauThu:
    def __init__(self, ma_db):
        self.conn = sqlite3.connect('bongda.db')
        self.cursor = self.conn.cursor()
        self.ma_db = ma_db

    def xoa_cau_thu(self):
        self.hien_thi = HienThiCauThu(self.ma_db)
        self.hien_thi.hien_thi()
        ma_ct = input("Nhập mã cầu thủ để xóa (hoặc 'q' để thoát): ")
        if ma_ct == 'q':
            return

        try:
            self.cursor.execute("DELETE FROM CauThu WHERE MaCT = ? AND MaDB = ?", (ma_ct, self.ma_db))
            self.conn.commit()
            if self.cursor.rowcount > 0:
                print("Xóa cầu thủ thành công!")
            else:
                print("Không tìm thấy cầu thủ với mã CT đó.")
        except sqlite3.Error as e:
            print("Lỗi khi xóa cầu thủ:", e)

class SuaCauThu:
    def __init__(self, ma_db):
        self.conn = sqlite3.connect('bongda.db')
        self.cursor = self.conn.cursor()
        self.ma_db = ma_db

    def sua_cau_thu(self):
        self.hien_thi = HienThiCauThu(self.ma_db)
        self.hien_thi.hien_thi()
        ma_ct = input("Nhập mã cầu thủ để sửa (hoặc 'q' để thoát): ")
        if ma_ct == 'q':
            return

        self.cursor.execute("SELECT * FROM CauThu WHERE MaCT = ? AND MaDB = ?", (ma_ct, self.ma_db))
        cau_thu = self.cursor.fetchone()

        if cau_thu:
            # Nhận thông tin mới từ người dùng
            ten_moi = input(f"Nhập tên mới (hiện tại: {cau_thu[1]}): ")
            so_ao_moi = int(input(f"Nhập số áo mới (hiện tại: {cau_thu[4]}): "))
            vi_tri_moi = input(f"Nhập vị trí mới (hiện tại: {cau_thu[5]}): ")
            ngay_sinh_moi = input(f"Nhập ngày sinh mới (YYYY-MM-DD, hiện tại: {cau_thu[6]}): ")
            quoc_tich_moi = input(f"Nhập quốc tịch mới (hiện tại: {cau_thu[7]}): ")
            chieu_cao_moi = float(input(f"Nhập chiều cao mới (cm, hiện tại: {cau_thu[8]}): "))
            can_nang_moi = float(input(f"Nhập cân nặng mới (kg, hiện tại: {cau_thu[9]}): "))
            gia_tri_moi = float(input(f"Nhập giá trị mới (hiện tại: {cau_thu[10]}): "))

            try:
                self.cursor.execute("""
                    UPDATE CauThu
                    SET TenCauThu = ?, SoAo = ?, ViTri = ?, NgaySinh = ?, QuocTich = ?, ChieuCao = ?, CanNang = ?, GiaTriCT = ?
                    WHERE MaCT = ? AND MaDB = ?
                """, (ten_moi, so_ao_moi, vi_tri_moi, ngay_sinh_moi, quoc_tich_moi, chieu_cao_moi, can_nang_moi, gia_tri_moi, ma_ct, self.ma_db))
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
Tên Đội: {db[1]}
Năm Thành Lập: {db[2]}
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
            self.TenDoi = input("Nhập tên đội: ")
            self.NamTL = int(input("Nhập năm thành lập: "))
            self.them_doi_bong()

    def them_doi_bong(self):
        try:
            self.cursor.execute("""
                INSERT INTO DoiBong (MaDB, TenDoi, NamTL)
                VALUES (?, ?, ?)
            """, (self.MaDB, self.TenDoi, self.NamTL))
            self.conn.commit()
            print("Thêm đội bóng thành công!")
        except sqlite3.Error as e:
            print("Lỗi khi thêm đội bóng:", e)

class XoaDoiBong:
    def __init__(self):
        self.conn = sqlite3.connect('bongda.db')
        self.cursor = self.conn.cursor()

    def xoa_doi_bong(self, ma_db):
        # Xóa cầu thủ thuộc đội bóng
        self.cursor.execute("DELETE FROM CauThu WHERE MaDB = ?", (ma_db,))
        # Xóa đội bóng
        self.cursor.execute("DELETE FROM DoiBong WHERE MaDB = ?", (ma_db,))
        self.conn.commit()

class SuaDoiBong:
    def __init__(self):
        self.conn = sqlite3.connect('bongda.db')
        self.cursor = self.conn.cursor()

    def sua_doi_bong(self, ma_db):
        self.cursor.execute("SELECT * FROM DoiBong WHERE MaDB = ?", (ma_db,))
        doi_bong = self.cursor.fetchone()
        
        if doi_bong:
            # Nhận thông tin mới từ người dùng
            ten_doi_moi = input(f"Nhập tên đội mới (hiện tại: {doi_bong[1]}): ")
            nam_tl_moi = int(input(f"Nhập năm thành lập mới (hiện tại: {doi_bong[2]}): "))

            try:
                # Cập nhật thông tin đội bóng
                self.cursor.execute("""
                    UPDATE DoiBong
                    SET TenDoi = ?, NamTL = ?
                    WHERE MaDB = ?
                """, (ten_doi_moi, nam_tl_moi, ma_db))
                self.conn.commit()
                print("Cập nhật thông tin đội bóng thành công!")

                # Cập nhật thông tin đội bóng của cầu thủ
                self.cursor.execute("""
                    UPDATE CauThu
                    SET TenDoi = ?
                    WHERE MaDB = ?
                """, (ten_doi_moi, ma_db))
                self.conn.commit()
                print("Cập nhật thông tin đội bóng của cầu thủ thành công!")

            except sqlite3.Error as e:
                print("Lỗi khi sửa thông tin đội bóng:", e)
        else:
            print("Không tìm thấy đội bóng với mã đó.")

def tinh_tong_gia_tri_doi_bong(ma_db):
    conn = sqlite3.connect('bongda.db')
    cursor = conn.cursor()
    cursor.execute("SELECT SUM(GiaTriCT) FROM CauThu WHERE MaDB = ?", (ma_db,))
    tong_gia_tri = cursor.fetchone()[0]
    conn.close()
    return tong_gia_tri if tong_gia_tri is not None else 0  # Tránh trường hợp None

class TimKiemCauThu:
    def __init__(self, ma_db):
        self.conn = sqlite3.connect('bongda.db')
        self.cursor = self.conn.cursor()
        self.ma_db = ma_db

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
        self.cursor.execute("SELECT * FROM CauThu WHERE TenCauThu LIKE ? AND MaDB = ?", ('%' + ten_cau_thu + '%', self.ma_db))
        cau_thu = self.cursor.fetchall()
        self.hien_thi_ket_qua(cau_thu)

    def tim_theo_vi_tri(self, vi_tri):
        self.cursor.execute("SELECT * FROM CauThu WHERE ViTri = ? AND MaDB = ?", (vi_tri, self.ma_db))
        cau_thu = self.cursor.fetchall()
        self.hien_thi_ket_qua(cau_thu)

    def tim_theo_quoc_tich(self, quoc_tich):
        self.cursor.execute("SELECT * FROM CauThu WHERE QuocTich = ? AND MaDB = ?", (quoc_tich, self.ma_db))
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
Tên Đội: {ct[3]}
Số áo: {ct[4]}
Vị trí: {ct[5]}
Ngày sinh: {ct[6]}
Quốc tịch: {ct[7]}
Chiều cao: {ct[8]} cm
Cân nặng: {ct[9]} kg
Giá trị: {ct[10]}
""")
        else:
            print("Không tìm thấy cầu thủ nào phù hợp.")

class SapXepCauThu:
    def __init__(self, ma_db):
        self.conn = sqlite3.connect('bongda.db')
        self.cursor = self.conn.cursor()
        self.ma_db = ma_db

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
        self.cursor.execute("SELECT * FROM CauThu WHERE MaDB = ? ORDER BY GiaTriCT ASC", (self.ma_db,))
        cau_thu = self.cursor.fetchall()
        self.hien_thi_ket_qua(cau_thu)

    def sap_xep_giam_dan(self):
        self.cursor.execute("SELECT * FROM CauThu WHERE MaDB = ? ORDER BY GiaTriCT DESC", (self.ma_db,))
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
Tên Đội: {ct[3]}
Số áo: {ct[4]}
Vị trí: {ct[5]}
Ngày sinh: {ct[6]}
Quốc tịch: {ct[7]}
Chiều cao: {ct[8]} cm
Cân nặng: {ct[9]} kg
Giá trị: {ct[10]}
""")
        else:
            print("Không tìm thấy cầu thủ nào.")

def chuyen_nhuong_cau_thu(ma_db_hien_tai):
    conn = sqlite3.connect('bongda.db')
    cursor = conn.cursor()

    hien_thi_doi_bong = HienThiDoiBong()
    hien_thi_doi_bong.hien_thi()

    while True:
        ma_db_muon_chuyen = input(f"Nhập mã đội bóng muốn chuyển nhượng (hoặc 'q' để thoát): ")
        if ma_db_muon_chuyen == 'q':
            return

        if ma_db_muon_chuyen == ma_db_hien_tai:
            print("Không thể chuyển nhượng đến cùng một đội bóng!")
            continue

        cursor.execute("SELECT TenDoi FROM DoiBong WHERE MaDB = ?", (ma_db_muon_chuyen,))
        ten_db_muon_chuyen = cursor.fetchone()

        if ten_db_muon_chuyen:
            ten_db_muon_chuyen = ten_db_muon_chuyen[0]
            break
        else:
            print("Không tìm thấy đội bóng với mã đó.")

    hien_thi_cau_thu = HienThiCauThu(ma_db_hien_tai)
    hien_thi_cau_thu.hien_thi()

    while True:
        ma_ct = input("Nhập mã cầu thủ muốn chuyển nhượng (hoặc 'q' để thoát): ")
        if ma_ct == 'q':
            return

        cursor.execute("SELECT TenCauThu, GiaTriCT FROM CauThu WHERE MaCT = ? AND MaDB = ?", (ma_ct, ma_db_hien_tai))
        cau_thu = cursor.fetchone()

        if cau_thu:
            ten_cau_thu, gia_tri_ct = cau_thu
            break
        else:
            print("Không tìm thấy cầu thủ với mã đó trong đội bóng.")

    thoi_gian = datetime.datetime.now().strftime("%H:%M:%S")
    ngay_thang_nam = datetime.datetime.now().strftime("%d/%m/%Y")

    try:
        # Chuyển nhượng cầu thủ
        cursor.execute("""
            UPDATE CauThu
            SET MaDB = ?, TenDoi = ?
            WHERE MaCT = ?
        """, (ma_db_muon_chuyen, ten_db_muon_chuyen, ma_ct))
        conn.commit()

        # Lưu lịch sử chuyển nhượng
        cursor.execute("""
            INSERT INTO ChuyenDich (MaGD, MaCT, MaDB, TenCauThu, GiaTriCT, TenDoi, NgayGiaoDich)
            VALUES (?, ?, ?, ?, ?, ?, ?)
        """, (None, ma_ct, ma_db_hien_tai, ten_cau_thu, gia_tri_ct, ten_db_muon_chuyen, ngay_thang_nam))
        conn.commit()

        # Hiển thị thông báo cho bên chuyển nhượng
        print(f"Chuyển nhượng thành công:\n{thoi_gian} | {ngay_thang_nam} | {ten_cau_thu} | {gia_tri_ct} | Từ đội bóng {ten_db} đến đội bóng {ten_db_muon_chuyen}")

        # Hiển thị thông báo cho bên nhận chuyển nhượng
        cursor.execute("SELECT TenDoi FROM DoiBong WHERE MaDB = ?", (ma_db_muon_chuyen,))
        ten_db_moi = cursor.fetchone()[0]
        print(f"Nhận cầu thủ thành công:\n{thoi_gian} | {ngay_thang_nam} | {ten_cau_thu} | {gia_tri_ct} | Từ đội bóng {ten_db} đến đội bóng {ten_db_moi}")

    except sqlite3.Error as e:
        print("Lỗi khi chuyển nhượng:", e)

    conn.close()

def xem_lich_su_chuyen_nhuong():
    conn = sqlite3.connect('bongda.db')
    cursor = conn.cursor()
    cursor.execute("SELECT * FROM ChuyenDich")
    lich_su = cursor.fetchall()

    if lich_su:
        print("Lịch sử chuyển nhượng:")
        for gd in lich_su:
            print(f"""
{gd[5]} | {gd[6]} | {gd[3]} | {gd[4]} | Từ đội bóng {gd[5]} đến đội bóng {gd[4]}
""")
    else:
        print("Không có lịch sử chuyển nhượng.")
    conn.close()

def menu():
    conn = sqlite3.connect('bongda.db')
    cursor = conn.cursor()

    while True:
        print("\nChọn chức năng:")
        print("1. Tạo đội bóng mới")
        print("2. Vào đội bóng đã có")
        print("3. Xóa đội bóng")
        print("4. Sửa đội bóng")
        print("5. Thoát")
        lua_chon = input("Nhập lựa chọn của bạn: ")

        if lua_chon == '1':
            them_doi_bong = ThemDoiBong()
            them_doi_bong.nhap_thong_tin()
            conn.commit()
            # conn.close()  # Không đóng kết nối ở đây
        elif lua_chon == '2':
            hien_thi_doi_bong = HienThiDoiBong()
            hien_thi_doi_bong.hien_thi()
            ma_db = input("Nhập mã đội bóng để vào: ")
            cursor.execute("SELECT TenDoi FROM DoiBong WHERE MaDB = ?", (ma_db,))
            ten_db = cursor.fetchone()
            if ten_db:
                ten_db = ten_db[0]
                while True:
                    print("\nChọn chức năng:")
                    print("1. Thêm cầu thủ")
                    print("2. Xóa cầu thủ")
                    print("3. Sửa cầu thủ")
                    print("4. Hiển thị cầu thủ")
                    print("5. Tìm kiếm cầu thủ")
                    print("6. Sắp xếp cầu thủ")
                    print("7. Xem tổng giá trị đội bóng")
                    print("8. Chuyển nhượng cầu thủ")
                    print("9. Xem lịch sử chuyển nhượng")
                    print("10. Quay lại menu chính")
                    lua_chon = input("Nhập lựa chọn của bạn: ")

                    if lua_chon == '1':
                        them_cau_thu = ThemCauThu(ma_db, ten_db)
                        them_cau_thu.nhap_thong_tin()
                    elif lua_chon == '2':
                        xoa_cau_thu = XoaCauThu(ma_db)
                        xoa_cau_thu.xoa_cau_thu()
                    elif lua_chon == '3':
                        sua_cau_thu = SuaCauThu(ma_db)
                        sua_cau_thu.sua_cau_thu()
                    elif lua_chon == '4':
                        hien_thi_cau_thu = HienThiCauThu(ma_db)
                        hien_thi_cau_thu.hien_thi()
                    elif lua_chon == '5':
                        tim_kiem_cau_thu = TimKiemCauThu(ma_db)
                        tim_kiem_cau_thu.tim_kiem()
                    elif lua_chon == '6':
                        sap_xep_cau_thu = SapXepCauThu(ma_db)
                        sap_xep_cau_thu.sap_xep()
                    elif lua_chon == '7':
                        tong_gia_tri = tinh_tong_gia_tri_doi_bong(ma_db)
                        print(f"Tổng giá trị đội bóng: {tong_gia_tri}")
                    elif lua_chon == '8':  # Chuyển nhượng cầu thủ
                        chuyen_nhuong_cau_thu(ma_db)
                    elif lua_chon == '9':  # Xem lịch sử chuyển nhượng
                        xem_lich_su_chuyen_nhuong()
                    elif lua_chon == '10':
                        break
                    else:
                        print("Lựa chọn không hợp lệ.")
            else:
                print("Không tìm thấy đội bóng với mã đó.")
        elif lua_chon == '3':
            hien_thi_doi_bong = HienThiDoiBong()
            hien_thi_doi_bong.hien_thi()
            ma_db = input("Nhập mã đội bóng để xóa (hoặc 'q' để thoát): ")
            if ma_db == 'q':
                continue
            xoa_doi_bong = XoaDoiBong()
            xoa_doi_bong.xoa_doi_bong(ma_db)
        elif lua_chon == '4':
            hien_thi_doi_bong = HienThiDoiBong()
            hien_thi_doi_bong.hien_thi()
            ma_db = input("Nhập mã đội bóng để sửa (hoặc 'q' để thoát): ")
            if ma_db == 'q':
                continue
            sua_doi_bong = SuaDoiBong()
            sua_doi_bong.sua_doi_bong(ma_db)
        elif lua_chon == '5':
            break
        else:
            print("Lựa chọn không hợp lệ.")
    
    conn.close()

menu()