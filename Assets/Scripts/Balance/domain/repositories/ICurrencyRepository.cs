using System.Collections.Generic;

namespace Balance.domain.repositories
{
    public interface ICurrencyRepository
    {
        public List<Currency> GetCurrencies();
    }
}