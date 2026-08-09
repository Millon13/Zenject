using UnityEngine;
using Zenject;
using System.Collections.Generic;
using JetBrains.Annotations;
using Modules;
using System;
using System.Coin;
using SnakeGame;

public class CoinCollectController : ITickable
{
    private readonly CoinManager _coinManager;

    private readonly Snake _snake;

    private CoinFactory _coinFactory;

    private List<Coin> _spawnedCoins = new List<Coin>();

    private IScore _score;

    private IDifficulty _difficulty;

    private readonly ILevelProgress _levelProgress;

    private int _currentDifficulty;

    [Inject]
    public CoinCollectController(Snake snake, CoinManager coinManager, 
        ILevelProgress levelProgress)
    {
        _snake = snake;
        _snake.OnMoved += this.OnMoved;
        _coinManager = coinManager;
        _levelProgress = levelProgress;
        _coinManager.LevelSpawn(_levelProgress.CoinsNeeded);
    }

    private void OnMoved(Vector2Int obj)
    {
        if (_coinManager.SpawnedCoins.Count > 0)
        {
            _coinManager.TryCollectCoin(_snake.HeadPosition);
        }
    }

    public void Tick()
    {

        if (_coinManager.SpawnedCoins.Count == 0 && !_levelProgress.IsLevelComplete)
        {
            _coinManager.SpawnCoin();
        }
    }

    public void Reset()
    {
        _coinManager.ClearAllCoins();
        _coinManager.SpawnCoin();
    }

    
}