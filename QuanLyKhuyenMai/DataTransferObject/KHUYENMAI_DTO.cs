using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class KHUYENMAI_DTO
    {
        public int MAKM { get; set; }
        public string TENKM { get; set; }
        public Nullable<int> MALKH { get; set; }
        public Nullable<int> MALSP { get; set; }
        public Nullable<int> MAHTTK { get; set; }
        public Nullable<int> MAHTVC { get; set; }
        public Nullable<int> MAHTGG { get; set; }

        public string TENLKH { get; set; }
        public string TENHT { get; set; }
        public string TENLSP { get; set; }

        public Nullable<System.DateTime> NGAYBATDAU { get; set; }
        public Nullable<System.DateTime> NGAYKETTHUC { get; set; }
        public string MOTA { get; set; }
        public Nullable<bool> TRANGTHAI { get; set; }

        
       

    }
}
