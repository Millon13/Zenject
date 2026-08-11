using System;
using Modules;
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
        this.Container.Bind<ISnake>().To<Snake>().FromInstance(_snake);
        Container.Bind<InputSystem>().FromInstance(inputSystem).AsSingle();
        Container.Bind<ITickable>().To<InputSystem>().FromInstance(inputSystem).AsCached();
        this.Container.BindInterfacesTo<SnakeController>().AsSingle();
        this.Container.Bind<Snake>().FromInstance(_snake).AsSingle();
        
    }
}