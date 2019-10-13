using System.Collections.Generic;
using System.Security.Cryptography;
using Helper.Patterns;
using UnityEngine;

namespace CustomUpdate
{
    public class CustomUpdater : Singleton<CustomUpdater>, IUpdating
    {
        List<IUpdatable> _updatableObjects = new List<IUpdatable>();
        private IUpdatable[] _updatables;
        private void Update()
        {
            if (_updatables.Length == 0)
                return;
            for (int i = 0; i < _updatables.Length; i++)
            {
                _updatables[i].UpdateMe();
            }
        }

        public void AddUpdatableItem(IUpdatable item)
        {
            if( !_updatableObjects.Contains( item))
                _updatableObjects.Add(item);
            _updatables = _updatableObjects.ToArray();

        }

        public void RemoveUpdateItem(IUpdatable item)
        {
            _updatableObjects.Remove(item);
            _updatables = _updatableObjects.ToArray();
        }
    }
}
