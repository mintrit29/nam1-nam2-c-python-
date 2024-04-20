USE QLDIEM
--1.1. Liệt kê danh sách các môn học gồm các thông tin: Mã môn, Tên môn,Số tiết
SELECT MAMH,TENMH,SOTIET
FROM DMMH
--1.2. Liệt kê danh sách các môn học có tên bắt đầu bằng chữ “T”, gồm các thông tin: Mã môn, Tên môn, Số tiết
SELECT MAMH,TENMH,SOTIET
FROM DMMH
WHERE TENMH LIKE 'T%'
--1.3. Liệt kê danh sách những sinh viên có chữ cái cuối cùng trong tên là I,gồm các thông tin: Họ tên sinh viên, Ngày sinh, Phái
SELECT HOSV,TENSV,NGAYSINH,PHAI
FROM DMSV
WHERE TENSV LIKE '%I'
--1.4. Danh sách những khoa có ký tự thứ hai của tên khoa có chứa chữ N,gồm các thông tin: Mã khoa, Tên khoa
SELECT MAKHOA,TENKHOA
FROM DMKHOA
WHERE TENKHOA LIKE '_N%'
--1.5. Liệt kê những sinh viên mà họ có chứa chữ Thị
SELECT *
FROM DMSV
WHERE HOSV LIKE N'%Thị%'
--1.6. Cho biết danh sách những sinh viên có ký tự đầu tiên của tên nằm trong khoảng từ a đến m, gồm các thông tin: Mã sinh viên, Họ tên sinh viên, Phái, Học bổng
SELECT MASV,HOSV,TENSV,PHAI,HOCBONG
FROM DMSV
WHERE TENSV LIKE '[a-m]%'
--1.7. Liệt kê các sinh viên có học bổng từ 150000 trở lên và sinh ở Hà Nội,gồm các thông tin: Họ tên sinh viên, Mã khoa, Nơi sinh, Học bổng.
SELECT HOSV,TENSV,MAKHOA,NOISINH,HOCBONG
FROM DMSV
WHERE HOCBONG > 150000 AND NOISINH = N'Hà Nội'
--1.8. Danh sách các sinh viên của khoa AV văn và khoa VL, gồm các thông tin: Mã sinh viên, Mã khoa, Phái
SELECT MASV,MAKHOA,PHAI
FROM DMSV
WHERE MAKHOA = 'AV' OR MAKHOA ='VL'
--1.9. Cho biết những sinh viên có ngày sinh từ ngày 01/01/1992 đến ngày 05/06/1993 gồm các thông tin: Mã sinh viên, Ngày sinh, Nơi sinh, Học bổng.
SELECT MASV,NGAYSINH,NOISINH,HOCBONG
FROM DMSV
WHERE NGAYSINH between '01/01/1992' and '05/06/1993'
--1.10. Danh sách những sinh viên có học bổng từ 80.000 đến 50.000, gồm các thông tin: Mã sinh viên, Ngày sinh, Phái, Mã khoa.
SELECT MASV,NGAYSINH,PHAI,MAKHOA
FROM DMSV
WHERE HOCBONG <= 150000 AND HOCBONG >=80000
--1.11. Cho biết những môn học có số tiết lớn hơn 30 và nhỏ hơn 45, gồm các thông tin: Mã môn học, Tên môn học, Số tiết
SELECT MAMH,TENMH,SOTIET
FROM DMMH
WHERE SOTIET > 30 AND SOTIET < 45
--1.12. Liệt kê những sinh viên nam của khoa Anh văn và khoa tin học, gồm các thông tin: Mã sinh viên, Họ tên sinh viên, tên khoa, Phái
SELECT DMSV.MASV,DMSV.HOSV,DMSV.TENSV,DMKHOA.TENKHOA,DMSV.PHAI
FROM DMKHOA inner join DMSV on DMKHOA.MAKHOA=DMSV.MAKHOA
WHERE DMSV.PHAI = '0' AND (TENKHOA = N'Tin Học' OR TENKHOA = N'Anh Văn')
--1.13. Liệt kê những sinh viên có điểm thi môn sơ sở dữ liệu nhỏ hơn 5,gồm thông tin: Mã sinh viên, Họ tên, phái, điểm
SELECT DMSV.MASV,DMSV.HOSV,DMSV.TENSV,DMSV.PHAI,KETQUA.DIEM
FROM KETQUA inner join DMSV on KETQUA.MASV=DMSV.MASV
WHERE DIEM < 5
--1.14. Liệt kê những sinh viên học khoa Anh văn mà không có học bổng gồm thông tin: Mã sinh viên, Họ và tên, tên khoa, Nơi sinh, Học bổng
SELECT DMSV.MASV,DMSV.HOSV,DMSV.TENSV,DMKHOA.TENKHOA,DMSV.NOISINH,DMSV.HOCBONG
FROM DMKHOA inner join DMSV on DMKHOA.MAKHOA=DMSV.MAKHOA
WHERE DMKHOA.TENKHOA = N'Anh Văn' AND DMSV.HOCBONG = '0'