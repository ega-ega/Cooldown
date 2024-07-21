using System;

namespace Cooldown
{
    /// <summary>
    /// Factory for creating cooldowns with common ticker.
    /// </summary>
    public class AdvanceCooldownFactory: CooldownFactory
    {
        private readonly ITicker _commonTicker;
        
        public AdvanceCooldownFactory(ITicker commonTicker)
        {
            _commonTicker = commonTicker;
        }
        
        /// <summary>
        /// Create cooldown with common ticker.
        /// </summary>
        /// <param name="duration"> Duration of cooldown. </param>
        /// <param name="finishHandler"> Handler that will be called when cooldown is finished. </param>
        /// <returns></returns>
        public virtual Cooldown CreateWithCommonTicker(float duration, Action finishHandler = null)
        {
            return Create(duration, _commonTicker, finishHandler);
        }
    }
}