using System;
using Balance.domain;
using Balance.domain.repositories;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Balance.presentation.ui
{
    public class ReactiveBalanceText: MonoBehaviour
    {
        [SerializeField] private Text text;
        [SerializeField] private CurrencyType currencyType = CurrencyType.Primary;
        [Inject] private IBalanceRepository balanceRepository;
        [SerializeField] private UnityEvent onUpdateText;

        private void Awake()
        {
            if (text == null)
                text = GetComponent<Text>();
        }

        private void Start() => balanceRepository.GetBalance(currencyType).Subscribe(UpdateBalance).AddTo(this);

        private void UpdateBalance(int balance)
        {
            text.text = balance.ToString();
            onUpdateText.Invoke();
        }
    }
}