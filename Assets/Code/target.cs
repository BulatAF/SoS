using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    [SerializeField] private BoxCollider2D[] Tfalse;
	[SerializeField] private BoxCollider2D[] Ttrue;
	public static int TfalsE;
	public static int TtruE;
	
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(TfalsE > 0)
		{
			Tfalse[TfalsE-1].GetComponent<BoxCollider2D>().enabled = false;
		}
		if(TtruE > 0)
		{
			Ttrue[TtruE-1].GetComponent<BoxCollider2D>().enabled = false;
		}
    }
}
