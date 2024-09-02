using Microsoft.AspNetCore.Mvc;
using remitee_challenge.Models;

namespace remitee_challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class BalanceController : ControllerBase
    {
        private IBalanceService _balanceService;

        public BalanceController(IBalanceService balanceService)
        {
            _balanceService = balanceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBalanceByCuentaId([FromQuery] string id)
        {
             var balance = _balanceService.GetBalanceByCuenta(id);
             return Ok(balance);           
        }

        [HttpPut]
        public async Task<IActionResult> ExtraerSaldo([FromBody] ExtraccionModelo extraccion)
        {
            var balance = _balanceService.GetDinero(extraccion);

            return Ok(balance);
        }
    }
}
