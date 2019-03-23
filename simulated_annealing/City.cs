using System;
using System.Collections.Generic;
using System.Text;

namespace simulated_annealing
{
    class City
    {
        int x;
        int y;

        private static Random rnd = new Random();

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        // Constructs a randomly placed city
        public City()
        {
            this.X = (int)(rnd.NextDouble() * 200);
            this.Y = (int)(rnd.NextDouble() * 200);
        }

        // Constructs a city at chosen x, y location
        public City(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Gets the distance to given city
        public double DistanceTo(City city)
        {
            int xDistance = Math.Abs(X - city.X);
            int yDistance = Math.Abs(Y - city.Y);
            double distance = Math.Sqrt((xDistance * xDistance) + (yDistance * yDistance));

            return distance;
        }

        public override String ToString()
        {
            return X + ", " + Y;
        }
    }
}
