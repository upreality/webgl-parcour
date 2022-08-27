﻿using Core.SDK.PlayerData.data;
using Core.SDK.PlayerData.domain;
using UnityEngine;
using Zenject;

namespace Core.SDK.PlayerData._di
{
    [CreateAssetMenu(menuName = "Installers/PlayerDataInstaller")]
    public class PlayerDataInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IPlayerIdRepository>()
#if YANDEX_SDK && !UNITY_EDITOR
                .To<YandexPlayerIdRepository>()
#else
                .To<EmptyPlayerIdRepository>()
#endif
                .AsSingle();
        }
    }
}