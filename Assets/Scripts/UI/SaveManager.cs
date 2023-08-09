using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int _standartHealth;
    [SerializeField] private int _standartVitality;
    [SerializeField] private int _standartScore;
    [SerializeField] private int _standartProgress; 

    private int _playerHealth;
    private int _playerVitality;
    private int _playerScore;
    private int _playerLvlProgress;
    private int _currentSceneIndex;
    private int _standartSceneIndex = 0;

    private string _playerHealthKey = "PlayerHP";
    private string _playerVitalityKey = "PlayerVitality";
    private string _playerScoreKey = "PlayerScore";
    private string _palaerLvlProgressKey = "PlayerProgress";
    private string _sceneIndexKey = "SceneIndex";

   public void SavePlayerData()
    {
        PlayerPrefs.SetInt(_playerHealthKey, _playerHealth);
        PlayerPrefs.SetInt(_playerVitalityKey, _playerVitality);
        PlayerPrefs.SetInt(_playerScoreKey, _playerScore);
        PlayerPrefs.SetInt(_palaerLvlProgressKey, _playerLvlProgress);
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt(_sceneIndexKey, _currentSceneIndex);
        Debug.Log("Сохранил данные");
    }

    public void LoadPalyerData()
    {
        if (PlayerPrefs.HasKey(_playerHealthKey))
        {
            _playerHealth = PlayerPrefs.GetInt(_playerHealthKey);
            _playerVitality = PlayerPrefs.GetInt(_playerVitalityKey);
            _playerScore = PlayerPrefs.GetInt(_playerScoreKey);
            _playerLvlProgress = PlayerPrefs.GetInt(_palaerLvlProgressKey);
            Debug.Log($"Загрузи данные!{_playerHealth}, {_playerVitality}");
        }
        else
        {
            _playerHealth = _standartHealth;
            _playerVitality = _standartVitality;
            _playerScore = _standartScore;
            _playerLvlProgress = _standartProgress;
            Debug.Log($"Загрузи стандартные!{_playerHealth}, {_playerVitality}");
        }

        _player.GetPlayerData(_playerHealth, _playerVitality);
    }

    public int GetSaveSceneIndex()
    {
        if (PlayerPrefs.HasKey(_sceneIndexKey))
        {
            return _currentSceneIndex;
        }
        else
        {
            return _standartSceneIndex;
        }
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();

        _playerHealth = _standartHealth;
        _playerVitality = _standartVitality;
        _playerScore = _standartScore;
        _playerLvlProgress = _standartProgress;
        _currentSceneIndex = _standartSceneIndex;
    }

}
