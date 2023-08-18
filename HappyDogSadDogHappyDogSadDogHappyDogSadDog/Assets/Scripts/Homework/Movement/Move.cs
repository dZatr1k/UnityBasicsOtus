using System;
using UnityEngine;

namespace Homework.Movement
{
    public abstract class Move
    {
        protected MonoBehaviour Owner;

        public event Action<float> OnDirectionChanged;

        protected Move(MonoBehaviour owner)
        {
            Owner = owner;
        }

        protected void InvokeOnDirectionChanged(float direction)
        {
            OnDirectionChanged?.Invoke(direction);
        }

        public abstract void Execute();
    }
}