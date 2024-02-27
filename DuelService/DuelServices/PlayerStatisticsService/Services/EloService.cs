namespace PlayerStatisticsService.Services
{
    public class EloService
    {
        public double ExpectationToWin(int playerOneRating, int playerTwoRating)
        {
            return 1 / (1 + Math.Pow(10, (playerTwoRating - playerOneRating) / 400.0));
        }

        public int CalculateEloDelta(int playerOneRating, int playerTwoRating)
        {
            int eloK = 32;
            return (int)(eloK * (1 - ExpectationToWin(playerOneRating, playerTwoRating)));
        }
    }
}