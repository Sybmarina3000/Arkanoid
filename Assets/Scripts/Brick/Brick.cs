using System;
using DefaultNamespace.GameEntity;
using UnityEngine;
using UnityEngine.Serialization;

public class Brick : MonoBehaviour, IDestroyable
{
    private SpriteRenderer _spriteRenderer;
    public GameObject MyGameObject
    {
        get { return gameObject; }
    }

    [SerializeField] private uint _startHP;
    public uint HP { get => _currentHP; }
    [SerializeField] private uint _currentHP;
    
    private void Awake()
    {
        _currentHP = _startHP;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public bool IsDestroy { get => _currentHP == 0; }

    public void Damage(uint damage)
    {
        _currentHP -= damage;
        if(_currentHP == 0 )
            Destroy();
    }

    public void Destroy()
    {
        MyGameObject.SetActive(false);
    }

    public void VisualUpdate(Color newColor)
    {
        _spriteRenderer.color = newColor;
    }
}
