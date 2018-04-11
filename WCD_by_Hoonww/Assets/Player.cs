using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    bool isColliding;
    private void OnCollisionEnter(Collision collision)
    {
        if (isColliding) return;
        isColliding = true;
        if (collision.collider.tag == "Tile")
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(0, 450, 0));

            UnityEngine.Color ChangedColor;
            ChangedColor = GetComponent<MeshRenderer>().materials[0].color + collision.collider.GetComponent<MeshRenderer>().materials[0].color;
                /*new UnityEngine.Color(
                (GetComponent<MeshRenderer>().materials[0].GetColor. + collision.collider.GetComponent<MeshRenderer>().materials[0].GetColor(0)) / 2.0f,
                (GetComponent<MeshRenderer>().materials[0].GetColor(1) + collision.collider.GetComponent<MeshRenderer>().materials[0].GetColor(1)) / 2.0f,
                (GetComponent<MeshRenderer>().materials[0].GetColor(2) + collision.collider.GetComponent<MeshRenderer>().materials[0].GetColor(2)) / 2.0f);*/
            GetComponent<MeshRenderer>().materials[0].SetColor("_Color", ChangedColor);
        }
    }

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(50, 0, 0));
        GetComponent<MeshRenderer>().materials[0].SetColor("_Color", new UnityEngine.Color(1.0f, 1.0f, 1.0f));
        
    }

    void Update()
    {
        isColliding = false;
    }
}