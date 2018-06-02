using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTile : MonoBehaviour {

    // Use this for initialization
    void Start() {
        float[] xx = new float[6] { 0, 9, 9, 0, -9, -9 };
        float[] zz = new float[6] { 10.392f, 5.196f, -5.196f, -10.392f, -5.196f, 5.196f };

            //1. instantiate existing gameobject
        GameObject obj = GameObject.Find("tile");
		for (int i = 0; i < 6; i++) {
			GameObject tile = Instantiate(obj, new Vector3(obj.transform.position.x + xx[i], obj.transform.position.y, obj.transform.position.z + zz[i]), Quaternion.identity);
            
            //tile.GetComponentInChildren<Renderer>().materials[0].SetColor("_Color", new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f)));
            tile.GetComponentInChildren<MeshRenderer>().materials[0] = (UnityEngine.Material)Resources.Load("Resources/Tile Material");
		}
        // 2. instantiate from resources/prefab
        //Instantiate(Resources.Load("Prefabs/Tile_prefab"), Vector3.up * 5, Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
