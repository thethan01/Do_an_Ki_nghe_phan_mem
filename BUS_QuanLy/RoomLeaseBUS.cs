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
    public class RoomLeaseBUS
    {
        public static bool InsertRoomLease(RoomLeaseDTO lease)
        {
            return RoomLeaseDAO.InsertRoomLease(lease);
        }
        public static bool InsertRoomLeasePayment(string roomID,Int64 roomprice)
        {
            return RoomLeaseDAO.InsertRoomLeasePayment(roomID,roomprice);
        }
        public static int GetLastLeaseIDOfRoom(string RoomID)
        {
            return RoomLeaseDAO.GetLastLeaseIDOfRoom(RoomID);
        }
        public static DataTable GetRentedRoomList(string date)
        {
            return RoomLeaseDAO.GetRentedRoomList(date);
        }
        public static int GetOverCustomerTaxPercent()
        {
            return RoomLeaseDAO.GetOverCustomerTaxPercent();
        }

        public static int GetForeignCustomerTaxPercent()
        {
            return RoomLeaseDAO.GetForeignCustomerTaxPercent();
        }
        public static bool UpdateOverCustomerTaxPercent(int num)
        {
            return RoomLeaseDAO.UpdateOverCustomerTaxPercent(num);
        }
        public static bool UpdateForeignCustomerTaxPercent(int num)
        {
            return RoomLeaseDAO.UpdateForeignCustomerTaxPercent(num);
        }
    }
}
