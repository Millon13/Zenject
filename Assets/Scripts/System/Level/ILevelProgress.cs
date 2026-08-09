namespace System
{
    public interface ILevelProgress
    {
        int CurrentLevel { get; }
        int CoinsNeeded { get; }
        int CoinsCollected { get; }
        bool IsLevelComplete { get; }
        void AddCoin();
        void ResetLevel();
        void NextLevel();
    }
}