using System;
using System.Collections.Generic;
using System.Data;
using DAO_QuanLY;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLy;

namespace BUS_QuanLy
{
   public class RoomBillBUS
    {
        public static bool InsertBill(RoomBillDTO bill)
        {
            return RoomBillDAO.InsertRoomBill(bill);
        }
        public static DataTable GetLeasePayment(string roomID, string date)
        {
            return RoomBillDAO.GetLeasePayment(roomID, date);
        }
    }
}
