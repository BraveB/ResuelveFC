using ResuelveFC.Interfaces;
using ResuelveFC.Models;

namespace ResuelveFC.Services
{
    public class ServicePaymentCalculator: IServicePaymentCalculator
    {
        public List<Player> Payments(PaymentHelper initialData)
        {
            return initialData.Jugadores;
        }

    }
}
