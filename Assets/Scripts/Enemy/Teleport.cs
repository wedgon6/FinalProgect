using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("����� ����� � ��������");
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene + 1);
        }
    }
}
