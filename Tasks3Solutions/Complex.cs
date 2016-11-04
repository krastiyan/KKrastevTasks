using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks3Solutions
{
    class Complex
    {
        public int Real { get; set; }
        public int Imaginary { get; set; }

        public override string ToString()
        {
            string addedString = (Imaginary == 0) ?"": ((Imaginary<0)?" ":" + ")+Imaginary+"i";
            return Real+addedString;
        }

        public Complex(int RealPart, int ImaginaryyPart)
        {
            Real = RealPart;
            Imaginary = ImaginaryyPart;
        }

        public static Complex operator +(Complex op1, Complex op2)
        {
            //(m + ni) + (p + qi) = (m + p) + (n+q)i
            return new Complex(op1.Real+op2.Real, op1.Imaginary+op2.Imaginary);
        }

        public static Complex operator -(Complex op1, Complex op2)
        {
            //(m + ni) - (p + qi) = (m - p) + (n - q)i
            return new Complex(op1.Real - op2.Real, op1.Imaginary - op2.Imaginary);
        }
    }//Complex class
}
