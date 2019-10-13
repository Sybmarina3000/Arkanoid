using System;
using DefaultNamespace;
using UnityEngine;

public class CustomUpdatableBehavior : MonoBehaviour, IUpdatable
{
    private void Start()
    {
        EnableUpdate();
        CustomStart();
    }

    public virtual void CustomStart()
    {
    }

    private void OnDestroy()
    {
        DisableUpdate();
    }

    public void EnableUpdate()
    {
        CustomUpdater.Instance.AddUpdatableItem( this);
    }

    public void DisableUpdate()
    {
        CustomUpdater.Instance.AddUpdatableItem( this);
    }

    public virtual void UpdateMe()
    {
        Debug.Log("UDDATE UPDATABLE");
        Debug.LogError("CustomUpdatableBehavior.UpdateMe() not override");
    }
}
