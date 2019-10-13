using DefaultNamespace.GameEntity;
using UnityEngine;

public class Brick : MonoBehaviour, IDestroyable
{
    public GameObject MyGameObject
    {
        get { return gameObject; }
    }

    public uint HP { get; set; }
    [SerializeField] private uint currentHP;

    public bool IsDestroy { get => currentHP == 0; }

    public void Damage(uint damage)
    {
        Debug.Log(" get damage " + damage);
        currentHP -= damage;
        if(currentHP == 0 )
            Destroy();
    }

    public void Destroy()
    {
        MyGameObject.SetActive(false);
    }
}
