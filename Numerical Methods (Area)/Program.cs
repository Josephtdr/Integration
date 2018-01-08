using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerical_Methods__Area_ {
    class Program {
        static void Main(string[] args) {
            for (int i = 0; i < 1000; i++) {
                Simpsons_Rule(1, (decimal)Math.E, (int)Math.Pow(2,i), f);
            }
            Console.ReadKey();
        }
        //equations
        static decimal f(decimal x) {
            return (1/x);
        }

        //methods
        static decimal Trapezium_Rule(decimal x1, decimal xn, int strips, Func<decimal, decimal> F) {
            decimal h = (xn - x1) / strips;
            decimal tempsum = F(x1) + F(xn);
            for (int i = 1; i < strips; i++) {
                tempsum += 2*F(x1 + (h*i));
            }
            return tempsum * (decimal)0.5 * h;
        }

        static decimal Midpoint_Rule(decimal x1, decimal xn, int strips, Func<decimal, decimal> F) {
            decimal h = (xn - x1) / strips;
            decimal tempsum = 0;
            for (int i = 1; i < strips+1; i++) {
                tempsum += F(x1 + (h * i) - (h * (decimal)0.5));
            }
            return tempsum * h;
        }

        static void Simpsons_Rule(decimal x1, decimal xn, int strips, Func<decimal, decimal> F) {
            decimal mid = Midpoint_Rule(x1,xn,strips, F);
            decimal trap = Trapezium_Rule(x1,xn,strips, F);
            decimal simp = ((mid * 2) + trap) / 3;
            Console.WriteLine("N = {0,-5}: Tn = {1,-30} Mn = {2,-30} Sn = {3,-30}",
                strips ,trap, mid, simp);
        }
    }
}
