using SnakeGame;
using UnityEngine;
using System;
using Modules;
using Zenject;

[Serializable]
public sealed class UIInstaller : Installer
{
    [SerializeField] private GameUI _gameUI;
    
    [SerializeField] private int _maxDifficulty = 9;
    
    [SerializeField] private WorldBounds _worldBounds;

    public override void InstallBindings()
    {
        Container.Bind<IGameUI>().FromInstance(_gameUI).AsSingle();
        Container.Bind<IScore>().To<Score>().AsSingle();
        Container.Bind<IDifficulty>().To<Difficulty>().AsSingle()
            .WithArguments(_maxDifficulty);
        Container.BindInterfacesTo<UIController>().AsCached().WithArguments(_worldBounds).NonLazy();

        Container.Bind<ITickable>().To<UIController>().AsCached().WithArguments(_worldBounds).NonLazy();
    }
}