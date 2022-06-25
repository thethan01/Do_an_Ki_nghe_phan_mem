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
    public class RoomReportDAO : DBconnection
    {
        public static bool InsertReport(RoomReportDTO report)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var command = new SqlCommand("ThemBaoCao", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Thang", report.Month));   
                command.Parameters.Add(new SqlParameter("@Nam", report.Year));
                command.Parameters.Add(new SqlParameter("@TongDoanhThu", report.RoomCostTotal));
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
        public static bool InsertRoomReportDetail(string roomID)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var command = new SqlCommand("ThemChiTietBaoCao", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@MaPhong", roomID));
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
        public static DataTable GetMonthYear()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var query = "SELECT DISTINCT Thang AS Thang, Nam AS Nam FROM BCDT\n";
                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();

                var dt = new DataTable();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
                return dt;
            }

            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        public static DataTable GetRoomReport(int month, int year)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var command = new SqlCommand("BaoCaoDoanhThuThang", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Thang", month));
                command.Parameters.Add(new SqlParameter("@Nam", year));
                command.ExecuteNonQuery();

                var dt = new DataTable();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception)
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
