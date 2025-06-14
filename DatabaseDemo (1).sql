CREATE DATABASE Demo
go
USE Demo
go
--Bảng phân quyền đã định nghĩa 2 quyền
CREATE TABLE PhanQuyen(
	PhanQuyenID INT IDENTITY PRIMARY KEY,
	TenPhanQuyen NVARCHAR(10) NOT NULL UNIQUE,
	MoTa NVARCHAR(50)
)
insert PhanQuyen(TenPhanQuyen,MoTa) values(N'Admin',N'Toàn quyền phần mềm')
insert PhanQuyen(TenPhanQuyen,MoTa) values(N'Staff',N'Bán hàng, quản lý thuốc, thông tin cá nhân')
select * from PhanQuyen
go
--Bảng chức vụ (thêm sẵn 4 chức vụ)
CREATE TABLE ChucVu(
	ChucVuID INT IDENTITY PRIMARY KEY,
	TenChucVu NVARCHAR(20) NOT NULL UNIQUE,
	Luong INT NOT NULL,
	MoTa NVARCHAR(50)
)
insert ChucVu(TenChucVu,Luong,MoTa) values(N'Quản lý',10000000,N'Quản lý nhân viên')
insert ChucVu(TenChucVu,Luong,MoTa) values(N'Kế toán',8000000,N'Quản lý tài chính')
insert ChucVu(TenChucVu,Luong,MoTa) values(N'Quản kho',8000000,N'Quản lý nhập xuất kho')
insert ChucVu(TenChucVu,Luong,MoTa) values(N'Tư vấn',7000000,N'Chăm sóc khách hàng, quản lý hóa đơn')
select * from ChucVu
go
--Bảng nhân viên
CREATE TABLE NhanVien(
	NhanVienID INT IDENTITY PRIMARY KEY,
	HoTen NVARCHAR(50) NOT NULL,
	NgaySinh DATE NOT NULL,
	GioiTinh BIT NOT NULL,
	DiaChi NVARCHAR(100) NOT NULL,
	Sdt VARCHAR(10) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	ChucVuID INT FOREIGN KEY REFERENCES ChucVu(ChucVuID),
	NgayVaoLam DATE NOT NULL,
	BangCap NVARCHAR(40),
	ChuyenNganh NVARCHAR(40),
	Anh IMAGE
)
go
--Tạo view chi tiết nhân viên
CREATE VIEW vChiTietNhanVien
as select NhanVienID,HoTen,NgaySinh,case GioiTinh when 0 then N'Nữ' when 1 then N'Nam' end GioiTinh,
DiaChi,Sdt,Email,TenChucVu,NgayVaoLam,BangCap,Anh,Luong,ChuyenNganh from NhanVien
left join ChucVu on NhanVien.ChucVuID = ChucVu.ChucVuID
select * from vChiTietNhanVien
go
--Thủ tục thêm nhân viên
CREATE PROCEDURE spThemNhanVien
@HoTen NVARCHAR(50),@NgaySinh DATE,@GioiTinh BIT,@DiaChi NVARCHAR(100),@Sdt VARCHAR(10),
@Email VARCHAR(50),@TenChucVu NVARCHAR(20),@NgayVaoLam DATE,@BangCap NVARCHAR(40),@ChuyenNganh NVARCHAR(40),@Anh IMAGE
AS BEGIN
	DECLARE @ChucVuID INT
	set @ChucVuID = (select ChucVuID from ChucVu where TenChucVu = @TenChucVu)
	insert NhanVien(HoTen,NgaySinh,GioiTinh,DiaChi,Sdt,Email,ChucVuID,NgayVaoLam,BangCap,ChuyenNganh,Anh)
	values(@HoTen,@NgaySinh,@GioiTinh,@DiaChi,@Sdt,@Email,@ChucVuID,@NgayVaoLam,@BangCap,@ChuyenNganh,@Anh)
