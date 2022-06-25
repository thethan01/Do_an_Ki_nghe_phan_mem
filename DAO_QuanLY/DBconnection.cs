using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAO_QuanLY
{
    public class DBconnection
    {
        protected static SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RLF3BM7\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True");
        //protected static SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-FL56Q9F;Initial Catalog=QuanLyKhachSan;Integrated Security=True");

    }

}
