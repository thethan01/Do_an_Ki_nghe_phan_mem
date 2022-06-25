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
    public class RoomBillDAO : DBconnection
    {
        public static bool InsertRoomBill(RoomBillDTO bill)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var command = new SqlCommand("ThemHoaDon", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@KhachHang", bill.CustomerName));
                command.Parameters.Add(new SqlParameter("@DiaChi", bill.CustomerAddress));
                command.Parameters.Add(new SqlParameter("@NgayLap", bill.BillDate));
                command.Parameters.Add(new SqlParameter("@TongTien", bill.BillCost));
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

        }
        

        public static DataTable GetLeasePayment(string roomID, string date)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var command = new SqlCommand("TimChiTietThanhToan", connection);
                command.CommandType = CommandType.StoredProcedure;  
                command.Parameters.Add(new SqlParameter("@MaPhong", roomID));
                command.Parameters.Add(new SqlParameter("@NgayThanhToan", date));
                command.ExecuteNonQuery();

                var adapter = new SqlDataAdapter(command);
                var dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch (SqlException)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
