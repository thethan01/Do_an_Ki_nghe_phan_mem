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
    public class RoomBUS
    {
        public static DataTable GetRoomList()
        {
            return RoomDAO.GetRoomList();
        }
        public static bool InsertRoom(RoomDTO room)
        {
            if (RoomDAO.CheckRoomByID(room.RoomID) || string.IsNullOrWhiteSpace(room.RoomID))
            {
                return false;
            }
            return RoomDAO.InsertRoom(room);
        }
        public static bool UpdateRoom(RoomDTO room)
        {
            if (RoomDAO.CheckRentedRoomByID(room.RoomID))
            {
                return false;
            }
            return RoomDAO.UpdateRoom(room);
        }
        public static bool DeleteRoom(string RoomID)
        {
            if (RoomDAO.CheckRentedRoomByID(RoomID))
            {
                return false;
            }
            return RoomDAO.DeleteRoom(RoomID);
        }
        public static DataTable GetAvailableRoomList()
        {
            return RoomDAO.GetAvailableRoomList();
        }
        public static int GetMaxCustomerInRoom()
        {
            return RoomDAO.GetMaxCustomerInRoom();
        }
        public static DataTable FindRoom(string id, string type, Int64 price, string status)
        {
            return RoomDAO.FindRoom(id, type, price, status);
        }
        public static bool UpdateMaxCustomerInRoom(int num)
        {
            return RoomDAO.UpdateMaxCustomerInRoom(num);
        }
        public static DataTable GetDataForReportByMonth(string month,string year)
        {
            return RoomDAO.GetDataForReportByMonth(month, year);
        }
    }
}
