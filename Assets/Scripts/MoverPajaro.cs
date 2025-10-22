using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPajaro : MonoBehaviour
{
    [SerializeField] GameObject manager;
    GameManager gameManager;

    [SerializeField] private Transform pajaro;
    [SerializeField] private Rigidbody rb;

    private Vector3 fuerza;
    [SerializeField] int fuerzaSalto = 1;
    [SerializeField] float velocidad = 1;
    [SerializeField] float grav = 1;


    //[SerializeField] private Transform pajaro;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = manager.GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();

        fuerza = new Vector3(0, fuerzaSalto, 0);
    }

    // Update is called once per frame
    void Update()
    {
        pajaro.Translate(new Vector3(0, 0, velocidad) * Time.deltaTime);

        rb.AddForce(new Vector3(0, -1, 0) * rb.mass * grav);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Saltar();
        }
    }

    private void Saltar()
    {
        rb.AddForce(fuerza, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameManager.GameOver();
    }
}
