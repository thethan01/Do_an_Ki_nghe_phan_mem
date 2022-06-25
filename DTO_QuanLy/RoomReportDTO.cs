using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class RoomReportDTO
    {
        public int RoomReportID { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public Int64 RoomCostTotal { get; set; }
        public RoomReportDTO() { }
    }
}
