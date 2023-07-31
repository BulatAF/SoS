using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public static float XWindd;
	public static float YWindd;
    void Start()
    {
        XWindd = Random.Range(-5f,5f);
		YWindd = Random.Range(-1f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
