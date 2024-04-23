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
mahv = "22BITV03"
hoten = "Tống Minh Triết"
dienthoai = "0921049048"
email = "tongminhtriet@gmail.com"
ngaysinh = "2004-10-29"

sql = f"""
INSERT INTO HocVien(MaHV,HoTen,NgaySinh,DienThoai,Email)
VALUES('{mahv}',{hoten}','{ngaysinh}','{dienthoai}',{email}')
"""
#print(sql)
conn.execute(sql)

conn.commit()
conn.close()
