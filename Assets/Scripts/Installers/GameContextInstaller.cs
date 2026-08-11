using UnityEngine;
using UnityEngine.Serialization;
using Zenject;


public sealed class GameContextInstaller : MonoInstaller
{
    [SerializeField] private SnakeMovementInstaller _snakeInstaller;

    [SerializeField] private CoinInstaller coinInstaller;

    [SerializeField] private UIInstaller uiInstaller;
    
    [FormerlySerializedAs("levelInstaller")] [SerializeField] private GameInstaller gameInstaller;

    public override void InstallBindings()
    {
        this.Container.Install(_snakeInstaller);
        this.Container.Install(uiInstaller);
        this.Container.Install(coinInstaller);
        this.Container.Install(gameInstaller);
    }
}