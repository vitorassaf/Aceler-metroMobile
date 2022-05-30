using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    Rigidbody rb;

    public Transform spawnpoint;
    public Transform spawnpoint2;
    public GameObject camera;
    public Transform cameraposition2;
    public Transform cameraposition1;





    public float speed = 5;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        rb.velocity = new Vector3(Input.acceleration.x * speed, 0,Input.acceleration.y * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "fim1")
        {
            transform.position = spawnpoint2.transform.position;
            camera.transform.position = cameraposition2.transform.position;
        }
       
        if (collision.collider.tag == "Buraco")
        {
            transform.position = spawnpoint.transform.position;
        }
        if(collision.collider.tag == "car")
        {
            transform.position = spawnpoint2.transform.position;
        }

        if (collision.collider.tag == "Fim2")
        {
            transform.position = spawnpoint.transform.position;
            camera.transform.position = cameraposition1.transform.position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "car")
        {
            transform.position = spawnpoint2.transform.position;
        }
    }



}
