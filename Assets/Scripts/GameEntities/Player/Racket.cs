using GameEntities.IBehaviour;
using UnityEngine;

namespace GameEntities.Player
{
    public class Racket : MonoBehaviour, IPlayer
    {
        [SerializeField] private float _speed;
        public Transform MyTransform
        {
            get => _myTransform;
        }

        public float Speed
        {
            get { return _speed; }
            set
            {
                _speed = value;
                UpdateDirectionVectors();
            }
        }
        
        private Vector3 _currentLeftSpeed, _currentRightSpeed;
        private Vector3 _leftLimitPos, _rightLimitPos;
        
        [SerializeField] private Transform _LeftLimiter;
        [SerializeField] private Transform _RightLimiter;

        private Transform _myTransform;
        private float _scale;
        
        private void Awake()
        {
            _myTransform = transform;
            _scale = _myTransform.localScale.x / 2;
            
            UpdateLimits();
            UpdateDirectionVectors();
        }

        public void MoveRight()
        {
            Vector3 newPosition = _myTransform.position + _currentRightSpeed * Time.deltaTime ;
            if( newPosition.x + _scale <= _RightLimiter.position.x )
                _myTransform.position = newPosition;
            else
                _myTransform.position = _rightLimitPos;
        }

        public void MoveLeft()
        {
            Vector3 newPosition = _myTransform.position + _currentLeftSpeed * Time.deltaTime ;
            if (newPosition.x - _scale >= _LeftLimiter.position.x)
                _myTransform.position = newPosition;
            else
                _myTransform.position = _leftLimitPos;
        }

        public void ChangeSize( float delta)
        {
            _myTransform.localScale += new Vector3(delta, 0,0);
            _scale += delta / 2;

            UpdateLimits();
        }

        public bool OnPlayer(float xPosition)
        {
            return transform.position.x - _scale <= xPosition && xPosition <= transform.position.x + _scale;
        }


        private void UpdateLimits()
        {
            _rightLimitPos = new Vector3( _RightLimiter.position.x - _scale, _myTransform.position.y, 0);
            _leftLimitPos  = new Vector3( _LeftLimiter.position.x + _scale, _myTransform.position.y, 0);
        }

        private void UpdateDirectionVectors()
        {
            _currentLeftSpeed = _speed * Vector3.left;
            _currentRightSpeed = _speed * Vector3.right;
        }
        
    }
}