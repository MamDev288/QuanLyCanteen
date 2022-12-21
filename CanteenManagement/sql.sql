create database quanlycangtin
go
use quanlycangtin
go
create table taikhoandn
(
	id int identity primary key,
	taikhoan varchar(32) not null,
	matkhau nvarchar(255) not null,
	hoten nvarchar(255) not null
)
go
create table loaisanpham
(
	id int identity primary key,
	tenloaisanpham nvarchar(255) not null,
)
go
create table sanpham
(
	id int identity primary key,
	tensanpham nvarchar(255) not null,
	giatien real not null,
	loaisanphamid int foreign key references loaisanpham(id)
)
go
create table donhang
(
	id int identity primary key,
	tenkhachhang nvarchar(255) not null,
	tongtien real,
	giamgia real default 0,
	thanhtoan real,
	taikhoanid int foreign key references taikhoandn(id)
)
go
create table chitietdonhang
(
	id int identity primary key,
	sanphamid int foreign key references sanpham(id),
	soluong real not null,
	thanhtien real not null,
	donhangid int foreign key references donhang(id)
)
go
--- Tài khoản
create procedure sp_addtaikhoan (@taikhoan varchar(32),@matkhau nvarchar(255),@hoTen nvarchar(255))
as
begin
	insert into taikhoandn(taikhoan,matkhau,hoten) values (@taikhoan,@matkhau,@hoTen)
end
go
create procedure sp_edittaikhoan (@matkhau nvarchar(255),@hoTen nvarchar(255),@id int)
as
begin
	update  taikhoandn set matkhau=@matkhau,hoten=@hoTen where id = @id
end
go
create procedure sp_deteletaikhoan (@id int)
as
begin
	delete taikhoandn  where id = @id
end
go
--Loại sản phẩm
create procedure sp_addloaisanpham (@tenloai varchar(255))
as
begin
	insert into loaisanpham(tenloaisanpham) values (@tenloai)
end
go
create procedure sp_editloaisanpham (@tenloai nvarchar(255),@id int)
as
begin
	update  loaisanpham set tenloaisanpham=@tenloai where id = @id
end
go
create procedure sp_deteleloaisanpham (@id int)
as
begin
	delete loaisanpham  where id = @id
end
go
---Sản phẩm
create procedure sp_addsanpham (@tensanpham nvarchar(255),@loaiSP int,@giatien real)
as
begin
	insert into sanpham(tensanpham,loaisanphamid,giatien) values (@tensanpham,@loaiSP,@giatien)
end
go
create procedure sp_editsanpham (@tensanpham nvarchar(255),@loaiSP int,@giatien real,@id int)
as
begin
	update  sanpham set tensanpham=@tensanpham ,loaisanphamid=@loaiSP,giatien=@giatien where id = @id
end
go
create procedure sp_detelesanpham (@id int)
as
begin
	delete sanpham  where id = @id
end
go
---Đơn hàng
create  procedure sp_adddonhang (@tenkhachhang nvarchar(255),@giamgia real,@taikhoan int)
as
begin
	insert into donhang(tenkhachhang,taikhoanid,giamgia,tongtien,thanhtoan) values (@tenkhachhang,@taikhoan,@giamgia,0,0);
	SELECT SCOPE_IDENTITY();
end
go
create procedure sp_editdonhang (@tenkhachhang nvarchar(255),@giamgia real ,@id int)
as
begin
	update  donhang set tenkhachhang=@tenkhachhang,giamgia= @giamgia  where id = @id
end
go
create procedure sp_deteledonhang (@id int)
as
begin
	delete donhang  where id = @id
end
go
---Chi tiểt đơn hàng
create procedure sp_addchitietdonhang (@id_sanpham int,@soluong real,@donhang_id int)
as
begin
	DECLARE @giatien real;
	set @giatien = (select giatien from sanpham where id = @id_sanpham)
	insert into chitietdonhang(sanphamid,soluong,thanhtien,donhangid) values (@id_sanpham,@soluong,(@soluong*@giatien),@donhang_id);
end
go
create procedure sp_editchitietdonhang (@id_sanpham int,@soluong real,@donhang_id int,@id int)
as
begin
DECLARE @giatien real;
	set @giatien = (select giatien from sanpham where id = @id_sanpham)
	update chitietdonhang set sanphamid =@id_sanpham ,soluong =@soluong,thanhtien = (@soluong*@giatien) ,donhangid = @donhang_id where id =@id ;
end
go
create procedure sp_detelechitietdonhang (@id int)
as
begin
	delete chitietdonhang  where id = @id
end
go
---trigger
create trigger trgg_chitietdonhang on chitietdonhang 
after insert,update,delete
as begin
	if exists (select * from deleted)
		begin
			update donhang set tongtien  = (tongtien- deleted.thanhtien),thanhtoan = ((tongtien - deleted.thanhtien) + giamgia) from donhang inner join deleted on deleted.donhangid = donhang.id
		end
	if exists (select * from inserted)
		begin
			update donhang set tongtien  = (tongtien + inserted.thanhtien),thanhtoan = ((tongtien + inserted.thanhtien) - giamgia) from donhang inner join inserted on inserted.donhangid = donhang.id
		end
end
GO
create trigger trgg_taikhoan on taikhoandn 
INSTEAD OF delete
as begin
	delete donhang from donhang inner join deleted on deleted.id = donhang.taikhoanid
	delete taikhoandn from taikhoandn inner join deleted on deleted.id = taikhoandn.id
end
GO
create trigger trgg_donHang on donhang 
INSTEAD OF delete
as begin
	delete chitietdonhang from chitietdonhang inner join deleted on deleted.id = chitietdonhang.donhangid
	delete donhang from donhang inner join deleted on deleted.id = donhang.id
end
GO
EXEC dbo.sp_addtaikhoan 'admin','1','Admin'
GO
EXEC dbo.sp_addloaisanpham N'Đồ ăn nhanh'
GO
EXEC dbo.sp_addloaisanpham N'Thức ăn mặn'
GO
EXEC dbo.sp_addloaisanpham N'Thức uống'
GO
EXEC dbo.sp_addloaisanpham N'Đồ dùng học tập'

