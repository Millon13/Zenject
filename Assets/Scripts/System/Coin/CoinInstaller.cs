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
        this.Container.Bind<CoinSpawner>().AsCached();
        this.Container.Bind<CoinCollector>().AsCached();
        this.Container.BindInterfacesTo<CoinController>().AsCached().NonLazy();
    }
}