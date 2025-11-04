using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;

    public bool poolCreated = false;

    private List<GameObject> pooledObjects;

    public GameObject objectToPool;
    public int poolSize = 6;

    public int min = -2;
    public int max = 2;

    [SerializeField] private float spawnSpaceInterval = 4f;
    private float spawnHeight;

    private int oldRnd = 0;
    private int rnd;

    private void Awake()
    {
        SharedInstance = this;
    }


    private void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject obj;

        for (int i = 0; i < poolSize; i++)
        {
            obj = Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);

            SpawnPooledObject(i);
        }

        poolCreated = true;
    }

    private void Update()
    {
        
        
    }

    public void SpawnPooledObject(int index)
    {
        
        if (index >= 1)
        {
            rnd = Random.Range(min, max);
            

            if (oldRnd == rnd)
            {
                rnd = Random.Range(min, max);
            }


            pooledObjects[index].gameObject.transform.position = new Vector3(0, (rnd + 1), (spawnSpaceInterval * index));
            pooledObjects[index].gameObject.SetActive(true);
        }
        else
        {
            pooledObjects[index].gameObject.transform.position = new Vector3(0, 0, (spawnSpaceInterval * index));
            pooledObjects[index].gameObject.SetActive(true);
        }

        oldRnd = rnd;
    }


    //for spawning just do getpooledobj translate + whatever distance in between

}
