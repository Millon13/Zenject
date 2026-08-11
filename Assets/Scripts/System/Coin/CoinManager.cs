using System;
using System.Coin;
using Modules;
using UnityEngine;
using SnakeGame;

public class CoinManager : IDisposable
{
    private readonly CoinFactory _coinFactory;

    private readonly IWorldBounds _worldBounds;

    private readonly CoinExpandController _expandController;

    private readonly CoinAddController _addController;

    public event Action OnLevelCompleted;

    private int _removedCoins;

    private readonly Pool _pool;

    private int _currentLevel = 1;

    private int _coinsCollected = 0;

    private int _coinsNeeded = 1;

    public int CurrentLevel => _currentLevel;
    public int CoinsNeeded => _coinsNeeded;

    public int CoinsCollected => _coinsCollected;
    public bool IsLevelComplete => _coinsCollected >= _coinsNeeded;

    public CoinManager(CoinFactory coinFactory, IWorldBounds worldBounds, Pool pool)
    {
        _coinFactory = coinFactory;
        _worldBounds = worldBounds;
        _pool = pool;
        _coinsNeeded = 1;
    }

    public Coin SpawnCoin()
    {
        if (_worldBounds == null) return null;

        Vector2 spawnPosition = _worldBounds.GetRandomPosition();
        Coin newCoin = _coinFactory.Create();

        Vector2Int positionInt = new Vector2Int(
            Mathf.RoundToInt(spawnPosition.x),
            Mathf.RoundToInt(spawnPosition.y)
        );
        newCoin.Position = positionInt;
        newCoin.Generate();
        _pool.AddInPool(newCoin);
        return newCoin;
    }


    public Coin GetCoinAtPosition(Vector2Int position)
    {
        foreach (Coin coin in _pool.Coins)
        {
            if (coin != null && coin.Position == position)
            {
                return coin;
            }
        }

        return null;
    }

    public bool TryCollectCoin(Vector2Int headPosition)
    {
        Coin coin = GetCoinAtPosition(headPosition);
        if (coin != null)
        {
            _pool.RemoveCoin(coin);
            _coinsCollected++;
            if (_coinsCollected >= _coinsNeeded)
            {
                NextLevel();
                LevelSpawn(CoinsNeeded);
                OnLevelCompleted?.Invoke();
                
            }

            return true;
        }

        return false;
    }

    public void LevelSpawn(int coinsNeeded)
    {
        _pool.ClearPool();
        for (int i = 0; i < coinsNeeded; i++)
        {
            SpawnCoin();
        }
    }
    

    public void NextLevel()
    {
        _currentLevel++;
        _coinsNeeded++;
        _coinsCollected = 0;
    }

    public void Dispose()
    {
        _pool.ClearPool();
    }
}