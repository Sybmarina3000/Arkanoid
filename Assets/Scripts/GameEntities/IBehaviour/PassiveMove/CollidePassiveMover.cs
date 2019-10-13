using System.Collections;
using System.Collections.Generic;
using GameEntities.IBehaviour.PassiveMove;
using UnityEngine;

public abstract class CollidePassiveMover : PassiveMoveBehavior
{
    abstract protected bool CalculateCollision();
    abstract protected void AnalyzeCollisionByTag(GameObject obj);
}
