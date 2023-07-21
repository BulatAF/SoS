using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faces : MonoBehaviour
{
	private Animator anim; // аниматор = аним
    void Start()
    {
        anim = GetComponent<Animator>();// амин = аниматор
		
    }

    void Update()
    {
        switch(Dialog.whoSay)
		{
			case 1: {anim.StopPlayback(); anim.Play("Gesh"); break;}
			case 2: 
			{
				switch(TextDialoUpdate.WhatFace)
				{
					case 0: anim.StopPlayback(); anim.Play("Mother");break;
					case 1: anim.StopPlayback(); anim.Play("MotherL");break;
				}
				break;
			}
			case 3: {anim.StopPlayback(); anim.Play("FatherN"); break;}
			case 4: 
			{
				switch(TextDialoUpdate.WhatFace)
				{
					case 0: anim.StopPlayback(); anim.Play("Star");break;
					case 1: anim.StopPlayback(); anim.Play("StarNapug");break;
				}
				break;
			}
			case 5: 
			{
				switch(TextDialoUpdate.WhatFace)
				{
					case 0: anim.StopPlayback(); anim.Play("Gonets");break;
					case 1: anim.StopPlayback(); anim.Play("GonetsZloi");break;
				}
				break;
			}
			case 6: {anim.StopPlayback(); anim.Play("Ser"); break;}
			case 7: 
			{
				switch(TextDialoUpdate.WhatFace)
				{
					case 0: anim.StopPlayback(); anim.Play("Mih");break;
					case 1: anim.StopPlayback(); anim.Play("MihL");break;
				}
				break;
			}
		}
    }
}
