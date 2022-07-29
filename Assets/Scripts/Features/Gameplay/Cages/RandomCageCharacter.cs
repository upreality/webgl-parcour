using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Features.Gameplay.Cages
{
    public class RandomCageCharacter : MonoBehaviour
    {
        [SerializeField] private List<GameObject> characters = new();
        [SerializeField] private string animatorTrigger = "free";
        [CanBeNull] private Animator animator;

        private void Start()
        {
            if (characters.Count == 0)
                return;

            var characterId = Random.Range(0, characters.Count - 1);
            Instantiate(characters[characterId], transform);
            animator = GetComponentInChildren<Animator>();
        }

        public void MakeFree()
        {
            if (animator != null)
                animator.SetTrigger(animatorTrigger);
        }
    }
}