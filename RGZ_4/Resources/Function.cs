using System;

namespace RGZ_4
{
    enum Functions
    {
        Linear_1 = 0,
        Linear_2,
        NonLinear_1,
        NonLinear_2
    }

    public static class Function
    {
        public static double LinearFunction1(double x)
        {
            return 6 * x;
        }

        public static double LinearFunction2(double x)
        {
            return (0.5 * x) - 1;
        }

        public static double NonLinearFunction1(double x)
        {
            return (3 * Math.Pow(x, 2)) - x + 5;
        }

        public static double NonLinearFunction2(double x)
        {
            return (0.7 * Math.Sin(x)) + 1;
        }
    }
}
