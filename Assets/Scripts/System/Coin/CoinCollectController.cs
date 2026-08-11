using UnityEngine;
using Zenject;
using System.Collections.Generic;
using Modules;
using System;
using System.Coin;
public class CoinCollectController : ITickable, IDisposable
{
    private CoinManager _coinManager;

    private Snake _snake;

    private CoinFactory _coinFactory;

    private IScore _score;

    private IDifficulty _difficulty;

    private Pool _pool;

    private int _currentDifficulty;

    [Inject]
    public CoinCollectController(Snake snake, CoinManager coinManager, Pool pool)
    {
        _snake = snake;
        _snake.OnMoved += this.OnMoved;
        _coinManager = coinManager;
        _pool = pool;
        _coinManager.LevelSpawn(_coinManager.CoinsNeeded);
    }

    private void OnMoved(Vector2Int obj)
    {
        if (_pool.Coins.Count > 0)
        {
            _coinManager.TryCollectCoin(_snake.HeadPosition);
        }
    }

    public void Tick()
    {
        if (_pool.Coins.Count == 0 && !_coinManager.IsLevelComplete)
        {
            _coinManager.SpawnCoin();
        }
    }


    public void Dispose()
    {
        _snake.OnMoved -= this.OnMoved;
    }
}