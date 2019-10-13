using GameEntities.Brick;
using GameEntities.IBehaviour;
using GameEntities.Player;
using Helper.Patterns;
using UnityEngine;

public class RealizationBox : Singleton<RealizationBox>
{
    [SerializeField] private Racket _Player;
    [SerializeField] private BrickManager _BrickManager;
    [SerializeField] private BrickBrush _BrickBrush;
    public IPlayer Player => _Player;
    public IManagerForDestroyable ManagerForDestroyable => _BrickManager;
    public IBrush BrickBrush => _BrickBrush;
}