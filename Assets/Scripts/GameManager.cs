using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private UIController UI;

    public int score = 0;

    public bool playing = false;

    // Start is called before the first frame update
    void Start()
    {        
        UI = GetComponent<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        Debug.Log("game over");
        playing = false;
        UI.gameOverImage.SetActive(true);
        UI.retryButton.SetActive(true);
        UI.quitButton.SetActive(true);
    }

    public void StartGame()
    {
        UI.startButton.SetActive(false);
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
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
