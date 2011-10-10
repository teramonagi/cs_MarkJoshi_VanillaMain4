using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VanillaMain4
{
    class SimpleMC6
    {
        public static double SimpleMonteCarlo4(VanillaOption option,
                                double spot,
                                Parameters vol,
                                Parameters r,
                                ulong number_of_paths)
        {
            double expiry = option.Expiry;
            double variance = vol.IntegralSquare(0, expiry);
            double root_variance = Math.Sqrt(variance);
            double moved_spot = spot * Math.Exp(r.Integral(0, expiry) - 0.5 * variance);

            double this_spot;
            double running_sum = 0;
            for (ulong i = 0; i < number_of_paths; i++)
            {
                double this_gaussian = MyRandom.GetOneGaussianByBoxMuller();
                this_spot = moved_spot * Math.Exp(root_variance * this_gaussian);
                running_sum += option.OptionPayOff(this_spot);
            }
            return Math.Exp(-r.Integral(0, expiry)) * (running_sum / number_of_paths);
        }

    }
}
