using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryCalculator.Services.Contracts
{
    public interface ILotteryOddsService
    {
        Dictionary<int, double> CalculateOdds(int numberOfBalls, int ballsDrawn);
    }
}
