using UnityEngine;
using Zenject;

namespace System.Coin
{
    [Serializable]
    public class CoinInstaller : Installer
    {
        [SerializeField] private Modules.Coin coinPrefab;

        public override void InstallBindings()
        {
            this.Container.BindMemoryPool<Modules.Coin, Pool>()
                .WithInitialSize(10)
                .ExpandByOneAtATime()
                .FromComponentInNewPrefab(coinPrefab);
            this.Container.Bind<CoinManager>().AsSingle();
            this.Container.BindInterfacesTo<CoinCollectController>().AsCached().NonLazy();
            this.Container.BindInterfacesTo<ScoreAddController>().AsCached().NonLazy();
            this.Container.BindInterfacesTo<DifficultyUpdater>().AsCached().NonLazy();
            this.Container.Bind<CoinSpawnerController>().AsCached().NonLazy();
        }
    }
}