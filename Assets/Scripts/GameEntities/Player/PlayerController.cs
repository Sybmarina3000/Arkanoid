using CustomUpdate;
using GameEntities.IBehaviour;
using UnityEngine;

namespace GameEntities.Player
{
    public class PlayerController : CustomUpdatableBehavior, IUpdatable
    {
        private IPlayer _player;

        private void Awake()
        {
            _player = RealizationBox.Instance.Player;
        }

        void IUpdatable.UpdateMe()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _player.MoveLeft();
                return;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                _player.MoveRight();
                return;
            }
        }
    }
}