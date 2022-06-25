using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_QuanLY
{
    public class CustomerTypeDAO : DBconnection
    {
        public static DataTable GetCustomerTypeList()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var query = "SELECT MaLoaiKhachHang, TenLoaiKhachHang,HeSoPhuThu * 100 AS HeSoPhuThu FROM LOAIKHACH WHERE KhaDung = 1";
                var command = new SqlCommand(query, connection);
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
        public static string GetCustomerTypeByID(int typeID)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var query = $"SELECT TenLoaiKhachHang FROM LoaiKhach WHERE MaLoaiKhachHang = {typeID}";
                var command = new SqlCommand(query, connection);
                var result = command.ExecuteScalar().ToString();
                return result;
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
        public static bool CheckCustomerType(string customerType)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var query = $"SELECT * FROM LoaiKhach\n" +
                    $"WHERE TenLoaiKhachHang = N'{customerType}' AND KhaDung = 1";
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
        public static bool InsertCustomerType(string customerType,int num)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                var command = new SqlCommand("ThemLoaiKhach", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@TenLoaiKhachHang", customerType));
                command.Parameters.Add(new SqlParameter("@HeSoPhuThu", num));
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
        public static bool DeleteCustomerType(string customerType)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var command = new SqlCommand("XoaLoaiKhach", connection);
                command.CommandType = CommandType.StoredProcedure;  
                command.Parameters.Add(new SqlParameter("@TenLoaiKhachHang", customerType));
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
        public static bool UpdateCustomerType(string oldType, string newType,int num)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var query = "UPDATE LoaiKhach\n" +
                    $"SET TenLoaiKhachHang = N'{newType}', HeSoPhuThu = CAST({num} AS FLOAT) / 100\n" +
                    $"WHERE TenLoaiKhachHang = N'{oldType}'";

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
