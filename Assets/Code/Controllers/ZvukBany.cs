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
	private  int repl;//чтобы записывать предыдущюю replwhat2
	private int Repl2;
    void Start()
    {
		aud = GetComponent<AudioSource>();
		aud.clip = ban1[Monolog.replWhat2];
		StartCoroutine(Shit());
    }
		IEnumerator Shit()// карутина чтобы проигрывало
		{
			aud.Play();//играть
			yield return  new WaitForSeconds(1000000f);//ждать
			aud.Stop();//не играть
		}
		
    void Update()
    {
		Repl2 = Monolog.replWhat2;
		if(Monolog.whatDialog2 == 1)//начальный монолог
				{
					aud.clip= ban1[Monolog.replWhat2];
					if(repl != Monolog.replWhat2)
					{
						StartCoroutine(Shit());
						repl = Monolog.replWhat2;
					}
				}
		if(Monolog.whatDialog2 == -1)//монолог влево 
				{
					aud.clip= ban2[target.TfalsE];
					if(repl != target.TfalsE)
					{
						StartCoroutine(Shit());
						repl = target.TfalsE;
					}
				}
		if(Monolog.whatDialog2 == 3 && target.TtruE == 1)// монолог бл бой
				{
					aud.clip= ban3[Monolog.replWhat2];
					if(repl != Monolog.replWhat2)
					{
						StartCoroutine(Shit());
						repl = Monolog.replWhat2;
					}
				}
		if(Monolog.whatDialog2 == 4 && target.TtruE == 2)//монолог дал бой
				{
					aud.clip= ban4[Monolog.replWhat2];
					if(repl != Monolog.replWhat2)
					{
						StartCoroutine(Shit());
						repl = Monolog.replWhat2;
					}
				}
		if(Monolog.whatDialog2 == 5 && target.TtruE == 3)// монолог итог
				{
					aud.clip= ban5[Monolog.replWhat2];
					if(repl != Monolog.replWhat2)
					{
						StartCoroutine(Shit());
						repl = Monolog.replWhat2;
					}
				}
    }
}
