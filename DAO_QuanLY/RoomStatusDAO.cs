using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_QuanLY
{
    public class RoomStatusDAO : DBconnection
    {
        public static DataTable GetRoomStatusList()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var query = $"SELECT * FROM TinhTrang";
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
    }
}
