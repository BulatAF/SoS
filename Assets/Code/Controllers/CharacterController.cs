using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class CharacterController : MonoBehaviour // объявление скрипта
{
	private Animator anim; // аниматор = аним
	[SerializeField] private float speed;// открытая переменная скорость
	[SerializeField] BoxCollider2D target;// открытый объект таргет
	private bool facingRight = true; // лицо вправо = правда
	private Rigidbody2D rb; //  рб = компонент риджет бади
	public static int cherch;
	[SerializeField] private GameObject kon;// это конь
	private Vector2 moveVector; //б приватная переменная вектор 2д moveVector 
	private bool run;// бул бег
	private bool mih;// бул диалог с михой
	public static float ypos;// открытая переменная  Y  позиция
	public static float xpos;// открытая переменная  X  позиция
	private bool isobject; // бул есть объект
	private bool isHome;// бул есть дом
	private bool isHome2;// бул есть дом(с улицы)
	private bool isCherch;// бул есть церковь
	private bool isCherch2;// бул есть церковь(с улицы)
	private bool isUl;// бул есть улицы
	private bool isDed;//бул есть дед
	private bool isTolp;//бул есть толпа
	private bool kat_end_1;//конец кат сцены
	public Transform CheckPos;// объект проверка позиции
	public float CheckRadius;// публичная переменная проверочный радиус 
	public LayerMask whatIsTable;// слой что есть стол, печь
	public LayerMask whatIsHome;// слой что есть дом
	public LayerMask whatIsHome2; // слой что есть вход в дом с улицы
	public LayerMask whatIsUl; // слой что есть выход из дом 
	public LayerMask whatIsCherch; // слой что есть выход из церкви 
	public LayerMask whatIsCherch2; // слой что есть вход в церковь 
	public LayerMask whatIsDed;// слой деда
	public LayerMask whatIsTolp;// слой толпа
    private bool oneComeinCherch;
	public PlayableDirector director;
	private bool pod;
	private bool dialog;
	
     void Start()// начало программы
    {
		if(Dialog.whatDialog == 1)
		{
			pod = true;
			dialog = true;
		}
		anim = GetComponent<Animator>();// амин = аниматор
		rb = GetComponent<Rigidbody2D>();// рб = риджет бади
		target = GetComponent<BoxCollider2D>();// таргет = бокс коллайдер
		if(cherch == 2 )
		{
			cherch = 0;
			transform.position = new Vector3(-58.7f, -5f, 0f);
			kon.SetActive(false);
		}
    }
	private void FixedUpdate()// постоянный покадровый цикл
	{
		
		if(Dialog.whatDialog == 0)
		{
			dialog = false;
		}
		if(pod == true)
		{
			StartCoroutine(Pod());
			IEnumerator Pod() 
		{
			pod = false;
			anim.StopPlayback();
			anim.Play("lesgit"); 
			yield return  new WaitForSeconds(3.38f);
			
		}
		}
			if(TimeLine.DialogDed != 1 && pod == false)
		{
			moveVector.x = Input.GetAxis("Horizontal");// движение по горизонтали на клавиатуре = движ по x
		}
		
		if(dialog == false && isobject == false && TimeLine.DialogDed != 1)
		{
			moveVector.y = Input.GetAxis("Vertical");
		}
		else{moveVector.y = 0f;}
		if(dialog == false &&facingRight == false && moveVector.x > 0 )
			{
				Flip();
				
			}
			else if(dialog == false && facingRight == true && moveVector.x < 0)
			{
				Flip();
				
			}
			if(dialog == false && run == false )
			{
				rb.velocity = new Vector2(moveVector.x * speed, moveVector.y * speed);
			}
			if(dialog == false && run == false )
		{
		
			if(moveVector.x == 0f && moveVector.y == 0f)
			{
				anim.StopPlayback();
				anim.Play("IDLE"); 
			}
			if(moveVector.x > 0f || moveVector.x < 0f || moveVector.y > 0f || moveVector.y < 0f) 
			{
			
				anim.StopPlayback();
				anim.Play("Walk");
			}
		}
		 else if(dialog == false  && run == false)
		{
			
			rb.velocity = new Vector2(moveVector.x * speed * 0.6f, moveVector.y * speed * 0.6f);
		
		if(dialog == false && moveVector.x == 0f && moveVector.y == 0f )
		{
			
			anim.StopPlayback();
			anim.Play("IDLEPris"); 
		}
		if(moveVector.x > 0f || moveVector.x < 0f || moveVector.y > 0f || moveVector.y < 0f) 
		{
			
			anim.StopPlayback();
			anim.Play("WalkPris");
		}
		}
	}
    IEnumerator Quit()
	{
		yield return  new WaitForSeconds(1.6f);
		SceneManager.LoadScene(2);
	}
	IEnumerator ComeIn2()// В церковь
	{
		rb.velocity = new Vector2(0f,0f);
		if(oneComeinCherch == false)
		{
			
			director.Play();
			TimeLine.quithome = 2;
			yield return  new WaitForSeconds(3f);
			SceneManager.LoadScene(3);
			TimeLine.quithome = 0;
			
		}
	}
    void Update()
    {
		
		isobject = Physics2D.OverlapCircle(CheckPos.position,CheckRadius,whatIsTable);
		isHome = Physics2D.OverlapCircle(CheckPos.position,CheckRadius,whatIsHome);
		isHome2 = Physics2D.OverlapCircle(CheckPos.position,CheckRadius,whatIsHome2);
		isCherch  = Physics2D.OverlapCircle(CheckPos.position,CheckRadius,whatIsCherch);
		isCherch2 = Physics2D.OverlapCircle(CheckPos.position,CheckRadius,whatIsCherch2);
		isUl = Physics2D.OverlapCircle(CheckPos.position,CheckRadius,whatIsUl);
		isDed = Physics2D.OverlapCircle(CheckPos.position,CheckRadius,whatIsDed);
		isTolp = Physics2D.OverlapCircle(CheckPos.position,CheckRadius,whatIsTolp);
		ypos = transform.position.y;
		xpos = transform.position.x;
		if(dialog == false && run == true && (moveVector.x > 0f || moveVector.x < 0f || moveVector.y > 0f || moveVector.y < 0f) )
		{
			anim.StopPlayback();
			anim.Play("Run");
			rb.velocity = new Vector2(moveVector.x * speed * 1.6f, moveVector.y * speed * 1.6f);
		}
		else if(moveVector.x == 0f && moveVector.y == 0f && dialog == false && pod == false)
			{
				rb.velocity = new Vector2(moveVector.x, moveVector.y);
				anim.StopPlayback();
				anim.Play("IDLE"); 
			}
		
		if(Input.GetKey(KeyCode.LeftShift)  && dialog == false && isHome == false)
		{
			run = true;
		}
		else {run = false;}
       if(isHome2 == true)// если на улице подошёл к дому
	   {
		  //StartCoroutine(ComeIn());
		  // SceneManager.LoadScene(1);
		  
		}
	   if(isUl == true)// если в доме подошёл к двери
	   {
		  StartCoroutine(Quit());
		  TimeLine.quithome = 1;
	   }
	    if(isCherch2 == true)// если на улице подошёл к церкви
	   {
		  rb.velocity = new Vector2(0f,0f);
		  StartCoroutine(ComeIn2());
		  cherch = 1;
		  
		}
	   if(isCherch == true)// если в церкви подошёл к двери
	   {
		  StartCoroutine(Quit());
		  TimeLine.quithome = 1;
		  cherch = 2;
	   }
	   if(isDed == true)
	   {
		   Dialog.whatDialog = 2;
	   }
	   if(isTolp == true )
	   {
		   if(mih == false)
		   {
				Dialog.whatDialog = 3;
				mih = true;
		   }
		   else
		   {
		   if(Dialog.whatDialog == 0)
		   {
			   Dialog.whatDialog = 5;
		   }
		   }
	   }
    }
	void Flip()
	{
		if(TimeLine.DialogDed != 1)
		{
			facingRight = !facingRight;
			Vector3 Scaler = transform.localScale;
			Scaler.x *= -1;
			transform.localScale = Scaler;
		}
	}
	
}

