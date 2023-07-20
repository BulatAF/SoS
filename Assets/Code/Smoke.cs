using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
	private Animator anim; // аниматор = аним
	[SerializeField] private GameObject Pers;
	[SerializeField] private GameObject smoke;
    void Start()
    {
		anim = GetComponent<Animator>();// амин = аниматор
        smoke.GetComponent<SpriteRenderer>().enabled = false;
    }

    IEnumerator SmokeL()
	{
		
		yield return new WaitForSeconds(1.8f);
		anim.SetBool("Shoot", false);
	}
    void Update()
    {
		if(YanHodit.Gun == 1)
        {
			anim.SetBool("Shoot", true);
			smoke.GetComponent<SpriteRenderer>().enabled = true;
			transform.position = new Vector3(5.47f + Pers.transform.position.x, 0.135f + Pers.transform.position.y, 0f);
			StartCoroutine(SmokeL());
		}
    }
}
