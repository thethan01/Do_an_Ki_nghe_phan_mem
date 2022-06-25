using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class RoomDTO
    {
        public string RoomID { get; set; }
        public string RoomTypeID { get; set; }
        public string RoomNote { get; set; }
        public string RoomStatus { get; set; }
        public RoomDTO() { }
    }
}
