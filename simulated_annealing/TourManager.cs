using System;
using System.Collections.Generic;
using System.Text;

namespace simulated_annealing
{
    class TourManager
    {
        // Holds our cities
        private static List<City> destinationCities = new List<City>();

        // Adds a destination city
        public static void AddCity(City city)
        {
            destinationCities.Add(city);
        }

        // Get a city
        public static City GetCity(int index)
        {
            return destinationCities[index];
        }

        // Get the number of destination cities
        public static int NumberOfCities()
        {
            return destinationCities.Count;
        }
    }
}
