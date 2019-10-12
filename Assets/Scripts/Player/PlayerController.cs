using System;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

namespace DefaultNamespace
{
    public class PlayerController : MonoBehaviour
    {
        private IPlayer _player;

        private void Awake()
        {
            _player = RealizationBox.Instance.Player;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _player.MoveLeft();
                return;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                _player.MoveRight();
                return;
            }
        }
    }
}