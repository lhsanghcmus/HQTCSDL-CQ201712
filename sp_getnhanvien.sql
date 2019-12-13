create PROC sp_GetNhanVien
	@UserName nvarchar(100),
	@PassWord nvarchar(500)
AS
BEGIN
	select nv.CMND, nv.EMAIL, nv.HOTEN, nv.MACHINHANH, nv.MANHANVIEN, nv.MATKHAU, nv.SDT ,cn.TENCHINHANH 
	from NHANVIEN nv, CHINHANH cn where EMAIL=@UserName and MATKHAU = @PassWord and nv.MACHINHANH = cn.MACHINHANH
	return
END
