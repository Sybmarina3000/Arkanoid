using UnityEngine;

namespace DefaultNamespace.GameEntity
{
    public interface IDestroyable
    {
        GameObject MyGameObject { get; }
        uint HP { get; set; }
        bool IsDestroy { get; }

        void Damage(uint damage);
        void Destroy();
        
        
    }
}