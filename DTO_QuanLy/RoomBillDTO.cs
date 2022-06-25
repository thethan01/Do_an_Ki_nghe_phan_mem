using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class RoomBillDTO
    {
        public int BillID { get; set; }
        public string BillDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public Int64 BillCost { get; set; }
        public RoomBillDTO() { }
    }
}
