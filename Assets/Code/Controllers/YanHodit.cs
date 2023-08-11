using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using UnityEngine.InputSystem;

public class YanHodit : MonoBehaviour // объявление скрипта
{
	private Animator anim; // аниматор = аним
	[SerializeField] private float speed;// открытая переменная скорость
	[SerializeField] private GameObject Canvas;	
	[SerializeField] private GameObject Okno;	
	[SerializeField] private GameObject Otorva;
	[SerializeField] private GameObject SpawnOtorva;
	[SerializeField] private AudioSource SHOOT;
	[SerializeField] private Joystick joy;
	private bool facingRight = true; // лицо вправо = правда
	private bool gun = true; // значение ружья
	private bool shot = true; // значение стрельбы
	private bool strt = true;
	private bool reload = false; // значение перезарядки
	private Rigidbody2D rb; //  рб = компонент риджет бади
	private Vector2 moveVector; //б приватная переменная вектор 2д moveVector 
	private bool isobject; // бул есть объект
	public Transform CheckPos;// объект проверка позиции
	public float CheckRadius;// публичная переменная проверочный радиус 
	public LayerMask whatIsTable;// слой что есть стол, печь
	public LayerMask whatIsHome;// слой что есть дом
	private string nameAnim;
	private InputController controls;
	public static int Gun;	
	
	void Awake()
	{
		controls = new InputController();
		controls.Move.Gun.performed += ctx => GunContr();
		controls.Move.Reload.performed += ctx => Reloading();
		controls.BlFight.ATCL.performed += ctx => AttackCl();
		controls.BlFight.ATUP.performed += ctx => AttackUp();
		controls.BlFight.BLCL.performed += ctx => BlockCl();
		controls.BlFight.BLUP.performed += ctx => BlockUp();
	}
	
	void OnEnable()
	{
		controls.Move.Enable();
		controls.BlFight.Enable();
	}
	void OnDisable()
	{
		controls.Move.Disable();
		controls.BlFight.Disable();
	}
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
		moveVector.x = controls.Move.Move.ReadValue<float>();// движение по горизонтали на клавиатуре = движ по x
		moveVector.x = joy.Horizontal;
		if(Monolog.whatDialog2 == 3 && strt == true)// начальный выбор
		{
			Canvas.SetActive(true);
		}
		if(isobject == false)
		{
			moveVector.y = controls.Move.MoveY.ReadValue<float>();
			moveVector.y = joy.Vertical;
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
		SHOOT.Play();
		yield return new WaitForSeconds(0.9f);
		shot = false;
		gun = false;
		reload = false; 
		SHOOT.Stop();
		
		
	}

    IEnumerator Reload()
	{
		shot = true;
		reload = true;
		gun = false;
		anim.StopPlayback(); // всем анимациям "остановитясь"
		anim.Play("relouding"); // сыграть анимацию перезарядки
		yield return new WaitForSeconds(1.45f);
		Instantiate(Otorva,SpawnOtorva.transform.position, Quaternion.identity);
		yield return new WaitForSeconds(28.55f);
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
	
	
	public void GunContr()
	{
		if(moveVector.x == 0f && moveVector.y == 0f && gun == true&& shot == false && reload == true) // стрельба
			{
				if(facingRight == true)
				{Gun = 1;}
				else{Gun =2;}
				StartCoroutine(Shoot());
			}
		if(gun == false && shot == false) // достать оружие
			{
				gun = true; // доступ к пушке
			}	
	}
	public void Reloading()
	{
		if(moveVector.x == 0f && moveVector.y == 0f && shot == false && reload == false) // перезарядка
			{
				StartCoroutine(Reload());
			}
	}
	public void AttackCl()
	{
		if(shot == false)
		{
			if(gun == false)
			{
				nameAnim = "atackst";
				StartCoroutine(Atackst());
			}else{gun = false;}
		}
	}
	public void AttackUp()
	{
		if(shot == false)
		{
			if(gun == false)
			{
				nameAnim = "atackup";
				StartCoroutine(Atackst());
			}else{gun = false;}
		}
	}
	public void BlockCl()
	{
		if(gun == false && shot == false)  //
		{
			nameAnim = "blockclas";
			StartCoroutine(Blockst());
		}
	}
	public void BlockUp()
	{
		if(gun == false && shot == false) // 
		{
			nameAnim = "blockup";
			StartCoroutine(Blockst());
		}
	}
	
	void Update()
    {
		
		isobject = Physics2D.OverlapCircle(CheckPos.position,CheckRadius,whatIsTable);
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


