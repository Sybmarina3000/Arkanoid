using System;
using System.Collections.Generic;
using GameEntities.Ball;
using UnityEngine;
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

    private void Start()
    {
        _ballManager = RealizationBox.Instance.BallManager;
        Reload();
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
                //Check count Ball;
                EndGame();
                break;
            }
        }

    }

    public void Reload()
    {
        _ballManager.CreateNewBall();
    }

    public void WinGame()
    {
        Debug.Log("Win Game!!!");
        
    }

    public void EndGame()
    {
        throw new System.NotImplementedException();
    }

    private void FinishAllGame()
    {
        Debug.Log("Win Game!!!");
    }
}
