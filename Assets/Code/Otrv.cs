using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otrv : MonoBehaviour
{
	private Rigidbody2D rb; //  рб = компонент риджет бади
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();// рб = риджет бади
		StartCoroutine(Down());
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	IEnumerator Down()
	{
		rb.velocity = new Vector2(Wind.XWindd * 0.6f,-1.2f+(Wind.YWindd * 0.6f));
		yield return new WaitForSeconds(1.5f);
		rb.velocity = new Vector2(0f,0f);
	}
	
}
