﻿using GameEntities.IBehaviour;
using GameEntities.IBehaviour.PassiveMove;
using UnityEngine;

namespace GameEntities.Ball
{
    public class Ball : CollidePassiveMover, IAttacking
    {
        // collision
        private RaycastHit2D _hitInfo;
        private Vector3 _collisionPoint;
    
        private float _size;
        private Vector3 _sizeCorrectorComponent;
    
        private Vector3[] _collisionPoints = new Vector3[3];
    
        // attack
        [field: SerializeField]
        public uint AttackValue { get; set; }
        private readonly string _attackTag = "Destroyable";
        private readonly string _floorTag = "Floor";
        
        private IManagerForDestroyable _destroyManager;
        private IBallManager _ballManager;
        private IPlayer _player;
        
        public override void CustomAwake()
        {
            _size = GetComponent<SpriteRenderer>().bounds.size.x / 2;
            _sizeCorrectorComponent = _size * Direction.normalized;
         
            _collisionPoints[0] = Vector3.zero;
            UpdateCollisionPoints();
        }
    
        public override void CustomStart()
        {
            _destroyManager =  RealizationBox.Instance.ManagerForDestroyable;
            _ballManager =  RealizationBox.Instance.BallManager;
            _player = RealizationBox.Instance.Player;
        }

        public override void Move()
        {
            var collision = CalculateCollision() ;
            if( collision)
            {
                _myTransform.position = _collisionPoint - _sizeCorrectorComponent;
                ChangeDirection(_hitInfo.normal);
            }
            else
                base.Move();
        }

        protected override bool CalculateCollision()
        {
            for (int i = 0; i < _collisionPoints.Length; i++)
            {
                _hitInfo = Physics2D.Raycast(_myTransform.position + _collisionPoints[i], Direction, _size + _currentSpeed.magnitude * Time.deltaTime);

                if (_hitInfo.collider !=null)
                {
                    _collisionPoint = _hitInfo.point - (Vector2)_collisionPoints[i];
                    AnalyzeCollisionByTag(_hitInfo.collider.gameObject);
                    return true;
                } 
            }
            return false;
        }

        private void ChangeDirection( Vector2 normal)
        {
            var lastDirection = Direction;
            Direction = (Vector2)lastDirection - 2 * Vector2.Dot(lastDirection, normal) * normal ; // reflection last direction 
        
            _sizeCorrectorComponent = _size * Direction.normalized;
            UpdateCollisionPoints();
        }

        protected override void AfterChangeDirection()
        {
            _sizeCorrectorComponent = _size * Direction.normalized;
            UpdateCollisionPoints();
        }

        private void UpdateCollisionPoints()
        {
            var normal = Vector3.Cross(Direction, new Vector3(0,0,1) ).normalized;
            _collisionPoints[1] = normal* _size;
            _collisionPoints[2] = normal * -_size;
        }

        protected override void AnalyzeCollisionByTag( GameObject obj)
        {
            if( obj.CompareTag( _attackTag))
            {
                Attack(_hitInfo.collider.gameObject);
                return;
            }   
            if( obj.CompareTag( _floorTag) && !_player.OnPlayer( _myTransform.position.x))
            {
                Speed = 0;
                Direction = Vector3.zero;
                
                _ballManager.DestroyBall(this);
                return;
            }
        }
        
        public void Attack(GameObject obj)
        {
            _destroyManager.DestroyObject(obj, AttackValue);
        }

    }
}
