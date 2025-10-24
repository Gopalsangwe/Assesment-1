using AvalphaTechnologies.CommissionCalculator.BusinessLogic;
using AvalphaTechnologies.CommissionCalculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace AvalphaTechnologies.CommissionCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommisionController : ControllerBase
    {
        private readonly ICommissionCalculator _calculator;
        private readonly ILogger<CommisionController> _logger;

        public CommisionController(ICommissionCalculator calculator, ILogger<CommisionController> logger)
        {
            _calculator = calculator;
            _logger = logger;
        }

        [ProducesResponseType(typeof(CommissionCalculationResponse), 200)]
        [ProducesResponseType(400)]
        [HttpPost]
        public IActionResult Calculate([FromBody] CommissionCalculationRequest calculationRequest)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            try
            {
                var result = _calculator.Calculate(
                    calculationRequest.LocalSalesCount,
                    calculationRequest.ForeignSalesCount,
                    calculationRequest.AverageSaleAmount);

                var response = new CommissionCalculationResponse
                {
                    AvalphaLocal = result.AvalphaLocal,
                    AvalphaForeign = result.AvalphaForeign,
                    AvalphaTotal = result.AvalphaTotal,
                    CompetitorLocal = result.CompetitorLocal,
                    CompetitorForeign = result.CompetitorForeign,
                    CompetitorTotal = result.CompetitorTotal
                };

                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid input to Calculate");
                return BadRequest(new { error = ex.Message });
            }
        }
    }




}
