using System;

namespace Cooldown
{
    public interface ICooldownReadonly
    {
        /// <summary>
        /// Gets the remaining time in seconds until the cooldown is finished.
        /// </summary>
        float RemainingTimeS { get; }
        /// <summary>
        /// Gets the elapsed time in seconds since the cooldown was launched.
        /// </summary>
        float ElapsedTimeS { get; }
        
        /// <summary>
        /// Gets the progress of the cooldown as a fraction between 0 and 1.
        /// </summary>
        float Progress { get; }
        /// <summary>
        /// Indicates whether the cooldown has finished.
        /// </summary>
        bool IsFinish { get; }

        /// <summary>
        /// Event triggered when the progress of the cooldown changes.
        /// </summary>
        event Action ProgressChanged;
        /// <summary>
        /// Event triggered when the cooldown completes.
        /// </summary>
        event Action Completed;
    }
}