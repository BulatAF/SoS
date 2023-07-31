using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class YanHodit : MonoBehaviour // объявление скрипта
{
	private Animator anim; // аниматор = аним
	[SerializeField] private float speed;// открытая переменная скорость
	[SerializeField] private GameObject Canvas;	
	[SerializeField] private GameObject Okno;	
	private bool facingRight = true; // лицо вправо = правда
	private bool gun = true; // значение ружья
	private bool shot = true; // значение стрельбы
	private bool strt = true;
	public bool reload = false; // значение перезарядки
	private Rigidbody2D rb; //  рб = компонент риджет бади
	private Vector2 moveVector; //б приватная переменная вектор 2д moveVector 
	private bool isobject; // бул есть объект
	public Transform CheckPos;// объект проверка позиции
	public float CheckRadius;// публичная переменная проверочный радиус 
	public LayerMask whatIsTable;// слой что есть стол, печь
	public LayerMask whatIsHome;// слой что есть дом
	private string nameAnim;
	
	public static int Gun;	
	
     void Start()// начало программы
    {
		name = "atackst";
		Canvas.SetActive(false);
		Okno.SetActive(true);
		anim = GetComponent<Animator>();// амин = аниматор
		rb = GetComponent<Rigidbody2D>();// рб = риджет бади
		
    }
	private void FixedUpdate()// постоянный покадровый цикл
	{
		moveVector.x = Input.GetAxis("Horizontal");// движение по горизонтали на клавиатуре = движ по x
		if(Monolog.whatDialog2 == 3 && strt == true)// начальный выбор
		{
			Canvas.SetActive(true);
		}
		if(isobject == false)
		{
			moveVector.y = Input.GetAxis("Vertical");
		}
		else{moveVector.y = 0f;}
		if(facingRight == false && moveVector.x > 0 && shot == false)//развороты
			{
				Flip();
			}
			else if(facingRight == true && moveVector.x < 0 && shot == false)
			{
				Flip();
			}
			if(moveVector.x == 0f && moveVector.y == 0f && gun == false && shot == false)// анимация покоя
			{
				
				anim.StopPlayback();
				anim.Play("banyapokoy"); 
			}
			if(moveVector.x == 0f && moveVector.y == 0f && gun == true  && shot == false)// анимация покоя с пушкой
			{
				anim.StopPlayback();
				anim.Play("banyapokoygun"); 
			}
			if((moveVector.x > 0f || moveVector.x < 0f || moveVector.y > 0f || moveVector.y < 0f) && shot == false)//анимация ходьбы
			{ 
				anim.StopPlayback();
				anim.Play("banyago");
			}
			if((moveVector.x > 0f || moveVector.x < 0f || moveVector.y > 0f || moveVector.y < 0f) && reload == true && gun == false && shot == true)//анимация ходьбы gпри перезарядке
			{ 
				StopCoroutine(Reload());
				reload = false;
				shot = false;
				gun = false;
			}
			if(shot == false || (reload == true && gun == false))//динамика ходьбы
			{
				rb.velocity = new Vector2(moveVector.x * speed, moveVector.y * speed);	
			}
				
			
			
		
		
	}
    IEnumerator Shoot()
	{
		shot = true;
		anim.StopPlayback(); // всем анимациям "остановитясь"
		anim.Play("banyagunshot"); // сыграть анимацию выстрела
		yield return new WaitForSeconds(0.9f);
		shot = false;
		gun = false;
		reload = false; 
		yield return new WaitForSeconds(1f);
		
	}

    IEnumerator Reload()
	{
		shot = true;
		reload = true;
		gun = false;
		anim.StopPlayback(); // всем анимациям "остановитясь"
		anim.Play("relouding"); // сыграть анимацию перезарядки
		yield return new WaitForSeconds(9.42f);
		gun = true;	
		shot = false;
	}
	IEnumerator Atackst()//атака ближняя
	{
		shot = true;
		if(gun == false)
		{
			gun = true;
		}
		if(facingRight == false)
		{
			rb.velocity = new Vector2(-1.5f * speed, moveVector.y);
			anim.StopPlayback(); // всем анимациям "остановитясь"
			anim.Play(nameAnim); // сыграть анимацию перезарядки
			yield return new WaitForSeconds(0.42f);
			rb.velocity = new Vector2(1.5f * speed, moveVector.y);
			yield return new WaitForSeconds(0.42f);
		}
		else
		{
			rb.velocity = new Vector2(1.5f * speed, moveVector.y);
			anim.StopPlayback(); // всем анимациям "остановитясь"
			anim.Play(nameAnim); // сыграть анимацию перезарядки
			yield return new WaitForSeconds(0.42f);
			rb.velocity = new Vector2(-1.5f * speed, moveVector.y);
			yield return new WaitForSeconds(0.42f);
		}
		shot = false;
		gun = false;
	}
	IEnumerator Blockst()//блоки ближнии
	{
		shot = true;
		if(facingRight == false)
		{
			rb.velocity = new Vector2(0f,0f);
			anim.StopPlayback(); // всем анимациям "остановитясь"
			anim.Play(nameAnim); // сыграть анимацию перезарядки
			yield return new WaitForSeconds(0.42f);
		}
		else
		{
			rb.velocity = new Vector2(0f,0f);
			anim.StopPlayback(); // всем анимациям "остановитясь"
			anim.Play(nameAnim); // сыграть анимацию перезарядки
			yield return new WaitForSeconds(0.42f);
		}
		shot = false;
		gun = false;
	}
	
	
	
	
	void Update()
    {
		
		isobject = Physics2D.OverlapCircle(CheckPos.position,CheckRadius,whatIsTable);
		if(moveVector.x == 0f && moveVector.y == 0f && gun == true && Input.GetKeyUp(KeyCode.F) && shot == false && reload == true) // стрельба
			{
				if(facingRight == true)
				{Gun = 1;}
				else{Gun =2;}
				StartCoroutine(Shoot());
			}
		if(gun == false && Input.GetKeyUp(KeyCode.F) && shot == false) // достать оружие
			{
				gun = true; // доступ к пушке
			}	
		if(moveVector.x == 0f && moveVector.y == 0f && Input.GetKeyUp(KeyCode.R) && shot == false && reload == false) // перезарядка
			{
				StartCoroutine(Reload());
			}
		
		
		
		
		
		
		if(Input.GetKeyUp(KeyCode.G) && shot == false) //
		{
			if(gun == false)
			{
				nameAnim = "atackst";
				StartCoroutine(Atackst());
			}else{gun = false;}
		}
		if(gun == false && Input.GetKeyUp(KeyCode.H) && shot == false) //
		{
			if(gun == false)
			{
				nameAnim = "atackup";
				StartCoroutine(Atackst());
			}else{gun = false;}
		}
		if(gun == false && Input.GetKeyUp(KeyCode.J) && shot == false)  //
		{
			nameAnim = "blockclas";
			StartCoroutine(Blockst());
		}
		if(gun == false && Input.GetKeyUp(KeyCode.K) && shot == false) // 
		{
			nameAnim = "blockup";
			StartCoroutine(Blockst());
		}
		if(target.TfalsE >= 3)// застрял)
		{
			rb.velocity = new Vector2(0f,0f);
			shot = true;
			anim.StopPlayback();
			anim.Play("banyapokoy");
		}
		
    }
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
		
	}
	public void Delete()
	{
		Okno.SetActive(false);
		Canvas.SetActive(false);
		strt = false;
		shot = false;
		reload = true;
		gun = false;
	}
	private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Finish") 
		{
			target.TfalsE +=1;
			Okno.SetActive(true);
			Monolog.whatDialog2 = -1;
		}
		if(collision.gameObject.tag == "Respawn" && Monolog.whatDialog2 - target.TtruE != 2) 
		{
			
			target.TtruE +=1;
			Okno.SetActive(true);
			//Monolog.whatDialog2 = target.TtruE + 2;
		}
	}
	
        
	
}


