﻿using GameEntities.Ball;
using GameEntities.Bonus;
using GameEntities.Brick;
using GameEntities.IBehaviour;
using GameEntities.Player;
using Helper.Patterns;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

public class RealizationBox : Singleton<RealizationBox>
{
    [SerializeField] private Racket _Player;
    [SerializeField] private BrickManager _BrickManager;
    [SerializeField] private BrickBrush _BrickBrush;
    [SerializeField] private GameLogic _GameLogic;
    [SerializeField] private BallManager _BallManager;
    [SerializeField] private BonusManager _BonusManager;
    
    public IPlayer Player => _Player;
    public IManagerForDestroyable ManagerForDestroyable => _BrickManager;
    public IBrush BrickBrush => _BrickBrush;
    public IGameLogic GameLogic => _GameLogic;
    public IBallManager BallManager => _BallManager;
    [CanBeNull] public IBonusManager BonusManager => _BonusManager;
}