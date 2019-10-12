using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

namespace DefaultNamespace
{
    public class PassiveMoveBehavior : CustomUpdatableBehavior, IPassiveMover
    {
        [SerializeField] private float _speed;
        public float Speed
        {
            get { return _speed;}
            set
            {
                _speed = value;
                UpdateCurrentSpeed();
            }
        }
        
        [SerializeField] private Vector3 _direction;

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

            Init();
        }

        public virtual void Init()
        {
        } 

        public virtual void Move()
        {
            _myTransform.position += _currentSpeed * Time.deltaTime;
        }

        public override void UpdateMe()
        {
            Move();
        }

        private void UpdateCurrentSpeed()
        {
            _currentSpeed = Speed * Direction;
        }
    }
}