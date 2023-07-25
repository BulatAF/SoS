using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class OzvuchkaNew : MonoBehaviour
{
    [SerializeField] private AudioClip[] evgen;
	[SerializeField] private AudioClip[] mat;
	[SerializeField] private AudioClip[] otets;
	[SerializeField] private AudioClip[] dialog1_1;
	[SerializeField] private AudioClip[] imena;
	[SerializeField] private AudioClip[] dialog1_2;
	[SerializeField] private AudioClip[] dialogDed;
	[SerializeField] private AudioClip[] dialogMih;
	private bool one;
	private bool one5;
	private int replWhat;
    void Start()
    {
        if(Dialog.whatDialog == 1)
		{
			replWhat = 1;
		}
    }

    IEnumerator Shit()
		{
			
				
				gameObject.GetComponent<AudioSource>().Play();
				yield return  new WaitForSeconds(1000000f);
				gameObject.GetComponent<AudioSource>().Stop();
			
		}
    void Update()
    {
		
         if(Dialog.whatDialog == 1)
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				StopCoroutine(Shit());
				gameObject.GetComponent<AudioSource>().Stop();
				one = false;
				replWhat += 1;
			}
			switch(TextDialoUpdate.replWhat)
                {
					case 1: {gameObject.GetComponent<AudioSource>().clip = otets[0];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 2: {gameObject.GetComponent<AudioSource>().clip = mat[0];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 3: {gameObject.GetComponent<AudioSource>().clip = evgen[0];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 4: {gameObject.GetComponent<AudioSource>().clip = otets[1];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 5: {gameObject.GetComponent<AudioSource>().clip = mat[1];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 6: {gameObject.GetComponent<AudioSource>().clip = evgen[1];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 7: {gameObject.GetComponent<AudioSource>().clip = evgen[2];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 8: {gameObject.GetComponent<AudioSource>().clip = otets[2];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 9: {gameObject.GetComponent<AudioSource>().clip = evgen[3];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 10: {gameObject.GetComponent<AudioSource>().clip = mat[2];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());} replWhat = 0;break;}
					default: break;
				}
		}
		if(Dialog.whatDialog == 2)
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				StopCoroutine(Shit());
				gameObject.GetComponent<AudioSource>().Stop();
				one = false;
				replWhat += 1;
			}
			switch(TextDialoUpdate.replWhat)
                {
					case 0: {gameObject.GetComponent<AudioSource>().clip = dialogDed[0];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 1: {gameObject.GetComponent<AudioSource>().clip = dialogDed[1];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 2: {gameObject.GetComponent<AudioSource>().clip = dialogDed[2];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 3: {gameObject.GetComponent<AudioSource>().clip = dialogDed[3];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 4: {gameObject.GetComponent<AudioSource>().clip = dialogDed[4];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 5: {gameObject.GetComponent<AudioSource>().clip = dialogDed[5];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 6: {gameObject.GetComponent<AudioSource>().clip = dialogDed[6];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 7: {gameObject.GetComponent<AudioSource>().clip = dialogDed[7];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 8: {gameObject.GetComponent<AudioSource>().clip = dialogDed[8];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 9: {gameObject.GetComponent<AudioSource>().clip = dialogDed[9];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 10: {gameObject.GetComponent<AudioSource>().clip = dialogDed[10];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 11: {gameObject.GetComponent<AudioSource>().clip = dialogDed[11];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 12: {gameObject.GetComponent<AudioSource>().clip = dialogDed[12];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 13: {gameObject.GetComponent<AudioSource>().clip = dialogDed[13];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 14: {gameObject.GetComponent<AudioSource>().clip = dialogDed[14];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 15: {gameObject.GetComponent<AudioSource>().clip = dialogDed[15];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 16: {gameObject.GetComponent<AudioSource>().clip = dialogDed[16];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}replWhat = 0;break;}
					default: break;
				}
		}
		if(Dialog.whatDialog == 3)
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				StopCoroutine(Shit());
				gameObject.GetComponent<AudioSource>().Stop();
				one = false;
				replWhat += 1;
			}
				switch(TextDialoUpdate.replWhat)
                {
					case 0: {gameObject.GetComponent<AudioSource>().clip = dialogMih[0];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 1: {gameObject.GetComponent<AudioSource>().clip = dialogMih[1];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 2: {gameObject.GetComponent<AudioSource>().clip = dialogMih[2];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 3: {gameObject.GetComponent<AudioSource>().clip = dialogMih[3];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 4: {gameObject.GetComponent<AudioSource>().clip = dialogMih[4];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}break;}
					case 5: {gameObject.GetComponent<AudioSource>().clip = dialogMih[5];if(one == false && replWhat == TextDialoUpdate.replWhat ){one = true;StartCoroutine(Shit());}replWhat = 0;break;}
					default: break;
				}
		}
		if(Dialog.whatDialog == 5)
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				StopCoroutine(Shit());
				gameObject.GetComponent<AudioSource>().Stop();
				one = false;
				one5 = true;
			}
				switch(TextDialoUpdate.replWhat)
                {
					case 0: {gameObject.GetComponent<AudioSource>().clip = dialog1_1[0];replWhat += 1;if(one5 == false && replWhat == TextDialoUpdate.replWhat + 1){one5 = true;StartCoroutine(Shit());}replWhat = 0;break;}
					//case 1:{replWhat = 0;break;}
					default: break;}
		}
		if( TimeLine.DialogDed == 3)
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				StopCoroutine(Shit());
				one = false;
				replWhat += 1;
			}
			if(TextDialoUpdate.replWhat == 0)
			{
				gameObject.GetComponent<AudioSource>().clip = dialog1_2[0];
				if(one == false)
				{
					one = true;StartCoroutine(Shit());
					StartCoroutine(Shit2());
				}
				replWhat = 0;
			}
		}
		IEnumerator Shit2()
		{
			
				
				gameObject.GetComponent<AudioSource>().Play();
				yield return  new WaitForSeconds(2f);
				gameObject.GetComponent<AudioSource>().clip = dialog1_2[1];
				gameObject.GetComponent<AudioSource>().Play();
				yield return  new WaitForSeconds(1f);
				gameObject.GetComponent<AudioSource>().Stop();
				
			
		}
		
		
    }
}