END
go
--Thủ tục sửa nhân viên
CREATE PROCEDURE spSuaNhanVien
@NhanVienID int,@HoTen NVARCHAR(50),@NgaySinh DATE,@GioiTinh BIT,@DiaChi NVARCHAR(100),@Sdt VARCHAR(10),
@Email VARCHAR(50),@TenChucVu NVARCHAR(20),@NgayVaoLam DATE,@BangCap NVARCHAR(40),@ChuyenNganh NVARCHAR(40),@Anh IMAGE
AS BEGIN
	DECLARE @Dem int, @Loi NVARCHAR(100) = '',@ChucVuID int
	set @Dem = (select count(*) from NhanVien where NhanVienID=@NhanVienID)
	if @Dem = 0
		set @Loi = N'Mã nhân viên không tồn tại'
	else
		BEGIN
			set @ChucVuID = (select ChucVuID from ChucVu where TenChucVu=@TenChucVu)
			set @Dem = (select count(*) from ChucVu where TenChucVu=@TenChucVu)
			if @Dem = 0
			set @Loi = N'Chức vụ không tồn tại'
		END
	if @Loi = ''
	update NhanVien set HoTen=@HoTen,NgaySinh=@NgaySinh,GioiTinh=@GioiTinh,DiaChi=@DiaChi,
	Sdt=@Sdt,Email=@Email,ChucVuID=@ChucVuID,NgayVaoLam=@NgayVaoLam,BangCap=@BangCap,ChuyenNganh=@ChuyenNganh,Anh=@Anh
	where NhanVienID=@NhanVienID
	else
		raiserror(@Loi,16,1)
END
go
--Thủ tục xóa nhân viên
ALTER PROCEDURE spXoaNhanVien
@NhanVienID int
AS BEGIN
	DECLARE @Dem int,@Username VARCHAR(30),@Loi nvarchar(200) = ''
	set @Dem = (select count(*) from NhanVien where NhanVienID=@NhanVienID)
	if @Dem = 0
		set @Loi = N'Mã nhân viên không tồn tại'
	else begin
		set @Dem = (select count(*) from TaiKhoan where NhanVienID=@NhanVienID)
		if @Dem != 0 begin
			set @Username = (select Username from TaiKhoan where NhanVienID=@NhanVienID)
			update TaiKhoan set NhanVienID = null where Username=@Username
			end
		delete NhanVien where NhanVienID=@NhanVienID
	end
END
go
--Hàm tìm kiếm nhân viên trả về vChiTietNhanVien
alter function fTimNhanVien
(@NhanVienID int,@HoTen nvarchar(50),@DiaChi nvarchar(100),@TenChucVu nvarchar(20))
returns table
as return
	(select * from vChiTietNhanVien
	where (@NhanVienID is null or NhanVienID=@NhanVienID)
	and (@HoTen is null or HoTen like '%' + @HoTen + '%')
	and (@DiaChi is null or DiaChi like '%' + @DiaChi + '%')
	and (@TenChucVu is null or TenChucVu like '%' + @TenChucVu + '%'))
select * from dbo.fTimNhanVien(null,N'Đạt',null,null)
select * from vChiTietNhanVien
go
--Bảng tài khoản
CREATE TABLE TaiKhoan(
	Username VARCHAR(30) NOT NULL PRIMARY KEY,
	Password VARCHAR(30) NOT NULL DEFAULT '1234',
	PhanQuyenID INT NOT NULL REFERENCES PhanQuyen(PhanQuyenID),
	NhanVienID INT FOREIGN KEY REFERENCES NhanVien(NhanVienID),
	Displayname NVARCHAR(50) NOT NULL
)
select * from TaiKhoan
go
--thủ tục login
CREATE PROCEDURE spLogin
@userName varchar(30), @passWord varchar(30)
AS
BEGIN
	SELECT * FROM TaiKhoan WHERE Username=@userName AND Password=@passWord
END
GO 
--thủ tục sửa email
create procedure spSuaThongTin
@NhanVienID INT, @Email varchar(50)
as begin
	update NhanVien set Email=@Email where NhanVienID=@NhanVienID	
end
go
--View chi tiết tài khoản
alter view vChiTietTaiKhoan
as select Username,Password,TenPhanQuyen,HoTen,TenChucVu,Anh,Displayname
from TaiKhoan 
left join PhanQuyen on TaiKhoan.PhanQuyenID=PhanQuyen.PhanQuyenID
left join vChiTietNhanVien on TaiKhoan.NhanVienID=vChiTietNhanVien.NhanVienID
select * from vChiTietTaiKhoan
select * from TaiKhoan
go
--Thủ tục thêm tài khoản
alter procedure spThemTaiKhoan
@Username varchar(30),@Password varchar(30),@TenPhanQuyen nvarchar(10),
@HoTen nvarchar(50),@Displayname nvarchar(50)
as begin
	declare @Dem int,@NhanvienID int,@PhanQuyenID int
	set @Dem = (select count(*) from TaiKhoan where Username=@Username)
	if @Dem = 0 begin
		set @NhanvienID = (select NhanVienID from NhanVien where HoTen=@HoTen)
		set @PhanQuyenID = (select PhanQuyenID from PhanQuyen where TenPhanQuyen=@TenPhanQuyen)
		insert TaiKhoan values(@Username,@Password,@PhanQuyenID,@NhanvienID,@Displayname)
		end
	else
		raiserror(N'Username đã tồn tại',16,1)
