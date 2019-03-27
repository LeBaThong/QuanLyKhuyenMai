using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataProvider
    {
        public static QuanLyKhuyenMaiEntities db;
        public static QuanLyKhuyenMaiEntities dbContext
        {
            get
            {
                if (db == null)
                    db = new QuanLyKhuyenMaiEntities();
                return db;
            }
        }
    }
}
