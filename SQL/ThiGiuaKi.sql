use QLXE
--2.1
alter table LOAIXE add constraint LX_TaiTrongXe check (TaiTrongXe <= 30)
--2.2
alter table BANGLAI add constraint BL_LoaiGPLX check (LoaiGPLX in('B1','B2','C','D','E','F'));
--3.1
select BienSo,TenLoaiXe
from LOAIXE LX,XETAI XT
where LX.MaLoaiXe = XT.MaLoaiXe and TaiTrongXe > 10
--3.2
select TenLoaiXe,NhaSX,year(NgayMua) As NamSX
from XETAI XT,LOAIXE LX
where XT.MaLoaiXe = LX.MaLoaiXe and NhaSX like N'HyunDai' and year(NgayMua) = 2021
--3.3
select TX.MaTaiXe,TX.HoTenTaiXe, count(MaBangLai) AS SL_BANGLAI
from TAIXE TX,BANGLAI BL
where TX.MaTaiXe = BL.MaTaiXe
group by TX.MaTaiXe,TX.HoTenTaiXe
having count(MaBangLai) > 3
order by count(MaBangLai) DESC