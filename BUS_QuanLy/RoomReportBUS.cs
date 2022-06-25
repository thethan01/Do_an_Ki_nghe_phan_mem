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
    public class RoomReportBUS
    {
        public static DataTable GetRoomReport(int month, int year)
        {
            return RoomReportDAO.GetRoomReport(month, year);
        }
        public static DataTable GetMonthYear()
        {
            return RoomReportDAO.GetMonthYear();
        }
        public static bool InsertReport(RoomReportDTO report)
        {
            return RoomReportDAO.InsertReport(report);
        }
        public static bool InsertRoomReportDetail(string roomID)
        {
            return RoomReportDAO.InsertRoomReportDetail(roomID);
        }
    }

}
