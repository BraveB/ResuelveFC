using Microsoft.AspNetCore.Mvc;
using ResuelveFC.Models;
using ResuelveFC.Interfaces;
using ResuelveFC.Services;

namespace ResuelveFC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IServicePaymentCalculator _servicePaymentCalculator = new ServicePaymentCalculator();

        [HttpPost]
        public List<Player> Post([FromBody] PaymentHelper playersPrePayment)
        {
            List<Player>? players = _servicePaymentCalculator.Payments(playersPrePayment);
            return players;
        }
    }
}
