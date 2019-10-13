using UnityEngine;

namespace GameEntities.IBehaviour
{
    public interface IManagerForDestroyable
    {
        void DestroyObject(GameObject destroyObj, uint damage);
        void VisualUpdateObj(IDestroyable destroyObj);
        void Reload();
    }
}