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
	public float rotationOffset;
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

		mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
		
		Vector2 lookDir = mousePos - rb.position;
		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg; 
		rb.rotation = angle;
	}
}	