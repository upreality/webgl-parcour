using System;
using Features.Interaction.presentation;
using Features.Keys.domain;
using UniRx;
using Zenject;

namespace Features.Keys.presentation
{
    public class KeyInteractable : UnityEventOutlineInteractable
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