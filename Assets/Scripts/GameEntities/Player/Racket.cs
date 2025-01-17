﻿using GameEntities.IBehaviour;
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
        private Vector3 _startSize;
        private float _scale;
        
        private void Awake()
        {
            _myTransform = transform;
            
            _scale = _myTransform.localScale.x / 2;
            _startSize = _myTransform.localScale;
            
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
            Transform[] childs = new Transform[MyTransform.childCount];
            for (var i = 0; i < childs.Length; i++)
            {
                childs[i] = _myTransform.GetChild(i);
                childs[i].parent = null;
            }

            _myTransform.localScale += new Vector3(delta, 0,0);
            _scale += delta / 2;

            UpdateLimits();
            
            for (var i = 0; i < childs.Length; i++)
            {
                childs[i].parent = _myTransform;
            }
        }

        public bool OnPlayer(float xPosition)
        {
            return transform.position.x - _scale <= xPosition && xPosition <= transform.position.x + _scale;
        }

        public void Reload()
        {
            _myTransform.localScale = _startSize;
            _scale = _myTransform.localScale.x / 2;
            UpdateLimits();
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