﻿using System.Collections.Generic;
using Helper.Patterns;
using UnityEngine;

namespace CustomUpdate
{
    public class CustomUpdater : Singleton<CustomUpdater>, IUpdating
    {
        List<IUpdatable> _updatableObjects = new List<IUpdatable>();
        private void Update()
        {
            for (int i = 0; i < _updatableObjects.Count; i++)
            {
                _updatableObjects[i].UpdateMe();
            }
        }

        public void AddUpdatableItem(IUpdatable item)
        {
            if( !_updatableObjects.Contains( item))
                _updatableObjects.Add(item);
                
        }

        public void RemoveUpdateItem(IUpdatable item)
        {
            _updatableObjects.Remove(item);
        }
    }
}
