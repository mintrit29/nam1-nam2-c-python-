import sqlite3

# Kết nối đến database (tạo file database nếu chưa tồn tại)
conn = sqlite3.connect('bongda.db')

# Tạo cursor
cursor = conn.cursor()

# Tạo bảng DOIBONG
cursor.execute('''
CREATE TABLE DOIBONG (
    MaDB INTEGER PRIMARY KEY,
    MaSH INTEGER,
    TenDoi TEXT NOT NULL,
    NamTL INTEGER,
    GiaTriDB REAL,
    FOREIGN KEY (MaSH) REFERENCES CHUSOHUU(MaSH)
)
''')

# Tạo bảng CHUSOHUU
cursor.execute('''
CREATE TABLE CHUSOHUU (
    MaSH INTEGER PRIMARY KEY,
    HoTen TEXT NOT NULL,
    Email TEXT UNIQUE,
    NganSach REAL
)
''')

# Tạo bảng CAUTHU
cursor.execute('''
CREATE TABLE CAUTHU (
    MaCT INTEGER PRIMARY KEY,
    TenCauThu TEXT NOT NULL,
    MaDB INTEGER,
    SoAo INTEGER,
    ViTri TEXT,
    NgaySinh DATE,
    QuocTich TEXT,
    ChieuCao REAL,
    CanNang REAL,
    GiaTriCT REAL,
    FOREIGN KEY (MaDB) REFERENCES DOIBONG(MaDB)
)
''')

# Tạo bảng CHUYENDICH
cursor.execute('''
CREATE TABLE CHUYENDICH (
    MaGD INTEGER PRIMARY KEY,
    MaCT INTEGER,
    MaDB INTEGER,
    LichSu TEXT,
    FOREIGN KEY (MaCT) REFERENCES CAUTHU(MaCT),
    FOREIGN KEY (MaDB) REFERENCES DOIBONG(MaDB)
)
''')

# Lưu thay đổi và đóng kết nối
conn.commit()
conn.close()

print("Đã tạo cơ sở dữ liệu thành công!")