using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoverCamera : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private float velocidad = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cam.Translate(new Vector3(0, 0, velocidad) * Time.deltaTime);
    }
}
