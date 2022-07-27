using Core.Sound.presentation;
using Features.Keys.domain;
using UnityEngine;
using Zenject;

namespace Features.Keys.presentation
{
    public class KeyCollectNavigator: MonoBehaviour
    {
        [SerializeField] private AudioClip clip;
        [Inject] private PlaySoundNavigator playSoundNavigator;
        [Inject] private IKeysRepository keysRepository;

        public void Collect()
        {
            playSoundNavigator.Play(clip);
            keysRepository.AddKey();
        }
    }
}