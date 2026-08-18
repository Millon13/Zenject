namespace System.Snake
{
    public class SnakeController : IDisposable
    {
        private readonly Modules.Snake _snake;

        private readonly InputSystem _inputSystem;


        public SnakeController(Modules.Snake snake, InputSystem inputSystem)
        {
            _snake = snake;
            _inputSystem = inputSystem;
            _inputSystem.OnTurn += _snake.Turn;
        }


        public void Dispose()
        {
            _inputSystem.OnTurn -= _snake.Turn;
        }
    }
}