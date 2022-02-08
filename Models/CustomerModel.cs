using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_on_Customer_Single_view_EF.Models
{
    public class CustomerModel
    {
        public int Cid { get; set; }
        public string cname { get; set; }
        public string cloc { get; set; }
        public string cmail { get; set; }
        collegeEntities1 objef = new collegeEntities1();
        public IQueryable GetCustomer()
        {
            return objef.customers;
        }
        public int InsertCustomer()
        {
            customer objcus = new customer();
            objcus.custid = Cid;
            objcus.custname = cname;
            objcus.custloc = cloc;
            objcus.cmailid = cmail;
            try
            {
                objef.customers.Add(objcus);
                objef.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int DeleteCustomer()
        {
            customer objcus = objef.customers.Find(Cid);
            try
            {
                objef.customers.Remove(objcus);
                objef.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int UpdateCustomer()
        {
            customer objcus = objef.customers.Find(Cid);
            objcus.custloc = cloc;
            try
            {
                objef.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}