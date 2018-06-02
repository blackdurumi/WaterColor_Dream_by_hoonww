using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    bool isColliding;
	const int side = 6;
    private void OnCollisionEnter(Collision collision)
    {
        if (isColliding) return;
        isColliding = true;
        if (collision.collider.tag == "Tile")
        {
            Rigidbody rb = GetComponent<Rigidbody>();
			rb.velocity = new Vector3(0,0,0);
            rb.AddForce(new Vector3(0, 9.836f, 5.679f)*50);

            //Debug.Log("player color : " + GetComponent<MeshRenderer>().materials[0].color);
            //Debug.Log("tile color : " + collision.collider.GetComponent<MeshRenderer>().materials[0].color);

            UnityEngine.Color ChangedColor;
            ChangedColor = (GetComponent<MeshRenderer>().materials[0].color + collision.collider.GetComponent<MeshRenderer>().materials[0].color) / 2.0f;
            GetComponent<MeshRenderer>().materials[0].SetColor("_Color", ChangedColor);

            //Debug.Log("Changed color : " + ChangedColor);

			GameObject scope = GameObject.Find("Scope");
			scope.transform.position += Vector3.forward * side * 1.9f;
        }
    }

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        GameObject camera = GameObject.Find("Main Camera");
        Rigidbody cmrb = camera.GetComponent<Rigidbody>();
        GetComponent<MeshRenderer>().materials[0].SetColor("_Color", new UnityEngine.Color(1.0f, 1.0f, 1.0f));

        cmrb.AddForce(new Vector3(0, 0, 5.679f) * 50);
    }

    void Update()
    {
        isColliding = false;
    }
}