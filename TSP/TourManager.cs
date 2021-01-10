using System.Collections.Generic;

namespace TSP
{
    public class TourManager
    {
        // List to hold our cities
        private static List<City> Cities = new List<City>();

        // Add a city to our list
        public static void AddCity(City city)
        {
            Cities.Add(city);
        }

        // Get a city with index
        public static City GetCity(int index)
        {
            return Cities[index];
        }

        // Get no. of cities in our list
        public static int NumOfCities()
        {
            return Cities.Count;
        }
    }
}
