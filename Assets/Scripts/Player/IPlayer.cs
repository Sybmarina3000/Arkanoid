using UnityEngine;

public interface IPlayer
{
    float Speed { get; set; }

    void MoveRight();
    void MoveLeft();

    void ChangeSize( float delta);
}
