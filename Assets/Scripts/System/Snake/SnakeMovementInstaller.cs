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
        this.Container.Bind<InputSystem>().FromInstance(inputSystem).AsSingle();
        this.Container.BindInterfacesTo<SnakeController>().AsCached();
        this.Container.Bind<Snake>().FromInstance(_snake).AsCached();
        
    }
}