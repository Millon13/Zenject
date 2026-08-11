using System;
using Modules;
using Zenject;


public class DiffiicultyUpdater : IDisposable
{
    private IDifficulty _difficulty;
    private ISnake _snake;
    private CoinManager _coinManager;

    [Inject]
    public DiffiicultyUpdater(IDifficulty difficulty, ISnake snake, CoinManager coinManager)
    {
        _difficulty = difficulty;
        _snake = snake;
        _coinManager = coinManager;
        _coinManager.OnLevelCompleted += OnComplete;
    }

    private void OnComplete()
    {
        if (_difficulty.Next(out int newDifficulty))
        {
            float newSpeed = 2f + (newDifficulty - 1) * 0.5f;
            _snake.SetSpeed(newSpeed);
        }
    }

    public void Dispose()
    {
        _coinManager.OnLevelCompleted -= OnComplete;
    }
}