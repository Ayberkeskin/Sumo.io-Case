using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StartPanel : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    [SerializeField] private int countDownTime;

    [SerializeField] private TextMeshProUGUI countDownDisplay;


    private void Start()
    {
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        while (countDownTime>0)
        {
            countDownDisplay.text=countDownTime.ToString();

            yield return new WaitForSeconds(1f);

            countDownTime--;

        }
        countDownDisplay.text = "GO!";

        _gameManager.isStart = true;

        yield return new WaitForSeconds(1f);

        countDownDisplay.gameObject.SetActive(false);
    }
}
