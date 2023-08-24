using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    const string MainMenuScene = "MainMenu";
    const string BattlegroundScene = "Battleground";

    [SerializeField] private SaveManager _saveManager;

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }

    public void StartNewGame()
    {
        _saveManager.ResetData();
        SceneManager.LoadScene(BattlegroundScene);
    }

    public void ResumeGame()
    {
        _saveManager.LoadSaveScene();
    }

    public void ExinMainMenu()
    {
        _saveManager.ResetData();
        SceneManager.LoadScene(MainMenuScene);
    }
}
