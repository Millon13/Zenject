using Modules;
using UnityEngine;
using Zenject;

namespace System.Snake
{
    [Serializable]
    public sealed class SnakeInstaller : Installer
    {
        [SerializeField] private InputSystem inputSystem;

        [SerializeField] private Modules.Snake _snake;

        public override void InstallBindings()
        {
            this.Container.Bind<ISnake>().To<Modules.Snake>().FromInstance(_snake);
            this.Container.Bind<InputSystem>().FromInstance(inputSystem).AsSingle();
            this.Container.Bind<ITickable>().To<InputSystem>().FromInstance(inputSystem).AsCached();
            this.Container.BindInterfacesTo<SnakeController>().AsSingle();
            this.Container.Bind<Modules.Snake>().FromInstance(_snake).AsSingle();
            this.Container.BindInterfacesTo<SnakeSpeedController>().AsCached();
            this.Container.BindInterfacesTo<SnakeExpandController>().AsCached().NonLazy();
        }
    }
}