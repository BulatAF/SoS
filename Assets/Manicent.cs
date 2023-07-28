using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manicent : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
		private void OnTriggerEnter2D(Collider2D collision)
		{
			if(collision.gameObject.tag == "shpaga") 
			{
				StartCoroutine(Ud());
			}
			else{
				anim.SetBool("Udar", false);
			}
		}
	    IEnumerator Ud()
	{
		anim.SetBool("Udar", true);
		yield return new WaitForSeconds(0.02f);
		anim.SetBool("Udar", false);
	}
    
}
