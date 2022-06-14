using System;
using UnityEngine;

namespace Interaction.domain
{
    [Serializable]
    public class InteractableData
    {
        public Sprite sprite;
        public string text;
        public KeyCode interactionKey = KeyCode.F;
    }
}