namespace AvalphaTechnologies.CommissionCalculator.BusinessLogic
{
    public interface ICommissionCalculator
    {
        CommissionCalculationResult Calculate(int localCount, int foreignCount, decimal averageSaleAmount);
    }
}
