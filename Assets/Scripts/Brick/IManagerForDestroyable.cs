using DefaultNamespace.GameEntity;
using UnityEngine;

namespace DefaultNamespace
{
    public interface IManagerForDestroyable
    {
        void DestroyObject(GameObject destroyObj, uint damage);
        void VisualUpdateObj(IDestroyable destroyObj);
        void FullDestroy();
    }
}