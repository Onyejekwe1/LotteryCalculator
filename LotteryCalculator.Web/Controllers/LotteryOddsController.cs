using LotteryCalculator.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LotteryCalculator.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LotteryOddsController : ControllerBase
    {
        private readonly ILotteryOddsService _lotteryOddsService;

        public LotteryOddsController(ILotteryOddsService lotteryOddsService)
        {
            _lotteryOddsService = lotteryOddsService;
        }

        [HttpGet]
        public ActionResult<Dictionary<int, double>> Get(int numberOfBalls, int ballsDrawn)
        {
            return _lotteryOddsService.CalculateOdds(numberOfBalls, ballsDrawn);
        }
    }

}