end
go
--Thủ tục sửa tài khoản
create procedure spSuaTaiKhoan
@Username varchar(30),@Password nvarchar(30),@TenPhanQuyen nvarchar(10),
@HoTen nvarchar(50),@Displayname nvarchar(50)
as begin
	declare @Dem int,@NhanvienID int,@PhanQuyenID int
	set @Dem = (select count(*) from TaiKhoan where Username=@Username)
	if @Dem != 0 begin
		set @NhanvienID = (select NhanVienID from NhanVien where HoTen=@HoTen)
		set @PhanQuyenID = (select PhanQuyenID from PhanQuyen where TenPhanQuyen=@TenPhanQuyen)
		update TaiKhoan set Password=@Password,PhanQuyenID=@PhanQuyenID,NhanVienID=@NhanvienID,
		Displayname=@Displayname where Username=@Username
		end
	else
		raiserror(N'Username không tồn tại',16,1)
end
go
--Thủ tục xóa tài khoản
create procedure spXoaTaiKhoan
@Username varchar(30)
as begin
	declare @Dem int
	set @Dem = (select count(*) from TaiKhoan where Username=@Username)
	if @Dem = 0
		raiserror(N'Username không tồn tại',16,1)
	else
		delete TaiKhoan where Username=@Username
end
go
--Hàm tìm Tài khoản trả về vChiTietTaiKhoan
alter function fTimTaiKhoan
(@UserName VARCHAR(30),@HoTen nvarchar(50),@Displayname nvarchar(50))
returns table
as return
	(select * from vChiTietTaiKhoan
	where (@Username is null or Username like '%' + @UserName + '%')
	and (@HoTen is null or HoTen like '%' + @HoTen + '%')
	and (@Displayname is null or Displayname like '%' + @Displayname + '%'))
