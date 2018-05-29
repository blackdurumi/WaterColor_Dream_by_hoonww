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
            GameObject camera = GameObject.Find("Main Camera");
            Rigidbody cmrb = camera.GetComponent<Rigidbody>();
			rb.velocity = new Vector3(0,0,0);
            rb.AddForce(new Vector3(0, 450, 100));
            //cmrb.AddForce(new Vector3(0, 450, 0));

            Debug.Log("player color : " + GetComponent<MeshRenderer>().materials[0].color);
            Debug.Log("tile color : " + collision.collider.GetComponent<MeshRenderer>().materials[0].color);
            UnityEngine.Color ChangedColor;
            ChangedColor = (GetComponent<MeshRenderer>().materials[0].color + collision.collider.GetComponent<MeshRenderer>().materials[0].color) / 2.0f;
            GetComponent<MeshRenderer>().materials[0].SetColor("_Color", ChangedColor);
            Debug.Log("Changed color : " + ChangedColor);
        }
    }

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        GameObject camera = GameObject.Find("Main Camera");
        Rigidbody cmrb = camera.GetComponent<Rigidbody>();
        GetComponent<MeshRenderer>().materials[0].SetColor("_Color", new UnityEngine.Color(1.0f, 1.0f, 1.0f));

        //rb.AddForce(new Vector3(0, 0, 100));
        //cmrb.AddForce(new Vector3(0, 0, 100));
    }

    void Update()
    {
        isColliding = false;
    }
}