using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monolog : MonoBehaviour
{
	string[] DStart =  new[]{"Приветствую тебя, Туша.","Чтобы не возникало лишних вопросов скажу сразу - это обучение.... "," Возможно... ","Для того, чтобы пройти это возможно-невозможное типа обучение повернись вправо и передвигай ногами вперёд - это называется ходьба.","Для подобных мероприятий можешь попробовать потыкать комбинацию кнопок  Ц Ы В, ну или W S D. ","Кому как удобней. ","Первоочередно, давай научим тебя говорить, хотя, можно подумать тебя будет кто-то слушать. ","Ты уже оставил отзыв о данной игре?"};
	string[] DTrue =  new[]{"Я задремал и мне приснился кошмар","Да, поел","Можно мне погулять?","Да"};
	string[] DFalse =  new[]{"Я задремал и мне приснился кошмар","Да, поел","Можно мне погулять?","Да"};
	public static int replWhat2;
	[SerializeField] private Text text2;
	
	private int whatDialog;
	
	void Start()
    {
        replWhat2 = 0;
    }

    
    void Update()
    {
        if(whatDialog == 0)
		{
			
			if(Input.GetKeyDown(KeyCode.E))
			{
				replWhat2 += 1;
			}
			while (replWhat2 < 8)
			{
				text2.text = DStart[replWhat2];
			}
			if(replWhat2 == 8)
			{
				replWhat2 = 0;
			}
			
		}
		if(whatDialog == 1)
		{
			
				//replWhat2 += 1;
			
			while (replWhat2 < 10)
			{
				text2.text = DFalse[replWhat2];
			}
			if(replWhat2 == 10)
			{
				replWhat2 = 0;
			}
			
		}
    }
}
