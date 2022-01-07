using System;
using System.Collections.Generic;
using System.Text;

namespace OysterCode.BusinessLogic
{
    public class Journey
    {
        public string Medium { get; set; }
        public string Station1 { get; set; }
        public string Station2 { get; set; }
        public double Amount { get; set; }

        public Journey()
        {
        }

        public Journey(string medium, string station1, string station2, double amount)
        {
            AddJourney(medium, station1, station2, amount);
        }


        public void AddJourney(string medium, string station1, string station2, double amount)
        {
            Medium = medium;
            Station1 = station1;
            Station2 = station2;
            Amount = amount;
        }

        public void Start()
        {
            double fare = 0;
            string isCont;
            Stations oysterStation = new Stations();
            ZoneStations oysterZoneStations = new ZoneStations();
            Fares fares = new Fares(oysterZoneStations);
            JourneyList journeyList = new JourneyList();
            do
            {
                GetInput(oysterStation, out int sourceStationId, out int destinationStationId, out int m1);
                double journeyFare = fares.CaluculateFare(oysterStation, oysterZoneStations, sourceStationId, destinationStationId, m1);
                fare += journeyFare;
                string medium = (m1 == 1) ? "Tube" : "Bus";
                Journey j = new Journey(medium, oysterStation.GetStation(sourceStationId), oysterStation.GetStation(destinationStationId), journeyFare);
                journeyList.Journeys.Add(j);
                Console.WriteLine(String.Format("Total Fare is {0:0.00}", fare));
                Console.WriteLine("Press any key to continue journey or n for exist?");
                isCont = Console.ReadLine();

            }
            while (isCont != "n");

            

            journeyList.PrintJourneyList();
        }

        public void GetInput(Stations oysterStation, out int sourceStationId, out int destinationStationId, out int m1)
        {
            Console.Clear();
            Console.WriteLine("Press 1 for tube or 2 bus journey.");
            string medium = Console.ReadLine();
            m1 = int.Parse(medium);

            Console.Clear();
            int count = 0;
            do
            {
                oysterStation.PrintStations();
                if (count > 0)
                {
                    Console.WriteLine("Invalid choice!");
                }
                
                 Console.WriteLine("Enter source");
               
                string source = Console.ReadLine();
                int s1 = int.Parse(source);
                sourceStationId = s1;
                count++;
            }
            while (!(sourceStationId == 1 || sourceStationId == 2 || sourceStationId == 3 || sourceStationId == 4 || sourceStationId == 5 || sourceStationId == 6));
            count = 0;
            do
            {
                Console.Clear();
               Console.WriteLine(string.Format("Selected source is {0} ",  oysterStation.GetStation(sourceStationId)));
                oysterStation.PrintStations();
                if (count >  0)
                {
                    Console.WriteLine("Invalid choice!");
                }
                
                Console.WriteLine("Enter destination or 0 for exit");
                

                string destination = Console.ReadLine();
                destinationStationId = int.Parse(destination);
                count++;
            }
            while (((sourceStationId == destinationStationId) || !(destinationStationId == 0 || destinationStationId == 1 || destinationStationId == 2 || destinationStationId == 3
            || destinationStationId == 4 || destinationStationId == 5 || destinationStationId == 6)));

            Console.Clear();
        }

        public string PrintJourney()
        {
            return String.Format("{0} {1} to {2}, fare is {3:0.00}", Medium, Station1, Station2, Amount);
        }

    }


    public class JourneyList
    {
        public List<Journey> Journeys { get; set; }
        public int cardAmount = 30;

        public JourneyList()
        {
            Journeys = new List<Journey>();
        }

        public JourneyList(Journey journey)
        {
            Journeys.Add(journey);
        }

        public JourneyList(List<Journey> journey)
        {
            Journeys.AddRange(journey);
        }


        public void PrintJourneyList()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("------------S U M M A R Y------------");
            Console.WriteLine("-------------------------------------");
            Journeys.ForEach(a => Console.WriteLine(a.PrintJourney()));
            Console.WriteLine("-------------------------------------");
            double total = 0;
            Journeys.ForEach(a => total += a.Amount);
            Console.WriteLine(String.Format("Total amount is {0:0.00}" , total));

            Console.WriteLine(String.Format("Balance is {0:0.00}", (cardAmount - total)));

        }

    }
}
