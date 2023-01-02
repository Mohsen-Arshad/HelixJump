using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace myTask
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public event Action GameMainMenu, GameStareted, GameFinished, GameWin, GameLose;
        public event Action<Vector3> TargetLocation;


        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            GameMenu();
        }

        #region EventFunctions
        public void StartTheGame()
        {
            GameStareted?.Invoke();
        }
        
        public void NextTarget(Vector3 target)
        {
            TargetLocation?.Invoke(target);
        }

        public void FinishTheGame()
        {
            GameFinished?.Invoke();
        }

        public void WinTheGame()
        {
            GameWin?.Invoke();
        }

        public void LoseTheGame()
        {
            GameLose?.Invoke();
        }

        public void GameMenu()
        {
            GameMainMenu?.Invoke();
        }
        #endregion

    }


}