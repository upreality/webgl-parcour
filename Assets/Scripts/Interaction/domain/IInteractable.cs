using System;

namespace Interaction.domain
{
    public interface IInteractable
    {
        public IObservable<bool> IsInteractableFlow();
        public void Interact();
        public InteractableData GetData();
    }
}
