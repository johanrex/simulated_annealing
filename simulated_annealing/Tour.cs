﻿using System;
using System.Collections.Generic;
using System.Text;

namespace simulated_annealing
{
    class Tour
    {
        // Holds our tour of cities
        private List<City> tour = new List<City>();
        // Cache
        private double distance = 0;

        // Constructs a blank tour
        public Tour()
        {
            for (int i = 0; i < TourManager.NumberOfCities(); i++)
            {
                tour.Add(null);
            }
        }

        // Constructs a tour from another tour
        public Tour(List<City> tour)
        {
            this.tour = new List<City>(tour);
        }

        // Returns tour information
        public List<City> GetTour()
        {
            return tour;
        }

        // Creates a random individual
        public void GenerateIndividual()
        {
            // Loop through all our destination cities and add them to our tour
            for (int cityIndex = 0; cityIndex < TourManager.NumberOfCities(); cityIndex++)
            {
                SetCity(cityIndex, TourManager.GetCity(cityIndex));
            }
            // Randomly reorder the tour
            tour.Shuffle();
        }

        // Gets a city from the tour
        public City GetCity(int tourPosition)
        {
            return tour[tourPosition];
        }

        // Sets a city in a certain position within a tour
        public void SetCity(int tourPosition, City city)
        {
            tour[tourPosition] = city;
            // If the tours been altered we need to reset the fitness and distance
            distance = 0;
        }

        // Gets the total distance of the tour
        public double GetDistance()
        {
            if (distance == 0)
            {
                double tourDistance = 0;
                // Loop through our tour's cities
                for (int cityIndex = 0; cityIndex < TourSize(); cityIndex++)
                {
                    // Get city we're traveling from
                    City fromCity = GetCity(cityIndex);
                    // City we're traveling to
                    City destinationCity;
                    // Check we're not on our tour's last city, if we are set our
                    // tour's final destination city to our starting city
                    if (cityIndex + 1 < TourSize())
                    {
                        destinationCity = GetCity(cityIndex + 1);
                    }
                    else
                    {
                        destinationCity = GetCity(0);
                    }
                    // Get the distance between the two cities
                    tourDistance += fromCity.DistanceTo(destinationCity);
                }
                distance = tourDistance;
            }
            return distance;
        }

        // Get number of cities on our tour
        public int TourSize()
        {
            return tour.Count;
        }

        public override string ToString()
        {
            String geneString = "|";
            for (int i = 0; i < TourSize(); i++)
            {
                geneString += GetCity(i) + "|";
            }
            return geneString;
        }
    }
}
