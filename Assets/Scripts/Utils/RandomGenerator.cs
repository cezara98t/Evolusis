using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RandomGenerator
{
    static Random random = new Random();
    public static double GetRandomDouble(double minimum, double maximum)
    {
        return random.NextDouble() * (maximum - minimum) + minimum;
    }
    public static double GetRandomDouble()
    {
        return random.NextDouble();
    }
    public static int GetRandomInt(int maximum)
    {
        return random.Next(maximum);
    }

    public static int GetRandomInt(int minimum, int maximum)
    {
        return random.Next(minimum, maximum);
    }
}