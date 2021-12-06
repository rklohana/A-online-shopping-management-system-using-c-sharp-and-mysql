using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace riozaar
{
    class bazaar
    {
        string id;
        string st;
        string ed;
        int shops;
        List<string> location;
        
        public void setdata(string did, string st_time, string ed_time, int n,List<string> locs)
        {
            id = did;
            st = st_time;
            ed = ed_time;
            location = new List<string>(locs);
            shops = n;
            
        }
        public string getst()
        {
            return st;
        }
        public string getdid()
        {
            return id;
        }
        public string geted()
        {
            return ed;
        }
        public int getshops()
        {
            return shops;
        }
        public List<string> getlocation()
        {
            return location;
        }
    }
}