select * from vChiTietTaiKhoan
select * from dbo.fTimTaiKhoan('ad',null,null)
go
--Bảng loại thuốc
CREATE TABLE LoaiThuoc(
	LoaiThuocID INT IDENTITY PRIMARY KEY,
	TenLoaiThuoc NVARCHAR(30) NOT NULL UNIQUE,
	MoTa NVARCHAR(50)
)
insert LoaiThuoc(TenLoaiThuoc,MoTa) values(N'Hạ sốt',N'Không dùng quá liều')
insert LoaiThuoc(TenLoaiThuoc,MoTa) values(N'Kháng viêm',N'Không dùng nhiều loại cùng lúc')
insert LoaiThuoc(TenLoaiThuoc,MoTa) values(N'Giảm đau',N'Hạn chế với người bị dạ dày')
insert LoaiThuoc(TenLoaiThuoc,MoTa) values(N'Thuốc tiêu hóa',N'Bù nước khi bị tiêu chảy')
insert LoaiThuoc(TenLoaiThuoc,MoTa) values(N'Da liễu',N'Điều trị bỏng, muỗi đốt,dị ứng')
insert LoaiThuoc(TenLoaiThuoc,MoTa) values(N'Thuốc sát trùng',N'Sát trùng vết thương ngoài da')
insert LoaiThuoc(TenLoaiThuoc,MoTa) values(N'Nước muối sinh lý',N'Bảo vệ mắt, mũi hằng ngày')
insert LoaiThuoc(TenLoaiThuoc,MoTa) values(N'Kháng sinh',N'Dùng theo chỉ định của bác sĩ')
insert LoaiThuoc(TenLoaiThuoc,MoTa) values(N'Thực phẩm chức năng',N'Không thay thế thuốc chữa bệnh')
go
--Bảng chống chỉ định
CREATE TABLE ChongChiDinh( --thuốc không dành cho người bị bệnh dạ dày, tiểu đường, cao huyết áp...
	ChongChiDinhID INT IDENTITY PRIMARY KEY,
	TenChongChiDinh NVARCHAR(50) NOT NULL UNIQUE
)
insert ChongChiDinh(TenChongChiDinh) values(N'Người bị bệnh dạ dày')
insert ChongChiDinh(TenChongChiDinh) values(N'Người bị bệnh tiểu đường')
insert ChongChiDinh(TenChongChiDinh) values(N'Người bị bệnh cao huyết áp')
insert ChongChiDinh(TenChongChiDinh) values(N'Người bị bệnh loãng máu')
insert ChongChiDinh(TenChongChiDinh) values(N'Người vừa phẫu thuật')
insert ChongChiDinh(TenChongChiDinh) values(N'Phụ nữ đang mang thai')
insert ChongChiDinh(TenChongChiDinh) values(N'Trẻ em dưới 6 tuổi')
insert ChongChiDinh(TenChongChiDinh) values(N'Trẻ em dưới 16 tuổi')
insert ChongChiDinh(TenChongChiDinh) values(N'Người bị bệnh tim mạch')
go
--Bảng đơn vị tính
CREATE TABLE DonViTinh( --viên, bột, dung dịch,.. 
	DonViTinhID INT IDENTITY PRIMARY KEY,
	TenDonViTinh  NVARCHAR(20) NOT NULL UNIQUE
)
insert DonViTinh(TenDonViTinh) values(N'Vỉ 10 viên')
insert DonViTinh(TenDonViTinh) values(N'Vỉ 5 viên')
insert DonViTinh(TenDonViTinh) values(N'Vỉ 14 viên')
insert DonViTinh(TenDonViTinh) values(N'Lọ 15 viên')
insert DonViTinh(TenDonViTinh) values(N'Lọ 30 viên')
insert DonViTinh(TenDonViTinh) values(N'Lọ 20 viên')
insert DonViTinh(TenDonViTinh) values(N'Lọ xịt')
insert DonViTinh(TenDonViTinh) values(N'Lọ nhỏ')
insert DonViTinh(TenDonViTinh) values(N'Viên nén')
insert DonViTinh(TenDonViTinh) values(N'Viên nhộng')
insert DonViTinh(TenDonViTinh) values(N'Viên đạn')
insert DonViTinh(TenDonViTinh) values(N'Viên sủi')
insert DonViTinh(TenDonViTinh) values(N'Ống uống')
insert DonViTinh(TenDonViTinh) values(N'Ống tiêm')
insert DonViTinh(TenDonViTinh) values(N'Chai 1 lít')
insert DonViTinh(TenDonViTinh) values(N'Chai 0.5 lít')
insert DonViTinh(TenDonViTinh) values(N'Chai 0.1 lít')
insert DonViTinh(TenDonViTinh) values(N'Miếng dán')
go
--Bảng kho
CREATE TABLE Kho(
	KhoID INT IDENTITY PRIMARY KEY,
	TenKho NVARCHAR(20) NOT NULL unique, --tủ A, tủ B, tủ C
	HinhThucBaoQuan NVARCHAR(20) NOT NULL, --nhiệt độ phòng, lạnh,...
)
insert Kho(TenKho,HinhThucBaoQuan) values(N'Kho A',N'Nhiệt độ phòng')
insert Kho(TenKho,HinhThucBaoQuan) values(N'Kho B',N'Tủ đông tích hợp')
insert Kho(TenKho,HinhThucBaoQuan) values(N'Kho C',N'Tủ lạnh dược phẩm')
insert Kho(TenKho,HinhThucBaoQuan) values(N'Kho D',N'Nhiệt độ phòng')
insert Kho(TenKho,HinhThucBaoQuan) values(N'Kho E',N'Nhiệt độ phòng')
select KhoID,TenKho from Kho
go
CREATE TABLE Thuoc(
	ThuocID INT IDENTITY PRIMARY KEY,
	TenThuoc NVARCHAR(50) NOT NULL,
	LoaiThuocID INT FOREIGN KEY REFERENCES LoaiThuoc(LoaiThuocID),
	DonViTinhID INT FOREIGN KEY REFERENCES DonViTinh(DonViTinhID),
	ChongChiDinhID INT FOREIGN KEY REFERENCES ChongChiDinh(ChongChiDinhID),
	CongDung NVARCHAR(100) NOT NULL,
	GiaNhap INT NOT NULL,
	GiaBan INT NOT NULL,
	ThanhPhan NVARCHAR(200) NOT NULL, --500mg paracetamol, 50mg cafein
	KhoID INT FOREIGN KEY REFERENCES Kho(KhoID),
	Anh image
)
go
--Tạo view chi tiết thuốc
create view vChiTietThuoc
as select ThuocID,Anh,TenThuoc,TenLoaiThuoc,TenDonViTinh,TenChongChiDinh,
CongDung,GiaNhap,GiaBan,ThanhPhan,TenKho from Thuoc
left join LoaiThuoc on Thuoc.LoaiThuocID=LoaiThuoc.LoaiThuocID
left join DonViTinh on Thuoc.DonViTinhID=DonViTinh.DonViTinhID
left join ChongChiDinh on Thuoc.ChongChiDinhID=ChongChiDinh.ChongChiDinhID
left join Kho on Thuoc.KhoID=Kho.KhoID

