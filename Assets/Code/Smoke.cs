using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
	private Animator anim; // аниматор = аним
	[SerializeField] private GameObject Pers;
	[SerializeField] private GameObject smoke;
	[SerializeField] private GameObject bullet;
	[SerializeField] private GameObject SpawnBullet;
	[SerializeField] private Rigidbody2D rb;
	private float XPers;
	private float YPers;
	private float pilyus;
    void Start()
    {
		anim = GetComponent<Animator>();// амин = аниматор
        smoke.GetComponent<SpriteRenderer>().enabled = false;
		rb = GetComponent<Rigidbody2D>();
    }

    IEnumerator SmokeL()
	{
		Instantiate(bullet,SpawnBullet.transform.position, Quaternion.identity);
		yield return new WaitForSeconds(0.1f);
		smoke.GetComponent<SpriteRenderer>().enabled = true;
		XPers = Pers.transform.position.x;
		YPers = Pers.transform.position.y;
		transform.position = new Vector3(pilyus + XPers, 0.135f + YPers, 0f);
		yield return new WaitForSeconds(1.8f);
		smoke.GetComponent<SpriteRenderer>().enabled = false;
		anim.SetBool("Shoot", false);
	}
    void Update()
    {
		if(YanHodit.Gun == 1)//смотрит вправо
        {
			transform.localScale = new Vector3(3f, 3f, 0f);
			pilyus = 5.47f;
			anim.SetBool("Shoot", true);
			StartCoroutine(SmokeL());
			rb.velocity = new Vector2(Wind.XWindd,Wind.YWindd);
		}
		if(YanHodit.Gun == 2)//смотрит влево
        {
			transform.localScale = new Vector3(-3f, 3f, 0f);
			pilyus = -5.47f;
			anim.SetBool("Shoot", true);
			StartCoroutine(SmokeL());
			rb.velocity = new Vector2(Wind.XWindd,Wind.YWindd);		
		}
    }
}
