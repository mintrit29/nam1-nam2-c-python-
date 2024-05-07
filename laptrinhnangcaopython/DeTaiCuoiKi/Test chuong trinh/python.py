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

# Thêm các phương thức cho mỗi lớp để thao tác với cơ sở dữ liệu (ví dụ: thêm, xóa, sửa, tìm kiếm)
# ...