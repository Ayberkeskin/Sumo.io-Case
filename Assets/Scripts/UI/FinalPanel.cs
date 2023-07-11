using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalPanel : MonoBehaviour
{
    [Header("De�i�kenler")]
    [SerializeField] private GameObject _finalPanel;
    [SerializeField] private GameManager _gameManager;

    private void Update()
    {
        if (_gameManager.isEnd)
        {
            _finalPanel.SetActive(true);
        }
    }
    // Oyunu yeniden ba�lat
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _finalPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
