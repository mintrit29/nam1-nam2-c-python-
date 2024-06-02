--1.BDAdmin: được toàn quyền trên CSDL QLBongDa:
USE QLBONGDA;
CREATE LOGIN BDadmin WITH PASSWORD = '123';
CREATE USER BDAdmin FOR LOGIN BDAdmin;
ALTER ROLE db_owner ADD MEMBER BDAdmin;
--2.BDBK: được phép backup CSDL QLBongDa:
USE QLBONGDA;
CREATE LOGIN BDBK WITH PASSWORD= '123';
CREATE USER BDBK FOR LOGIN BDBK;
ALTER ROLE db_backupoperator ADD MEMBER BDBK;
--3.BDRead: chỉ được phép xem dữ liệu trong CSDL QLBongDa
USE QLBONGDA;
CREATE LOGIN BDRead WITH PASSWORD= '123';
CREATE USER BDRead FOR LOGIN BDRead;
GRANT SELECT TO BDRead;
--4.BD001: được phép thêm mới table
USE QLBONGDA;
CREATE LOGIN BDU01 WITH PASSWORD = '123';
CREATE USER BDU01 FOR LOGIN BDU01;
GRANT CREATE TABLE TO BDU01;
--5.BD002: được phép cập nhật các table, không được phép thêm mới hoặc xóa table
USE QLBONGDA;
CREATE LOGIN BDU02 WITH PASSWORD = '123';
CREATE USER BDU02 FOR LOGIN BDU02;
GRANT UPDATE, SELECT ON SCHEMA:: dbo TO BDU02;
DENY CREATE TABLE TO BDU02;
DENY DELETE ON SCHEMA :: dbo TO BDU02 ;
--6.BD003: chỉ được phép thao tác table Caulacbo (select, insert, delete, update),
-- không được phép thao tác các table khác.
Create login BDU03 with password = '123';
create user BDU03 from login BDU03;
grant select, insert, delete, update on dbo.CAULACBO to BDU03
--7.BDU04: chỉ được phép thao tác table CAUTHU, trong đó không được phép xem cột ngày sinh (NGAYSINH)
-- và không được phép chỉnh sửa giá trị trong cột Vị trí (VITRI), không được phép thao tác các table khác.
USE QLBONGDA;
CREATE LOGIN BDU04 WITH PASSWORD = '123';
CREATE USER BDU04 FOR LOGIN BDU04;
GRANT SELECT, INSERT, UPDATE, DELETE ON CAUTHU TO BDU04;
DENY SELECT ON CAUTHU(NGAYSINH) TO BDU04; 
DENY UPDATE ON CAUTHU(VITRI) TO BDU04;
--8.BDProfile: được phép thao tác SQL Profile
USE master;
CREATE LOGIN BDProfile WITH PASSWORD = '123';
CREATE USER BDProfile FOR LOGIN BDProfile;
GRANT ALTER TRACE TO BDProfile;

