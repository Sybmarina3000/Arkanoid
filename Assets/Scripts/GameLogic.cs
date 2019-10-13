using System;
using System.Collections.Generic;
using GameEntities.Ball;
using GameEntities.IBehaviour;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public enum GameEvents
{
    DestroyAllBricks,
    DropBall,
}
public interface IGameLogic
{
    void AnalyzeGameEvent( GameEvents currentEvent);
    
    void Reload();
    void WinGame();
    void EndGame();
}

public class GameLogic : MonoBehaviour, IGameLogic
{
    [SerializeField] private bool FinishGame;
    [SerializeField] private Scene _NextScene;

    private IBallManager _ballManager;
    private IManagerForDestroyable _brickmanager;
    private IPlayer _player;

    [SerializeField] private UnityEvent _EndGame;
    [SerializeField] private UnityEvent _WinGame;

    private void Start()
    {
        _ballManager = RealizationBox.Instance.BallManager;
        _brickmanager = RealizationBox.Instance.ManagerForDestroyable;
        _player = RealizationBox.Instance.Player;

    }

    public void AnalyzeGameEvent(GameEvents currentEvent)
    {
        switch (currentEvent)
        {
            case GameEvents.DestroyAllBricks:
            {
                WinGame();
                break;
            }
            case GameEvents.DropBall:
            {
                EndGame();
                break;
            }
        }

    }

    public void Reload()
    {
        _ballManager.CreateNewBall();
        _brickmanager.Reload();
        _player.Reload();
    }

    public void WinGame()
    {
        Debug.Log("Win GAME");
        _ballManager.FinishGame();
        _WinGame.Invoke();
    }

    public void EndGame()
    {
        Debug.Log("GAME OVER");
        _EndGame.Invoke();
    }

    private void FinishAllGame()
    {
        Debug.Log("Win ALL Game!!!");
    }
}
