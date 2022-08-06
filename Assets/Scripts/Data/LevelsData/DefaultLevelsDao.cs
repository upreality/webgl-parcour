using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Data.LevelsData
{
    [CreateAssetMenu(menuName = "Levels/LevelsDao/DefaultLevelsDao")]
    internal class DefaultLevelsDao : ScriptableObject, ILevelsDao
    {
        [SerializeField] private List<LevelEntity> levels;

        public Dictionary<long, LevelEntity> GetLevels() => levels
            .Select((entity, index) => new {val = entity, key = (long) index})
            .ToDictionary(x => x.key, x => x.val);

        public LevelEntity GetLevel(long levelId)
        {
            var index = Convert.ToInt32(levelId);
            return levels[index];
        }
    }
}