using Balance.domain.repositories;
using Sound.presentation;
using UnityEngine;
using Zenject;

namespace Balance.presentation
{
    public class AddBalanceNavigator : MonoBehaviour
    {
        [SerializeField] private AudioClip collectSound;
        [Inject] private PlaySoundNavigator playSoundNavigator;
        [Inject] private IBalanceRepository balanceRepository;
    
        public void AddBalance(int amount)
        {
            playSoundNavigator.Play(collectSound);
            balanceRepository?.Add(amount);
        }
    }
}
