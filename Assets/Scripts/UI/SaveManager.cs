using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private AbilityTree _abilityTree;
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
        _playerHealth = _player.CurrentHealth;
        _playerVitality = _player.CurrentVitality;
        _playerScore = _abilityTree.TotalScore;
        _playerLvlProgress = _abilityTree.CurrentProgress;
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        PlayerPrefs.SetInt(_playerHealthKey, _playerHealth);
        PlayerPrefs.SetInt(_playerVitalityKey, _playerVitality);
        PlayerPrefs.SetInt(_playerScoreKey, _playerScore);
        PlayerPrefs.SetInt(_palaerLvlProgressKey, _playerLvlProgress);
        PlayerPrefs.SetInt(_sceneIndexKey, _currentSceneIndex);
        Debug.Log(_currentSceneIndex);
    }

    public void LoadPalyerData()
    {
        if (PlayerPrefs.HasKey(_playerHealthKey))
        {
            _playerHealth = PlayerPrefs.GetInt(_playerHealthKey);
            _playerVitality = PlayerPrefs.GetInt(_playerVitalityKey);
            _playerScore = PlayerPrefs.GetInt(_playerScoreKey);
            _playerLvlProgress = PlayerPrefs.GetInt(_palaerLvlProgressKey);
        }
        else
        {
            _playerHealth = _standartHealth;
            _playerVitality = _standartVitality;
            _playerScore = _standartScore;
            _playerLvlProgress = _standartProgress;
        }

        _player.GetPlayerData(_playerHealth, _playerVitality);
        _abilityTree.GetPlayerData(_playerScore, _playerLvlProgress);
    }

    public int GetSaveSceneIndex()
    {
        if (PlayerPrefs.HasKey(_sceneIndexKey))
        {
            return _currentSceneIndex = PlayerPrefs.GetInt(_sceneIndexKey);
        }
        else
        {
            return _standartSceneIndex;
        }
    }

    public void LoadSaveScene()
    {
        Debug.Log(_currentSceneIndex);
        SceneManager.LoadScene(_currentSceneIndex = PlayerPrefs.GetInt(_sceneIndexKey));
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
