using Interaction.domain;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using Zenject;
using static Interaction.domain.IInteractable.SelectedState;

namespace Interaction.presentation
{
    public class InteractionHandler : MonoBehaviour
    {
        [Inject] private ISelectedInteractableRepository interactableRepository;
        [CanBeNull] private IInteractable lastInteractable = null;
        private bool hasInteractable = false;
        private bool isInteractable = false;

        private void Start()
        {
            interactableRepository
                .GetInteractableFlow()
                .Do(_ =>
                {
                    lastInteractable?.OnSelectedStateChanged(NotSelected);
                    lastInteractable = _;
                })
                .Select(_ => _.IsInteractableFlow())
                .Switch()
                .Subscribe(_ =>
                {
                    isInteractable = _;
                    lastInteractable.OnSelectedStateChanged(isInteractable? SelectedInteractable : Selected);
                })
                .AddTo(this);
            interactableRepository.GetHasInteractableFlow().Subscribe(_ =>
            {
                hasInteractable = _; 
                
                if(hasInteractable)
                    lastInteractable?.OnSelectedStateChanged(isInteractable? SelectedInteractable : Selected);
                else
                    lastInteractable?.OnSelectedStateChanged(NotSelected);
            }).AddTo(this);
        }

        private void Update()
        {
            if (!hasInteractable || lastInteractable == null) return;
            if (!Input.GetKeyDown(lastInteractable.GetData().interactionKey)) return;
            if (!isInteractable) return;
            lastInteractable.Interact();
        }
    }
}