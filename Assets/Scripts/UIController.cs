using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    public GameObject gameOverImage;
    public GameObject quitButton;
    public GameObject startButton;
    public GameObject retryButton;
    public GameObject panel;
    private GameManager gameManager;
    

    private int scoreVal = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        gameOverImage.SetActive(false);
        quitButton.SetActive(false);
        retryButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.score != scoreVal)
        {
            UpdateScore();            
        }

        scoreText.text = ("Puntos: " + scoreVal);
    }

    private void UpdateScore()
    {
        scoreVal = gameManager.score;        
    }
}
