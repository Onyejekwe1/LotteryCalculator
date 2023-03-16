using LotteryCalculator.Services;
using LotteryCalculator.Services.Contracts;
using Moq;

namespace LotteryCalculator.Tests
{
    public class LotteryOddsServiceTests
    {
        private readonly ILotteryOddsService _lotteryOddsService;
        private readonly Mock<ICombinatoricsCalculator> _mockCombinatoricsCalculator;

        public LotteryOddsServiceTests()
        {
            _mockCombinatoricsCalculator = new Mock<ICombinatoricsCalculator>();

            _mockCombinatoricsCalculator.Setup(c => c.Combination(48, 6)).Returns(12271512);
            _mockCombinatoricsCalculator.Setup(c => c.Combination(6, 6)).Returns(1);
            _mockCombinatoricsCalculator.Setup(c => c.Combination(6, 5)).Returns(6);
            _mockCombinatoricsCalculator.Setup(c => c.Combination(6, 4)).Returns(15);
            _mockCombinatoricsCalculator.Setup(c => c.Combination(6, 3)).Returns(20);
            _mockCombinatoricsCalculator.Setup(c => c.Combination(6, 2)).Returns(15);
            _mockCombinatoricsCalculator.Setup(c => c.Combination(6, 1)).Returns(6);

            _mockCombinatoricsCalculator.Setup(c => c.Combination(42, 0)).Returns(1);
            _mockCombinatoricsCalculator.Setup(c => c.Combination(42, 1)).Returns(42);
            _mockCombinatoricsCalculator.Setup(c => c.Combination(42, 2)).Returns(861);
            _mockCombinatoricsCalculator.Setup(c => c.Combination(42, 3)).Returns(11480);
            _mockCombinatoricsCalculator.Setup(c => c.Combination(42, 4)).Returns(111930);
            _mockCombinatoricsCalculator.Setup(c => c.Combination(42, 5)).Returns(850668);

            _lotteryOddsService = new LotteryOddsService(_mockCombinatoricsCalculator.Object);

        }

        [Fact]
        public void CalculateOdds_WithValidInput_ReturnsCorrectOdds()
        {
            // Arrange
            int numberOfBalls = 48;
            int ballsDrawn = 6;
            Dictionary<int, double> expectedOdds = new Dictionary<int, double>
                {
                    { 6, 12271512 },
                    { 5, 48696 },
                    { 4, 950 },
                    { 3, 53 },
                    { 2, 7 },
                    { 1, 2 }
                };

            // Act
            var result = _lotteryOddsService.CalculateOdds(numberOfBalls, ballsDrawn);

            // Assert
            Assert.Equal(expectedOdds, result);

        }

        [Fact]
        public void CalculateOdds_WithInvalidInput_ReturnsEmptyDictionary()
        {
            // Arrange
            int numberOfBalls = -1;
            int ballsDrawn = 6;

            // Act
            var result = _lotteryOddsService.CalculateOdds(numberOfBalls, ballsDrawn);

            // Assert
            Assert.Empty(result);
        }

    }

}
