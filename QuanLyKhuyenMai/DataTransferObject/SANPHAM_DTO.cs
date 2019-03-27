using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class SANPHAM_DTO
    {
        public int MASP { get; set; }
        public string TENSP { get; set; }
        public int SOLUONG { get; set; }
        public Nullable<int> MALSP { get; set; }
        public string TENLSP { get; set; }
    }
}
