﻿using System;
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
        [Inject] private DefaultLevelsDao levelsDao;

        public List<Level> GetLevels() => levelsDao.levels.Select(GetLevel).ToList();

        public Level GetLevel(long levelId)
        {
            var index = Convert.ToInt32(levelId);
            var entity = GetById(levelId);
            return GetLevel(entity, index);
        }

        public GameObject GetLevelScene(long levelId) => GetById(levelId).scenePrefab;

        private Level GetLevel(LevelEntity entity, int index)
        {
            var id = Convert.ToInt64(index);
            return new Level(id, index + 1, entity.reward);
        }

        private LevelEntity GetById(long levelId)
        {
            var index = Convert.ToInt32(levelId);
            return levelsDao.levels[index];
        }

        public interface ILevelsDao
        {
            public List<LevelEntity> GetLevelEntities();
        }
    }
}