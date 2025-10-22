using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;

    public bool playing = false;

    // Start is called before the first frame update
    void Start()
    {
        playing = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        Debug.Log("game over");
        playing = false;
    }
}
