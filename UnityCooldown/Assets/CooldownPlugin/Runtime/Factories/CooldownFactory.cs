using System;

namespace Cooldown
{
    /// <summary>
    /// Factory for creating cooldowns.
    /// </summary>
    public class CooldownFactory
    {
        /// <summary>
        /// Create cooldown.
        /// </summary>
        /// <param name="duration"> Duration of cooldown. </param>
        /// <param name="ticker"> Ticker for cooldown. </param>
        /// <param name="finishHandler"> Handler that will be called when cooldown is finished. </param>
        /// <returns> Cooldown instance. </returns>
        public Cooldown Create(float duration, ITicker ticker, Action finishHandler = null)
        {
            return new Cooldown(duration, ticker, finishHandler);
        }

        /// <summary>
        /// Create finished cooldown.
        /// </summary>
        /// <returns> Finished cooldown instance. </returns>
        public Cooldown CreateFinished()
        {
            var instance = Create(1, new ITicker.Fake());
            instance.Launch();
            instance.ForceFinish();
            return instance;
        }
    }
}