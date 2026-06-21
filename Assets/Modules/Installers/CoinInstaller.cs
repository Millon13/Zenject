using System;
using Modules;
using UnityEngine;
using Zenject;
using SnakeGame;

[Serializable]
public class CoinInstaller : Installer
{
    [SerializeField] private Coin coinPrefab;
    
    [SerializeField] private Snake snake;
    
    [SerializeField] private WorldBounds _worldBounds;


    public override void InstallBindings()
    {
        this.Container.Bind<CoinController>().AsCached().WithArguments(coinPrefab, snake, _worldBounds).NonLazy();
        this.Container.Bind<ITickable>().To<CoinController>().AsCached().WithArguments(coinPrefab, snake, _worldBounds);
    }
}