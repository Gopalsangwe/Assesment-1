namespace AvalphaTechnologies.CommissionCalculator.BusinessLogic
{
    public class CommissionCalculator : ICommissionCalculator
    {
        private const decimal AvalphaLocalRate = 0.20m;
        private const decimal AvalphaForeignRate = 0.35m;
        private const decimal CompetitorLocalRate = 0.02m;
        private const decimal CompetitorForeignRate = 0.0755m;

        private static decimal Round2(decimal value) =>
            Math.Round(value, 2, MidpointRounding.AwayFromZero);

        public CommissionCalculationResult Calculate(int localCount, int foreignCount, decimal averageSaleAmount)
        {
            if (localCount < 0 || foreignCount < 0 || averageSaleAmount < 0)
                throw new ArgumentException("Inputs must be non-negative.");

            var avalphaLocal = Round2(AvalphaLocalRate * localCount * averageSaleAmount);
            var avalphaForeign = Round2(AvalphaForeignRate * foreignCount * averageSaleAmount);
            var competitorLocal = Round2(CompetitorLocalRate * localCount * averageSaleAmount);
            var competitorForeign = Round2(CompetitorForeignRate * foreignCount * averageSaleAmount);

            return new CommissionCalculationResult
            {
                AvalphaLocal = avalphaLocal,
                AvalphaForeign = avalphaForeign,
                AvalphaTotal = Round2(avalphaLocal + avalphaForeign),
                CompetitorLocal = competitorLocal,
                CompetitorForeign = competitorForeign,
                CompetitorTotal = Round2(competitorLocal + competitorForeign)
            };
        }
    }
}
