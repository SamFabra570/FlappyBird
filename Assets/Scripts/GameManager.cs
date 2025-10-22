using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private UIController UI;

    public int score = 0;

    public bool playing = false;

    // Start is called before the first frame update
    void Start()
    {
        playing = true;
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

    public void RestartGame()
    {
        //restart scene
    }
    
    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
