using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRule : MonoBehaviour
{
    [SerializeField] private GameObject _deadPanel;
    [SerializeField] private Player _player;
    [SerializeField] private SaveManager _saveManager;

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
        int currenSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            _saveManager.ResetData();
            SceneManager.LoadScene(currenSceneIndex);
        }

        SceneManager.LoadScene(currenSceneIndex);
    }

    public void ExitMainMenu()
    {
        _saveManager.SavePlayerData();
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
