using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace riozaar
{
    class order
    {
        string id;
        string name;
        string phone;
        string custId;
        string vid;
        List<string> pid;
        string location;

        public void setdata(string did, string n, string pho, string cid,string v, List<string> p,string loc)
        {
            id = did;
            name = n;
            phone = pho;
            custId = cid;
            vid = v;
            location = loc;
            pid = new List<string>(p);
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
        public string getcustid()
        {
            return custId;
        }
        public string getvid()
        {
            return vid;
        }
        public List<string> getpid()
        {
            return pid;
        }
        public string getlocation()
        {
            return location;
        }
    }
}
