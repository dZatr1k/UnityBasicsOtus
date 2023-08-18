using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerAnimations : MonoBehaviour
    {
        private static readonly int State = Animator.StringToHash("State");

        public enum AnimationsStates 
        {
            Idle = 0,
            Move = 1,
            Attack = 2,
            Die = 3,
        }

        [SerializeField] private Animator _animator;

        public void Play(int state)
        {
            _animator.SetInteger(State, state);
        }
    }
}

