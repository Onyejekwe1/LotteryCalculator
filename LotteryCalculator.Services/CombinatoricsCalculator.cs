using LotteryCalculator.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryCalculator.Services
{
    public class CombinatoricsCalculator : ICombinatoricsCalculator
    {
        private readonly Dictionary<int, double> _factorialCache = new Dictionary<int, double>();

        public double Combination(int n, int r)
        {
            return Factorial(n) / (Factorial(r) * Factorial(n - r));
        }

        public double Factorial(int n)
        {
            if (n == 0 || n == 1)
                return 1;

            if (_factorialCache.ContainsKey(n))
                return _factorialCache[n];

            double result = n * Factorial(n - 1);
            _factorialCache[n] = result;

            return result;
        }
    }

}
