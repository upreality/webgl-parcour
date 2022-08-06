using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Data.LevelsData
{
    [CreateAssetMenu(menuName = "Levels/LevelsDao/SimpleLevelsDao")]
    internal class SimpleLevelsDao : ScriptableObject
    {
        [SerializeField] private int defaultReward = 100;

        [SerializeField] private List<GameObject> scenePrefabs = new();

        public List<LevelEntity> GetLevelEntities() => Enumerable
            .Range(0, scenePrefabs.Count)
            .Select(GetEntity)
            .ToList();

        private LevelEntity GetEntity(int levelId) => new(defaultReward, scenePrefabs[levelId]);
    }
}