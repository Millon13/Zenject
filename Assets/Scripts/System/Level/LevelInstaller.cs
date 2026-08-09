using SnakeGame;
using UnityEngine;
using System;
using Modules;
using Zenject;

[Serializable]
    public class LevelInstaller:Installer
    {
        [SerializeField] private int _maxDifficulty = 9;
        
        [SerializeField] private WorldBounds _worldBounds;

        public override void InstallBindings()
        {

            this.Container.Bind<GameCycle>().AsCached().NonLazy();
            this.Container.Bind<IDifficulty>().To<Difficulty>().AsSingle().WithArguments(_maxDifficulty);
            this.Container.Bind<IScore>().To<Score>().AsSingle();
            this.Container.Bind<IWorldBounds>().To<WorldBounds>().FromInstance(_worldBounds).AsCached();
            this.Container.Bind<ILevelProgress>().To<LevelProgress>().AsCached();
            this.Container.BindInterfacesTo<GameLoseController>().AsCached();
            this.Container.BindInterfacesTo<GameWinController>().AsCached();
            this.Container.BindInterfacesTo<LevelUpdateController>().AsCached();
            this.Container.BindInterfacesTo<DiffiicultyUpdater>().AsCached();
        }
    }
