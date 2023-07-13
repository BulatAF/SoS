using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monolog : MonoBehaviour
{
	string[] DStart =  new[]{"Приветствую тебя, Туша.","Чтобы не возникало лишних вопросов скажу сразу - это обучение.... "," Возможно... ","Для того, чтобы пройти это возможно-невозможное типа обучение повернись вправо и передвигай ногами вперёд - это называется ходьба.","Для подобных мероприятий можешь попробовать потыкать комбинацию кнопок  Ц Ы В, ну или W S D. ","Кому как удобней. ","Первоочередно, давай научим тебя говорить, хотя, можно подумать тебя будет кто-то слушать. ","Ты уже оставил отзыв о данной игре?"};
	string[] DTrue =  new[]{"Я задремал и мне приснился кошмар","Да, поел","Можно мне погулять?","Да"};
	string[] DFalse =  new[]{"","Эмм, дорогая туша, вправо находится СПРАВА, а не с этой, богом проклятой, стороны.","Вправо, это как влево, но НАОБОРОТ. Ты куда тащишься, тюбик? Иди в другую сторону!","Ну что ж, дружок-пирожок, ты попал... А ведь я тебя предупреждал, кокетливая ты морда."," Знаешь, а давай я попробую скруглить твой косяк. Подожди всего 10 секундочек, сейчас...","Ах и да, подключи интернет, если он не был включен, а то, как бы сказать, игра может немножко выйти за рамки функционала.","Так-с, у нас тут технические притирки, нужно подождать ещё секундок десять.","Эм, что-то они не хотят идти на уступки, говорят, мол, вина на тебе большая... Ладно, попробуем по другому.","Ну вот, пошло дело. Ты, конечно, прости, но придётся ещё чирик секундов отсидеть.","Что ж, всё готово, но так как ты, тушка, провинилась, не послушав мой дикторский голос, то по моей хотелке отсидишь ещё 10 секунд. Хе-хе.","О, пошло-поехало. Спасибо за вашу усидчивость и покладистый нрав.","Ах, и да, пожалуйста, уважаемое членистоногое, оставьте хотя бы добрый и справедливый отзыв об игре."};
	public static int replWhat2;
	[SerializeField] Text text2;
	private bool one;
	
	public static int whatDialog2 = 1;
	void Start()
    {
        replWhat2 = 0;
    }

    
    void Update()
    {
		
        if(whatDialog2 == 1)
		{
			text2.text = DStart[replWhat2];
			if(Input.GetKeyDown(KeyCode.E))
			{
				replWhat2 += 1;
			}
			
			if(replWhat2 == 8)
			{
				replWhat2 = 0;
				whatDialog2 =0;
			}
			
		}
		if(whatDialog2 == 2)
		{
			text2.text = DFalse[target.TfalsE];
			
			if(target.TfalsE == 3)
			{
				if(one == false)
				{
					StartCoroutine(FalseVarStart());
				}
			}
			
	}
    }
	IEnumerator FalseVarStart()
	{
		one = true;
		yield return new WaitForSeconds(5f);
		target.TfalsE += 1;
		StartCoroutine(FalseVar());
	}
	IEnumerator FalseVar()
	{
		if(target.TfalsE == 4 || target.TfalsE == 10)
		{
			yield return new WaitForSeconds(5f);
			target.TfalsE += 1;
			yield return new WaitForSeconds(5f);
			target.TfalsE += 1;
		}
		else{
			yield return new WaitForSeconds(10f);
			target.TfalsE += 1;
		}
		if(target.TfalsE <= 10)
		{
			StartCoroutine(FalseVar());
		}
		else{
			yield return new WaitForSeconds(5f);
			Application.OpenURL("https://www.youtube.com/watch?v=Cxmvq1MCR3c");
			Application.Quit();    // закрыть приложение
		}
	}
}
