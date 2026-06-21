using System;
using Modules;
using UnityEngine;
using Zenject;

[Serializable]
public sealed class SnakeMovementInstaller : Installer
{
    [SerializeField] private InputButtonSystem _inputButtonSystem;
    
    [SerializeField] private Snake _snakePrefab;
    
    [SerializeField] private SnakeDirection _snakeDir;

    public override void InstallBindings()
    {
        this.Container.Bind<InputButtonSystem>().FromInstance(_inputButtonSystem).AsCached();
        this.Container.Bind<SnakeDirection>().FromInstance(_snakeDir).AsCached();
        this.Container.Bind<ITickable>().To<SnakeController>().AsCached();
        this.Container.Bind<Snake>().FromInstance(_snakePrefab).AsCached();
    }
}