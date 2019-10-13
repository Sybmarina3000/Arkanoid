
using UnityEngine;

public interface IAttacking
{
    uint AttackValue { get; set; }

    void Attack(GameObject obj);
}
