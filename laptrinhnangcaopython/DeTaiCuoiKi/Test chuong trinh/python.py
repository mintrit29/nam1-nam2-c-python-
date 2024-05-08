import sqlite3

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

#them_cau_thu = ThemCauThu()
#them_cau_thu.nhap_thong_tin()
#xoa_cau_thu = XoaCauThu()
#xoa_cau_thu.xoa_cau_thu()
#sua_cau_thu = SuaCauThu()
#sua_cau_thu.sua_cau_thu()
