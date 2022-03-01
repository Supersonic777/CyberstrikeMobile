using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour 
{

    public float playerHealth = 100;
	public float speed = 2f;
	public float acceleration = 6f;
	public float staminaFill = 1f;
	public GameObject dieMessage;
	public GameObject flashlight;
	public Rigidbody2D rb;
	public Camera cam;
	public Image bar;
	public Image stamina;
	public AudioClip walkSound;
	public AudioClip runSound;
	public AudioClip fleshlightSound;
	private float healthFill;
	private GameObject reloadNotifier;
	private bool flashlightIsActive;
	Vector2 movement;
	Vector2 mousePos;
	AudioSource playerAudioSrs;
	void Start()
	{
		flashlightIsActive = false;
		reloadNotifier = GetComponentInChildren<GunController>().reloadNotification;
        playerAudioSrs = GetComponent<AudioSource>();
	}

	void Update () 
	{
		healthFill = playerHealth/100f;
        bar.fillAmount = healthFill;
		stamina.fillAmount = staminaFill;

		movement.x = Input.GetAxis("Horizontal");
		movement.y = Input.GetAxis("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
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
	}
	void FixedUpdate ()
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
		Vector2 lookDir = mousePos - rb.position;
		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;  //+-90 градусов
		rb.rotation = angle;
	}

}	