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
    using System.Collections.Generic;
    
    public partial class donhang
    {
        public int id { get; set; }
        public string tenkhachhang { get; set; }
        public Nullable<float> tongtien { get; set; }
        public Nullable<float> giamgia { get; set; }
        public Nullable<float> thanhtoan { get; set; }
        public Nullable<int> taikhoanid { get; set; }
    
        public virtual taikhoan taikhoan { get; set; }
    }
}
