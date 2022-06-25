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
    public class RoomDAO : DBconnection
    {
        public static DataTable GetRoomList()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                var command = new SqlCommand("LietKeDanhMucPhong", connection);
                command.CommandType = CommandType.StoredProcedure;
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
        public static bool CheckRoomByID(string RoomID)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var query = $"SELECT * FROM Phong WHERE MaPhong = {RoomID}";
                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();

                var dt = new DataTable();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    return true;
                }
                else return false;
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

        public static DataTable GetDataForReportByMonth(string month, string year)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var command = new SqlCommand("GetDataForReportByMonthAndYear", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@month", month));
                command.Parameters.Add(new SqlParameter("@year", year));
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

        public static bool InsertRoom(RoomDTO room)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var command = new SqlCommand("ThemPhong", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@MaPhong", room.RoomID));
                command.Parameters.Add(new SqlParameter("@MaLoaiPhong", room.RoomTypeID));
                command.Parameters.Add(new SqlParameter("@MaTinhTrang", room.RoomStatus));

                if (!string.IsNullOrWhiteSpace(room.RoomNote))
                {
                    command.Parameters.Add(new SqlParameter("GhiChu", room.RoomNote));
                }

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
        public static bool UpdateRoom(RoomDTO room)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var command = new SqlCommand("SuaPhong", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@MaPhong", room.RoomID));
                command.Parameters.Add(new SqlParameter("@MaLoaiPhong", room.RoomTypeID));
                command.Parameters.Add(new SqlParameter("@MaTinhTrang", room.RoomStatus));

                if (!string.IsNullOrWhiteSpace(room.RoomNote))
                {
                    command.Parameters.Add(new SqlParameter("GhiChu", room.RoomNote));
                }

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
        public static bool DeleteRoom(string RoomID)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var query = $"DELETE Phong WHERE MaPhong = '{RoomID}'";
                var command = new SqlCommand(query, connection);
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
        public static DataTable GetAvailableRoomList()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var query = "SELECT MaPhong FROM Phong\n" +
                    "WHERE MaTinhTrang = 'PHTR'\n" +
                    "AND MaLoaiPhong IS NOT NULL";

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
        public static bool CheckRentedRoomByID(string RoomID)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var query = $"SELECT * FROM Phong " +
                    $"WHERE MaPhong = {RoomID} " +
                    $"AND MaTinhTrang = 'PHTH'";

                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();

                var dt = new DataTable();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    return true;
                }
                else return false;
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
        public static int GetMaxCustomerInRoom()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                var query = "SELECT GiaTri FROM ThamSo WHERE TenThamSo = 'SoKhachToiDa'";
                var command = new SqlCommand(query, connection);
                var result = Convert.ToInt32(command.ExecuteScalar());
                return result;
            }
            catch
            {
                return -1;
            }
            finally
            {
                connection.Close();
            }
        }
        public static DataTable FindRoom(string id, string type, Int64 price, string status)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var command = new SqlCommand("TraCuuPhong", connection);
                command.CommandType = CommandType.StoredProcedure;


                command.Parameters.Add(new SqlParameter("@MaPhong", id));
                command.Parameters.Add(new SqlParameter("@MaLoaiPhong", type));
                command.Parameters.Add(new SqlParameter("@MaTinhTrang", status));

                if (price != -1)
                {
                    command.Parameters.Add(new SqlParameter("@DonGia", price));
                }

                command.ExecuteNonQuery();
                var adapter = new SqlDataAdapter(command);
                var dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        public static bool UpdateMaxCustomerInRoom(int num)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var query = "UPDATE THAMSO\n" +
                    $"SET GiaTri = {num}\n" +
                    "WHERE TenThamSo = 'SoKhachToiDa'";

                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                return true;
            }

            catch (Exception)
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
