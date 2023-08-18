using UnityEngine;

namespace Game.Scripts.Player
{
    public sealed class Player : MonoBehaviour
    {
        [SerializeField] private PlayerMover _mover;
        [SerializeField] private PlayerAnimations _animations;

        private bool _isDead = false;

        public void Move(Vector3 direction)
        {
            if(!_isDead)
                _mover.Move(direction);
        }


        public void PlayIdle()
        {
            PlayAnimation((int)PlayerAnimations.AnimationsStates.Idle);
        }

        public void PlayMove()
        {
            PlayAnimation((int)PlayerAnimations.AnimationsStates.Move);
        }

        public void PlayAttack()
        {
            PlayAnimation((int)PlayerAnimations.AnimationsStates.Attack);
        }

        public void PlayDie()
        {
            PlayAnimation((int)PlayerAnimations.AnimationsStates.Die);
        }

        public void PlayAnimation(int state)
        {
            if (!_isDead)
                _animations.Play(state);
            else
                _animations.Play(-1);
        }

        public void Die()
        {
            if (!_isDead)
            {
                PlayDie();
                _isDead = true;
            }
        }
    }
}