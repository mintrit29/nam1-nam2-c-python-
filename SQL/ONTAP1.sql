use ONTAP1
--1 Truy vấn đơn giản
--1.1
select MAMH,TENMH,SOTIET
from DMMH
--1.2
select MAMH,TENMH,SOTIET
from DMMH
where TENMH like N'T%'
--1.3
select HOSV,TENSV,NGAYSINH,PHAI
from DMSV
where TENSV like N'%I'
--1.4
select MAKHOA,TENKHOA
from DMKHOA
where TENKHOA like N'_N%'
--1.5
select * 
from DMSV
where HOSV like N'%Thị%'
--1.6
select MASV,HOSV,TENSV,PHAI,HOCBONG
from DMSV
where TENSV like N'[a-m]%'
--1.7
select K.MAKHOA,SV.NOISINH,SV.HOCBONG
from DMKHOA K,DMSV SV
where K.MAKHOA = SV.MAKHOA and HOCBONG >= 150000 and NOISINH = N'Hà Nội'
--1.8
select MASV,K.MAKHOA,PHAI
from DMSV SV, DMKHOA K
where SV.MAKHOA = K.MAKHOA and (K.MAKHOA = N'AV' or K.MAKHOA = N'VL')
--1.9
select MASV,NGAYSINH,NOISINH,HOCBONG
from DMSV SV
where NGAYSINH between '01/01/1992' and '05/06/1993'
--1.10
select MASV,NGAYSINH,PHAI,K.MAKHOA
from DMSV SV, DMKHOA K
where SV.MAKHOA = K.MAKHOA and HOCBONG between '50000' and '80000'
--1.11
select MAMH,TENMH,SOTIET
from DMMH
where SOTIET between '30' and '45'
--1.12
select MASV,HOSV,TENSV,TENKHOA,PHAI
from DMSV SV, DMKHOA K
where SV.MAKHOA = K.MAKHOA and (K.MAKHOA = N'AV' or K.MAKHOA = N'TH') and PHAI ='False'
--1.13
select SV.MASV,HOSV,TENSV,PHAI,DIEM
from DMSV SV,KETQUA KQ,DMMH MH
where SV.MASV = KQ.MASV and KQ.MAMH = MH.MAMH and TENMH = N'Cơ sở dữ liệu' and DIEM < 5
--1.14
select SV.MASV,HOSV,TENSV,TENKHOA,NOISINH,HOCBONG
from DMSV SV, DMKHOA K
where SV.MAKHOA = K.MAKHOA and TENKHOA = N'Anh Văn' and HOCBONG = 0

--2 Sắp xếp (Order by)
--2.1
select HOSV,TENSV,NGAYSINH,NOISINH
from DMSV
order by TENSV ASC
--2.2
select HOSV,TENSV,NGAYSINH,NOISINH
from DMSV
where TENSV like N'[%[a-m]%'
order by TENSV ASC
--2.3
select MASV,HOSV,TENSV,HOCBONG
from DMSV
order by MASV ASC
--2.4
select HOSV,TENSV,NGAYSINH,HOCBONG
from DMSV
order by NGAYSINH ASC, HOCBONG DESC
--2.5
select MASV,HOSV,TENSV,K.MAKHOA,HOCBONG
from DMSV SV,DMKHOA K
where SV.MAKHOA = K.MAKHOA and HOCBONG > '100000'
order by MAKHOA DESC

--Truy vấn sử dụng hàm YEAR,MONTH,DAY...
--1.1
select HOSV,TENSV,NOISINH,NGAYSINH
from DMSV
where NOISINH like N'Hà Nội' and MONTH(NGAYSINH) = 2
--1.2
select HOSV,TENSV,YEAR(GETDATE()) - YEAR(NGAYSINH) AS TUOI,HOCBONG 
from DMSV
where YEAR(GETDATE()) - YEAR(NgaySinh) > 20
--1.3
select HOSV,TENSV,YEAR(GETDATE()) - YEAR(NGAYSINH) AS TUOI,TENKHOA
from DMSV SV,DMKHOA K
where SV.MAKHOA = K.MAKHOA and YEAR(GETDATE()) - YEAR(NGAYSINH) between 20 and 25
--2.1
select MASV,PHAI,MAKHOA,MUCHOCBONG=
case
when HOCBONG > 150000 then 'Hoc bong cao'
else 'Muc trung binh'
end
from DMSV
--2.2
select HOSV,TENSV,MAMH,LANTHI,DIEM,KETQUATHI=
case
when DIEM < 5 then 'Rot'
else 'Dau'
end
from DMSV SV, KETQUA KQ
where SV.MASV = KQ.MASV 
--3.1
select count(*) AS SL_SV
from DMSV
--3.2
select count(*) AS SL_SV,
count(case
when PHAI ='1' then 1
else NULL
end) as SL_NU
from DMSV
--3.3
select SV.MAKHOA,TENKHOA,count(MASV) AS SL_SV
from DMSV SV, DMKHOA K
where SV.MAKHOA = K.MAKHOA
group by SV.MAKHOA,TENKHOA
--3.4
select MH.MAMH,TENMH,count(distinct SV.MASV) AS SL_SV
from DMSV SV, DMMH MH, KETQUA KQ
where SV.MASV = KQ.MASV and MH.MAMH = KQ.MAMH
group by MH.MAMH,TENMH
--3.5
select SV.MASV,TENSV, count(MH.MAMH) as SL_MH
from DMSV SV, DMMH MH, KETQUA KQ
where SV.MASV = KQ.MASV and MH.MAMH = KQ.MAMH
group by SV.MASV,TENSV
--3.6
select K.MAKHOA,TENKHOA, max(HOCBONG) AS HB_CAONHAT
from DMSV SV,DMKHOA K
where SV.MAKHOA = K.MAKHOA
group by K.MAKHOA,TENKHOA
--3.7
select K.MAKHOA,TENKHOA,
sum(case
when PHAI = 0 Then 1
else 0
end) AS TONG_NAM,
sum(case 
when PHAI = 1 then 1
else 0
end) AS TONG_NU
from DMSV SV, DMKHOA K
where SV.MAKHOA = K.MAKHOA
group by K.MAKHOA,TENKHOA
--3.8
select year(getdate()) - year(NGAYSINH) as TUOI, count(year(getdate()) - year(NGAYSINH)) AS SL_SV
from DMSV
group by year(getdate()) - year(NGAYSINH)
--3.9
select LANTHI,TENMH,
sum(case
when DIEM > 5 then 1
else 0
end) AS SVDAU,
sum(case
when DIEM < 5 then 1
else 0
end) AS SVROT
from KETQUA KQ, DMMH MH
where KQ.MAMH = MH.MAMH and LANTHI = 1
group by LANTHI,TENMH
--4.1
select year(NGAYSINH) AS NAMSINH,count(MASV) AS SL_SV
from DMSV
group by year(NGAYSINH)
having count(MASV) = 2
--4.3
select MH.MAMH,TENMH,count(distinct MASV) AS SL_SV
from DMMH MH, KETQUA KQ
where MH.MAMH = KQ.MAMH
group by MH.MAMH,TENMH
having count(MASV)>3
--4.4
select SV.MASV,TENSV,COUNT(DISTINCT LANTHI) AS SLTHILAI
from DMSV SV,KETQUA KQ
where SV.MASV = KQ.MASV
group by SV.MASV,TENSV
having COUNT(DISTINCT LANTHI) > 2
