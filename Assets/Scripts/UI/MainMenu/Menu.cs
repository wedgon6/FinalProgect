using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
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
        SceneManager.LoadScene("Battleground");
    }

    public void ResumeGame()
    {
        SceneManager.LoadScene(_saveManager.GetSaveSceneIndex());
    }
}
