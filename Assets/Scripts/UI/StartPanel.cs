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
    [SerializeField] private Canvas _startPanel;


    private void Start()
    {
        StartCoroutine(CountdownToStart());
    }

    // Oyun baþýnda 3 den geriye sayým
    IEnumerator CountdownToStart()
    {
        while (countDownTime > 0)
        {
            countDownDisplay.text = countDownTime.ToString();

            yield return new WaitForSeconds(1f);

            countDownTime--;

        }
        countDownDisplay.text = "GO!";
        yield return new WaitForSeconds(.2f);
        _gameManager.isStart = true;
        _startPanel.enabled = false;

        yield return new WaitForSeconds(1f);

        countDownDisplay.gameObject.SetActive(false);

    }
}
