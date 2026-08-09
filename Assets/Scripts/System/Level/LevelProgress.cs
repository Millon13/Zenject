using System;
using UnityEngine;

public class LevelProgress : ILevelProgress
{
    private int _currentLevel = 1;

    private int _coinsCollected = 0;

    private int _coinsNeeded = 1;

    public int CurrentLevel => _currentLevel;
    public int CoinsNeeded => _coinsNeeded;

    public int CoinsCollected => _coinsCollected;
    public bool IsLevelComplete => _coinsCollected >= _coinsNeeded;

    public LevelProgress()
    {
        _coinsNeeded = 1;
    }

    public void AddCoin()
    {
        _coinsCollected++;
    }

    public void ResetLevel()
    {
        _coinsCollected = 0;
    }

    public void NextLevel()
    {
        _currentLevel++;
        _coinsNeeded++;
        _coinsCollected = 0;
    }
}