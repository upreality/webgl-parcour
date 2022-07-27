using Core.Localization;
using Features.Purchases.data.model;
using Features.Purchases.domain.model;
using Zenject;

namespace Features.Purchases.data
{
    public class PurchaseEntityConverter
    {
        [Inject] private ILanguageProvider languageProvider;
        
        private Language? language;
        private Language Language
        {
            get
            {
                language ??= languageProvider.GetCurrentLanguage();
                return language.Value;
            }
        }

        public Purchase GetPurchaseFromEntity(PurchaseEntity entity)
        {
            var en = Language == Language.English;
            return new Purchase(
                entity.Id,
                en ? entity.EnName : entity.RuName,
                entity.Type,
                en ? entity.EnDescription : entity.RuDescription
            );
        }
    }
}