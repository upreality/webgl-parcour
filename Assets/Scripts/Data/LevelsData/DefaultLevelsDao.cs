using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data.LevelsData
{
    [CreateAssetMenu(menuName = "Levels/LevelsDao/DefaultLevelsDao")]
    public class DefaultLevelsDao : ScriptableObject
    {
        [SerializeField] public List<LevelEntity> levels;
    }
}