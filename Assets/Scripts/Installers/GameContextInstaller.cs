using UnityEngine;
using UnityEngine.Serialization;
using Zenject;
using GameCycle;
using System.Coin;
using System.Snake;
using UIGame;


public sealed class GameContextInstaller : MonoInstaller
{
    [SerializeField] private SnakeInstaller _snakeInstaller;

    [SerializeField] private CoinInstaller coinInstaller;

    [SerializeField] private UIInstaller uiInstaller;

    [FormerlySerializedAs("levelInstaller")] [SerializeField]
    private GameInstaller gameInstaller;

    public override void InstallBindings()
    {
        this.Container.Install(_snakeInstaller);
        this.Container.Install(uiInstaller);
        this.Container.Install(coinInstaller);
        this.Container.Install(gameInstaller);
    }
}