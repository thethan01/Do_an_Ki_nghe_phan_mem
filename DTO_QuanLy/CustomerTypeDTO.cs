using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class CustomerTypeDTO
    {
        public int CustomerTypeID { get; set; }
        public string CustomerTypeName { get; set; }
        public bool AddtionalSurcharge { get; set; }
        public CustomerTypeDTO() { }
    }
}
