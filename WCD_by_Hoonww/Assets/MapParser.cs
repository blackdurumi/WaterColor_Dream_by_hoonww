using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class MapParser : MonoBehaviour {

    public DS data;

    string m_strPath = "Assets/Resources/";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Parse()
    {
        TextAsset dt = Resources.Load("Data.txt", typeof(TextAsset)) as TextAsset;
        StringReader sr = new StringReader(dt.text);

        string sources = sr.ReadLine();
        string[] values;
        int n = 0;
        int c = 0;

        while (sources != null)
        {
            values = sources.Split(' ');
            if (values.Length == 0)
            {
                sr.Close();
                return;
            }

            if (values.Length == 1 && data.Areas == 0)
                data.Areas = Convert.ToInt32(values[0]);
            else if (values.Length == 1)
                data.map[n].nextArea = Convert.ToInt32(values[0]);
            else
            {
                if (c == 0)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (Convert.ToInt32(values[i]) == 0) data.map[n].tile[i].enable = false;
                        else data.map[n].tile[i].enable = true;
                    }
                }
                else
                {
                    for (int i = 0; i < 7; i++)
                        data.map[n].tile[i].material_num = values[i];
                    n++;
                }

                c = 1 - c;
            }

            sources = sr.ReadLine();
        }
    }
}

public class DS{
    public int Areas;
    public Area[] map;
}

public class Area
{
    public Tile[] tile = new Tile[7];
    public int nextArea;
}

public class Tile
{
    public bool enable;
    public string material_num;
}