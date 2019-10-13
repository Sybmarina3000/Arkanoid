using CustomUpdate;
using GameEntities.Ball;
using GameEntities.IBehaviour;
using UnityEngine;

namespace GameEntities.Player
{
    public class PlayerController : CustomUpdatableBehavior, IUpdatable
    {
        private IPlayer _player;
        private IBallManager _ballManager;

        public override void CustomStart()
        {
            _player = RealizationBox.Instance.Player;
            _ballManager = RealizationBox.Instance.BallManager;
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
            if (Input.GetKey(KeyCode.Space))
            {
                _ballManager.RunBall();
                return;
            }
            
        }
    }
}