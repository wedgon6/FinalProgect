using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    private SaveManager _saveManager;
    private GameObject _target;

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("SaveManager");
        _saveManager = _target.GetComponent<SaveManager>();       
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _saveManager.SavePlayerData();
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene + 1);
        }
    }
}
