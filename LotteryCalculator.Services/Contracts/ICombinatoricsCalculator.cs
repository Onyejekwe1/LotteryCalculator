using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryCalculator.Services.Contracts
{
    public interface ICombinatoricsCalculator
    {
        double Combination(int n, int r);
        double Factorial(int n);
    }
}
