using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Monolog : MonoBehaviour
{
	string[] DStart =  new[]{"Приветствую тебя, Туша.(Нажми на E англ)",
	"Чтобы не возникало лишних вопросов скажу сразу - это обучение.... ",
	" Возможно... ",
	"Для того, чтобы пройти это возможно-невозможное типа обучение повернись вправо и передвигай ногами вперёд - это называется ходьба.",
	"Для подобных мероприятий можешь попробовать потыкать комбинацию кнопок  Ц Ы В, ну или W S D. ",
	"Кому как удобней. ",
	"Первоочередно, давай научим тебя говорить, хотя, можно подумать тебя будет кто-то слушать. ",
	"Ты уже оставил отзыв о данной игре?"};
	string[] DTrueBA =  new[]{"Что ж, выбор интересный, а главное правильный. Приступим к обучению.",
	"Если ты обратил внимание на своего персонажа, то скорее всего заметил, что ты весьма вооружен.",
	"К примеру у тебя есть такое оружие ближнего боя, как шпага.",
	"Раз оружие ближнего боя, то попробуй атаковать на кнопку ✍︎, а для того, чтобы шпынать воткни в клавиатуру ✍︎.",
	"Подобные виды искусных техник также будут использовать и ваши противники, так что не мешало бы вас обучить и тому, как от них отбиваться.",
	"Эх, почему меня заставляют это делать? Хотелось бы понаблюдать, как ты будешь страдать...",
	"Начнём. Для защиты от первой и второй вида вялых атак ваших противников, нажмите ✍︎ и ✍︎ соответственно.",
	"Ну что, просто ведь?",
	"Для продолжения своих мучений продолжи движение вправо и ни в коем случе не ВЛЕВО"};
	string[] DTrueDA =  new[]{"А теперь перейдём к огнеплюйке, он же мушкет.",
	"Производить неточный одноразовый выстрел стоит ДВАЖДЫ НАЖАВ на копку ✍︎.",
	"Волшебную (звуки истошного кряхтения)...Волшебную клавишу перезарядки, пожалуй, я разглашать не буду - она же тебе не понадобится.",
	"Спросишь почему? Потому что потому. Чумба, это мушкет. Один выстрел и пошёл резать. Всё.",
	"Но если хочешь, можешь поискать её, она точно есть. Но вряд ли она тебе пригодится."};
	string[] DTrueEnd =  new[]{"Туша, ты прошла обучение и уже годна быть фронтовым мясом, поздравляю.",
	"Теперь ты переходишь из звания туши, в звание отбивной.",
	"И да, можешь оставить отзыв об игре после выхода? Ну пожалуйста. Если не оставишь, то я крашнусь.",
	"Думаю, тебе не стоит затруднять себя выходом из игры, я, ради твоей драгоценной оценки, тебе с этим сейчас помогу.",
	"До новых встреч, мой Ватсон."};
	string[] DFalse =  new[]{"","Эмм, дорогая туша, вправо находится СПРАВА, а не с этой, богом проклятой, стороны.",
	"Вправо, это как влево, но НАОБОРОТ. Ты куда тащишься, тюбик? Иди в другую сторону!",
	"Ну что ж, дружок-пирожок, ты попал... А ведь я тебя предупреждал, кокетливая ты морда.",
	" Знаешь, а давай я попробую скруглить твой косяк. Подожди всего 10 секундочек, сейчас..."
	,"Ах и да, подключи интернет, если он не был включен, а то, как бы сказать, игра может немножко выйти за рамки функционала.",
	"Так-с, у нас тут технические притирки, нужно подождать ещё секундок десять.",
	"Эм, что-то они не хотят идти на уступки, говорят, мол, вина на тебе большая... Ладно, попробуем по другому.",
	"Ну вот, пошло дело. Ты, конечно, прости, но придётся ещё чирик секундов отсидеть.",
	"Что ж, всё готово, но так как ты, тушка, провинилась, не послушав мой дикторский голос, то по моей хотелке отсидишь ещё 10 секунд. Хе-хе.",
	"О, пошло-поехало. Спасибо за вашу усидчивость и покладистый нрав.",
	"Ах, и да, пожалуйста, уважаемое членистоногое, оставьте хотя бы добрый и справедливый отзыв об игре."};
	[SerializeField] private GameObject neprohod;
	public static int replWhat2;
	public int RRR;
	[SerializeField] Text text2;
	private bool one;
	public static int whatDialog2 = 1;
	public int WWW;
	private InputController controls; 
	void Awake()
	{
		controls = new InputController();
		controls.Move.Gun.performed += ctx => PressF();
		controls.Move.Monolog.performed += ctx => PressE();
		controls.BlFight.ATCL.performed += ctx => PressGH();
		controls.BlFight.ATUP.performed += ctx => PressGH();
		controls.BlFight.BLCL.performed += ctx => PressJK();
		controls.BlFight.BLUP.performed += ctx => PressJK();
	}
	
	void OnEnable()
	{
		controls.Move.Enable();
		controls.BlFight.Enable();
	}
	void OnDisable()
	{
		controls.Move.Disable();
		controls.BlFight.Enable();
	}
	void Start()
    {
        replWhat2 = 0;
		neprohod.SetActive(false);
    }
	void PressF()
	{
		if(replWhat2 == 1 && whatDialog2 == 4 && target.TtruE == 2) ///
		{
			replWhat2 += 1;
		}
	}
	void PressE()
	{
		if(whatDialog2 == 1)
			{
				replWhat2 += 1;
			}
		if(replWhat2 == 8 && whatDialog2 == 1)
			{
				whatDialog2 = 3;
				replWhat2 = 0;
			}
		if(replWhat2 != 3 && replWhat2 != 6 && target.TtruE == 1 && (whatDialog2 == 3 || whatDialog2 == -1))
			{
				replWhat2 += 1;
			}
		if(replWhat2 == 9 && target.TtruE == 1 && (whatDialog2 == 3 || whatDialog2 == -1))
			{
				replWhat2 = 0;
				whatDialog2 = 4;
			}
		if(replWhat2 != 1 && whatDialog2 == 4 && target.TtruE == 2)
			{
				replWhat2 += 1;
			}
		if(replWhat2 == 4 && whatDialog2 == 4 && target.TtruE == 2)
			{
				replWhat2 = 0;
				whatDialog2 = 5;
			}
		if(whatDialog2 == 5 && target.TtruE == 3)
			{
				replWhat2 += 1;
			}
	}
	void PressGH()
	{
		if(replWhat2 == 3 && target.TtruE == 1 && (whatDialog2 == 3 || whatDialog2 == -1))
			{
				replWhat2 += 1;
			}
	}
	void PressJK()
	{
		if(replWhat2 == 6 && target.TtruE == 1 && (whatDialog2 == 3 || whatDialog2 == -1)) 
			{
				replWhat2 += 1;
			}
	}
    
    void Update()
    {
		RRR = replWhat2;
		WWW = whatDialog2;
        if(whatDialog2 == 1)
		{
			text2.text = DStart[replWhat2];
			if(replWhat2 > 7)
			{
				whatDialog2 = 3;
				replWhat2 = 0;
			}
		}
		if(whatDialog2 == -1)// диалог влево
		{
			text2.text = DFalse[target.TfalsE];
			
			if(target.TfalsE == 3 && one == false)
			{
				StartCoroutine(FalseVarStart());
			}
		}
		
		if(target.TtruE == 1 && (whatDialog2 == 3 || whatDialog2 == -1)) // диалог вправо ближний бой
		{
			whatDialog2 =3;
			text2.text = DTrueBA[replWhat2];
		}
		if(whatDialog2 == 4 && target.TtruE == 2) // диалог вправо дальний бой
		{
			text2.text = DTrueDA[replWhat2];
		}
		if(whatDialog2 == 5 && target.TtruE == 3) // диалог вправо итог
		{
			text2.text = DTrueEnd[replWhat2];
			if(replWhat2 == 4)
			{
				replWhat2 =10;
				StartCoroutine(Exit());
				IEnumerator Exit()
				{
					yield return new WaitForSeconds(3f);
					Application.OpenURL("https://vk.com/notnevername");
					Application.Quit();    // закрыть приложение
				}
			}
		}
		if(target.TtruE !=0) 
		{
			neprohod.SetActive(true); 
		}
		
		
		if(whatDialog2 == 2)
		{
			text2.text = DFalse[target.TfalsE];
			
			if(target.TfalsE == 3 && one == false)
			{
					StartCoroutine(FalseVarStart());
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
