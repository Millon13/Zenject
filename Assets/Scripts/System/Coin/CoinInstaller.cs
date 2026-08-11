using System;
using System.Coin;
using Modules;
using UnityEngine;
using Zenject;

[Serializable]
public class CoinInstaller : Installer
{
    [SerializeField] private Coin coinPrefab;

    public override void InstallBindings()
    {
        this.Container.BindFactory<Coin, CoinFactory>().FromComponentInNewPrefab(coinPrefab).AsCached();
        this.Container.Bind<Pool>().AsCached();
        this.Container.Bind<CoinManager>().AsCached();
        this.Container.BindInterfacesTo<CoinCollectController>().AsCached().NonLazy();
        this.Container.BindInterfacesTo<CoinAddController>().AsCached().NonLazy();
        this.Container.BindInterfacesTo<CoinExpandController>().AsCached().NonLazy();
        
        this.Container.BindInterfacesTo<DiffiicultyUpdater>().AsCached().NonLazy();
    }
}