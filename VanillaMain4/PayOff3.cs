using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VanillaMain4
{
    public abstract class PayOff
    {
        public abstract double Do(double spot);
        public abstract PayOff Clone();
    }
    public class PayOffCall : PayOff
    {
        public PayOffCall(PayOffCall payoff) : this(payoff.strike_)
        {
        }
        public PayOffCall(double strike)
        {
            this.strike_ = strike;
        }
        public override double Do(double spot)
        { 	
            return(Math.Max(spot - strike_, 0));
        }
        public override PayOff Clone()
        {
            return new PayOffCall(this);
        }

        private double strike_;
    }
    public class PayOffPut : PayOff
    {
        public PayOffPut(PayOffPut payoff) : this(payoff.strike_)
        {
        }
        public PayOffPut(double strike)
        {
            this.strike_ = strike;
        }
        public override double Do(double spot)
        { 	
            return(Math.Max(strike_ - spot, 0));
        }
        public override PayOff Clone()
        {
            return new PayOffPut(this);
        }

        private double strike_;
    }
}