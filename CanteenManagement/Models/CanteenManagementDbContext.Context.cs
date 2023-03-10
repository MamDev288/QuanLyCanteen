//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CanteenManagement.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CanteenManagementEntities : DbContext
    {
        public CanteenManagementEntities()
            : base("name=CanteenManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<chitietdonhang> chitietdonhangs { get; set; }
        public virtual DbSet<donhang> donhangs { get; set; }
        public virtual DbSet<loaisanpham> loaisanphams { get; set; }
        public virtual DbSet<sanpham> sanphams { get; set; }
        public virtual DbSet<taikhoandn> taikhoandns { get; set; }
    
        public virtual int sp_addchitietdonhang(Nullable<int> id_sanpham, Nullable<float> soluong, Nullable<int> donhang_id)
        {
            var id_sanphamParameter = id_sanpham.HasValue ?
                new ObjectParameter("id_sanpham", id_sanpham) :
                new ObjectParameter("id_sanpham", typeof(int));
    
            var soluongParameter = soluong.HasValue ?
                new ObjectParameter("soluong", soluong) :
                new ObjectParameter("soluong", typeof(float));
    
            var donhang_idParameter = donhang_id.HasValue ?
                new ObjectParameter("donhang_id", donhang_id) :
                new ObjectParameter("donhang_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_addchitietdonhang", id_sanphamParameter, soluongParameter, donhang_idParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> sp_adddonhang(string tenkhachhang, Nullable<float> giamgia, Nullable<int> taikhoan)
        {
            var tenkhachhangParameter = tenkhachhang != null ?
                new ObjectParameter("tenkhachhang", tenkhachhang) :
                new ObjectParameter("tenkhachhang", typeof(string));
    
            var giamgiaParameter = giamgia.HasValue ?
                new ObjectParameter("giamgia", giamgia) :
                new ObjectParameter("giamgia", typeof(float));
    
            var taikhoanParameter = taikhoan.HasValue ?
                new ObjectParameter("taikhoan", taikhoan) :
                new ObjectParameter("taikhoan", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("sp_adddonhang", tenkhachhangParameter, giamgiaParameter, taikhoanParameter);
        }
    
        public virtual int sp_addloaisanpham(string tenloai)
        {
            var tenloaiParameter = tenloai != null ?
                new ObjectParameter("tenloai", tenloai) :
                new ObjectParameter("tenloai", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_addloaisanpham", tenloaiParameter);
        }
    
        public virtual int sp_addsanpham(string tensanpham, Nullable<int> loaiSP, Nullable<float> giatien)
        {
            var tensanphamParameter = tensanpham != null ?
                new ObjectParameter("tensanpham", tensanpham) :
                new ObjectParameter("tensanpham", typeof(string));
    
            var loaiSPParameter = loaiSP.HasValue ?
                new ObjectParameter("loaiSP", loaiSP) :
                new ObjectParameter("loaiSP", typeof(int));
    
            var giatienParameter = giatien.HasValue ?
                new ObjectParameter("giatien", giatien) :
                new ObjectParameter("giatien", typeof(float));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_addsanpham", tensanphamParameter, loaiSPParameter, giatienParameter);
        }
    
        public virtual int sp_addtaikhoan(string taikhoan, string matkhau, string hoTen)
        {
            var taikhoanParameter = taikhoan != null ?
                new ObjectParameter("taikhoan", taikhoan) :
                new ObjectParameter("taikhoan", typeof(string));
    
            var matkhauParameter = matkhau != null ?
                new ObjectParameter("matkhau", matkhau) :
                new ObjectParameter("matkhau", typeof(string));
    
            var hoTenParameter = hoTen != null ?
                new ObjectParameter("hoTen", hoTen) :
                new ObjectParameter("hoTen", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_addtaikhoan", taikhoanParameter, matkhauParameter, hoTenParameter);
        }
    
        public virtual int sp_detelechitietdonhang(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_detelechitietdonhang", idParameter);
        }
    
        public virtual int sp_deteledonhang(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_deteledonhang", idParameter);
        }
    
        public virtual int sp_deteleloaisanpham(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_deteleloaisanpham", idParameter);
        }
    
        public virtual int sp_detelesanpham(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_detelesanpham", idParameter);
        }
    
        public virtual int sp_deteletaikhoan(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_deteletaikhoan", idParameter);
        }
    
        public virtual int sp_editchitietdonhang(Nullable<int> id_sanpham, Nullable<float> soluong, Nullable<int> donhang_id, Nullable<int> id)
        {
            var id_sanphamParameter = id_sanpham.HasValue ?
                new ObjectParameter("id_sanpham", id_sanpham) :
                new ObjectParameter("id_sanpham", typeof(int));
    
            var soluongParameter = soluong.HasValue ?
                new ObjectParameter("soluong", soluong) :
                new ObjectParameter("soluong", typeof(float));
    
            var donhang_idParameter = donhang_id.HasValue ?
                new ObjectParameter("donhang_id", donhang_id) :
                new ObjectParameter("donhang_id", typeof(int));
    
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_editchitietdonhang", id_sanphamParameter, soluongParameter, donhang_idParameter, idParameter);
        }
    
        public virtual int sp_editdonhang(string tenkhachhang, Nullable<float> giamgia, Nullable<int> id)
        {
            var tenkhachhangParameter = tenkhachhang != null ?
                new ObjectParameter("tenkhachhang", tenkhachhang) :
                new ObjectParameter("tenkhachhang", typeof(string));
    
            var giamgiaParameter = giamgia.HasValue ?
                new ObjectParameter("giamgia", giamgia) :
                new ObjectParameter("giamgia", typeof(float));
    
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_editdonhang", tenkhachhangParameter, giamgiaParameter, idParameter);
        }
    
        public virtual int sp_editloaisanpham(string tenloai, Nullable<int> id)
        {
            var tenloaiParameter = tenloai != null ?
                new ObjectParameter("tenloai", tenloai) :
                new ObjectParameter("tenloai", typeof(string));
    
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_editloaisanpham", tenloaiParameter, idParameter);
        }
    
        public virtual int sp_editsanpham(string tensanpham, Nullable<int> loaiSP, Nullable<float> giatien, Nullable<int> id)
        {
            var tensanphamParameter = tensanpham != null ?
                new ObjectParameter("tensanpham", tensanpham) :
                new ObjectParameter("tensanpham", typeof(string));
    
            var loaiSPParameter = loaiSP.HasValue ?
                new ObjectParameter("loaiSP", loaiSP) :
                new ObjectParameter("loaiSP", typeof(int));
    
            var giatienParameter = giatien.HasValue ?
                new ObjectParameter("giatien", giatien) :
                new ObjectParameter("giatien", typeof(float));
    
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_editsanpham", tensanphamParameter, loaiSPParameter, giatienParameter, idParameter);
        }
    
        public virtual int sp_edittaikhoan(string matkhau, string hoTen, Nullable<int> id)
        {
            var matkhauParameter = matkhau != null ?
                new ObjectParameter("matkhau", matkhau) :
                new ObjectParameter("matkhau", typeof(string));
    
            var hoTenParameter = hoTen != null ?
                new ObjectParameter("hoTen", hoTen) :
                new ObjectParameter("hoTen", typeof(string));
    
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_edittaikhoan", matkhauParameter, hoTenParameter, idParameter);
        }
    }
}
