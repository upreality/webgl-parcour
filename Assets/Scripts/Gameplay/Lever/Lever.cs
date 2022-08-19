using System;
using Features.Interaction.presentation;
using UniRx;
using UnityEngine;
using Zenject;

namespace Features.Gameplay.Lever
{
    public class Lever: UnityEventInteractable
    {
        [Inject] private LeverStateNavigator leverStateNavigator;
        [SerializeField] private Animator animator;
        [SerializeField] private string boolName = "on";

        private void Start() => leverStateNavigator.GetLeverState().Subscribe(UpdateState).AddTo(this);

        public override IObservable<bool> IsInteractableFlow()
        {
            return base.IsInteractableFlow().CombineLatest(
                leverStateNavigator.GetLeverState(),
                (interactable, leverState) => interactable && !leverState
            );
        }

        private void UpdateState(bool isEnabled)
        {
            animator.SetBool(boolName, isEnabled);
        }

        protected override void Interaction()
        {
            base.Interaction();
            leverStateNavigator.SelectLever();
        }
    }
}