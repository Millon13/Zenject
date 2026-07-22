using System;
using SnakeGame;
using Modules;
using Zenject;

namespace UI
{
    public class GameLoseController : ITickable
    {
        private readonly Snake _snake;

        private GameCycle _gameCycle;

        private IWorldBounds _worldBounds;

        public GameLoseController(Snake snake, GameCycle gameCycle, IWorldBounds worldBounds)
        {
            _snake = snake;
            _gameCycle = gameCycle;
            _worldBounds = worldBounds;
            _snake.OnSelfCollided += Dead;
        }


        public void Dispose()
        {
            _snake.OnSelfCollided -= Dead;
        }

        public void Tick()
        {
            if (isWorldCollided())
            {
                Dead();
            }
        }

        public bool isWorldCollided()
        {
            if (!_worldBounds.IsInBounds(_snake.HeadPosition))
            {
                return true;
            }

            return false;
        }

        private void Dead()
        {
            _gameCycle.Lose();
        }
    }
}