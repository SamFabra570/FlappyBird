using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tubo : MonoBehaviour
{
    [SerializeField] private GameObject manager;
    private GameManager gameManager;
    private static int score;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = manager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        score++;        

        if (score > gameManager.score)
        {
            gameManager.score = score;
        }
    }
}
