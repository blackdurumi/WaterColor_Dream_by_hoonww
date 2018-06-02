using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour {

    UIManager UIManager;

	// Use this for initialization
	void Start () {
		GameObject pl = GameObject.Find("Sphere");
		RaycastHit hit;
		Physics.Raycast(pl.transform.position, Vector3.down, out hit, Mathf.Infinity);
		transform.position = hit.point + new Vector3(0, 0.001f, 0);

        UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
	}
	
	// Update is called once per frame
	void Update () {
		GameObject pl = GameObject.Find("Sphere");
		RaycastHit hit;
		bool tf = Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity);

		UnityEngine.Color ExpectedColor;

        if (tf)
        {
            ExpectedColor = (pl.GetComponent<MeshRenderer>().materials[0].color + hit.transform.gameObject.GetComponent<MeshRenderer>().materials[0].color) / 2.0f;

            UIManager.UpdateExpectedColorImage(ExpectedColor);
        }
	}
}
