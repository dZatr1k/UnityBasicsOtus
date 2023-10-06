using System;
using UnityEngine;

namespace Game.Scripts
{
    [Serializable]
    public class Health
    {
        public event Action OnDeath;
        public event Action<int, int> OnChanged;

        [SerializeField]
        private int _max;

        [SerializeField]
        private int _current;

        public bool IsAlive => _current > 0;

        public int Max => _max;
        public int Current => _current;


        public void TakeDamage(int damage)
        {
            if (!IsAlive)
            {
                return;
            }

            _current -= damage;

            OnChanged?.Invoke(_current, _max);

            if (_current <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Debug.Log($"{GetType().Name}.Die:");

            OnDeath?.Invoke();
        }
    }
}