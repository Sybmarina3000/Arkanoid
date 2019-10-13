using UnityEngine;

namespace GameEntities.IBehaviour
{
    public interface IPlayer
    {
        Transform MyTransform { get; }
        float Speed { get; set; }

        void MoveRight();
        void MoveLeft();

        void ChangeSize( float delta);
    }
}
