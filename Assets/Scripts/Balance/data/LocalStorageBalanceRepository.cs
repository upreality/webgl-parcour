using System;
using Balance.domain;
using Balance.domain.repositories;
using Plugins.FileIO;
using UniRx;
using UnityEngine;
using Utils.Reactive;

namespace Balance.data
{
    public class LocalStorageBalanceRepository : IBalanceRepository
    {
        private const string PREFS_KEY_PREFIX = "Balance";

        private readonly ReactiveDictionary<CurrencyType, int> balanceFlowMap = new();

        public IObservable<int> GetBalance(CurrencyType currencyType)
        {
            balanceFlowMap[currencyType] = GetBalanceValue(currencyType);
            return balanceFlowMap.GetItemFlow(currencyType);
        }

        public void Add(int value, CurrencyType currencyType)
        {
            var balance = GetBalanceValue(currencyType) + value;
            LocalStorageIO.SetInt(PREFS_KEY_PREFIX, balance);
            LocalStorageIO.Save();
            try
            {
                balanceFlowMap[currencyType] = balance;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Remove(int value, CurrencyType currencyType)
        {
            var removeResult = GetBalanceValue(currencyType) - value;
            var balance = Mathf.Max(0, removeResult);
            LocalStorageIO.SetInt(PREFS_KEY_PREFIX + currencyType, balance);
            LocalStorageIO.Save();
            balanceFlowMap[currencyType] = balance;
        }

        private static int GetBalanceValue(CurrencyType currencyType) => LocalStorageIO
            .GetInt(PREFS_KEY_PREFIX + currencyType, 0);
    }
}