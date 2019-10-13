using System;
using System.Collections.Generic;
using GameEntities.IBehaviour;
using GameEntities.IBehaviour.PassiveMove;
using Helper.Patterns;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace GameEntities.Ball
{
    public interface IBallManager
    {
        void DestroyBall( PassiveMoveBehavior ball);
        void CreateNewBall();
        void RunBall();
        void FinishGame();
    }
    
    public class BallManager : MonoBehaviour, IBallManager
    {
        [FormerlySerializedAs("_ballPool")] [SerializeField] private PassiveMoveObjPool passiveMoveObjPool;
        private List<PassiveMoveBehavior> Balls;
        
        private IPlayer _player;
        private IGameLogic _gameLogic;
        [SerializeField] private float startSpeed;

        private void Start()
        {
            Balls = new List<PassiveMoveBehavior>();
            _player = RealizationBox.Instance.Player;
            _gameLogic = RealizationBox.Instance.GameLogic;
            
            CreateNewBall();
        }

        public void DestroyBall(PassiveMoveBehavior ball)
        {
            passiveMoveObjPool.DestroyObject(ball);
            Balls.Remove(ball);
            if (Balls.Count == 0)
                _gameLogic.AnalyzeGameEvent(GameEvents.DropBall);
        }

        public void CreateNewBall()
        {
            var ball = passiveMoveObjPool.CreateObject(Vector3.zero);
            
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

        public void FinishGame()
        {
            foreach (var item in Balls)
            {
                item.Speed = 0;
            }
        }
    }
}
