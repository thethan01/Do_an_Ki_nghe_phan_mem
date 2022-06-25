using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class RoomLeaseDetailDTO
    {
        public int LeaseID { get; set; }
        public string CustomerName { get; set; }
        public int CustomerTypeID { get; set; }
        public string CustomerID { get; set; }
        public string CustomerAddress { get; set; }
        public RoomLeaseDetailDTO() { }
    }
}
