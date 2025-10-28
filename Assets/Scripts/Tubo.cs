using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tubo : MonoBehaviour
{
    [SerializeField] private GameObject manager;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = manager.GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager.score++;
    }

    //use this for object pooling
    private void OnBecameInvisible()
    {
        
    }
}
