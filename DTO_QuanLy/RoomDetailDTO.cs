using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class RoomDetailDTO
    {
        public int ID { get; set; }
        public string RoomID { get; set; }
        public string SUA_VAT_TU { get; set; }
        public string HONG_VAT_TU { get; set; }
        public RoomDetailDTO() { }
    }
}
