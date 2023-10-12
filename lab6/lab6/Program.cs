using System.Runtime.Intrinsics.X86;

namespace AbstractsANDInterfaces {
    public abstract class Equation
    {
        protected float b2;
        protected float b1;
        protected float b0;
        protected float a0;

        public abstract float B2
        {
            get;set;
        }
        public abstract float B1
        {
            get; set;
        }
        public abstract float B0
        {
            get; set;
        }
        public abstract float A0
        {
            get; set;
        }
        public virtual bool Xval_Valid(float x)
        {
            return (b2 * (x * x) + b1 * (x) + b0 == 0)? true : false;
        }
        public double? Get_Solution(int n)
        {
            double D = b1 * b1 - 4 * b2 * b0;
            if (D < 0) return null;
            else if (n == 1) return (-1) * b1 + Math.Sqrt(D) / 2 * b2;
            else if (n == 2 && D != 0) return (-1) * b1 + (-1) * Math.Sqrt(D) / 2 * b2;
            else return null;
        }
    } 
}
