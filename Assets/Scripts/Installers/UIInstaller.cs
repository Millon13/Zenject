using SnakeGame;
using UnityEngine;
using System;
using Modules;
using UI;
using Zenject;

[Serializable]
public sealed class UIInstaller : Installer
{
    [SerializeField] private GameUI _gameUI;

    [SerializeField] private int _maxDifficulty = 9;


    public override void InstallBindings()
    {
        Container.Bind<IGameUI>().FromInstance(_gameUI).AsSingle();
        Container.Bind<IScore>().To<Score>().AsSingle();
        Container.Bind<IDifficulty>().To<Difficulty>().AsSingle()
            .WithArguments(_maxDifficulty);
        Container.BindInterfacesTo<UIController>().AsCached().NonLazy();
        Container.Bind<GameCycle>().AsCached().NonLazy();
        Container.Bind<ITickable>().To<UIController>().AsCached().NonLazy();
    }
}