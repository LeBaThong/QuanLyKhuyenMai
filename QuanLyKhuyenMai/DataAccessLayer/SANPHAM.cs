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
    
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            this.CHITIETDONHANGs = new HashSet<CHITIETDONHANG>();
            this.CHITIETHOADONs = new HashSet<CHITIETHOADON>();
            this.CHITIETSANPHAMTANGKEMs = new HashSet<CHITIETSANPHAMTANGKEM>();
        }
    
        public int MASP { get; set; }
        public string TENSP { get; set; }
        public Nullable<int> SOLUONG { get; set; }
        public Nullable<float> GIABAN { get; set; }
        public Nullable<System.DateTime> NGAYTAO { get; set; }
        public Nullable<bool> TRANGTHAI { get; set; }
        public string MOTA { get; set; }
        public Nullable<int> MALSP { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOADON> CHITIETHOADONs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETSANPHAMTANGKEM> CHITIETSANPHAMTANGKEMs { get; set; }
        public virtual LOAISANPHAM LOAISANPHAM { get; set; }
    }
}
