using System;
using System.Collections.Generic;
using GameEntities.IBehaviour;
using GameEntities.IBehaviour.PassiveMove;
using Helper.Patterns;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameEntities.Ball
{
    public interface IBallManager
    {
        void DestroyBall( PassiveMoveBehavior ball);
        void CreateNewBall();

        void RunBall();
    }
    public class BallManager : MonoBehaviour, IBallManager
    {
        [SerializeField] private BallPool _ballPool;
        private List<PassiveMoveBehavior> Balls;
        
        private IPlayer _player;
        private IGameLogic _gameLogic;
        [SerializeField] private float startSpeed;

        private void Start()
        {
            Balls = new List<PassiveMoveBehavior>();
            _player = RealizationBox.Instance.Player;
        }

        public void DestroyBall(PassiveMoveBehavior ball)
        {
            _ballPool.DestroyObject(ball);
            Balls.Remove(ball);
         Invoke(   nameof( CreateNewBall), 2f);
        }

        public void CreateNewBall()
        {
            var ball = _ballPool.CreateObject(Vector3.zero);
            
            ball.MyTransform.position = _player.MyTransform.position + new Vector3(0, 0.3f, 0);
            ball.MyTransform.parent = _player.MyTransform;
            Balls.Add(ball);
        }

        public void RunBall()
        {
            foreach (var ball in Balls)
            {
                if (Math.Abs(ball.Speed) < 0.1f)
                {
                    ball.Speed = startSpeed;
                    ball.Direction = new Vector3( Random.Range( -0.5f, 0.5f), 1 , 0 ).normalized;
                    ball.MyTransform.parent = null;
                    return;
                }
            }
        }
    }
}
