using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VanillaMain4
{
    class VanillaOption
    {
        public VanillaOption(PayOffBridge payoff_, double expiry_)
        {
            this.payoff = payoff_;
            this.Expiry = expiry_;
        }
        public double OptionPayOff(double spot_)
        {
            return payoff.Do(spot_);
        }

        public double Expiry{get; private set;}
        private PayOffBridge payoff;
    }
}
