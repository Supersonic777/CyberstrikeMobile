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
	private bool flashlightIsActive;
	private float healthFill;
	public float rotationSpeed;
	private GameObject reloadNotifier;
	[SerializeField] private Joystick _movementJoystick;
	public Joystick _rotationJoystick;
	[SerializeField] private RectTransform _handlePos;
	public bool playerCanFire;
	private RectTransform _handleZeroPos;
	Vector2 movement;
	Vector2 movementRot;
	private float playerRotation;
	Vector2 mousePos;
	AudioSource playerAudioSrs;
	void Start()
	{
		_handleZeroPos = _handlePos;
		flashlightIsActive = false;
		reloadNotifier = GetComponentInChildren<GunController>().reloadNotification;
        playerAudioSrs = GetComponent<AudioSource>();
	}

	void Update () 
	{
		healthFill = playerHealth/100f;
        bar.fillAmount = healthFill;
		stamina.fillAmount = staminaFill;

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
		movement.x = _movementJoystick.Horizontal * speed;
		movement.y = _movementJoystick.Vertical * speed;
		rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
		
		movementRot.x = _rotationJoystick.Horizontal;
		movementRot.y = _rotationJoystick.Vertical;
		Vector3 direction = new Vector3(movementRot.x, movementRot.y);
		Vector3 aa = new Vector3(0, 0, 0);
		Vector3 diff = direction - aa;
		diff.Normalize();
		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

		if(movementRot.x >= 0.7f || movementRot.y >= 0.7f || movementRot.x <= -0.7f || movementRot.y <= -0.7f )
		{
			playerCanFire = true;
		}
		else
		{
			playerCanFire = false;
		}
	}
}	