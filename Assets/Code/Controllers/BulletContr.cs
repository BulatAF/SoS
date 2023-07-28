using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletContr : MonoBehaviour
{
    private Animator anim; // аниматор = аним
	private Rigidbody2D rb;
	private float storon;
	private bool stopMove;
    void Start()
    {
		storon = (YanHodit.Gun *2 - 3) * -10f;
        anim = GetComponent<Animator>();// амин = аниматор
		rb = GetComponent<Rigidbody2D>();// рб = риджет бади
		YanHodit.Gun = 0;
    }
		private void OnTriggerEnter2D(Collider2D collision)
		{
			if(collision.gameObject.tag == "Mishen") 
			{
				stopMove = true;
				storon = 0f;
				
			}
		}
	void Update()
	{
		if(stopMove == false)
		{

			rb.velocity = new Vector3(storon * (Wind.XWindd * 0.1f),Wind.YWindd * 0.1f,0f);
		}
		else{
			rb.velocity = new Vector3(0f,0f,0f);
			transform.position += new Vector3(Random.Range(storon * 0.0001f,storon * 0.0003f), 0f,0f);
			storon = 0f;
			anim.Play("bulletStop");
		}
	}
	
	
}
