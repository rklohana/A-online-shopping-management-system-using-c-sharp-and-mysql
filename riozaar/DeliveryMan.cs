using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace riozaar
{
    class DeliveryMan
    {
        string id;
        string name;
        string phone;
        string managerId;
        string location;

        public void setdata(string did, string n, string pho, string mid,string loc)
        {
            id = did;
            name = n;
            phone = pho;
            managerId = mid;
            location = loc;
        }
        public string getname()
        {
            return name;
        }
        public string getdid()
        {
            return id;
        }
        public string getphone()
        {
            return phone;
        }
        public string getmanagerid()
        {
            return managerId;
        }
        public string getlocation()
        {
            return location;
        }
    }
}
