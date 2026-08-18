using SnakeGame;
using UnityEngine;
using System;
using Zenject;

namespace UIGame
{
    [Serializable]
    public sealed class UIInstaller : Installer
    {
        [SerializeField] private GameUI _gameUI;

        public override void InstallBindings()
        {
            this.Container.Bind<IGameUI>().FromInstance(_gameUI).AsSingle();
            this.Container.BindInterfacesTo<UIController>().AsCached().NonLazy();
        }
    }
}