using System;

namespace Cooldown
{
    public interface ITicker
    {
        event Action<float> Tick;

        public class Fake : ITicker
        {
            public event Action<float> Tick;
        }
    }
}