using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private int _standartHealth;
    private int _standartVitality;
    private int _standartScore;
    private int _standartProgress; 
    private int _playerHealth;
    private int _playerVitality;
    private int _playerScore;
    private int _playerLvlProgress;

    private string _playerHealthKey = "PlayerHP";
    private string _playerVitalityKey = "PlayerVitality";
    private string _playerScoreKey = "PlayerScore";
    private string _palaerLvlProgressKey = "PlayerProgress";

   public void SavePlayerData()
    {
        PlayerPrefs.SetInt(_playerHealthKey, _playerHealth);
        PlayerPrefs.SetInt(_playerVitalityKey, _playerVitality);
        PlayerPrefs.SetInt(_playerScoreKey, _playerScore);
        PlayerPrefs.SetInt(_palaerLvlProgressKey, _playerLvlProgress);
    }

    public void LoadPalyerData()
    {
        if (PlayerPrefs.HasKey(_playerHealthKey))
        {
            _playerHealth = PlayerPrefs.GetInt(_playerHealthKey);
        }
        else
        {

        }

        if (PlayerPrefs.HasKey(_playerVitalityKey))
        {
            _playerVitality = PlayerPrefs.GetInt(_playerVitalityKey);
        }
        else
        {

        }

        if (PlayerPrefs.HasKey(_playerScoreKey))
        {
            _playerScore = PlayerPrefs.GetInt(_playerScoreKey);
        }
        else
        {

        }

        if (PlayerPrefs.HasKey(_palaerLvlProgressKey))
        {
            _playerLvlProgress = PlayerPrefs.GetInt(_palaerLvlProgressKey);
        }
        else
        {

        }
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();

        _playerHealth = 0;
        _playerVitality = 0;
        _playerScore = 0;
        _playerLvlProgress = 0;
    }

}
