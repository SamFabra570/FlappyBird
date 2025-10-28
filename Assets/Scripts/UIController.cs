using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    public GameObject gameOverImage;
    public GameObject quitButton;
    public GameObject startButton;
    public GameObject retryButton;
    public GameObject resetHighScoreButton;
    public GameObject panel;
    private GameManager gameManager;
    

    private int scoreVal = 0;
    private float highScoreVal;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = ("High Score: 0");
        gameManager = GetComponent<GameManager>();
        gameOverImage.SetActive(false);
        quitButton.SetActive(false);
        retryButton.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.score > scoreVal)
        {
            UpdateScore();            
        }

        scoreText.text = ("Score: " + scoreVal);

        if (highScoreVal != gameManager.highScore)
        {
            highScoreVal = gameManager.highScore;

            UpdateHighScoreText(gameManager.highScore);
        }
        
    }

    private void UpdateScore()
    {
        scoreVal = gameManager.score;        
    }

    public void UpdateHighScoreText(float highScore)
    {
        Debug.Log("high score update");
        highScoreText.text = ("High Score: " + highScore);
    }
}
