using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePanel : MonoBehaviour
{
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private PlayerController _playerController;

    [SerializeField] private TextMeshProUGUI _aliveCount;
    [SerializeField] private TextMeshProUGUI _skore;

    private void Awake()
    {
        _skore.text = _playerController.playerScore.ToString();
        _aliveCount.text = _gameManager.aliveCount.ToString();

    }
    private void FixedUpdate()
    {
        if (_gameManager.isStart == true)
        {
            _gamePanel.SetActive(true);
        }
        _skore.text = _playerController.playerScore.ToString();
    }
}
