using System;
using System.Collections.Generic;
using System.Text;

namespace OysterCode.BusinessLogic
{
    public class Station
    {
        public int StationID { get; set; }
        public string StationName { get; set; }
        public Station()
        {

        }

        public Station(int stationId, string stationName)
        {
            AddStation(stationId, stationName);
        }


        void AddStation(int stationId, string stationName)
        {
            StationID = stationId;
            StationName = stationName;
        }

    }


    public class Stations
    {
        public List<Station> StationLst { get; set; }

        public Stations()
        {
            StationLst = new List<Station>();
            AddStations();
        }


        void AddStations()
        {
            int id = 1;

            StationLst.Add(new Station(id++, "Holborn"));
            StationLst.Add(new Station(id++, "Aldgate"));
            StationLst.Add(new Station(id++, "Earl’s Court"));
            StationLst.Add(new Station(id++, "Hammersmith"));
            StationLst.Add(new Station(id++, "Arsenal"));
            StationLst.Add(new Station(id++, "Wimbledon"));
            StationLst.Add(new Station(id++, "Chelsea"));

        }

        public void PrintStations()
        {
            this.StationLst.ForEach(a =>
            {
                Console.WriteLine(string.Format("Station {0}, {1}", a.StationID, a.StationName));
            });
        }

        public string GetStation(int stationId)
        {
            string stationName = "Default";
            Station st = StationLst.Find(a => a.StationID == stationId);
            if (st != null)
            {
                stationName = st.StationName;
            }
            return stationName;
        }


    }
}
