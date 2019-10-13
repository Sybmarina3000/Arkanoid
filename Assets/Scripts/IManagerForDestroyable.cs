using UnityEngine;

namespace DefaultNamespace
{
    public interface IManagerForDestroyable
    {
        void DestroyObject(GameObject destroyObj, uint damage);
    }
}