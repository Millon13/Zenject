using System;
using System.Snake;
using Modules;
using Zenject;

namespace System.Coin
{
    public class DifficultyUpdater : IDisposable
    {
        private readonly IDifficulty _difficulty;
        
        private readonly CoinManager _coinManager;
        
        private readonly GameCycle.GameCycle _gameCycle;

        public DifficultyUpdater(IDifficulty difficulty, CoinManager coinManager, GameCycle.GameCycle gameCycle)
        {
            _difficulty = difficulty;
            _gameCycle = gameCycle;
            _coinManager = coinManager;
            _coinManager.OnLevelCompleted += OnComplete;
        }

        private void OnComplete()
        {
            if (_difficulty.Current == _difficulty.Max)
            {
                _gameCycle.Win();
            }
            else
            {
                _difficulty.Next(out int newDifficulty);
            }
        }

        public void Dispose()
        {
            _coinManager.OnLevelCompleted -= OnComplete;
        }
    }
}