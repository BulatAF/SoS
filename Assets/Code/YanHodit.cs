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
	private bool gun; // значение ружья
	private bool shot = true; // значение стрельбы
	private bool strt = true;
	private bool reload = true; // значение перезарядки
	private Rigidbody2D rb; //  рб = компонент риджет бади
	private Vector2 moveVector; //б приватная переменная вектор 2д moveVector 
	private bool isobject; // бул есть объект
	public Transform CheckPos;// объект проверка позиции
	public float CheckRadius;// публичная переменная проверочный радиус 
	public LayerMask whatIsTable;// слой что есть стол, печь
	public LayerMask whatIsHome;// слой что есть дом
	private string name = "atackst";
	
     void Start()// начало программы
    {
		Canvas.SetActive(false);
		Okno.SetActive(true);
		anim = GetComponent<Animator>();// амин = аниматор
		rb = GetComponent<Rigidbody2D>();// рб = риджет бади
		
    }
	private void FixedUpdate()// постоянный покадровый цикл
	{
		moveVector.x = Input.GetAxis("Horizontal");// движение по горизонтали на клавиатуре = движ по x
		if(Monolog.whatDialog2 == 3 && strt == true)
		{
			Canvas.SetActive(true);
		}
		if(isobject == false)
		{
			moveVector.y = Input.GetAxis("Vertical");
		}
		else{moveVector.y = 0f;}
		if(facingRight == false && moveVector.x > 0 && shot == false)
			{
				Flip();
			}
			else if(facingRight == true && moveVector.x < 0 && shot == false)
			{
				Flip();
			}
			if(moveVector.x == 0f && moveVector.y == 0f && gun == false && shot == false)
			{
				anim.StopPlayback();
				anim.Play("banyapokoy"); 
			}
			if(moveVector.x == 0f && moveVector.y == 0f && gun == true  && shot == false)
			{
				anim.StopPlayback();
				anim.Play("banyapokoygun"); 
			}
			if((moveVector.x > 0f || moveVector.x < 0f || moveVector.y > 0f || moveVector.y < 0f) && shot == false) 
			{ 
				anim.StopPlayback();
				anim.Play("banyago");
			}
			if(shot == false)
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
	}

    IEnumerator Reload()
	{
		shot = true;
		reload = true;
		anim.StopPlayback(); // всем анимациям "остановитясь"
		anim.Play("relouding"); // сыграть анимацию перезарядки
		yield return new WaitForSeconds(19.42f);
		shot = false;
		gun = true;	
	}
	IEnumerator Atackst()
	{
		shot = true;
		if(facingRight == false)
		{
			rb.velocity = new Vector2(-1.5f * speed, moveVector.y);
			anim.StopPlayback(); // всем анимациям "остановитясь"
			anim.Play(name); // сыграть анимацию перезарядки
			yield return new WaitForSeconds(0.42f);
			rb.velocity = new Vector2(1.5f * speed, moveVector.y);
			yield return new WaitForSeconds(0.42f);
		}
		else
		{
			rb.velocity = new Vector2(1.5f * speed, moveVector.y);
			anim.StopPlayback(); // всем анимациям "остановитясь"
			anim.Play(name); // сыграть анимацию перезарядки
			yield return new WaitForSeconds(0.42f);
			rb.velocity = new Vector2(-1.5f * speed, moveVector.y);
			yield return new WaitForSeconds(0.42f);
		}
		shot = false;
		gun = false;
	}
	IEnumerator Blockst()
	{
		shot = true;
		if(facingRight == false)
		{
			rb.velocity = new Vector2(0f,0f);
			anim.StopPlayback(); // всем анимациям "остановитясь"
			anim.Play(name); // сыграть анимацию перезарядки
			yield return new WaitForSeconds(0.42f);
		}
		else
		{
			rb.velocity = new Vector2(0f,0f);
			anim.StopPlayback(); // всем анимациям "остановитясь"
			anim.Play(name); // сыграть анимацию перезарядки
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
				StartCoroutine(Shoot());
			}
		if(gun == false && Input.GetKeyUp(KeyCode.F) && shot == false && reload == true) // достать оружие
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
				name = "atackst";
				StartCoroutine(Atackst());
			}else{gun = false;}
		}
		if(gun == false && Input.GetKeyUp(KeyCode.H) && shot == false) //
		{
			if(gun == false)
			{
				name = "atackup";
				StartCoroutine(Atackst());
			}else{gun = false;}
		}
		if(gun == false && Input.GetKeyUp(KeyCode.J) && shot == false)  //
		{
			name = "blockclas";
			StartCoroutine(Blockst());
		}
		if(gun == false && Input.GetKeyUp(KeyCode.K) && shot == false) // 
		{
			name = "blockup";
			StartCoroutine(Blockst());
		}
		if(target.TfalsE >= 3)
		{
			rb.velocity = new Vector2(0f,0f);
			shot = true;
			anim.StopPlayback();
			anim.Play("banyapokoy");
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
	public void Delete()
	{
		Okno.SetActive(false);
		Canvas.SetActive(false);
		strt = false;
		shot = false;
	}
	private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Finish") 
		{
			target.TfalsE +=1;
			Okno.SetActive(true);
			Monolog.whatDialog2 = 2;
		}
		if(collision.gameObject.tag == "Respawn" && Monolog.whatDialog2 ==2) 
		{
			
			target.TtruE +=1;
			Okno.SetActive(true);
			//Monolog.whatDialog2 = target.TtruE + 2;
		}
	}
	
        
	
}


