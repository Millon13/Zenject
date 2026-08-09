using UnityEngine;
using Zenject;
using System.Collections.Generic;
using JetBrains.Annotations;
using Modules;
using System;
using System.Coin;
using SnakeGame;

public class CoinController : ITickable
{
    private readonly CoinSpawner _coinSpawner;

    private readonly CoinCollector _coinCollector;

    private readonly Snake _snake;

    private CoinFactory _coinFactory;

    private List<Coin> _spawnedCoins = new List<Coin>();

    private IScore _score;

    private IDifficulty _difficulty;

    private readonly ILevelProgress _levelProgress;

    private int _currentDifficulty;

    [Inject]
    public CoinController(Snake snake, CoinSpawner coinSpawner, [CanBeNull] CoinCollector coinCollector,
        ILevelProgress levelProgress)
    {
        _snake = snake;
        _coinSpawner = coinSpawner;
        _coinCollector = coinCollector;
        _levelProgress = levelProgress;
    }

    public void Tick()
    {
        if (_coinSpawner.SpawnedCoins.Count > 0)
        {
            _coinCollector.TryCollectCoin(_snake.HeadPosition);
        }

        if (_coinSpawner.SpawnedCoins.Count == 0 && !_levelProgress.IsLevelComplete)
        {
            _coinSpawner.SpawnCoin();
        }
    }

    public void Reset()
    {
        _coinSpawner.ClearAllCoins();
        _coinSpawner.SpawnCoin();
    }

    
}