select * from vChiTietThuoc
go
--Thủ tục thêm thuốc
create procedure spThemThuoc
@TenThuoc nvarchar(50),@LoaiThuocID int,@DonViTinhID int,@ChongChiDinhID int,@CongDung nvarchar(100),
@GiaNhap int,@GiaBan int,@ThanhPhan nvarchar(200),@KhoID int,@Anh image
as begin
	insert Thuoc(TenThuoc,LoaiThuocID,DonViTinhID,ChongChiDinhID,CongDung,
	GiaNhap,GiaBan,ThanhPhan,KhoID,Anh)
	values(@TenThuoc,@LoaiThuocID,@DonViTinhID,@ChongChiDinhID,@CongDung,
	@GiaNhap,@GiaBan,@ThanhPhan,@KhoID,@Anh)
end
go
--Thủ tục sửa thuốc
alter procedure spSuaThuoc
@ThuocID int,@TenThuoc nvarchar(50),@LoaiThuocID int,@DonViTinhID int,@ChongChiDinhID int,@CongDung nvarchar(100),
@GiaNhap int,@GiaBan int,@ThanhPhan nvarchar(200),@KhoID int,@Anh image
as begin
	declare @Dem int
	set @Dem = (select count(*) from Thuoc where ThuocID = @ThuocID)
	if @Dem = 0
		raiserror(N'Mã thuốc không tồn tại',16,1)
	else
		update Thuoc set TenThuoc=@TenThuoc,LoaiThuocID=@LoaiThuocID,DonViTinhID=@DonViTinhID,
		ChongChiDinhID=@ChongChiDinhID,CongDung=@CongDung,GiaNhap=@GiaNhap,GiaBan=@GiaBan,
		ThanhPhan=@ThanhPhan,KhoID=@KhoID,Anh=@Anh where ThuocID=@ThuocID
end

go
--Bảng hạn dùng
CREATE TABLE HanDung(
	HanDungID INT IDENTITY PRIMARY KEY,
	NgayHetHan DATE,
	ThuocID INT FOREIGN KEY REFERENCES Thuoc(ThuocID),
	SoLuong INT Default 0
)
go
alter view vChiTietHanDung
as select Thuoc.ThuocID,Anh,TenThuoc,TenLoaiThuoc,TenDonViTinh,CongDung,TenKho,NgayHetHan,SoLuong,GiaBan
from Thuoc left join LoaiThuoc on Thuoc.LoaiThuocID=LoaiThuoc.LoaiThuocID
inner join Kho on Thuoc.KhoID=Kho.KhoID
inner join DonViTinh on Thuoc.DonViTinhID=DonViTinh.DonViTinhID
inner join HanDung on Thuoc.ThuocID=HanDung.ThuocID
go
--Thủ tục xóa thuốc
create procedure spXoaThuoc
@ThuocID int
as begin
	declare @Dem int
	set @Dem = (select count(*) from Thuoc where ThuocID = @ThuocID)
	if @Dem = 0
		raiserror(N'Mã thuốc không tồn tại',16,1)
	else begin
		delete HanDung where ThuocID=@ThuocID
		delete Thuoc where ThuocID=@ThuocID
	end
end
go
CREATE TABLE NhapThuoc(
	NhapThuocID INT identity PRIMARY KEY,
	TenNhaCungCap NVARCHAR(100) NOT NULL,
	DiaChi NVARCHAR(200),
	Sdt VARCHAR(10),
	NgayNhap DATE
)
select * from NhapThuoc
select * from ChiTietNhap
select * from HanDung
delete from NhapThuoc
go
CREATE TABLE ChiTietNhap(
	NhapThuocID INT FOREIGN KEY REFERENCES NhapThuoc(NhapThuocID),
	ThuocID INT FOREIGN KEY REFERENCES Thuoc(ThuocID),
	PRIMARY KEY(NhapThuocID,ThuocID)
)
go
--Thủ tục nhập thuốc
alter procedure spNhapThuoc
@TenNhaCungCap NVARCHAR(100),@DiaChi NVARCHAR(200),@Sdt VARCHAR(10),@NgayNhap DATE,@NhapThuocID INT output
as begin
		insert NhapThuoc values(@TenNhaCungCap,@DiaChi,@Sdt,@NgayNhap)
		set @NhapThuocID = SCOPE_IDENTITY()
end
go
--Thủ tục thêm hạn dùng
alter procedure spThemHanDung
@NhapThuocID int, @ThuocID int,@NgayHetHan date, @SoLuong int
as begin
	declare @Dem int,@HanDungID int
	set @Dem = (select count(*) from NhapThuoc where NhapThuocID=@NhapThuocID)
	if @Dem = 0
		raiserror(N'Mã đơn nhập không tồn tại',16,1)
	else begin
		set @Dem = (select count(*) from ChiTietNhap where NhapThuocID=@NhapThuocID and ThuocID=@ThuocID)
		if @Dem = 0
			insert ChiTietNhap values(@NhapThuocID,@ThuocID)
		set @HanDungID = (select HanDungID from HanDung where ThuocID=@ThuocID and NgayHetHan=@NgayHetHan)
		if @HanDungID != 0
			update HanDung set SoLuong = SoLuong + @SoLuong where HanDungID=@HanDungID
		else
			insert HanDung(NgayHetHan,ThuocID,SoLuong) values(@NgayHetHan,@ThuocID,@SoLuong)
		end
