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
    public class RoomDetailBUS
    {
        public static DataTable GetRoomDetailList(string RoomId)
        {
            return RoomDetailDAO.GetRoomDetailList(RoomId);
        }
        public static bool InsertRoomDetail(RoomDetailDTO room)
        {
            return RoomDetailDAO.InsertRoomDetail(room);
        }
        public static bool UpdateRoomDetail(RoomDetailDTO room)
        {
            return RoomDetailDAO.UpdateRoomDetail(room);
        }
        public static bool DeleteRoomDetail(string RoomID, int ID)
        {
            return RoomDetailDAO.DeleteRoomDetail(RoomID,ID);
        }
        
        //khach hang
        public static DataTable GetRoomDetailListCustomer(string RoomId)
        {
            return RoomDetailDAO.GetRoomDetailListCustomer(RoomId);
        }
        public static bool RoomDetail_InsertCustomer(string RoomId, string CMND, int MA_LOAI_KHACH, string TEN_KHACH, string DIA_CHI)
        {
            return RoomDetailDAO.RoomDetail_InsertCustomer(RoomId,  CMND,  MA_LOAI_KHACH,  TEN_KHACH,  DIA_CHI);

        }
        public static bool RoomDetail_UpdateCustomer(string RoomId, string CMND, int MA_LOAI_KHACH, string TEN_KHACH, string DIA_CHI, string cmnd_old)
        {
            return RoomDetailDAO.RoomDetail_UpdateCustomer(RoomId, CMND, MA_LOAI_KHACH, TEN_KHACH, DIA_CHI, cmnd_old);

        }
        public static bool RoomDetail_DeleteCustomer(string RoomId, string CMND)
        {
            return RoomDetailDAO.RoomDetail_DeleteCustomer(RoomId,  CMND);

        }
        public static DataTable GetListCustomer()
        {
            return RoomDetailDAO.GetListCustomer();
        }
        public static DataTable GetInfoCustomerByCMND(string CMND)
        {
            return RoomDetailDAO.GetInfoCustomerByCMND(CMND);
        }
    }
}
