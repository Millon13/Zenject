using System;
using Modules;
using SnakeGame;
using UI;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

[Serializable]
public sealed class SnakeMovementInstaller : Installer
{
    [FormerlySerializedAs("_inputButtonSystem")] [SerializeField]
    private InputSystem inputSystem;

    [SerializeField] private Snake _snake;


    public override void InstallBindings()
    {
        this.Container.Bind<InputSystem>().FromInstance(inputSystem).AsSingle();
        this.Container.Bind<ITickable>().To<SnakeController>().AsCached();
        this.Container.Bind<Snake>().FromInstance(_snake).AsCached();
        this.Container.Bind<ITickable>().To<GameLoseController>().AsCached();
        this.Container.Bind<ITickable>().To<GameWinController>().AsCached();
    }
}