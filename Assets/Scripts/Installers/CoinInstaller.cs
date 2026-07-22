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
        Container.Bind<ISnake>().To<Snake>().FromInstance(snake);
        Container.Bind<IWorldBounds>().To<WorldBounds>().FromInstance(_worldBounds).AsCached();
        Container.Bind<ILevelProgress>().To<LevelProgress>().AsCached();
        Container.BindFactory<Coin, CoinController.Factory>()
            .FromComponentInNewPrefab(coinPrefab)
            .AsCached();
        Container.Bind<CoinSpawner>().AsCached();
        Container.Bind<CoinCollector>().AsCached();
        Container.Bind<CoinController>().AsCached().NonLazy();
        Container.Bind<ITickable>().To<CoinController>().AsCached().NonLazy();
    }
}