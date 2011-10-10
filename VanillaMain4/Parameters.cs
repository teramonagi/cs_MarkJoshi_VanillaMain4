using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VanillaMain4
{
    class Parameters
    {
        Parameters(Parameters original)
        {
            this.params_inner_ = original.params_inner_.Clone();
        }
        Parameters(ParametersInner params_inner)
        {
            this.params_inner_ = params_inner.Clone();
        }
        public double Integral(double time1, double time2)
        {
            return params_inner_.Integral(time1, time2);
        }
        public double IntegralSquare(double time1, double time2)
        {
            return params_inner_.IntegralSquare(time1, time2);
        }
        public double Mean(double time1, double time2)
        {
            return (Integral(time1, time2) / (time2 - time1));
        }
        public double RootMeanSquare(double time1, double time2)
        {
            return (IntegralSquare(time1, time2) / (time2 - time1));
        }
        public static implicit operator Parameters(ParametersInner params_inner)
        {
            return new Parameters(params_inner);
        }

        private ParametersInner params_inner_;
    }
    abstract class ParametersInner
    {
        public abstract ParametersInner Clone();
        public abstract double Integral(double time1, double time2);
        public abstract double IntegralSquare(double time1, double time2);
    }
    class ParametersConstant : ParametersInner
    {
        public ParametersConstant(double constant)
        {
            this.constant_ = constant;
            this.constantSquare_ = constant * constant;
        }
        public override ParametersInner Clone()
        {
            return new ParametersConstant(this.constant_);
        }
        public override double Integral(double time1, double time2)
        {
            return ((time2 - time1) * constant_);
        }
        public override double IntegralSquare(double time1, double time2)
        {
            return ((time2 - time1) * constantSquare_);
        }

        private double constant_;
        private double constantSquare_;
    }
}
