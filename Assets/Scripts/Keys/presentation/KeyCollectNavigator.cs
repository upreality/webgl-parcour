using Keys.domain;
using Sound.presentation;
using UnityEngine;
using Zenject;

namespace Keys.presentation
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