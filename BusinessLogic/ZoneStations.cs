using System;
using System.Collections.Generic;
using System.Text;

namespace OysterCode.BusinessLogic
{
    public class ZoneStation
    {
        public int ZoneStationID { get; set; }
        public int ZoneID { get; set; }
        public int StationID { get; set; }

        public ZoneStation()
        {

        }

        public ZoneStation(int zoneStationId, int zoneId, int stationId)
        {
            AddZoneStation(zoneStationId, zoneId, stationId);
        }


        void AddZoneStation(int zoneStationID, int zoneId, int stationId)
        {
            ZoneStationID = zoneStationID;
            ZoneID = zoneId;
            StationID = stationId;
        }


    }


    public class ZoneStations
    {

        public List<ZoneStation> ZoneStationLst { get; set; }

        public ZoneStations()
        {
            ZoneStationLst = new List<ZoneStation>();
            AddZoneStations();
        }


        void AddZoneStations()
        {
            int id = 1;

            ZoneStationLst.Add(new ZoneStation(id++, 1, 1));
            ZoneStationLst.Add(new ZoneStation(id++, 1, 2));
            ZoneStationLst.Add(new ZoneStation(id++, 1, 3));

            ZoneStationLst.Add(new ZoneStation(id++, 2, 3));
            ZoneStationLst.Add(new ZoneStation(id++, 2, 4));
            ZoneStationLst.Add(new ZoneStation(id++, 2, 5));

            ZoneStationLst.Add(new ZoneStation(id++, 3, 6));
            ZoneStationLst.Add(new ZoneStation(id++, 3, 7));

        }

        public ZoneStation GetZoneStation(int zoneId, int stationId)
        {
            return ZoneStationLst.Find(a => a.ZoneID == zoneId && a.StationID == stationId);
        }


        public void PrintZoneStations(Stations stations)
        {
            this.ZoneStationLst.ForEach(a =>
            {
                Console.WriteLine(string.Format("zone station detail  {0}, {1}, {2}", a.ZoneStationID, a.ZoneID, stations.StationLst.Find(b => b.StationID == a.StationID).StationName));
            });

        }

        public void FindBestZone( int sourceStationId, int destinationStationId, out int zoneId1, out int zoneId2)
        {
            List<ZoneStation> lstZSSource = this.ZoneStationLst.FindAll(a => a.StationID == sourceStationId);
            List<ZoneStation> lstZSDestination = this.ZoneStationLst.FindAll(a => a.StationID == destinationStationId);
            zoneId1 = 1;
            zoneId2 = 3;
            if (lstZSSource.Count > 1 || lstZSDestination.Count > 1)
            {
                this.GetZoneForFare(lstZSSource, lstZSDestination, out zoneId1, out zoneId2);
            }
            else
            {
                zoneId1 = lstZSSource[0].ZoneID;
                if (lstZSDestination.Count != 0)
                {
                    zoneId2 = lstZSDestination[0].ZoneID;
                }
            }
        }

        public void GetZoneForFare(List<ZoneStation> lstZSSource, List<ZoneStation> lstZSDestination, out int zoneId1, out int zoneId2)
        {
            zoneId1 = 1;
            zoneId2 = 3;
            if (lstZSSource.Count > 1)
            {
                if (lstZSDestination != null)
                {
                    int zoneID = lstZSDestination[0].ZoneID;
                    var zs = lstZSSource.Find(a => a.ZoneID == zoneID);
                    if (zs != null)
                    {
                        zoneId1 = lstZSSource.Find(a => a.ZoneID == zoneID).ZoneID;
                    }

                    zoneId2 = lstZSDestination[0].ZoneID;
                }
            }

            if (lstZSDestination.Count > 1)
            {
                if (lstZSSource != null)
                {
                    int zoneID = lstZSSource[0].ZoneID;
                    var zs = lstZSDestination.Find(a => a.ZoneID == zoneID);
                    if (zs != null)
                    {
                        zoneId2 = lstZSDestination.Find(a => a.ZoneID == zoneID).ZoneID;
                    }
                    zoneId1 = lstZSSource[0].ZoneID;
                }
            }

        }




    }
}
