using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MapParser : MonoBehaviour {

    string m_strPath = "Assets/Resources/";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void Parse()
    {
        TextAsset data = Resources.Load("Data", typeof(TextAsset)) as TextAsset;
        StringReader sr = new StringReader(data.text);

        string sources = sr.ReadLine();
        string[] values;

        while(sources != null)
        {
            values = sources.Split(' ');
            if(values.Length == 0)
            {
                sr.Close();
                return;
            }
            sources = sr.ReadLine();
        }
    }
}
