using System;
using System.Collections;
using Features.Balance.domain;
using Features.Balance.domain.repositories;
using Features.Coins.domain;
using ModestTree;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Features.Collectables.presentation
{
    public class CollectableChest : MonoBehaviour
    {
        [Inject] private ICollectableRepository collectableRepository;
        [Inject] private IBalanceRepository balanceRepository;

        [SerializeField] private int reward = 100;
        [SerializeField] private CurrencyType rewardCurrency = CurrencyType.Primary;
        
        [SerializeField] private GameObject unOpened;
        [SerializeField] private GameObject opened;
        [SerializeField] private ParticleSystem openParticles;
        [SerializeField] private ParticleSystem disappearParticles;
        
        [SerializeField] private float openDelay = 0.5f;
        [SerializeField] private float lookDelay = 1f;
        [SerializeField] private float disappearDelay = 0.5f;
        [SerializeField] private float destroyDelay = 0.5f;
        
        [SerializeField] private string collectableId = "";

        private void Awake()
        {
            if (!collectableRepository.IsCollected(collectableId)) return;
            gameObject.SetActive(false);
        }

        private void Reset()
        {
            if (!collectableId.IsEmpty()) return;
            collectableId = Guid.NewGuid().ToString();
        }

#if UNITY_EDITOR
        [ContextMenu("Generate Id")]
        void GenerateId()
        {
            collectableId = Guid.NewGuid().ToString();
            EditorUtility.SetDirty(this);
        }
#endif

        public void Collect() => StartCoroutine(CollectCoroutine());

        private IEnumerator CollectCoroutine()
        {
            openParticles.Play();
            yield return new WaitForSeconds(openDelay);
            unOpened.SetActive(false);
            opened.SetActive(true);
            collectableRepository.Collect(collectableId);
            balanceRepository.Add(reward, rewardCurrency);
            yield return new WaitForSeconds(lookDelay);
            disappearParticles.Play();
            yield return new WaitForSeconds(disappearDelay);
            opened.SetActive(false);
            yield return new WaitForSeconds(destroyDelay);
            gameObject.SetActive(false);
        }
    }
}