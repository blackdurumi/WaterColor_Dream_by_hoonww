using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    [SerializeField]
    private int speed = 60;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        GameObject sphere = GameObject.Find("Sphere");
        Transform tf = sphere.GetComponent<Transform>();

		if (Input.GetKey(KeyCode.A))
			transform.RotateAround(new Vector3(tf.position.x, 0, tf.position.z), Vector3.up, speed * Time.deltaTime);

		if (Input.GetKey(KeyCode.D))
			transform.RotateAround(new Vector3(tf.position.x, 0, tf.position.z), Vector3.down, speed * Time.deltaTime);
	}
}
