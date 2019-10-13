using System;
using GameEntities.Ball;
using GameEntities.IBehaviour;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameEntities.Bonus
{
    public interface IBonusManager
    {
        void GenerateBonus( Vector3 position);
        void UseBonus(IBonus bonus);
    }
    public class BonusManager : MonoBehaviour, IBonusManager
    {
        [SerializeField] private BonusPool Pool;
    
        [SerializeField] private float _speedMax, _speedMin;

        // TODO add enum enumerator in custom editor. For set mass.count == Enum.GetValues(typeof(BonusType)).Length
        [HideInInspector] [SerializeField] private Color[] _BonusColors;
        [SerializeField] [Range(0.0f, 1.0f)] private float _Probability;
    
        private int _countBonusType;

        private IPlayer _player;
        private IBallManager _ballManager;

        [Space(20)] [Header("BONUS VALUE")] 
        [SerializeField] private float _DeltaSize;
        [SerializeField] private float _DeltaSpeed;

    
        // Start is called before the first frame update
        void Start()
        {
            _player = RealizationBox.Instance.Player;
            _ballManager = RealizationBox.Instance.BallManager;
            _countBonusType = Enum.GetValues(typeof(BonusType)).Length;
        }
    
        public void GenerateBonus( Vector3 position)
        {
            if (Random.Range(0.0f, 1.0f) > _Probability)
                return;
        
            var point = Pool.CreateObject(position);

            int randomType = Random.Range(0, _countBonusType);
            point.SetType( (BonusType)randomType, _BonusColors[randomType]  );
        
            point.Direction = Vector3.down;
            point.Speed = Random.Range( _speedMin, _speedMax);
        }

        public void UseBonus(IBonus bonus)
        {
            if (_player.OnPlayer(bonus.UseCoordinat))
            {
                switch (bonus.BonusType)
                {
                    case BonusType.Sizer:
                    {
                        ChangePlayerSize();
                        break;
                    }
                    case BonusType.SpeedFaster:
                    {
                        ChangeBallsSpeed( _DeltaSpeed);
                        break;
                    }
                    case BonusType.SpeedLow:
                    {
                        ChangeBallsSpeed( -_DeltaSpeed);
                        break;
                    }
                    case BonusType.AddBall:
                    {
                        AddBonusBall();
                        break;
                    }
                }
            }

            Pool.DestroyObject( (Bonus)bonus);
        }

        private void ChangePlayerSize()
        {
            _player.ChangeSize(_DeltaSize);
        }

        private void ChangeBallsSpeed(float delta )
        {
            _ballManager.ChangeBallsSpeed( delta );
        }

        private void AddBonusBall()
        {
            _ballManager.CreateNewBall();
        }
    }
}