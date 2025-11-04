using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    private GameObject manager;
    private GameManager gameManager;
    private ObjectPool objectPool;

    private Transform pipe;

    int rnd;
    int oldRnd;

    [SerializeField] private float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = manager.GetComponent<GameManager>();
        objectPool = manager.GetComponent<ObjectPool>();
        pipe = this.gameObject.transform;
    }

    private void Update()
    {
        if (gameManager.playing)
        {
            transform.position += new Vector3(0f, 0f, -speed * Time.deltaTime);
        }

        if (transform.position.z <= -10)
        {
            rnd = Random.Range(-2, 2);


            if (oldRnd == rnd)
            {
                rnd = Random.Range(-2, 2);
            }

            pipe.transform.position = new Vector3(0, rnd, 14.83f);
        }

        oldRnd = rnd;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager.score++;
    }

    
}
