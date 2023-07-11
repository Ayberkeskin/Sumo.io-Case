using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePanel : MonoBehaviour
{
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private PlayerController _playerController;

    [SerializeField] private TextMeshProUGUI _aliveCount;
    [SerializeField] private TextMeshProUGUI _skore;

    [SerializeField] private GameObject _pausePanel;

    [SerializeField] private Button _pauseBtn;
    [SerializeField] private Button _resummeBtn;
    [SerializeField] private Button _restartBtn;

    private void Awake()
    {
        _skore.text = _playerController.playerScore.ToString();

    }
    private void FixedUpdate()
    {
        if (_gameManager.isStart == true)
        {
            _gamePanel.SetActive(true);
        }
        _skore.text = _playerController.playerScore.ToString();
        _aliveCount.text = _gameManager.aliveCount.ToString();
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        _pausePanel.SetActive(true);
    }
    public void RessumeGame()
    {
        Time.timeScale = 1f;
        _pausePanel.SetActive(false);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
