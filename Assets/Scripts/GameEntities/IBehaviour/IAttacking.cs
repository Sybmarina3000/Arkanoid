
using UnityEngine;

namespace GameEntities.IBehaviour
{
    public interface IAttacking
    {
        uint AttackValue { get; set; }

        void Attack(GameObject obj);
    }
}
