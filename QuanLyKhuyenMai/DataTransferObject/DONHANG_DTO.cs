using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class DONHANG_DTO
    {
        public int MADH { get; set; }
        public Nullable<System.DateTime> NGAYTAO { get; set; }
        public string PHUONGTHUCTT { get; set; }
        public Nullable<bool> COKM { get; set; }
        public Nullable<decimal> SOLUONG { get; set; }
        public Nullable<bool> TRANGTHAI { get; set; }

        public Nullable<int> MAKH { get; set; }
        public Nullable<int> MAKM { get; set; }

        public string TENKH { get; set; }
        public string TENKM { get; set; }

        //public double TONGTIEN { get; set; }
    }
}
