using ResuelveFC.Models;

namespace ResuelveFC.Interfaces
{
    public interface IServicePaymentCalculator
    {
        public List<Player> Payments(PaymentHelper initialData);
    }
}
