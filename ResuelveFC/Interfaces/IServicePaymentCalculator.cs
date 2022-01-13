using ResuelveFC.Models;

namespace ResuelveFC.Interfaces
{
    public interface IServicePaymentCalculator
    {
        public List<PlayerPaycheckInfo> Payments(PaymentHelper initialData);
    }
}
