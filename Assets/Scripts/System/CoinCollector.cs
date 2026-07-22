using System;
using JetBrains.Annotations;
using Modules;
using UnityEngine;

public class CoinCollector
{
    private readonly Snake _snake;
    private readonly IScore _score;
    private readonly IDifficulty _difficulty;
    private readonly ILevelProgress _levelProgress;
    private readonly CoinSpawner _coinSpawner;
    private readonly Action _onCoinCollected;

    public CoinCollector(Snake snake, IScore score, IDifficulty difficulty, [CanBeNull] ILevelProgress levelProgress,
        CoinSpawner coinSpawner)
    {
        _snake = snake;
        _score = score;
        _difficulty = difficulty;
        _levelProgress = levelProgress;
        _coinSpawner = coinSpawner;
    }

    public bool TryCollectCoin(Vector2Int headPosition)
    {
        Coin coin = _coinSpawner.GetCoinAtPosition(headPosition);
        if (coin != null)
        {
            CollectCoin(coin);
            return true;
        }

        return false;
    }

    private void CollectCoin(Coin coin)
    {
        _snake.Expand(1);
        _score.Add(1);
        _levelProgress.AddCoin();
        if (_levelProgress.IsLevelComplete)
        {
            OnLevelComplete();
        }

        _coinSpawner.RemoveCoin(coin);
        _onCoinCollected?.Invoke();
    }

    private void OnLevelComplete()
    {
        if (_difficulty.Next(out int newDifficulty))
        {
            float newSpeed = 2f + (newDifficulty - 1) * 0.5f;
            _snake.SetSpeed(newSpeed);
        }

        _levelProgress.NextLevel();
        _coinSpawner.ClearAllCoins();
        for (int i = 0; i < _levelProgress.CoinsNeeded; i++)
        {
            _coinSpawner.SpawnCoin();
        }
    }
}