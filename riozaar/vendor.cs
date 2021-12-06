using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace riozaar
{
    class vendor
    {
        string id;
        string name;
        string phone;
        string[] days;
        string location;
        string[] start_time;
        string[] end_time;
        
        public vendor()
        {
            days = new string[7];
            start_time = new string[7];
            end_time = new string[7];
        }
        public void setdata(string did, string n, string pho, string[] d ,string [] st,string[] et, string loc)
        {
            id = did;
            name = n;
            phone = pho;
            for (int i=0;i<7;i++)
            {
                days[i] = d[i];
                start_time[i] = st[i];
                end_time[i] = et[i];
            }
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
        
        public string[] getdays()
        {
            return days;
        }
        public string[] getst()
        {
            return start_time;
        }
        public string[] getet()
        {
            return end_time;
        }
        public string getlocation()
        {
            return location;
        }
    }
}
