using System;
using System.Collections.Generic;
using GameEntities.Ball;
using GameEntities.IBehaviour;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public interface IBonusManager
{
    void GenerateBonus( Vector3 position);
    void UseBonus(IBonus bonus);
}
public class BonusCreator : MonoBehaviour, IBonusManager
{
    [SerializeField] private BonusPool Pool;

    [SerializeField] private float _speedMax, _speedMin;

    // TODO add enum enumerator in custom editor. For set mass.count == Enum.GetValues(typeof(BonusType)).Length
    [SerializeField] private Color[] _BonusColors;
    private int _countBonusType;

    private IPlayer _player;

    [SerializeField] private Transform pos;
    // Start is called before the first frame update
    void Start()
    {
        _player = RealizationBox.Instance.Player;
        _countBonusType = Enum.GetValues(typeof(BonusType)).Length;
        
        GenerateBonus( pos.position);
    }

 
    public void GenerateBonus( Vector3 position)
    {
        var point = Pool.CreateObject(position);

        int randomType = Random.Range(0, _countBonusType);
        point.SetType( (BonusType)randomType, _BonusColors[randomType]  );
        
        point.Direction = Vector3.down;
        point.Speed = Random.Range( _speedMin, _speedMax);
    }

    public void UseBonus(IBonus bonus)
    {
        Debug.Log(" use bonus => " + bonus.BonusType);
        Pool.DestroyObject( (Bonus)bonus);
    }
}
