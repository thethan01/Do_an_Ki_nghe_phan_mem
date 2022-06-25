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
    public class RoomDetailDAO:DBconnection
    {
        public static DataTable GetRoomDetailList(string RoomId)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                var query = $"SELECT * FROM CT_PHONG WHERE ROOM_ID='{RoomId}' ";

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
        public static bool InsertRoomDetail(RoomDetailDTO room)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var command = new SqlCommand("RoomDetail_Insert", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ROOM_ID", room.RoomID));
                command.Parameters.Add(new SqlParameter("@HONG_VAT_TU", room.HONG_VAT_TU));
                command.Parameters.Add(new SqlParameter("@SUA_VAT_TU", room.SUA_VAT_TU));

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

        public static DataTable GetInfoCustomerByCMND(string cMND)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                var query = $"SELECT CTPT.MaPTP, CMND, MaloaiKhachHang, CTPT.KhachHang, DiaChi FROM CTPT"
                        + " LEFT JOIN PHIEUTHUE ON CTPT.MaPTP=PHIEUTHUE.MaPTP"
                        + " WHERE SoHD IS NULL AND CMND=N'" + cMND + "'";

                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();

                var dt = new DataTable();
                var adapter = new SqlDataAdapter(command);
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

        public static bool UpdateRoomDetail(RoomDetailDTO room)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var command = new SqlCommand("RoomDetail_Update", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ROOM_ID", room.RoomID));
                command.Parameters.Add(new SqlParameter("@HONG_VAT_TU", room.HONG_VAT_TU));
                command.Parameters.Add(new SqlParameter("@SUA_VAT_TU", room.SUA_VAT_TU));
                command.Parameters.Add(new SqlParameter("@ID", room.ID));

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
        public static bool DeleteRoomDetail(string RoomID, int ID)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var query = $"DELETE CT_PHONG WHERE ROOM_ID = '{RoomID}' AND ID={ID}";
                query = query + $" declare @COUNTS as int";
                query = query + $" select @COUNTS = COUNT(ID) FROM CT_PHONG WHERE ROOM_ID='{RoomID}' AND HONG_VAT_TU=''";
                query = query + $" declare @COUNTH as int";
                query = query + $" select @COUNTH = COUNT(ID) FROM CT_PHONG WHERE ROOM_ID='{RoomID}' AND SUA_VAT_TU=''";
                query = query + $" IF @COUNTS=0";
                query = query + $" BEGIN";
                query = query + $" UPDATE PHONG SET MaTinhTrang='PHTR' WHERE MaPhong='{RoomID}'";
                query = query + $" END";
                query = query + $" IF @COUNTH=0";
                query = query + $" BEGIN";
                query = query + $" UPDATE PHONG SET MaTinhTrang='PHTR' WHERE MaPhong='{RoomID}'";
                query = query + $" END";
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
        //list customer
        public static DataTable GetRoomDetailListCustomer(string RoomId)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                var command = new SqlCommand("RoomDetail_GetListCustomer", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ROOM_ID", RoomId));
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
        public static bool RoomDetail_InsertCustomer(string RoomId,string CMND,int MA_LOAI_KHACH,string TEN_KHACH,string DIA_CHI)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var command = new SqlCommand("RoomDetail_InsertCustomer", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ROOM_ID", RoomId));
                command.Parameters.Add(new SqlParameter("@CMND", CMND));
                command.Parameters.Add(new SqlParameter("@MA_LOAI_KHACH", MA_LOAI_KHACH));
                command.Parameters.Add(new SqlParameter("@NAME", TEN_KHACH));
                command.Parameters.Add(new SqlParameter("@DIACHI", DIA_CHI));
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
        public static bool RoomDetail_UpdateCustomer(string RoomId, string CMND, int MA_LOAI_KHACH, string TEN_KHACH, string DIA_CHI, string CMND_OLD)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var command = new SqlCommand("RoomDetail_UpdateCustomer", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ROOM_ID", RoomId));
                command.Parameters.Add(new SqlParameter("@CMND", CMND));
                command.Parameters.Add(new SqlParameter("@MA_LOAI_KHACH", MA_LOAI_KHACH));
                command.Parameters.Add(new SqlParameter("@NAME", TEN_KHACH));
                command.Parameters.Add(new SqlParameter("@DIACHI", DIA_CHI));
                command.Parameters.Add(new SqlParameter("@CMND_OLD", CMND_OLD));
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
        public static bool RoomDetail_DeleteCustomer(string RoomId, string CMND)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                var command = new SqlCommand("RoomDetail_DeleteCustomer", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ROOM_ID", RoomId));
                command.Parameters.Add(new SqlParameter("@CMND", CMND));

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
        public static DataTable GetListCustomer()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                var query = $"SELECT CMND,  CTPT.KhachHang FROM CTPT"
                        + " LEFT JOIN PHIEUTHUE ON CTPT.MaPTP=PHIEUTHUE.MaPTP"
                        + " WHERE SoHD IS NULL";

                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();

                var dt = new DataTable();
                var adapter = new SqlDataAdapter(command);
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
    }
}
