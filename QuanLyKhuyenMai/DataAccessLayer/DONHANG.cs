//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class DONHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONHANG()
        {
            this.CHITIETDONHANGs = new HashSet<CHITIETDONHANG>();
            this.CHITIETSANPHAMTANGKEMs = new HashSet<CHITIETSANPHAMTANGKEM>();
            this.HOADONs = new HashSet<HOADON>();
        }
    
        public int MADH { get; set; }
        public Nullable<System.DateTime> NGAYTAO { get; set; }
        public string PHUONGTHUCTT { get; set; }
        public Nullable<bool> COKM { get; set; }
        public Nullable<decimal> SOLUONG { get; set; }
        public Nullable<bool> TRANGTHAI { get; set; }
        public Nullable<int> MAKH { get; set; }
        public Nullable<int> MAKM { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETSANPHAMTANGKEM> CHITIETSANPHAMTANGKEMs { get; set; }
        public virtual KHACHHANG KHACHHANG { get; set; }
        public virtual KHUYENMAI KHUYENMAI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
    }
}