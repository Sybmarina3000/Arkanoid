using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.GameEntity;
using UnityEngine;

public class BrickManager : MonoBehaviour, IManagerForDestroyable
{
   private Dictionary<GameObject, IDestroyable> _bricks = new Dictionary<GameObject, IDestroyable>();
   private int _currentCount;
   
   private void Awake()
   {
      InitializationBricks();
   }

   private void InitializationBricks()
   {
      foreach (var brick in GetComponentsInChildren<IDestroyable>())
      {
         Debug.Log("Add in dictionary " );
         _bricks.Add( brick.MyGameObject, brick);
      }
      _currentCount = _bricks.Count;
   }

   public void DestroyObject( GameObject destroyObj, uint damage)
   {
      Debug.Log("Destroy obj name " + destroyObj.name);
      IDestroyable brick = _bricks[destroyObj];
      if (ReferenceEquals(brick, null))
         return;
      
      brick.Damage( damage);
      if (brick.IsDestroy)
         _currentCount--;
   }
}
