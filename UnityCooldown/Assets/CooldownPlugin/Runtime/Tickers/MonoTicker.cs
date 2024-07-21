using System;
using UnityEngine;

namespace Cooldown
{
    public class MonoTicker : MonoBehaviour, ITicker
    {
        public event Action<float> Tick;

        private void Update()
        {
            Tick?.Invoke(Time.deltaTime);
        }
    }
}