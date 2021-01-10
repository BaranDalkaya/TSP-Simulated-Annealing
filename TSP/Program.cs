using System;

namespace TSP
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Random rnd = new Random();

            // Create and add our cities
            City city1 = new City();
            TourManager.AddCity(city1);
            City city2 = new City(180, 200);
            TourManager.AddCity(city2);
            City city3 = new City();
            TourManager.AddCity(city3);
            City city4 = new City(140, 180);
            TourManager.AddCity(city4);
            City city5 = new City();
            TourManager.AddCity(city5);
            City city6 = new City(100, 160);
            TourManager.AddCity(city6);
            City city7 = new City();
            TourManager.AddCity(city7);
            City city8 = new City(140, 140);
            TourManager.AddCity(city8);
            City city9 = new City();
            TourManager.AddCity(city9);
            City city10 = new City(100, 120);
            TourManager.AddCity(city10);
            City city11 = new City();
            TourManager.AddCity(city11);
            City city12 = new City();
            TourManager.AddCity(city12);
            City city13 = new City();
            TourManager.AddCity(city13);
            City city14 = new City(180, 60);
            TourManager.AddCity(city14);
            City city15 = new City(20, 40);
            TourManager.AddCity(city15);
            City city16 = new City();
            TourManager.AddCity(city16);
            City city17 = new City(200, 40);
            TourManager.AddCity(city17);
            City city18 = new City();
            TourManager.AddCity(city18);
            City city19 = new City(60, 20);
            TourManager.AddCity(city19);
            City city20 = new City(160, 20);
            TourManager.AddCity(city20);

            Console.WriteLine("No. of cities to visit: {0}", TourManager.NumOfCities());

            // Set initial Temp
            double temp = Math.Pow(10, 9);

            // cooling rate
            double coolingRate = 0.001;

            //Initialize initial solution
            var currentPath = new Tour();
            currentPath.GenerateIndividual();

            Console.WriteLine("Initial total distance: {0}", currentPath.GetDistance());

            // Set as current best
            Tour bestPath = new Tour(currentPath.GetTour());

            // Loop until system has cooled
            while (temp > 1)
            {
                Tour newPath = new Tour(currentPath.GetTour());

                // Select 2 random cities to swap in tour
                int cityIndex1 = (int)(newPath.tourCount() * rnd.NextDouble());
                int cityIndex2 = (int)(newPath.tourCount() * rnd.NextDouble());
                City citySwap1 = newPath.GetCity(cityIndex1);
                City citySwap2 = newPath.GetCity(cityIndex2);

                newPath.SetCity(cityIndex1, citySwap2);
                newPath.SetCity(cityIndex2, citySwap1);

                // Get energy of solution
                double currentEnergy = currentPath.GetDistance();
                double newEnergy = newPath.GetDistance();

                // Check if we should accept neighbour solution
                if (acceptantceProb(currentEnergy, newEnergy, temp) > rnd.NextDouble())
                {
                    currentPath = new Tour(newPath.GetTour());
                }

                // Keep track of best solution
                if (currentPath.GetDistance() < bestPath.GetDistance())
                {
                    bestPath = new Tour(currentPath.GetTour());
                }

                // Cool system
                temp *= 1 - coolingRate;
            }
            Console.WriteLine("Final solution distance: {0}", bestPath.GetDistance());

        }

        // Acceptance probability
        public static double acceptantceProb(double energy, double newEnergy, double temp)
        {
            // If new solution is better than old, return 1, else calc probability
            return (newEnergy > energy) ? 1.0 : Math.Exp((energy - newEnergy) / temp);
        }
    }
}
