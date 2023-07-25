using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletContr : MonoBehaviour
{
    private Animator anim; // аниматор = аним
	[SerializeField] private GameObject Pers;
	[SerializeField] private GameObject bullet;
	private Rigidbody2D rb;
	private float storon;
    void Start()
    {
		storon = (YanHodit.Gun *2 - 3) * -10f;
        anim = GetComponent<Animator>();// амин = аниматор
        bullet.GetComponent<SpriteRenderer>().enabled = false;
		rb = GetComponent<Rigidbody2D>();// рб = риджет бади
		StartCoroutine(SmokeL());
		YanHodit.Gun = 0;
    }
IEnumerator SmokeL()
	{
		bullet.GetComponent<SpriteRenderer>().enabled = true;
		
		rb.velocity = new Vector3(storon,0.05f*storon,0f);	
		yield return new WaitForSeconds(2f);
		rb.velocity = new Vector3(storon,-0.05f*storon,0f);
		yield return new WaitForSeconds(2f);
	}
	
		private void OnTriggerEnter2D(Collider2D collision)
		{
			if(collision.gameObject.tag == "Mishen") 
			{
				rb.velocity = new Vector3(0f,0f,0f);	
				storon = 0f;
				anim.Play("bulletStop");
			}
		}
	
}
