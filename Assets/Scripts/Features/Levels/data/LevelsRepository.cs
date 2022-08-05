using System;
using System.Collections.Generic;
using System.Linq;
using Data.LevelsData;
using Features.Levels.domain.model;
using Features.Levels.domain.repositories;
using UnityEngine;
using Zenject;

namespace Features.Levels.data
{
    public class LevelsRepository : ILevelsRepository, ILevelSceneObjectRepository
    {
        [Inject] private ILevelsDao levelsDao;

        public List<Level> GetLevels() => levelsDao
            .GetLevels()
            .Select(pair => GetLevel(pair.Value, pair.Key))
            .ToList();

        public Level GetLevel(long levelId)
        {
            var index = Convert.ToInt32(levelId);
            var entity = levelsDao.GetLevel(levelId);
            return GetLevel(entity, index);
        }

        public GameObject GetLevelScene(long levelId) => levelsDao.GetLevel(levelId).scenePrefab;

        private static Level GetLevel(LevelEntity entity, long index)
        {
            var number = Convert.ToInt32(index) + 1;
            return new Level(index, number, entity.reward);
        }
    }
}