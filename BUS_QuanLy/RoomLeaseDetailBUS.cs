using DAO_QuanLY;
using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class RoomLeaseDetailBUS
    {
        public static bool InsertDetail(RoomLeaseDetailDTO detail)
        {
            return RoomLeaseDetailDAO.InsertDetail(detail);
        }
    }
}
