using LotteryCalculator.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryCalculator.Services
{
    public class LotteryOddsService : ILotteryOddsService
    {
        private readonly ICombinatoricsCalculator _combinatoricsCalculator;

        public LotteryOddsService(ICombinatoricsCalculator combinatoricsCalculator)
        {
            _combinatoricsCalculator = combinatoricsCalculator;
        }

        public Dictionary<int, double> CalculateOdds(int numberOfBalls, int ballsDrawn)
        {
            if (numberOfBalls < 1 || ballsDrawn < 1 || numberOfBalls < ballsDrawn)
            {
                return new Dictionary<int, double>();
            }

            Dictionary<int, double> results = new Dictionary<int, double>();

            for (int matchedBalls = ballsDrawn; matchedBalls >= 1; matchedBalls--)
            {
                double odds = _combinatoricsCalculator.Combination(numberOfBalls, ballsDrawn) /
                              (_combinatoricsCalculator.Combination(ballsDrawn, matchedBalls) *
                               _combinatoricsCalculator.Combination(numberOfBalls - ballsDrawn, ballsDrawn - matchedBalls));

                results.Add(matchedBalls, Math.Round(odds));
            }

            return results;
        }
    }

}
