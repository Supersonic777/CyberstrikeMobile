using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour 
{
    public bool controllWithJoystick = false;
    public float playerHealth = 100;
	public float speed = 2f;
	public float acceleration = 6f;
	public float staminaFill = 1f;
	public GameObject dieMessage;
	public GameObject flashlight;
	public Camera cam;
	public Joystick joystick;
	public Image bar;
	public Image stamina;
	public AudioClip walkSound;
	public AudioClip runSound;
	public AudioClip fleshlightSound;
	private float healthFill;
	public float rotationOffset;
	private GameObject reloadNotifier;
	private Rigidbody2D rb;
	private bool flashlightIsActive;
	Vector2 movement;
	Vector2 mousePos;
	Vector2 moveVelocity;
	AudioSource playerAudioSrs;
	void Start()
	{
		flashlightIsActive = false;
		reloadNotifier = GetComponentInChildren<GunController>().reloadNotification;
        playerAudioSrs = GetComponent<AudioSource>();
		rb = GetComponent<Rigidbody2D>();
	}

	void Update () 
	{
		
		healthFill = playerHealth/100f;
        bar.fillAmount = healthFill;
		stamina.fillAmount = staminaFill;

		movement.x = Input.GetAxis("Horizontal");
		movement.y = Input.GetAxis("Vertical");

		if(playerHealth<=0)
		{
			dieMessage.SetActive(true);
			reloadNotifier.SetActive(false);
			Time.timeScale = 0f;
			gameObject.SetActive(false); //деактивирует игрока при обнулении HP

		}
		if(Input.GetKeyDown(KeyCode.F) && flashlightIsActive == false)
		{
           flashlight.SetActive(true);
           playerAudioSrs.PlayOneShot(fleshlightSound);
		   flashlightIsActive = true;
		}
		else if(Input.GetKeyDown(KeyCode.F) && flashlightIsActive == true)
		{
           flashlight.SetActive(false);
           playerAudioSrs.PlayOneShot(fleshlightSound);
		   flashlightIsActive = false;
		}

		//if(joystick.Horizontal > 0){transform.localRotation = Quaternion.Euler(0,0,0);}
		//if(joystick.Horizontal < 0){transform.localRotation = Quaternion.Euler(0,100,0);}
		Vector2 moveInput = new Vector2 (joystick.Horizontal, joystick.Vertical);
		moveVelocity = moveInput.normalized * speed;
	}
	void FixedUpdate ()
	{
		if(controllWithJoystick != true)
		{
		if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.A))
		{
		   if(Input.GetKey(KeyCode.LeftShift))
		   {
			   if(staminaFill >0)
			   {
			    	rb.MovePosition(rb.position +  movement * acceleration * Time.fixedDeltaTime);
			        staminaFill -= 0.002f;
			   }
			   else
			   {
			    	rb.MovePosition(rb.position +  movement * speed * Time.fixedDeltaTime);
			   }
		   }
	
		   else
		   {
			   if(staminaFill<1)
			   {
		         staminaFill +=0.001f;
		       }
		   rb.MovePosition(rb.position +  movement * speed * Time.fixedDeltaTime);
		   }
		}
		else if(staminaFill < 1)
		{
		   staminaFill +=0.004f;
		}
		}
		else
		{
            rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
		}

		mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
		
		Vector2 lookDir = mousePos - rb.position;
		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg; 
		rb.rotation = angle;
	}
}	