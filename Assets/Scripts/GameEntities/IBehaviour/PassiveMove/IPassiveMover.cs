using UnityEngine;

namespace GameEntities.IBehaviour.PassiveMove
{
    public interface IPassiveMover
    {
        float Speed { get; set; }
        Vector3 Direction { get; set; }

        void Move();
    }
}
