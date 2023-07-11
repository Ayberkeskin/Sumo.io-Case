using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Animator animator;

    public TimeController timeController;



    public bool isStart;

     public  int aliveCount ;

    private void Awake()
    {
        aliveCount = 8;

    }
    private void Update()
    {
        FinishGame();
        Debug.Log(aliveCount);
    }

    private void FinishGame()
    {
        if (aliveCount == 1|| timeController.timeLeft==0)
        {
            animator.SetBool(CharacterAnimationsStrings.MoveStr, false);
            animator.SetBool(CharacterAnimationsStrings.WinStr, true);
            isStart = false;
            timeController.timerOn = false;

        }
        
    }
}
