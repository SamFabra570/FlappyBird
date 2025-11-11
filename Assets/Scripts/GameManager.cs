using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private UIController UI;

    public int score = 0;
    public float highScore = 0;

    public bool playing = false;
    public bool inMenu = true;

    private float masterVol;
    private float musicVol;
    private float sfxVol;

    // Start is called before the first frame update
    void Start()
    {
        UI = GetComponent<UIController>();
        
        highScore = PlayerPrefs.GetFloat("highScore");

        LoadVolumeSettings();
    }

    // Update is called once per frame
    void Update()
    {
        if (playing == false && inMenu)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartGame();
            } 
        }
    }

    public void GameOver()
    {
        if (score > highScore)
        {
            Debug.Log("send highscore update");
            UpdateHighScore();
        }

        Debug.Log("game over");
        playing = false;        

        UI.gameOverImage.SetActive(true);
        UI.retryButton.SetActive(true);
        UI.quitButton.SetActive(true);
    }

    public void StartGame()
    {
        UI.startButton.SetActive(false);
        UI.resetHighScoreButton.SetActive(false);
        UI.panel.SetActive(false);
        UI.titleText.SetActive(false);
        UI.volumeSettings.SetActive(false);
        playing = true;
        inMenu = false;

    }

    public void RestartGame()
    {
        //restart scene
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        //Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void UpdateHighScore()
    {
        PlayerPrefs.SetFloat("highScore", score);
        PlayerPrefs.Save();

        Debug.Log("high score updated");

        highScore = PlayerPrefs.GetFloat("highScore");
        UI.UpdateHighScoreText(highScore);        
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetFloat("highScore", 0);
        highScore = PlayerPrefs.GetFloat("highScore");

        UI.UpdateHighScoreText(highScore);
    }

    private void LoadVolumeSettings()
    {
        masterVol = PlayerPrefs.GetFloat("MasterVol");
        UI.master.value = masterVol;

        musicVol = PlayerPrefs.GetFloat("MusicVol");
        UI.music.value = musicVol;

        sfxVol = PlayerPrefs.GetFloat("SFXVol");
        UI.sfx.value = sfxVol;        
    }
}
