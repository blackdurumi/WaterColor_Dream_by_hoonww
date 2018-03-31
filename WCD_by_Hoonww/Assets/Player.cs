using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(50, 0, 0));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Tile")
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(0, 450, 0));
        }
    }
}