using Modules;

namespace System.Snake
{
    public class SnakeSpeedController : IDisposable
    {
        private readonly Modules.Snake _snake;
        
        private readonly IDifficulty _difficulty;

        public SnakeSpeedController(Modules.Snake snake, IDifficulty difficulty)
        {
            _snake = snake;
            _difficulty = difficulty;
            _difficulty.OnStateChanged += SetNextLevelSpeed;
        }

        public void SetSpeed(float speed)
        {
            _snake.SetSpeed(speed);
        }

        public void SetNextLevelSpeed()
        {
            float speed = 2f + (_difficulty.Current - 1) * 0.5f;
            SetSpeed(speed);
        }

        public void Dispose()
        {
            _difficulty.OnStateChanged -= SetNextLevelSpeed;
        }
    }
}