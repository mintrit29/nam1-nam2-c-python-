use QLKSAN

--1.1 Lấy khách hàng có cùng ngày đặt phòng với bà 'Nguyễn Thị Hương'
SELECT *
FROM KHACHHANG KH
JOIN PHONG P ON KH.MaKH = P.MaKH
WHERE DAY(P.NgayDat) = (
    SELECT DAY(P1.NgayDat)
    FROM KHACHHANG KH1
    JOIN PHONG P1 ON KH1.MaKH = P1.MaKH
    WHERE KH1.HoTen = N'Nguyễn Thị Hương'
)
--1.2 In ra danh sách khách hàng có sử dụng dịch vụ và ngày thanh toán vào 2023-06-28
SELECT *
FROM KHACHHANG KH, HOADON HD, SUDUNGDV SD
WHERE KH.MaKH = SD.MaKH AND KH.MaKH = HD.MaKH AND NgayTT = '2023-06-28' AND SuDung = 'True'
--2.1 Truy vấn khách hàng sử dụng phương thức thanh toán thẻ tín dụng
SELECT KH.MaKH, KH.HoTen, COUNT(HD.MaHD) AS SoLuongHD
FROM KHACHHANG KH
JOIN HOADON HD ON KH.MaKH = HD.MaKH
WHERE HD.PTTT = N'Thẻ tín dụng'
GROUP BY KH.MaKH, KH.HoTen
--2.2 
SELECT 
    P.LoaiPHG,
    COUNT(DISTINCT P.MaKH) AS SOLUONGKHACHHANGDATPHONG
FROM 
    PHONG P
GROUP BY 
    P.LoaiPHG;

--3 Tìm hóa đơn của tất cả các phòng có khách đến từ Việt Nam
SELECT HOADON.*
FROM HOADON
WHERE EXISTS (
    SELECT 1
    FROM KHACHHANG
    WHERE KHACHHANG.MaKH = HOADON.MaKH
    AND KHACHHANG.QuocTich = 'VN'
) AND EXISTS (
    SELECT 1
    FROM PHONG
    WHERE PHONG.MaKH = HOADON.MaKH
    AND EXISTS (
        SELECT 1
        FROM KHACHHANG
        WHERE KHACHHANG.MaKH = HOADON.MaKH
        AND KHACHHANG.QuocTich = 'VN'
    )
)
--Vấn đề 2
--2.1 Năm sinh của nhân viên không được nhỏ hơn 2006
ALTER TABLE NHANVIEN
ADD CONSTRAINT CHK_NgaySinh CHECK (YEAR(NgaySinh) <= 2006);
--2.2 Giá đặt cọc phải nhỏ hơn giá phòng
ALTER TABLE PHONG
ADD CONSTRAINT CHK_GiaDatCoc CHECK (GiaDatCoc < GiaPHG)





