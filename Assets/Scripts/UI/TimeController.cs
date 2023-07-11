using System.Collections;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    public float timeLeft;
    public bool timerOn = false;

    public TextMeshProUGUI timerText;


    private void Update()
    {
        if (gameManager.isStart)
        {
            timerOn = true;
        }
        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
            }
            else
            {
                timeLeft = 0;
                timerOn = false;
            }
        }
    }
    void updateTimer(float time)
    {
        time -= 1;
        float min = Mathf.FloorToInt(time / 60);
        float sec = Mathf.FloorToInt(time % 60);

        timerText.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}
