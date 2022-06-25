using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_QuanLY
{
    public class RoomLeaseDetailDAO : DBconnection
    {
        public static bool InsertDetail(RoomLeaseDetailDTO detail)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var command = new SqlCommand("ThemChiTietPhieuThue", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@MaPTP", detail.LeaseID));
                command.Parameters.Add(new SqlParameter("@CMND", detail.CustomerID));
                command.Parameters.Add(new SqlParameter("@MaLoaiKhachHang", detail.CustomerTypeID));
                command.Parameters.Add(new SqlParameter("@KhachHang", detail.CustomerName));
                command.Parameters.Add(new SqlParameter("@DiaChi", detail.CustomerAddress));
                command.ExecuteNonQuery();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
