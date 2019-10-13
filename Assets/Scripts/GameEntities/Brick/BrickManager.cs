using System;
using System.Collections.Generic;
using GameEntities.IBehaviour;
using UnityEngine;

namespace GameEntities.Brick
{
   public class BrickManager : MonoBehaviour, IManagerForDestroyable
   {
      [SerializeField] private bool _GenerateBonus;
      
      private Dictionary<GameObject, IDestroyable> _bricks = new Dictionary<GameObject, IDestroyable>();
      private int _currentCount;

      private IBrush _brush;
      private IGameLogic _gameLogic;
      private IBonusManager _bonusManager;
      
      private void Start()
      {
         _brush = RealizationBox.Instance.BrickBrush;
         _gameLogic =  RealizationBox.Instance.GameLogic;
         if(_GenerateBonus)
            _bonusManager =  RealizationBox.Instance.BonusManager;
         InitializationBricks();
      }

      private void InitializationBricks()
      {
         foreach (var brick in GetComponentsInChildren<IDestroyable>())
         {
            _bricks.Add( brick.MyGameObject, brick);
            VisualUpdateObj(brick);
         }
         _currentCount = _bricks.Count;
      }

      public void DestroyObject( GameObject destroyObj, uint damage)
      {
         if( !_bricks.ContainsKey( destroyObj) )
            return;
      
         IDestroyable brick = _bricks[destroyObj];
         brick.Damage( damage);
         
         if (brick.IsDestroy)
         {
            _currentCount--;
            if (_currentCount == 0)
               FullDestroy();
         }
         else
            VisualUpdateObj( brick);
         
         if(_GenerateBonus)
            _bonusManager.GenerateBonus(brick.MyPosition);
      }

      public void VisualUpdateObj(IDestroyable destroyObj)
      {
         destroyObj.VisualUpdate( _brush.GetColor( (int)destroyObj.HP ));
      }

      public void FullDestroy()
      {
         _gameLogic.AnalyzeGameEvent( GameEvents.DestroyAllBricks);
      }

      public void Reload()
      {
         foreach (var gameObj in _bricks.Keys)
         {
            gameObj.SetActive(true);
            var brick = _bricks[gameObj];
            
            brick.Reload();
            VisualUpdateObj( brick );
         }
         _currentCount = _bricks.Count;
      }
   }
}
