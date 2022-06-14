using Interaction.domain;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using Zenject;

namespace Interaction.presentation
{
    public class InteractionHandler : MonoBehaviour
    {
        [Inject] private ISelectedInteractableRepository interactableRepository;
        [CanBeNull] private IInteractable lastInteractable = null;
        private bool hasInteractable = false;

        private void Start()
        {
            interactableRepository.GetInteractableFlow().Subscribe(_ => lastInteractable = _).AddTo(this);
            interactableRepository.GetHasInteractableFlow().Subscribe(_ => hasInteractable = _).AddTo(this);
        }

        // Update is called once per frame
        private void Update()
        {
            if (!hasInteractable || lastInteractable == null) return;
            if (!Input.GetKeyDown(lastInteractable.GetData().interactionKey)) return;
            lastInteractable.Interact();
        }
    }
}