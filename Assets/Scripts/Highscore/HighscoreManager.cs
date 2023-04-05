using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HighscoreManager : MonoBehaviour
{
    public static HighscoreManager Instance;

    private string KeyToSave = "HighscorePlayer";

    public TextMeshProUGUI HighScoreText;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        HighScoreText.text = PlayerPrefs.GetString(KeyToSave, "No highscore");
    }

    public void SavePlayerWin(Player player)
    {
        PlayerPrefs.SetString(KeyToSave, player.Name);
        HighScoreText.text = player.Name;
    }

    public void ResetKeys()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
}
