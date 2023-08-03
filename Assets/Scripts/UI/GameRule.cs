using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRule : MonoBehaviour
{
    public void ExitMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
