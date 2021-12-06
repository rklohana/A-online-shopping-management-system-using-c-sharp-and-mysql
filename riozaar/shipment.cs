using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace riozaar
{
    class shipment
    {
        string id;
        string orderId;
        string DMid;
        string status;
        string paymentstatus;
        string location;

        public void setdata(string did, string oid, string dmid, string st, string pst,string loc)
        {
            id = did;
            orderId = oid;
            DMid = dmid;
            status= st;
            paymentstatus = pst;
            location = loc;
        }
        public string getoid()
        {
            return orderId;
        }
        public string getdid()
        {
            return id;
        }
        public string getdmid()
        {
            return DMid;
        }
        public string getstatus()
        {
            return status;
        }
        public string getpstatus()
        {
            return paymentstatus;
        }
        public string getlocation()
        {
            return location;
        }
    }
}
