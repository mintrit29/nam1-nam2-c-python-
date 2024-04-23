import sqlite3

conn = sqlite3.connect("MyDB.db")
cur = conn.cursor()
#cur.execute('''CREATE TABLE HocVien
#(
    #MaHV text PRIMARY KEY,
    #HoTen text,
    #DienThoai text,
    #NgaySinh date,
    #Email text
#)
#''')

#Demo them du lieu
mahv = "22BITV02"
hoten = "Tống Minh Triet "
dienthoai = "0949048290"
email = "tongminht@gmail.com"
ngaysinh = "2004-10-29"

sql = f"""
INSERT INTO HocVien(MaHV,HoTen,NgaySinh,DienThoai,Email)
VALUES('{mahv}','{hoten}','{ngaysinh}','{dienthoai}','{email}')
"""
print(sql)
conn.execute(sql)

conn.commit()
conn.close()
