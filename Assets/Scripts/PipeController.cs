using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    private GameObject manager;
    private GameManager gameManager;

    [SerializeField] private float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = manager.GetComponent<GameManager>();
    }

    private void Update()
    {
        if ( gameManager.playing)
        {
            transform.position += new Vector3(0f, 0f, -speed * Time.deltaTime);
        }

        
        
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
