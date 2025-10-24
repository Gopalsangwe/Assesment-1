using AvalphaTechnologies.CommissionCalculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace AvalphaTechnologies.CommissionCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommisionController : ControllerBase
    {
        [ProducesResponseType(typeof(CommissionCalculationResponse), 200)]
        [HttpPost]
        public IActionResult Calculate(CommissionCalculationRequest calculationRequest)
        {
            return Ok(new CommissionCalculationResponse() { 
                AvalphaTechnologiesCommissionAmount = 999,
                CompetitorCommissionAmount = 100
            });
        }
    }

   

   
}
