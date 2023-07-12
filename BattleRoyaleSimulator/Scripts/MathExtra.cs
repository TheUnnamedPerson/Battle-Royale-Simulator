using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using MathNet.Numerics.Distributions;


namespace BattleRoyaleSimulator
{
    class MathExtra //Used to store general math functions i made.
    {
        public static float InverseNorm(float _mu, float _sigma, float _area)   //Inverse Normal CDF.
        {
            float result = result = (float)(Normal.InvCDF(_mu, _sigma, _area));
            return result;
        }

        public static float RandomFloat(float lower, float upper)       //produces a random float between lower and upper.
        {
            float range = upper - lower;
            Random rnd = new Random();
            float result = ((float)rnd.NextDouble() * range) + lower;
            return result;
        }
        public static int RandomInt(int lower, int upper) //Random.next(int, int) already does this but remade it for consistancy
        {
            Random rnd = new Random();
            int result = rnd.Next(lower, upper + 1);
            return result;
        }

        public static float SkewedFloat(float k, float _i)  //Skews a float. Used for skewing random numbers mainly.
        {
            if (k == 0) return _i;
            else
            {
                float result = (float)Math.Pow((Math.Sign(k) * -1 * _i + 0.5f + 0.5f * Math.Sign(k)), (1 + Math.Abs(k))) * -1 * Math.Sign(k) + 0.5f + 0.5f * Math.Sign(k);
                return result;
            }
        }
    }
}
