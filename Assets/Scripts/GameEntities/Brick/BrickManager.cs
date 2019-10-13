using System;
using System.Collections.Generic;
using GameEntities.IBehaviour;
using UnityEngine;

namespace GameEntities.Brick
{
   public class BrickManager : MonoBehaviour, IManagerForDestroyable
   {
      private Dictionary<GameObject, IDestroyable> _bricks = new Dictionary<GameObject, IDestroyable>();
      private int _currentCount;

      private IBrush _brush;
      private IGameLogic _gameLogic;
      
      private void Start()
      {
         _brush = RealizationBox.Instance.BrickBrush;
         _gameLogic =  RealizationBox.Instance.GameLogic;
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
            if(_currentCount == 0) 
               _gameLogic.AnalyzeGameEvent( GameEvents.DestroyAllBricks);
         }
         else
            VisualUpdateObj( brick);
      }

      public void VisualUpdateObj(IDestroyable destroyObj)
      {
         destroyObj.VisualUpdate( _brush.GetColor( (int)destroyObj.HP ));
      }

      public void FullDestroy()
      {
         throw new NotImplementedException();
      }
   }
}
