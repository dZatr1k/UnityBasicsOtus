using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField]
        private float _moveSpeed;

        [SerializeField]
        private float _rotationSpeed;

        [SerializeField]
        private Player _player;

        private Vector3 _moveDirection = Vector3.zero;
        private bool _isMoving
        {
            get
            {
                return _moveDirection != Vector3.zero;
            }
        }

        public void Move(Vector3 direction)
        {
            _moveDirection = direction.normalized;
        }

        private void FixedUpdate()
        {
            if (_isMoving)
            {
                UpdateMovement();
                _player.PlayMove();
                _moveDirection = Vector3.zero;
            }
            else
            {
                _player.PlayIdle();
            }
        }

        private void UpdateMovement()
        {
            var deltaTime = Time.fixedDeltaTime;
            this.transform.position += _moveDirection * this._moveSpeed * deltaTime;
            var targetRotation = Quaternion.LookRotation(this._moveDirection, Vector3.up);
            var nextRotation = Quaternion.Slerp(this.transform.rotation, targetRotation, this._rotationSpeed * deltaTime);
            this.transform.rotation = nextRotation;
        }
    }
}
