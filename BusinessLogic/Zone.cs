using System;
using System.Collections.Generic;
using System.Text;

namespace OysterCode.BusinessLogic
{
    public class Zone
    {
        public int ZoneID { get; set; }
        public string ZoneName { get; set; }

        public Zone() { 
        
        }

        public Zone(int zoneId, string zoneName) {
            AddZone(zoneId,zoneName);
        }


        void AddZone(int zoneId, string zoneName) {
            ZoneID = zoneId;
            ZoneName = zoneName;
        }

        
    }


    public class Zones
    {
        
        public List<Zone> ZoneLst { get; set; }

        public Zones()
        {
            ZoneLst = new List<Zone>();
            AddZones();
        }    
        

        void AddZones()
        {
            int id = 1;
            
            ZoneLst.Add(new Zone(id++, "Zone 1"));
            ZoneLst.Add(new Zone(id++, "Zone 2"));
            ZoneLst.Add(new Zone(id++, "Zone 3"));

        }

        public void PrintZones() {
            this.ZoneLst.ForEach(a => Console.WriteLine(string.Format("Zone detail {0}, {1}", a.ZoneID, a.ZoneName)));
        }


    }



    public class ZoneFare
    {
        public int Zone1ID { get; set; }
        public int Zone2ID { get; set; }
        public double Fare { get; set; }

        

        public ZoneFare(int zoneId, int zone2Id, double amount)
        {
            Zone1ID = zoneId;
            Zone2ID = zone2Id;
            Fare = amount;
        }

    }
}
