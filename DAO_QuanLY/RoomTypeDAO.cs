﻿using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_QuanLY
{
    public class RoomTypeDAO : DBconnection
    {
        public static DataTable GetRoomTypeList()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var query = "SELECT MaLoaiPhong, DonGia FROM LOAIPHONG WHERE isDelete <> 1";
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
        public static Int64 GetRoomPriceByID(string roomID)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var command = new SqlCommand("TimGiaTheoMaPhong", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@MaPhong", roomID));
                var price = Convert.ToInt64(command.ExecuteScalar());
                return price;
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
        public static Int64 GetRoomPriceByType(string roomType)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                var query = $"SELECT DonGia FROM LoaiPhong WHERE MaLoaiPhong = '{roomType}'";
                var command = new SqlCommand(query, connection);
                var result = Convert.ToInt64(command.ExecuteScalar());
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
        public static DataTable GetRoomPriceList()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var query = "SELECT DISTINCT(DonGia) FROM LOAIPHONG ORDER BY DonGia";
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
        public static bool CheckRoomTypeID(string RoomTypeID)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var query = $"SELECT * FROM LoaiPhong WHERE MaLoaiPhong = '{RoomTypeID}'";
                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();

                var dt = new DataTable();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else return false;
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
        public static bool InsertRoomType(RoomTypeDTO roomType)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var query = "INSERT INTO LoaiPhong(MaLoaiPhong, DonGia)\n" +
                    $"VALUES ('{roomType.RoomTypeID}', {roomType.RoomTypePrice})";

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
        public static bool UpdateRoomType(RoomTypeDTO roomType)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var query = "UPDATE LoaiPhong\n" +
                    $"SET DonGia = {roomType.RoomTypePrice}\n" +
                    $"WHERE MaLoaiPhong = '{roomType.RoomTypeID}'";

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
        public static int CountRoomWithTypeID(string roomTypeID)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var query = $"SELECT COUNT(*) FROM Phong WHERE MaLoaiPhong = '{roomTypeID}'";
                var command = new SqlCommand(query, connection);
                var result = Convert.ToInt32(command.ExecuteScalar());
                return result;
            }

            catch (Exception)
            {
                return -1;
            }
            finally
            {
                connection.Close();
            }
        }
        public static bool DeleteRoomType(string roomTypeID)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var query = $"UPDATE LoaiPhong SET isDelete=1 WHERE MaLoaiPhong = '{roomTypeID}'";
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
