﻿using System;
using System.Collections;
using Interaction.domain;
using UniRx;
using UnityEngine;

namespace Interaction.presentation
{
    public class BaseInteractable : MonoBehaviour, IInteractable
    {
        [Header("Data"), SerializeField] private InteractableData data;

        [Header("Settings")] [SerializeField] private bool interactOnce = true;
        [SerializeField] private float cooldown = 1f;

        private readonly ReactiveProperty<bool> onCooldown = new(false);
        
        private bool firstInteraction = false;

        public virtual IObservable<bool> IsInteractableFlow() => onCooldown.Select(_ => !_ && !(interactOnce && firstInteraction));

        public void Interact()
        {
            StartCoroutine(CooldownCoroutine());
            Interaction();
        }

        protected virtual void Interaction()
        {
            firstInteraction = true;
            //do nothing
        }

        private IEnumerator CooldownCoroutine()
        {
            onCooldown.Value = true;
            yield return new WaitForSeconds(cooldown);
            onCooldown.Value = false;
        }

        public InteractableData GetData() => data;
    }
}