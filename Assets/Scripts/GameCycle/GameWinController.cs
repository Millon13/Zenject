using System;
using Modules;

namespace GameCycle
{
    public class GameWinController : IDisposable
    {
        private readonly GameCycle _gameCycle;

        private readonly IDifficulty _difficulty;

        public GameWinController(GameCycle gameCycle, IDifficulty difficulty)
        {
            _gameCycle = gameCycle;
            _difficulty = difficulty;
            _difficulty.OnStateChanged += OnStateChanged;
        }

        private void OnStateChanged()
        {
            if (_difficulty.Current > _difficulty.Max)
            {
                _gameCycle.Win();
            }
        }

        public void Dispose()
        {
            _difficulty.OnStateChanged -= OnStateChanged;
        }
    }
}