using System;

namespace TestingFunctionalCodeKata.Net
{
    public class TrigMath
    {
        public const double PI = Math.PI;
        public const double SQUARED_PI = PI * PI;
        public const double HALF_PI = PI / 2;
        public const double QUARTER_PI = HALF_PI / 2;
        public const double TWO_PI = 2 * PI;
        public const double THREE_PI_HALVES = TWO_PI - HALF_PI;
        public const double DEG_TO_RAD = PI / 180;
        public const double HALF_DEG_TO_RAD = PI / 360;
        public const double RAD_TO_DEG = 180 / PI;

        // Trig
        private const int SIN_BITS = 22;

        private const int SIN_SIZE = 1 << SIN_BITS;
        private const int SIN_MASK = SIN_SIZE - 1;
        private const double SIN_CONVERSION_FACTOR = SIN_SIZE / TWO_PI;

        private const int COS_OFFSET = SIN_SIZE / 4;

        // Arc trig
        private const double sq2p1 = 2.414213562373095048802;

        private const double sq2m1 = 0.414213562373095048802;
        private const double p4 = 0.161536412982230228262E2;
        private const double p3 = 0.26842548195503973794141E3;
        private const double p2 = 0.11530293515404850115428136E4;
        private const double p1 = 0.178040631643319697105464587E4;
        private const double p0 = 0.89678597403663861959987488E3;
        private const double q4 = 0.5895697050844462222791E2;
        private const double q3 = 0.536265374031215315104235E3;
        private const double q2 = 0.16667838148816337184521798E4;
        private const double q1 = 0.207933497444540981287275926E4;
        private const double q0 = 0.89678597403663861962481162E3;
        public static double SQRT_OF_TWO = Math.Sqrt(2);

        public static double HALF_SQRT_OF_TWO = SQRT_OF_TWO / 2;
        private static readonly double[] SIN_TABLE = CreateSinTable();

        private static double[] CreateSinTable()
        {
            var table = new double[SIN_SIZE];
            for (var i = 0; i < SIN_SIZE; i++)
                table[i] = Math.Sin(i * TWO_PI / SIN_SIZE);
            return table;
        }


        public static double Sin(double angle)
        {
            return SinRaw(Floor(angle * SIN_CONVERSION_FACTOR));
        }

        public static int Floor(double a)
        {
            return (int) a;
        }


        public static double Cos(double angle)
        {
            return CosRaw(Floor(angle * SIN_CONVERSION_FACTOR));
        }

        public static double Tan(double angle)
        {
            var idx = Floor(angle * SIN_CONVERSION_FACTOR);
            return SinRaw(idx) / CosRaw(idx);
        }

        public static double Csc(double angle)
        {
            return 1 / Sin(angle);
        }

        public static double Sec(double angle)
        {
            return 1 / Cos(angle);
        }


        public static double Cot(double angle)
        {
            var idx = Floor(angle * SIN_CONVERSION_FACTOR);
            return CosRaw(idx) / SinRaw(idx);
        }

        public static double Asin(double value)
        {
            if (value > 1)
                return double.NaN;
            if (value < 0)
                return -Asin(-value);
            var temp = Math.Sqrt(1 - value * value);
            if (value > 0.7)
                return HALF_PI - Msatan(temp / value);
            return Msatan(value / temp);
        }

        public static double Acos(double value)
        {
            if (value > 1 || value < -1)
                return double.NaN;
            return HALF_PI - Asin(value);
        }

        public static double Atan(double value)
        {
            if (value > 0)
                return Msatan(value);
            return -Msatan(-value);
        }

        public static double Atan2(double y, double x)
        {
            if (y + x == y)
                return y >= 0 ? HALF_PI : -HALF_PI;
            y = Atan(y / x);
            if (x < 0)
                if (y <= 0)
                    return y + PI;
                else
                    return y - PI;
            return y;
        }

        public static double Acsc(double value)
        {
            if (value == 0)
                return double.NaN;
            return Asin(1 / value);
        }

        public static double Asec(double value)
        {
            if (value == 0)
                return double.NaN;
            return Acos(1 / value);
        }

        public static double Acot(double value)
        {
            if (value == 0)
                return double.NaN;
            if (value > 0)
                return Atan(1 / value);
            return Atan(1 / value) + PI;
        }

        private static double SinRaw(int idx)
        {
            return SIN_TABLE[idx & SIN_MASK];
        }

        private static double CosRaw(int idx)
        {
            return SIN_TABLE[(idx + COS_OFFSET) & SIN_MASK];
        }

        private static double Mxatan(double arg)
        {
            var argsq = arg * arg;
            var value = (((p4 * argsq + p3) * argsq + p2) * argsq + p1) * argsq + p0;
            value /= ((((argsq + q4) * argsq + q3) * argsq + q2) * argsq + q1) * argsq + q0;
            return value * arg;
        }

        private static double Msatan(double arg)
        {
            if (arg < sq2m1)
                return Mxatan(arg);
            if (arg > sq2p1)
                return HALF_PI - Mxatan(1 / arg);
            return HALF_PI / 2 + Mxatan((arg - 1) / (arg + 1));
        }
    }
}