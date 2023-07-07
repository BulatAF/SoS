using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class YanHodit : MonoBehaviour // объявление скрипта
{
	private Animator anim; // аниматор = аним
	[SerializeField] private float speed;// открытая переменная скорость
	private bool facingRight = true; // лицо вправо = правда
	private bool gun;
	private bool shot;
	private Rigidbody2D rb; //  рб = компонент риджет бади
	private Vector2 moveVector; //б приватная переменная вектор 2д moveVector 
	private bool isobject; // бул есть объект
	public Transform CheckPos;// объект проверка позиции
	public float CheckRadius;// публичная переменная проверочный радиус 
	public LayerMask whatIsTable;// слой что есть стол, печь
	public LayerMask whatIsHome;// слой что есть дом
	
     void Start()// начало программы
    {
		
		anim = GetComponent<Animator>();// амин = аниматор
		rb = GetComponent<Rigidbody2D>();// рб = риджет бади
		
    }
	private void FixedUpdate()// постоянный покадровый цикл
	{
		moveVector.x = Input.GetAxis("Horizontal");// движение по горизонтали на клавиатуре = движ по x
		
		
		if(isobject == false)
		{
			moveVector.y = Input.GetAxis("Vertical");
		}
		else{moveVector.y = 0f;}
		if(facingRight == false && moveVector.x > 0 )
			{
				Flip();
				
			}
			else if(facingRight == true && moveVector.x < 0)
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
			if(moveVector.x > 0f || moveVector.x < 0f || moveVector.y > 0f || moveVector.y < 0f) 
			{
			
				anim.StopPlayback();
				anim.Play("banyago");
			}
			rb.velocity = new Vector2(moveVector.x * speed, moveVector.y * speed);
			
	}
    IEnumerator Shoot()
	{
		shot = true;
		anim.StopPlayback(); // всем анимациям "остановитясь"
		anim.Play("banyagunshot"); // сыграть анимацию выстрела
		yield return new WaitForSeconds(0.9f);
		shot = false;
		gun = false;
	}
	void Update()
    {
		
		isobject = Physics2D.OverlapCircle(CheckPos.position,CheckRadius,whatIsTable);
		if(moveVector.x == 0f && moveVector.y == 0f && gun == true && Input.GetKeyUp(KeyCode.F) && shot == false) // стрельба
			{
				StartCoroutine(Shoot());
			}
		if(gun == false && Input.GetKeyUp(KeyCode.F) && shot == false) // достать оружие
			{
				gun = true; // доступ к пушке
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