end
go
CREATE TABLE HinhThucThanhToan(
	HinhThucThanhToanID INT IDENTITY PRIMARY KEY,
	TenHinhThucThanhToan NVARCHAR(15) NOT NULL UNIQUE
)
insert HinhThucThanhToan(TenHinhThucThanhToan) values(N'Trực tiếp')
insert HinhThucThanhToan(TenHinhThucThanhToan) values(N'Chuyển khoản')
insert HinhThucThanhToan(TenHinhThucThanhToan) values(N'Ví điện tử')

go
CREATE TABLE HoaDon(
	HoaDonID INT IDENTITY PRIMARY KEY,
	TenKhachHang NVARCHAR(50) NOT NULL,
	Sdt VARCHAR(10) NOT NULL,
	NgayTao DATE NOT NULL,
	HinhThucThanhToanID INT FOREIGN KEY REFERENCES HinhThucThanhToan(HinhThucThanhToanID),
	TongTien INT NOT NULL default(0)
)
go
CREATE TABLE ChiTietHoaDon(
	HoaDonID INT FOREIGN KEY REFERENCES HoaDon(HoaDonID),
	ThuocID INT FOREIGN KEY REFERENCES Thuoc(ThuocID),
	SoLuong INT NOT NULL,
	PRIMARY KEY(HoaDonID,ThuocID)
)
go
--Thủ tục thêm hóa đơn
alter PROCEDURE spThemHoaDon
@TenKhachHang NVARCHAR(50),@Sdt VARCHAR(10),@NgayTao DATE,@HinhThucThanhToanID INT,@HoaDonID INT OUTPUT
AS BEGIN
    INSERT INTO HoaDon (TenKhachHang, Sdt, NgayTao, HinhThucThanhToanID)
    VALUES (@TenKhachHang, @Sdt, @NgayTao, @HinhThucThanhToanID)
    -- Lấy HoaDonID của hoá đơn mới tạo
    SET @HoaDonID = SCOPE_IDENTITY()
END
select * from HoaDon
go
--Thủ tục ChiTietSoLuong
alter procedure spChiTietSoLuong
@HoaDonID int, @ThuocID int, @SoLuong int, @NgayHetHan date
as begin
	declare @Dem int, @TonKho int, @TenThuoc NVARCHAR(50), @Loi nvarchar(100)
	--Kiểm tra xem số lượng còn đủ bán không
	set @TonKho = (select SoLuong from HanDung where ThuocID=@ThuocID and NgayHetHan=@NgayHetHan)
	if @TonKho >= @SoLuong begin
		set @Dem = (select count(*) from ChiTietHoaDon where HoaDonID=@HoaDonID and ThuocID=@ThuocID)
		if @Dem = 0
			insert ChiTietHoaDon values(@HoaDonID,@ThuocID,@SoLuong)
		else
			update ChiTietHoaDon set SoLuong = SoLuong+@SoLuong where HoaDonID=@HoaDonID and ThuocID=@ThuocID
	
		update HoaDon set TongTien = TongTien + @SoLuong * (select GiaBan from Thuoc where ThuocID=@ThuocID)
		where HoaDonID = @HoaDonID
		update HanDung set SoLuong = SoLuong - @SoLuong where ThuocID=@ThuocID and NgayHetHan=@NgayHetHan
	end
	else begin
		set @TenThuoc = (select TenThuoc from Thuoc where ThuocID=@ThuocID)
		set @Loi = N'Số lượng tồn kho của thuốc ' + @TenThuoc + N' không đủ'
	end
end
select * from ChiTietHoaDon
select * from HoaDon
go
--Tạo View Hóa đơn(Đạt thêm ngày 12/12)
alter view vHoaDon
as select HoaDon.HoaDonID,TenKhachHang,Sdt,NgayTao,TongTien,TenHinhThucThanhToan
from HoaDon inner join HinhThucThanhToan on HoaDon.HinhThucThanhToanID=HinhThucThanhToan.HinhThucThanhToanID
go
--Tạo view chi tiết hóa đơn(Đạt thêm 12/12) --  đã sửa ngày 14/12
alter view vChiTietHoaDon
as select HoaDonID,Thuoc.ThuocID,TenThuoc,SoLuong,GiaBan,SoLuong*GiaBan as TongTien from ChiTietHoaDon
inner join Thuoc on ChiTietHoaDon.ThuocID=Thuoc.ThuocID
go
--Tạo thủ tục cập nhập Bill(Đạt thêm ngày 12/12)
create procedure spSuaHoaDon
@HoaDonID int, @TenKhachHang nvarchar(50), @Sdt varchar(10)
as begin
	update HoaDon set TenKhachHang=@TenKhachHang, Sdt=@Sdt where HoaDonID=@HoaDonID
