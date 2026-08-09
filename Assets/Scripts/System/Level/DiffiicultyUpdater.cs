using System;
using Modules;


    public class DiffiicultyUpdater:IDisposable
    {
        private readonly IDifficulty _difficulty;
        private readonly ISnake _snake;
        private readonly CoinManager _coinManager;

        public DiffiicultyUpdater(IDifficulty difficulty, ISnake snake,CoinManager coinManager)
        {
            _difficulty = difficulty;
            _snake = snake;
            _coinManager = coinManager;
            _coinManager.OnLevelCompleted += OnComplete;
        }
        public void OnComplete()
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
