using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VanillaMain4
{
    class Program
    {
        static void Main(string[] args)
        {
            //parameters
            double expiry = 1.0;
            double strike = 50.0;
            double spot = 49.0;

            ParametersConstant vol = new ParametersConstant(0.2);
            ParametersConstant r   = new ParametersConstant(0.01);

            //input number of montecarlo paths
            ulong number_of_paths = 10000;
            Console.Write("Enter number of montecarlo paths : ");
            number_of_paths = ulong.Parse(Console.ReadLine());

            //create payoff & option object
            PayOff payoff = new PayOffCall(strike);
            //implicit convert
            VanillaOption option1 = new VanillaOption(payoff, expiry);
            
            //montecarlo simulation & output result
            double result = SimpleMC6.SimpleMonteCarlo4(option1, spot, vol, r, number_of_paths);
            Console.WriteLine("the call price is " + result.ToString());
        }
    }
}
