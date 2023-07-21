using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletContr : MonoBehaviour
{
    private Animator anim; // аниматор = аним
	[SerializeField] private GameObject Pers;
	[SerializeField] private GameObject bullet;
	private Rigidbody2D rb;
	private float pilyus;
    void Start()
    {
		YanHodit.Gun = 0;
		
        anim = GetComponent<Animator>();// амин = аниматор
        bullet.GetComponent<SpriteRenderer>().enabled = false;
		rb = GetComponent<Rigidbody2D>();// рб = риджет бади
		if(YanHodit.Gun == 1)//смотрит вправо
        {
			pilyus = 1.64f;
			StartCoroutine(SmokeL());
		}
		if(YanHodit.Gun == 2)//смотрит влево
        {
			pilyus = -1.64f;
			StartCoroutine(SmokeL());
		}
    }
IEnumerator SmokeL()
	{
		bullet.GetComponent<SpriteRenderer>().enabled = true;
		transform.position = new Vector3(pilyus + Pers.transform.position.x, 0.14f + Pers.transform.position.y, 0f);
		rb.velocity = new Vector3(0f,0f,0f);	
		yield return new WaitForSeconds(1.9f);
		//bullet.GetComponent<SpriteRenderer>().enabled = false;
	}
}
