--2.1
alter table VATNUOI add
constraint VN_TG_SinhTruong check (TG_SinhTTruong>60)
--2.2
alter table VatNuoi add LoaiVatNuoi Varchar(25)

alter table VATNUOI add
constraint VN_LoaiVatNuoi check (LoaiVatNuoi in ('Gia suc','Gia cam','Ca','Loai khac'))
--3.1
select NT.TenNongTrai,NH.TenNongHo,NT.DienTich
from NONGTRAI NT, VATNUOI VN , NONGHO NH,CHANNUOI CN
where NT.MaNongHo=NH.MaNongHo and CN.MaNongTrai=NT.MaNongTrai and CN.MaVatNuoi=VN.MaVatNuoi and TenVatNuoi =N'Cá diêu hồng'and DienTich>1000
--3.2
select VN.MaVatNuoi,TenVatNuoi,VN.LoaiVatNuoi,NgayBD
from VATNUOI VN, CHANNUOI CN
where VN.MaVatNuoi=CN.MaVatNuoi and year(NgayBD) between 2019 and 2020 and year(NgayBD) <> 2021
--3.3
select NT.MaNongTrai,TenNongTrai,sum(SanLuong) as TongSanLuong
from NONGTRAI NT,CHANNUOI CN,NONGHO NH
where NT.MaNongHo=NH.MaNongHo and NT.MaNongTrai = CN.MaNongTrai and TenNongHo like N'Nguyễn Anh Tuấn' and year(NgayTH) = 2021
group by NT.MaNongTrai,TenNongTrai
--3.4
select NT.MaNongTrai,TenNongTrai
from NONGTRAI NT,CHANNUOI CN,NONGHO NH
where NT.MaNongTrai=CN.MaNongTrai and NH.MaNongHo=NT.MaNongHo
and TenNongHo like N'Nguyễn Anh Tuấn' and year(NgayBD) not between 1/10/2021 and 30/11/2021