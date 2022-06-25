using DAO_QuanLY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class RoomStatusBUS
    {
        public static DataTable GetRoomStatusList()
        {
            return RoomStatusDAO.GetRoomStatusList();
        }
    }
}
