using UnityEngine;

namespace GameEntities.IBehaviour
{
    public interface IDestroyable
    {
        GameObject MyGameObject { get; }
        Vector3 MyPosition { get; } 
        uint HP { get;}
        bool IsDestroy { get; }

        void Damage(uint damage);
        void Destroy();
        void VisualUpdate(Color newColor);

        void Reload();


    }
}