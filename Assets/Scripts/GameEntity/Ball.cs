using DefaultNamespace;
using UnityEngine;

public interface IBall
{
//    GameObject Hit
//    void ChangeDirection
}

public class Ball : PassiveMoveBehavior
{
    private Vector2 _reflection;
    private RaycastHit2D _hitInfo;
    private Vector3 _collisionPoint;
    
    private float _size;
    private Vector3 _deltaPosition; 
        
    public override void Init()
    {
         _size = GetComponent<SpriteRenderer>().bounds.size.x / 2;
         _deltaPosition = _size * _direction.normalized;
    }

    private bool CalculateCollision()
    {
        var ray = new Ray2D (_myTransform.position, _direction );
        Debug.DrawRay( _myTransform.position,  _direction, Color.magenta, _currentSpeed.magnitude  * Time.deltaTime);
        
        _hitInfo = Physics2D.Raycast(_myTransform.position, _direction, _size + _currentSpeed.magnitude * Time.deltaTime);
        
        if (_hitInfo.collider !=null)
        {
            _reflection = ReflectedDirection( _hitInfo.normal);

            _collisionPoint = _hitInfo.point;
            return true;
        }
        
        return false;
    }

    public override void Move()
    {
        var collision = CalculateCollision() ;
        if( collision)
        {
            _myTransform.position = _collisionPoint - _deltaPosition;
            Direction = _reflection;
            _deltaPosition = _size * _direction.normalized;
        }
        else
            base.Move();
      

    }

    Vector2 ReflectedDirection( Vector2 normal)
    {
        return (Vector2)_direction - 2 * Vector2.Dot(_direction, normal) * normal ;
    }
}
