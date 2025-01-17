using System;
using UnityEngine;

namespace Cooldown
{
    public class Cooldown : ICooldownReadonly
    {
        private readonly float _duration;
        private readonly ITicker _ticker;
        private readonly Action _finishHandler;

        private float _timer;

        public float RemainingTimeS => _timer;
        public float ElapsedTimeS => _duration - _timer;
        public float Progress => _timer / _duration;
        public bool IsFinish { get; private set; }

        public event Action ProgressChanged;
        public event Action Completed;

        
        public Cooldown(float duration, ITicker ticker, Action finishHandler)
        {
            _duration = duration;
            _ticker = ticker;
            _finishHandler = finishHandler;
        }

        public void Launch()
        {
            if (IsFinish)
            {
                Debug.LogError("Launch failure. Cooldown already finished!");
                return;
            }

            _timer = _duration;
            _ticker.Tick += Update;
        }

        private void Update(float deltaTime)
        {
            if (_timer < 0)
            {
                return;
            }

            _timer -= deltaTime;
            ProgressChanged?.Invoke();

            if (_timer <= 0)
            {
                Finish();
            }
        }

        private void Finish()
        {
            IsFinish = true;

            _ticker.Tick -= Update;

            _finishHandler?.Invoke();
            Completed?.Invoke();
        }

        public void ForceFinish()
        {
            _timer = 0;
            Finish();
        }
    }
}