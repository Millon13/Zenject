using System;
using Zenject;
using Modules;
using SnakeGame;

namespace UIGame
{
    public class UIController : IDisposable
    {
        private readonly IGameUI _gameUI;

        private readonly GameCycle.GameCycle _gameCycle;

        private readonly IScore _score;

        private readonly IDifficulty _difficulty;

        public UIController(
            IGameUI gameUI,
            IScore score,
            IDifficulty difficulty, GameCycle.GameCycle gameCycle)
        {
            _gameUI = gameUI;
            _score = score;
            _difficulty = difficulty;
            _gameCycle = gameCycle;
            OnDifficultyChanged();
            OnScoreChanged(0);
            _gameCycle.OnLose += this.OnLose;
            _gameCycle.OnWin += this.OnWin;
            _difficulty.OnStateChanged += OnDifficultyChanged;
            _score.OnStateChanged += OnScoreChanged;
        }

        private void OnLose()
        {
            _gameUI.GameOver(false);
        }

        private void OnWin()
        {
            WinGame();
        }

        private void WinGame()
        {
            _gameUI.GameOver(true);
            _gameCycle.OnLose -= this.OnLose;
        }

        public void Dispose()
        {
            _gameCycle.OnLose -= this.OnLose;
            _gameCycle.OnWin -= this.OnWin;
            _difficulty.OnStateChanged -= this.OnDifficultyChanged;
            _score.OnStateChanged -= this.OnScoreChanged;
        }

        private void OnDifficultyChanged()
        {
            _gameUI.SetScore(_score.Current.ToString());
            _gameUI.SetDifficulty(_difficulty.Current, _difficulty.Max);
            if (_difficulty.Current > _difficulty.Max)
                WinGame();
        }

        private void OnScoreChanged(int score)
        {
            _gameUI.SetScore(score.ToString());
        }
    }
}