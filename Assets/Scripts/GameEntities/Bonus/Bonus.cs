using UnityEngine;

public enum  BonusType
{
    Sizer,
    SpeedHide,
    SpeedLow,
}

public interface IBonus
{
    float UseCoordinat { get; }
    BonusType BonusType { get; }
    void Use();
    void SetType(BonusType type, Color color);
}


public class Bonus : CollidePassiveMover, IBonus
{
    // Start is called before the first frame update
    public float UseCoordinat { get => _myTransform.position.x; }
    
    public BonusType BonusType { get => _myType; }
    private BonusType _myType;
    
    private float _size;
    private readonly string _floorTag = "Floor";

    private SpriteRenderer _spriteRenderer;
    private IBonusManager _bonusManager;

    private Transform _myTransform;
    public override void CustomAwake()
    {
        _myTransform = transform;
        _size = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _bonusManager = RealizationBox.Instance.Bonusmanager;
    }
    
    public override void Move()
    {
        CalculateCollision();
        base.Move();
    }
    
    protected override bool CalculateCollision()
    {
        var _hitInfo = Physics2D.Raycast(_myTransform.position, Direction, _size + _currentSpeed.magnitude * Time.deltaTime);

        if (_hitInfo.collider !=null)
        {
            AnalyzeCollisionByTag(_hitInfo.collider.gameObject);
            return true;
        } 
        
        return false;
    }

    protected override void AnalyzeCollisionByTag(GameObject obj)
    {
        if (obj.CompareTag(_floorTag))
        {
            Use();
        }
    }

    public void Use()
    { 
        _bonusManager.UseBonus(this);   
    }

    public void SetType(BonusType type, Color color)
    {
        _myType = type;
        _spriteRenderer.color = color;
        
    }
}
