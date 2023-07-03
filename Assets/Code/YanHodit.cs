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
	private Rigidbody2D rb; //  рб = компонент риджет бади
	private Vector2 moveVector; //б приватная переменная вектор 2д moveVector 
	private bool run;// бул бег
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
			if(run == false )
			{
				rb.velocity = new Vector2(moveVector.x * speed, moveVector.y * speed);
			}
			if(run == false)
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
		 else if(run == false)
		{
			
			rb.velocity = new Vector2(moveVector.x * speed * 0.6f, moveVector.y * speed * 0.6f);
		
		if(moveVector.x == 0f && moveVector.y == 0f )
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
    /*IEnumerator Quit()
	{
		//yield return  new WaitForSeconds(1.6f);
		//SceneManager.LoadScene(2);
	}*/
	void Update()
    {
		
		isobject = Physics2D.OverlapCircle(CheckPos.position,CheckRadius,whatIsTable);
		if(run == true && (moveVector.x > 0f || moveVector.x < 0f || moveVector.y > 0f || moveVector.y < 0f) )
		{
			anim.StopPlayback();
			anim.Play("Run");
			rb.velocity = new Vector2(moveVector.x * speed * 1.6f, moveVector.y * speed * 1.6f);
		}
		else if(moveVector.x == 0f && moveVector.y == 0f)
			{
				rb.velocity = new Vector2(moveVector.x, moveVector.y);
				anim.StopPlayback();
				anim.Play("IDLE"); 
			}
		
		if(Input.GetKey(KeyCode.LeftShift))
		{
			run = true;
		}
		else {run = false;}
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


