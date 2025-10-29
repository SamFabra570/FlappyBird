using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;

    public bool poolCreated = false;

    private List<GameObject> pooledObjects;

    public GameObject objectToPool;
    public int poolSize = 6;

    [SerializeField] private float spawnSpaceInterval = 4.5f;
    private float spawnHeight;

    

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
        }

        poolCreated = true;
    }

    private void Update()
    {
        
        for (int y = 0; y < poolSize; y++)
        {


            SpawnPooledObject(y);


        }


    }

    public void SpawnPooledObject(int index)
    {
        
        if (index >= 1)
        {
            int rnd = Random.Range(-1, 1);
            pooledObjects[index].gameObject.transform.position = new Vector3(0, (rnd), (spawnSpaceInterval * index));
            pooledObjects[index].gameObject.SetActive(true);
        }
        else
        {
            pooledObjects[index].gameObject.transform.position = new Vector3(0, 0, (spawnSpaceInterval * index));
            pooledObjects[index].gameObject.SetActive(true);
        } 
    }


    //for spawning just do getpooledobj translate + whatever distance in between

}
