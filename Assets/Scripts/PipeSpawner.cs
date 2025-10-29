using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    private ObjectPool objectPool;

    // Start is called before the first frame update
    void Start()
    {
        GameObject pipe = ObjectPool.SharedInstance.GetPooledObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
