using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private GameManager gameManager;

    private int scoreVal = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.score != scoreVal)
        {
            UpdateScore();            
        }

        scoreText.text = ("Score: " + scoreVal);
    }

    private void UpdateScore()
    {
        scoreVal = gameManager.score;

        
    }
}
