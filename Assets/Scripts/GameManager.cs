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

    // Start is called before the first frame update
    void Start()
    {
        UI = GetComponent<UIController>();
        
        highScore = PlayerPrefs.GetFloat("highScore");
    }

    // Update is called once per frame
    void Update()
    {

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
        playing = true;

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
}
