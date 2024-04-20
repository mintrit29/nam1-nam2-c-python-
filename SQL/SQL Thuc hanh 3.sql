use QLCHANNUOI
--2.1 Thời gian sinh trưởng của vật nuôi tối thiểu là 60 ngày
alter table VatNuoi 
add constraint VN_TG_SinhTruong check(TG_SinhTruong>= 60);
--2.2 Loại vật nuôi gồm các vụ mùa sau (“Gia súc”, “Gia cầm”, “Cá”, “Loại khác”)
alter table VatNuoi add LoaiVatNuoi Varchar(25) Not null

alter table VatNuoi 
add constraint VN_LoaiVatNuoi 
check (LoaiVatNuoi IN ('Gia suc', 'Gia cam', 'Ca', 'Loai khac'));

--3.1Liệt kê danh sách nông trại và nông hộ sở hữu nông trại (TenNongTrai,TenNongHo) nuôi “Cá diêu hồng”, các nông trại phải có diện tích hơn 1.000 mét vuông
select TenNongTrai,TenNongHo
from NONGTRAI NT
join NONGHO NH on NH.MaNongHo = NT.MaNongHo
join CHANNUOI CN on CN.MaNongTrai = NT.MaNongTrai
join VATNUOI VN on VN.MaVatNuoi = CN.MaVatNuoi
where TenVatNuoi = 'Cá diêu hồng' and DienTich > 1000
--3.2Tìm những vật nuôi (MaVatNuoi,TenVatNuoi,LoaiVatNuoi) được nuôi trong năm2019, 2020 nhưng không ai nuôi trong năm 2021 (Căn cứ NgayBD)
select VN.MaVatNuoi,TenVatNuoi,LoaiVatNuoi
from VATNUOI VN
join CHANNUOI CN on CN.MaVatNuoi = VN.MaVatNuoi
where year(CN.NgayBD) between 2019 and 2020 and year(CN.NgayBD) <> 2021
--3.3Thống kê tổng sản lượng tất cả vật nuôi theo từng nông trại của nông hộ “Nguyễn Anh Tuấn” thu hoạch trong năm 2021 (theo NgayTH) thông tin cần hiển thị (MaNongTrai,TenNongTrai, TongSanLuong)
select CN.MaNongTrai,TenNongTrai,sum(SanLuong) as TongSanLuong
from CHANNUOI CN
join NONGTRAI NT on NT.MaNongTrai = CN.MaNongTrai
join NONGHO NH on NH.MaNongHo = NT.MaNongHo
where TenNongHo = N'Nguyễn Anh Tuấn' and year(NgayTH) = 2021
group by CN.MaNongTrai, TenNongTrai
--3.4Tìm những nông trại (MaNongTrai,TenNongTrai) của nông hộ “Nguyễn Anh Tuấn”để trống trong thời gian từ tháng 10/2021 đến 11/2021
select NT.MaNongTrai,TenNongTrai
from NONGTRAI NT
join CHANNUOI CN on CN.MaNongTrai = NT.MaNongTrai
join NONGHO NH on NH.MaNongHo = NT.MaNongHo
where TenNongHo = N'Nguyễn Anh Tuấn' and CN.MaNongTrai not in (select CN.MaNongTrai from CHANNUOI where NgayBD between '2021-10-01' and '2021-11-30')