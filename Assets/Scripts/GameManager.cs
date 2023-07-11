using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Animator animator;

    public TimeController timeController;

    public CharacterController characterController;

    public bool isStart;

    public bool isEnd = false;

    public int aliveCount;

    private void Awake()
    {
        aliveCount = 8;

    }
    private void Update()
    {
        if (GameObject.Find("Player") == null)
        {
            isEnd = true;
        }
        FinishGame();
    }
  
    //Oyunu bitiren fonksiyon
    private void FinishGame()
    {
        if (aliveCount == 1 || timeController.timeLeft == 0)
        {
        
            animator.SetBool(CharacterAnimationsStrings.MoveStr, false);
            animator.SetBool(CharacterAnimationsStrings.WinStr, true);
            isStart = false;
            timeController.timerOn = false;
            isEnd = true;
        }

    }
}
