using UnityEngine;
using Zenject;


public sealed class GameContextInstaller : MonoInstaller
{
    [SerializeField] private SnakeMovementInstaller _snakeInstaller;

    [SerializeField] private CoinInstaller coinInstaller;

    [SerializeField] private UIInstaller uiInstaller;
    
    [SerializeField] private LevelInstaller levelInstaller;

    public override void InstallBindings()
    {
        this.Container.Install(_snakeInstaller);
        this.Container.Install(uiInstaller);
        this.Container.Install(coinInstaller);
        this.Container.Install(levelInstaller);
    }
}