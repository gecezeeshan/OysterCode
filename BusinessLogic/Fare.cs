using System;
using System.Collections.Generic;
using System.Text;

namespace OysterCode.BusinessLogic
{
    public class Fare
    {

        public int FareID { get; set; }
        public int StartZoneId { get; set; }
        public int EndZoneId { get; set; }
        public double Amount { get; set; }


        public Fare()
        {

        }

        public Fare(int fareId, int zoneId1, int zoneId2, double amount)
        {
            AddFare(fareId, zoneId1, zoneId2, amount);
        }


        void AddFare(int fareId, int zoneId1, int zoneId2, double amount)
        {
            FareID = fareId;
            StartZoneId = zoneId1;
            EndZoneId = zoneId2;
            Amount = amount;
        }


    }



    public class Fares
    {

        public List<Fare> FareLst { get; set; }

        public Fares()
        {
            FareLst = new List<Fare>();
            AddFares();
        }


        void AddFares()
        {
            int id = 1;
            /*
            Anywhere in Zone 1 £2.50 From Holborn to Aldgate
            Any one zone outside zone 1 £2.00 From Arsenal to Hammersmith
            Any two zones including zone 1 £3.00 From Hammersmith to Holborn
            Any two zones excluding zone 1 £2.25 From Arsenal to Wimbledon
            More than two zones (3+) £3.20 From Wimbledon to Aldgate
            Any bus journey £1.80 Earl’s Court to Chelsea
            */
            //Anywhere in Zone 1 cost 2.50.
            FareLst.Add(new Fare(id++, 1, 1, 2.50));

            //Any one zone outside zone 1 £2.00
            FareLst.Add(new Fare(id++, 2, 2, 2.00));
            FareLst.Add(new Fare(id++, 3, 3, 2.00));

            //Any two zones including zone 1 £3.00 
            FareLst.Add(new Fare(id++, 1, 2, 3.00));
            FareLst.Add(new Fare(id++, 2, 1, 3.00));


            //Any two zones excluding zone 1  £2.25
            FareLst.Add(new Fare(id++, 2, 3, 2.25));
            FareLst.Add(new Fare(id++, 3, 2, 2.25));

            //More than two zones (3+)  £3.20
            FareLst.Add(new Fare(id++, 1, 3, 3.20));
            FareLst.Add(new Fare(id++, 3, 1, 3.20));

        }



       

        public double CaluculateFare(Stations oysterStation, ZoneStations oysterZoneStations, int sourceStationId,  int destinationStationId,  int m1)
        {            
            double fare;
            if (m1 == 2)
            {
                fare = 1.80;
            }
            else
            {
                
                oysterZoneStations.FindBestZone(sourceStationId, destinationStationId, out int zoneId1, out int zoneId2);
                fare = GetFare(zoneId1, zoneId2);
            }
            Console.WriteLine(String.Format("The fare from {1} to {2} is {0:0.00} ", fare, oysterStation.GetStation(sourceStationId), oysterStation.GetStation(destinationStationId)));
            return fare;
        }

        public double GetFare(int s1, int s2)
        {
            return this.FareLst.Find(a => a.StartZoneId == s1 && a.EndZoneId == s2).Amount;
        }

    }
}
