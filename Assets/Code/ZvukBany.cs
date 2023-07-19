using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class ZvukBany : MonoBehaviour
{
    [SerializeField] private AudioClip[] ban1;
	[SerializeField] private AudioClip[] ban2;
	[SerializeField] private AudioClip[] ban3;
	[SerializeField] private AudioClip[] ban4;
	[SerializeField] private AudioClip[] ban5;
	private AudioSource aud;
	private bool one;//чтобы один раз	
	private int repl;//чтобы записывать предыдущюю replwhat2
    void Start()
    {/*
		aud = GetComponent<AudioSource>().clip;
		aud = ban1[Monolog.replWhat2];
		StartCoroutine(Shit());*/
    }
		IEnumerator Shit()// карутина чтобы проигрывало
		{
			gameObject.GetComponent<AudioSource>().Play();//играть
			yield return  new WaitForSeconds(1000000f);//ждать
			gameObject.GetComponent<AudioSource>().Stop();//не играть
		}
		
    void Update()
    {
		if(Monolog.whatDialog2 == 1)
				{
					gameObject.GetComponent<AudioSource>().clip = ban1[Monolog.replWhat2];
					if(repl != Monolog.replWhat2)
					{
						StartCoroutine(Shit());
						repl = Monolog.replWhat2;
					}
				}
    }
}
