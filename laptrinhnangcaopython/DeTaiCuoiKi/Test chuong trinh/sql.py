import sqlite3

# Kết nối đến database (tạo file database nếu chưa tồn tại)
conn = sqlite3.connect('bongda.db')

# Tạo cursor
cursor = conn.cursor()

# Tạo bảng DOIBONG
cursor.execute('''
CREATE TABLE DOIBONG (
  MaDB TEXT PRIMARY KEY,
  TenDoi TEXT NOT NULL,
  NamTL INTEGER,
  GiaTriDB REAL
);
''')

# Tạo bảng CAUTHU
cursor.execute('''
CREATE TABLE CAUTHU (
  MaCT INTEGER PRIMARY KEY AUTOINCREMENT,  -- Sử dụng AUTOINCREMENT
  TenCauThu TEXT NOT NULL,
  MaDB TEXT NOT NULL,
  TenDoi TEXT,
  SoAo INTEGER,
  ViTri TEXT,
  NgaySinh DATE,
  QuocTich TEXT,
  ChieuCao REAL,
  CanNang REAL,
  GiaTriCT REAL,
  FOREIGN KEY (MaDB) REFERENCES DOIBONG(MaDB)
);
''')

# Tạo bảng CHUYENDICH
cursor.execute('''
CREATE TABLE ChuyenDich (
    MaGD INTEGER PRIMARY KEY AUTOINCREMENT,  -- Sử dụng AUTOINCREMENT
    MaCT TEXT NOT NULL,
    MaDB TEXT NOT NULL,
    TenCauThu TEXT,
    GiaTriCT REAL,
    TenDoi TEXT,
    NgayGiaoDich DATE,
    FOREIGN KEY (MaCT) REFERENCES CauThu(MaCT),
    FOREIGN KEY (MaDB) REFERENCES DoiBong(MaDB)
);
''')

# Lưu thay đổi và đóng kết nối
conn.commit()
conn.close()

print("Đã tạo cơ sở dữ liệu thành công!")