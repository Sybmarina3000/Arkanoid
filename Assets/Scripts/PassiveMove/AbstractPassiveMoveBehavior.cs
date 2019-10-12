using UnityEngine;

namespace DefaultNamespace
{
    public class PassiveMoveBehavior : CustomUpdatableBehavior, IPassiveMover
    {
        [SerializeField] protected float _speed;
        public float Speed
        {
            get { return _speed;}
            set
            {
                _speed = value;
                UpdateCurrentSpeed();
            }
        }
        
        [SerializeField] protected Vector3 _direction;

        public Vector3 Direction
        {
            get { return _direction; }
            set
            {
                _direction = value;
                UpdateCurrentSpeed();
            }
        }

        protected Vector3 _currentSpeed;
        protected Transform _myTransform;

        private void Awake()
        {
            UpdateCurrentSpeed();
            _myTransform = transform;

            EnableUpdate();
        }

        public virtual void Move()
        {
            _myTransform.position += _currentSpeed * Time.deltaTime;
        }

        public override void UpdateMe()
        {
            Debug.Log("Move");
            Move();
        }

        private void UpdateCurrentSpeed()
        {
            _currentSpeed = Speed * Direction;
        }
    }
}