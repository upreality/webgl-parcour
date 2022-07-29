﻿using JetBrains.Annotations;
using UnityEngine;

namespace Features.Gameplay.Enemies.AttackAreas
{
    public class AttackAreaNavigator
    {
        [CanBeNull] private Transform currentArea;
        
        public bool GetLastAttackArea(out Transform area)
        {
            area = currentArea;
            return currentArea != null;
        }

        public void SetAttackArea(Transform area) => currentArea = area;
    }
}