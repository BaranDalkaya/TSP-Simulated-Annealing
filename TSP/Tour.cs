using System;
using System.Collections.Generic;
using System.Linq;

namespace TSP
{
    public class Tour
    {
        public Random rnd = new Random();

        // PROPERTIES and FIELDS
        // Holds our path of cities
        private double distance = 0;
        private List<City> tour = new List<City>();


        // CONSTRUCTORS
        // Construct a blank tour
        public Tour()
        {
            for (int i = 0; i < TourManager.NumOfCities(); i++)
            {
                tour.Add(null);
            }
        }

        // Copy our path not to change original (Pass by Ref)
        public Tour(List<City> tour)
        {
            this.tour = new List<City>(tour);
        }


        // METHODS
        // create a person for the tour
        public void GenerateIndividual()
        {
            // Loop through all our cities and add them to our tour
            for (int i = 0; i < TourManager.NumOfCities(); i++)
            {
                SetCity(i, TourManager.GetCity(i));
            }
            // Randomly shuffle our list of cities
            tour = tour.OrderBy(x => rnd.Next()).ToList();
        }

        public List<City> GetTour() => tour;

        // Set a specific index in tour with a city
        public void SetCity(int tourPosition, City city)
        {
            tour[tourPosition] = city;

            // If the tour has been altered we reset the distance
            distance = 0;
        }

        // Get a city from the tour list
        public City GetCity(int tourPosition) => tour[tourPosition];

        // return the number of cities in our tour
        public int tourCount() => tour.Count;


        // Get the total distance of current tour path
        public double GetDistance()
        {
            if(distance == 0)
            {
                double tourDistance = 0;
                for (int cityIndex = 0; cityIndex < tourCount(); cityIndex++)
                {
                    City fromCity = tour[cityIndex];
                    City toCity;
                    if (cityIndex == tourCount() - 1)
                    {
                        toCity = tour[0];
                    }
                    else
                    {
                        toCity = tour[cityIndex + 1];
                    }

                    tourDistance += fromCity.DistanceTo(toCity);
                }

                distance = tourDistance;
            }
            return distance;
        }

    }
}