end
go
--Thủ tục cập nhập chi tiết hóa đơn(Đạt thêm ngày 12/12)
alter procedure spSuaChiTietHoaDon
@HoaDonID int, @ThuocID int, @SoLuong int
as begin
	declare @SLuong int, @TenThuoc nvarchar(50), @Loi nvarchar(100), @Gia int
	set @SLuong = (select SoLuong from ChiTietHoaDon where HoaDonID=@HoaDonID and ThuocID=@ThuocID)
	set @TenThuoc = (select TenThuoc from Thuoc where ThuocID=@ThuocID)
	set @Gia = (select GiaBan from Thuoc where ThuocID=@ThuocID)
	set @Loi = N'Số lượng thuốc ' + @TenThuoc + ' vưot quá ban đau'
	if @SLuong < @SoLuong
		raiserror(@Loi,16,1)
	else begin
		update ChiTietHoaDon set SoLuong = @SoLuong where HoaDonID=@HoaDonID and ThuocID=@ThuocID
		update HoaDon set TongTien = TongTien - (@SLuong-@SoLuong)*@Gia where HoaDonID = @HoaDonID
	end
end
select * from HoaDon
go
--Thủ tục xóa hóa đơn(Đạt thêm ngày 12/12)
create procedure spXoaHoaDon
@HoaDonID int
as begin
	delete ChiTietHoaDon where HoaDonID=@HoaDonID
	delete HoaDon where HoaDonID=@HoaDonID
end
go
--thủ tục tìm kiếm bill theo khoảng ngày
create function fTimBillNgayNhap
(@FromDate Date, @ToDate Date)
returns table
as return
	(select * from vHoaDon
	where (NgayTao>=@FromDate AND NgayTao<=@ToDate))
go
--Ngày 14/12
CREATE FUNCTION dbo.GetTop5HighTotalCustomers
(
    @fromDate DATE,
    @toDate DATE
)
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 5
        TenKhachHang,
        SUM(TongTien) AS TotalSpent
    FROM
        HoaDon
    WHERE
        NgayTao >= @fromDate
        AND NgayTao < DATEADD(DAY, 1, @toDate)
    GROUP BY
        TenKhachHang
    ORDER BY
        TotalSpent DESC
)
--hàm lấy ra top 5 khách hàng tốn tiền nhất
create FUNCTION fGetKhachHangPerTime
(
    @statisticType NVARCHAR(50),
    @dateFilter DATE
)
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 5
        TenKhachHang,
        SUM(TongTien) AS TotalSpent
    FROM
        HoaDon
    WHERE
        (
            (@statisticType = 'day' AND NgayTao >= @dateFilter AND NgayTao < DATEADD(DAY, 1, @dateFilter))
            OR
            (@statisticType = 'month' AND DATEPART(MONTH, NgayTao) = DATEPART(MONTH, @dateFilter) AND DATEPART(YEAR, NgayTao) = DATEPART(YEAR, @dateFilter))
            OR
            (@statisticType = 'year' AND DATEPART(YEAR, NgayTao) = DATEPART(YEAR, @dateFilter))
            OR
            (@statisticType = 'week' AND DATEPART(WEEK, NgayTao) = DATEPART(WEEK, @dateFilter) AND DATEPART(YEAR, NgayTao) = DATEPART(YEAR, @dateFilter))
        )
    GROUP BY
        TenKhachHang
    ORDER BY
        TotalSpent DESC
)
--hàm lấy ra tổng số lượng bán theo khoảng thời gian
CREATE FUNCTION dbo.GetTotalQuantityByDateRange
(
    @fromDate DATE,
    @toDate DATE
)
RETURNS INT
AS
BEGIN
    DECLARE @totalQuantity INT;

    SELECT @totalQuantity = SUM(SoLuong)
    FROM ChiTietHoaDon AS cthd
    INNER JOIN HoaDon AS hd ON cthd.HoaDonID = hd.HoaDonID
    WHERE hd.NgayTao >= @fromDate AND hd.NgayTao < DATEADD(DAY, 1, @toDate);

    RETURN ISNULL(@totalQuantity, 0);
