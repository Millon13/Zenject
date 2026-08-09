using System;
using System.Dynamic;
using Modules;


    public class LevelUpdateController:IDisposable
    {
        private readonly ILevelProgress _levelProgress;
        private readonly CoinManager _coinManager;


        public LevelUpdateController(ILevelProgress levelProgress, CoinManager coinManager)
        {
            _levelProgress = levelProgress;
            _coinManager = coinManager;
            _coinManager.OnLevelCompleted += OnComplete;
            
        }
    
        private void OnComplete()
        {
            _levelProgress.AddCoin();
            _levelProgress.NextLevel();
            _coinManager.LevelSpawn(_levelProgress.CoinsNeeded);
        }

        public void Dispose()
        {
            _coinManager.OnLevelCompleted -= OnComplete;
        }
    }
