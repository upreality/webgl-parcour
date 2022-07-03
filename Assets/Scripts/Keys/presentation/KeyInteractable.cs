using System;
using Gameplay.Keys.domain;
using Interaction.presentation;
using UniRx;
using Zenject;

namespace Keys.presentation
{
    public class KeyInteractable : UnityEventInteractable
    {
        [Inject] private IKeysRepository keysRepository;

        public override IObservable<bool> IsInteractableFlow()
        {
            var enoughKeysFlow = keysRepository.GetCollectedKeysCountFlow().Select(keys => keys > 0);
            return base.IsInteractableFlow().CombineLatest(
                enoughKeysFlow,
                (interactable, enoughKeys) => interactable && enoughKeys
            );
        }
        
        protected override void Interaction()
        {
            base.Interaction();
            keysRepository.RemoveKey();
        }
    }
}