﻿using Features.Purchases.domain.model;

namespace Features.Purchases.domain.repositories
{
    public interface IPassLevelRewardPurchasesRepository
    {
        public bool HasForLevel(long levelId);
        long GetLevelId(string purchaseId);
        public Purchase GetForLevel(long levelId);
    }
}