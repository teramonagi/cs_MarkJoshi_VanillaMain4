using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VanillaMain4
{
    class PayOffBridge
    {
        public PayOffBridge(PayOffBridge origin)
        {
            this.payoff_ = origin.payoff_.Clone();
        }
        public PayOffBridge(PayOff inner_payoff)
        {
            this.payoff_ = inner_payoff.Clone();
        }
        public double Do(double spot)
        {
            return this.payoff_.Do(spot);
        }
        public static implicit operator PayOffBridge(PayOff payoff)
        {
            return new PayOffBridge(payoff);
        }

        private PayOff payoff_;
    }
}
