using System;
using System.Collections.Generic;
using GameEntities.IBehaviour;
using Helper.Patterns;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameEntities.Ball
{
    public interface IBallManager
    {
        void DestroyBall( IBall ball);
        void CreateNewBall();

        void RunBall();
    }
    public class BallManager : MonoBehaviour, IBallManager
    {
        [SerializeField] private BallPool _ballPool;
        private List<IBall> Balls;
        
        private IPlayer _player;

        [SerializeField] private float startSpeed;

        private void Start()
        {
            Balls = new List<IBall>();
            _player = RealizationBox.Instance.Player;
        }

        public void DestroyBall(IBall ball)
        {
            _ballPool.DestroyObject(ball);
            Balls.Remove(ball);
        }

        public void CreateNewBall()
        {
            var ball = _ballPool.CreateObject(Vector3.zero);
            
            ball.MyTransform.parent = _player.MyTransform;
            ball.MyTransform.position = _player.MyTransform.position + new Vector3(0, 0.3f, 0);
            Balls.Add(ball);
        }

        public void RunBall()
        {
            foreach (var ball in Balls)
            {
                if (Math.Abs(ball.Speed) < 0.1f)
                {
                    ball.Speed = startSpeed;
                    ball.Direction = new Vector3( Random.Range( -0.7f, 0.7f), Random.Range( -1f, 1f) , 0 );
                    ball.MyTransform.parent = null;
                    return;
                }
            }
        }
    }
}
