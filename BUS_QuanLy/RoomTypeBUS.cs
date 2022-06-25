using DAO_QuanLY;
using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class RoomTypeBUS
    {
        public static DataTable GetRoomTypeList()
        {
            return RoomTypeDAO.GetRoomTypeList();
        }
        public static Int64 GetRoomPriceByType(string RoomType)
        {
            return RoomTypeDAO.GetRoomPriceByType(RoomType);
        }
        public static Int64 GetRoomPriceByID(string RoomID)
        {
            return RoomTypeDAO.GetRoomPriceByID(RoomID);
        }
        public static DataTable GetRoomPriceList()
        {
            return RoomTypeDAO.GetRoomPriceList();
        }
        public static bool InsertRoomType(RoomTypeDTO roomType)
        {
            if (RoomTypeDAO.CheckRoomTypeID(roomType.RoomTypeID))
            {
                return false;
            }
            return RoomTypeDAO.InsertRoomType(roomType);
        }
        public static bool UpdateRoomType(RoomTypeDTO roomType)
        {
            return RoomTypeDAO.UpdateRoomType(roomType);
        }
        public static int CountRoomWithType(string roomTypeID)
        {
            return RoomTypeDAO.CountRoomWithTypeID(roomTypeID);
        }
        public static bool DeleteRoomType(string roomTypeID)
        {
            return RoomTypeDAO.DeleteRoomType(roomTypeID);
        }
    }
}
