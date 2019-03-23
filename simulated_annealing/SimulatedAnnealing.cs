using System;
using System.Collections.Generic;
using System.Text;

namespace simulated_annealing
{
    class SimulatedAnnealing
    {
        public static double AcceptanceProbability(double energy, double newEnergy, double temperature)
        {
            // If the new solution is better, accept it
            if (newEnergy < energy)
            {
                return 1.0;
            }

            // If the new solution is worse, calculate an acceptance probability
            return Math.Exp((energy - newEnergy) / temperature);
        }

        public static void Start()
        {
            // Create and add our cities
            City city = new City(60, 200);
            TourManager.AddCity(city);
            City city2 = new City(180, 200);
            TourManager.AddCity(city2);
            City city3 = new City(80, 180);
            TourManager.AddCity(city3);
            City city4 = new City(140, 180);
            TourManager.AddCity(city4);
            City city5 = new City(20, 160);
            TourManager.AddCity(city5);
            City city6 = new City(100, 160);
            TourManager.AddCity(city6);
            City city7 = new City(200, 160);
            TourManager.AddCity(city7);
            City city8 = new City(140, 140);
            TourManager.AddCity(city8);
            City city9 = new City(40, 120);
            TourManager.AddCity(city9);
            City city10 = new City(100, 120);
            TourManager.AddCity(city10);
            City city11 = new City(180, 100);
            TourManager.AddCity(city11);
            City city12 = new City(60, 80);
            TourManager.AddCity(city12);
            City city13 = new City(120, 80);
            TourManager.AddCity(city13);
            City city14 = new City(180, 60);
            TourManager.AddCity(city14);
            City city15 = new City(20, 40);
            TourManager.AddCity(city15);
            City city16 = new City(100, 40);
            TourManager.AddCity(city16);
            City city17 = new City(200, 40);
            TourManager.AddCity(city17);
            City city18 = new City(20, 20);
            TourManager.AddCity(city18);
            City city19 = new City(60, 20);
            TourManager.AddCity(city19);
            City city20 = new City(160, 20);
            TourManager.AddCity(city20);

            // Set initial temp
            double temp = 10000;

            // Cooling rate
            double coolingRate = 0.003;

            // Initialize intial solution
            Tour currentSolution = new Tour();
            currentSolution.GenerateIndividual();

            Console.WriteLine("Initial solution distance: " + currentSolution.GetDistance());

            // Set as current best
            Tour best = new Tour(currentSolution.GetTour());

            Random rnd = new Random();

            // Loop until system has cooled
            while (temp > 1)
            {
                // Create new neighbour tour
                Tour newSolution = new Tour(currentSolution.GetTour());

                // Get a random positions in the tour
                int tourPos1 = (int)(newSolution.TourSize() * rnd.NextDouble());
                int tourPos2 = (int)(newSolution.TourSize() * rnd.NextDouble());

                // Get the cities at selected positions in the tour
                City citySwap1 = newSolution.GetCity(tourPos1);
                City citySwap2 = newSolution.GetCity(tourPos2);

                // Swap them
                newSolution.SetCity(tourPos2, citySwap1);
                newSolution.SetCity(tourPos1, citySwap2);

                // Get energy of solutions
                double currentEnergy = currentSolution.GetDistance();
                double neighbourEnergy = newSolution.GetDistance();

                // Decide if we should accept the neighbour
                if (AcceptanceProbability(currentEnergy, neighbourEnergy, temp) > rnd.NextDouble())
                {
                    currentSolution = new Tour(newSolution.GetTour());
                }

                // Keep track of the best solution found
                if (currentSolution.GetDistance() < best.GetDistance())
                {
                    best = new Tour(currentSolution.GetTour());
                }

                // Cool system
                temp *= 1 - coolingRate;
            }

            Console.WriteLine("Final solution distance: " + best.GetDistance());
            Console.WriteLine("Tour: " + best);
        }
    }
}
