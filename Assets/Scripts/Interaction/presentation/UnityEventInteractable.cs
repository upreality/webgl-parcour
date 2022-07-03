using UnityEngine;
using UnityEngine.Events;

namespace Interaction.presentation
{
    public class UnityEventInteractable : BaseInteractable
    {
        [SerializeField] private UnityEvent interaction;

        protected override void Interaction()
        {
            base.Interaction();
            interaction?.Invoke();
        }
    }
}