END
go
----------------------------------------------------
create view vChiTiet
as select NgayTao,TongTien
from HoaDon
go
---------theo tháng-------
create PROCEDURE DoanhThuTheoThang
@NgayBatDau Date,@NgayKetThuc Date
as begin
select MONTH(NgayTao) as Thang,sum(TongTien) as Tien
from vChiTiet
where Month(NgayTao) between month(@NgayBatDau) and month(@NgayKetThuc) and YEAR(NgayTao)=YEAR(getdate())
group by MONTH(NgayTao)
end
go
---------theo ngày---------
create procedure DoanhThuTheoNgay
@NgayBatDau Date,@NgayKetThuc Date
as begin
select NgayTao,sum(TongTien) as Tien
from vChiTiet
where NgayTao between @NgayBatDau and @NgayKetThuc
group by NgayTao
end
go
----------theo năm-----------
create procedure DoanhThuTheoNam
@Nam1 int,@Nam2 int
as begin
  select year([NgayTao]) as nam,sum(TongTien)  as Tien
  from vChiTiet
  where YEAR([NgayTao]) between @Nam1 and @Nam2
  group by year([NgayTao])
  end
go
  --Tìm thuốc
create function fTimThuocNgayNhap
(@FromDate Date, @ToDate Date)
returns table
as return
	(select * from vChiTietNhapThuoc
	where (NgayNhap>=@FromDate AND NgayNhap<=@ToDate))
go
--View Chi tiết nhập thuốc
create view vChiTietNhapThuoc
as select Thuoc.ThuocID,Thuoc.Anh,Thuoc.TenThuoc,Thuoc.GiaNhap,NgayNhap from ChiTietNhap
left join NhapThuoc on ChiTietNhap.NhapThuocID=NhapThuoc.NhapThuocID
left join Thuoc on ChiTietNhap.ThuocID=Thuoc.ThuocID
left join ChongChiDinh on Thuoc.ChongChiDinhID=ChongChiDinh.ChongChiDinhID
select * from vChiTietNhapThuoc
go
create procedure spChangePass
@Username varchar(30),@Password varchar(30)
as begin
	update TaiKhoan set Password=@Password where Username=@Username
end
go
--Hàm tìm thuốc
create function fTimThuoc
(@ThuocID int,@TenThuoc nvarchar(50),@TenLoaiThuoc nvarchar(30),@CongDung nvarchar(100),@TenKho nvarchar(20))
returns table
as return
	(select * from vChiTietHanDung
	where (@ThuocID is null or ThuocID=@ThuocID)
	and (@TenThuoc is null or TenThuoc like '%'+@TenThuoc+'%')
	and (@TenLoaiThuoc is null or TenLoaiThuoc like '%'+@TenLoaiThuoc+'%')
	and (@CongDung is null or CongDung like '%'+@CongDung+'%')
	and (@TenKho is null or TenKho like '%'+@TenKho+'%'))
go
--Hàm tìm thuốc trong view chi tiết thuốc
create function fTimChiTietThuoc
(@TenThuoc nvarchar(50),@TenLoaiThuoc nvarchar(30),@CongDung nvarchar(100),@TenChongChiDinh nvarchar(50),
@TenDonViTinh nvarchar(20), @ThanhPhan nvarchar(200), @TenKho nvarchar(20))
returns table
as return
	(select * from vChiTietThuoc
	where (@TenThuoc is null or TenThuoc like '%'+@TenThuoc+'%')
	and (@TenLoaiThuoc is null or TenLoaiThuoc like '%'+@TenLoaiThuoc+'%')
	and (@CongDung is null or CongDung like '%'+@CongDung+'%')
	and (@TenChongChiDinh is null or TenChongChiDinh like '%'+@TenChongChiDinh+'%')
	and (@TenDonViTinh is null or TenDonViTinh like '%'+@TenDonViTinh+'%')
	and (@ThanhPhan is null or ThanhPhan like '%'+@ThanhPhan+'%')
	and (@TenKho is null or TenKho like '%'+@TenKho+'%'))
go
--Tìm chi tiết hóa đơn
create function fTimHoaDon
(@HoaDonID int, @TenKhachHang nvarchar(50), @Sdt varchar(10))
returns table
as return
	(select * from vHoaDon
	where (@HoaDonID is null or HoaDonID=@HoaDonID)
	and (@TenKhachHang is null or TenKhachHang like '%'+@TenKhachHang+'%')
	and (@Sdt is null or Sdt = @Sdt))
go
--Tìm chi tiết hóa đơn theo ngày tạo
create function fTimHDNgayTao
(@NgayBatDau date,@NgayKetThuc date)
returns table
as return
	(select * from vHoaDon
	where NgayTao between @NgayBatDau and @NgayKetThuc)