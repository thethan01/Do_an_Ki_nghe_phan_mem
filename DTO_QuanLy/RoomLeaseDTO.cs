using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class RoomLeaseDTO
    {
        public int LeaseID { get; set; }
        public string RoomID { get; set; }
        public string LeaseDate { get; set; }
        public int CustomerAmount { get; set; }
        public Int64 RoomPrice { get; set; }
        public RoomLeaseDTO() { }
    }
}
