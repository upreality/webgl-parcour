using System;
using Doozy.Engine.UI;
using Interaction.domain;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Interaction.presentation
{
    public class InteractionView : MonoBehaviour
    {
        [SerializeField] private UIView rootView;
        [SerializeField] private Image interaction;
        [SerializeField] private Text description;
        [SerializeField] private Text key;

        [Inject] private ISelectedInteractableRepository selectedInteractableRepository;

        private void Start()
        {
            Debug.Log("InteractionView: ");
            selectedInteractableRepository
                .GetHasInteractableFlow()
                .Do(_ => Debug.Log("HasInteractable: " + _))
                .Subscribe(rootView.SetVisibility)
                .AddTo(this);

            selectedInteractableRepository
                .GetInteractableFlow()
                .Do(_ => Debug.Log("Interactable: " + _))
                .Select(GetStateFlow)
                .Switch()
                .Subscribe(UpdateData)
                .AddTo(this);
        }

        private void UpdateData(InteractableState state)
        {
            var color = state.IsInteractable ? Color.white : Color.gray;
            interaction.color = color;
            description.color = color;
            key.color = color;
            
            interaction.sprite = state.Data.sprite;
            description.text = state.Data.text;
            key.text = state.Data.interactionKey.ToString("g");
        }

        private static IObservable<InteractableState> GetStateFlow(IInteractable interactable) => interactable
            .IsInteractableFlow()
            .Select(isInteractable =>
                {
                    var data = interactable.GetData();
                    return new InteractableState(interactable.GetData(), isInteractable);
                }
            );

        private class InteractableState
        {
            public InteractableData Data;
            public bool IsInteractable;

            public InteractableState(InteractableData data, bool isInteractable)
            {
                Data = data;
                IsInteractable = isInteractable;
            }
        }
    }
}