using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace riozaar
{
    class product
    {
        string id;
        string name;
        string image;
        string description;
        string vendorid;
        public void setdata(string pid,string n, string im, string des,string vid)
        {
            id = pid;
            name = n;
            image = im;
            description = des;
            vendorid = vid;
        }
        public string getname()
        {
            return name;
        }
        public string getpid()
        {
            return id;
        }
        public string getimage()
        {
            return image;
        }
        public string getdescription()
        {
            return description;
        }
        public string getvid()
        {
            return vendorid;
        }

    }
}
