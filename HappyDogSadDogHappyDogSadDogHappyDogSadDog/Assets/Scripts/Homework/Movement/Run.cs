using UnityEngine;

namespace Homework.Movement
{
    /**
     * TODO:
     * 1. Реализовать этот тип перемещения по аналогии с Walk, но отличающийся от него,
     * например, пусть перемещение будет по окружности заданного радиуса.
     * 2. Заменить передвижение у HappyDog и/или SadDog этим типом. Убедиться, что он работает.
     */
    public class Run : Move
    {
        private readonly float _radius;
        private readonly float _minAngle;
        private readonly float _maxAngle;
        private readonly float _speed;

        private float _angle;
        private int _direction = 1;

        public Run(MonoBehaviour owner) : base(owner)
        {
        }

        public Run(MonoBehaviour owner, float radius, float minAngle, float maxAngle, float speed) : base(owner)
        {
            _radius = radius;
            _minAngle = minAngle;
            _maxAngle = maxAngle;
            _speed = speed;

            _angle = _minAngle;
        }

        public override void Execute()
        {
            var newPosition = Owner.transform.position;

            _angle += _direction * Time.deltaTime * _speed;

            newPosition.x = _radius * Mathf.Cos(_angle);
            newPosition.y = _radius * Mathf.Sin(_angle);

            Owner.transform.position = newPosition;

            if (_angle > _maxAngle)
            {
                _direction = -1;
                InvokeOnDirectionChanged(_direction);
            }
            else if (_angle < _minAngle)
            {
                _direction = 1;
                InvokeOnDirectionChanged(_direction);
            }
        }
    }
}