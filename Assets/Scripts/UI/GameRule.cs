using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRule : MonoBehaviour
{
    [SerializeField] private GameObject _deadPanel;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.PlaeyDie += OnPlayerDay;
    }

    private void OnDisable()
    {
        _player.PlaeyDie -= OnPlayerDay;
    }

    private void OnPlayerDay()
    {
        _deadPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
