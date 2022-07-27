using System.Collections.Generic;

namespace Features.Balance.domain.repositories
{
    public interface ICurrencyRepository
    {
        public List<Currency> GetCurrencies();
    }
}