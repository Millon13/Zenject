using SnakeGame;
using Modules;
using Zenject;

namespace UI
{
    public class GameWinController : ITickable
    {
        private readonly GameCycle _gameCycle;

        private readonly IDifficulty _difficulty;

        public GameWinController(GameCycle gameCycle, IDifficulty difficulty)
        {
            _gameCycle = gameCycle;
            _difficulty = difficulty;
        }

        public void Tick()
        {
            if (_difficulty.Current == _difficulty.Max)
                _gameCycle.Win();
        }
    }
}