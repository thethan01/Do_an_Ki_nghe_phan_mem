using DAO_QuanLY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class CustomerTypeBUS
    {
        public static DataTable GetCustomerTypeList()
        {
            return CustomerTypeDAO.GetCustomerTypeList();
        }
        public static string GetCustomerTypeByID(int typeID)
        {
            return CustomerTypeDAO.GetCustomerTypeByID(typeID);
        }
        public static bool InsertCustomerType(string customerType,int num)
        {
            if (CustomerTypeDAO.CheckCustomerType(customerType))
            {
                return false;
            }
            return CustomerTypeDAO.InsertCustomerType(customerType, num);
        }
        public static bool DeleteCustomerType(string customerType)
        {
            return CustomerTypeDAO.DeleteCustomerType(customerType);
        }
        public static bool UpdateCustomerType(string oldType,string newType,int num)
        {
            return CustomerTypeDAO.UpdateCustomerType(oldType, newType,num);
        }
    }
}
