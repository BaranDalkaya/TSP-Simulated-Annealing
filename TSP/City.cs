using System;

namespace TSP
{
    public class City
    {
        public Random rnd = new Random();

        // Coordinates of city
        public int CoX { get; set; }
        public int CoY { get; set; }

        // Construct a randomly located city
        public City()
        {
            this.CoX = rnd.Next(200);
            this.CoY = rnd.Next(200);
        }

        // Construct a city with a given location
        public City(int x, int y)
        {
            this.CoX = x;
            this.CoY = y;
        }

        // Gets the distance to the given city
        public double DistanceTo(City city)
        {
            int distanceX = Math.Abs(CoX - city.CoX);
            int distanceY = Math.Abs(CoY - city.CoY);
            double distance = Math.Sqrt(Math.Pow(distanceX, 2) + Math.Pow(distanceY, 2));

            return distance;
        }
    }
}
