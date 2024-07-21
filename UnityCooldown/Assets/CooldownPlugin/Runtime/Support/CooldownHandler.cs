using System;

namespace Cooldown
{
    /// <summary>
    /// A utility class that manages event subscriptions for a cooldown process,
    /// facilitating the subscription and unsubscription from cooldown events.
    /// It also provides a mechanism to prematurely terminate the cooldown completion call.
    /// </summary>
    public class CooldownHandler
    {
        private readonly ICooldownReadonly _cooldown;
        private readonly Action<float> _progressHandler;
        private readonly Action _finishHandler;

        
        /// <summary>
        /// Initializes a new instance of the <see cref="CooldownHandler"/> class.
        /// </summary>
        /// <param name="cooldown">The cooldown to manage.</param>
        /// <param name="progressHandler">The action to call on progress updates.</param>
        /// <param name="finishHandler">The action to call upon cooldown completion.</param>
        public CooldownHandler(ICooldownReadonly cooldown, Action<float> progressHandler, Action finishHandler)
        {
            _cooldown = cooldown;
            _progressHandler = progressHandler;
            _finishHandler = finishHandler;

            _cooldown.ProgressChanged += OnProgressChanged;
            _cooldown.Completed += OnCompleted;
        }

        private void OnProgressChanged()
        {
            _progressHandler?.Invoke(_cooldown.Progress);
        }

        private void OnCompleted()
        {
            Break();
            
            _finishHandler?.Invoke();
        }
        
        /// <summary>
        /// Detaches the handler from the cooldown events, preventing further updates and completion calls.
        /// </summary>
        public void Break()
        {
            _cooldown.ProgressChanged -= OnProgressChanged;
            _cooldown.Completed -= OnCompleted;
        }
    }
}