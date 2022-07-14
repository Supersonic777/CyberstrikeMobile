using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunController : MonoBehaviour
{
    public enum fireModeList
    {
      Single, 
      Auto, 
      Birst,
      Shootgun
    };
    public fireModeList fireMode;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject reloadNotification;
    public GameObject gunFlashbang;
    public Texture2D cursor;
    private Vector2 cursorHotspot;
    //public bool isInRightHand;
    public float bulletSpeed;
    public float fireRate;
    public int ammoInMag;
    public int allAmmo;
    public int shootgunFraction;
    public float reloadSpeed;
    public float gunDamage;
    public float gunAccuracy;
    public float mass;
    public AudioClip shot;
    public AudioClip reloadSound;
    AudioSource audioSrs;
    private bool isReloading;
    private int ammoInMagNow;

    private Quaternion nativeRotation;
 //для хранения координат из начального положения пули

    // Update is called once per frame
    void Start()
    {
      cursorHotspot = new Vector2 (cursor.width / 2, cursor.height / 2);
      Cursor.SetCursor(cursor, cursorHotspot, CursorMode.Auto);
      gunFlashbang.transform.position = firePoint.position;
      nativeRotation.z = firePoint.transform.rotation.z;
      ammoInMagNow = ammoInMag;
      audioSrs = GetComponent<AudioSource>();
      allAmmo = ammoInMag*2;
    }
    void Update()
    {
      if(ammoInMagNow > 0)
      {
        //блок управления стрельбой обыкновенного пистолета
        if (Input.GetButtonDown("Fire1") && fireMode == fireModeList.Single)
        {
          Shot();
          audioSrs.PlayOneShot(shot);
          ammoInMagNow--;
          gameObject.GetComponent<AmmoEnumerator>().ammo --;
        }
        //блок управления стрельбой пистолета-пулемёта
        if(Input.GetButton("Fire1") && fireMode == fireModeList.Auto)
        {
          if(!IsInvoking("Shot")) 
          {
            Invoke("Shot", fireRate); //Вызываем функцию Shot со скорость FireRate, в секундах
            audioSrs.PlayOneShot(shot);
            ammoInMagNow--;
            gameObject.GetComponent<AmmoEnumerator>().ammo --;
          }
        }
      //блок управления дробовиком
        if (Input.GetButtonDown("Fire1") && fireMode == fireModeList.Shootgun)
        {
          while(shootgunFraction > 0)
          {
          Shot();
          shootgunFraction --;
          }
        audioSrs.PlayOneShot(shot);
        }
      }
      //блок управления перезарядкой
      if (ammoInMagNow != ammoInMag && Input.GetKeyDown(KeyCode.R) && isReloading != true)
      { //здесь задаете  любую кнопку
        isReloading = true;
        ammoInMagNow = 0;
        reloadNotification.SetActive(true);
        audioSrs.PlayOneShot(reloadSound);
        Invoke("Reload", reloadSpeed);
      }
      else if(ammoInMagNow == 0 && isReloading != true)
      {
        isReloading = true;
        reloadNotification.SetActive(true);
        audioSrs.PlayOneShot(reloadSound);
        Invoke("Reload", reloadSpeed);
      }
    }
    void Shot()
    {
      //управление разбросом оружия
      firePoint.transform.localEulerAngles = new Vector3(0, 0 , Random.Range(nativeRotation.z - gunAccuracy/2+90, nativeRotation.z + gunAccuracy/2+90));
      
      gunFlashbang.SetActive(true);

      GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
      Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
      rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);

      Invoke("GunFlashbang", 0.05f);
    }
    void Reload()
    {
      reloadNotification.SetActive(false);
      ammoInMagNow = ammoInMag;
      gameObject.GetComponent<AmmoEnumerator>().ammo = ammoInMag;
      isReloading = false;
      allAmmo -= ammoInMag;
    }

    void GunFlashbang()
    {
      gunFlashbang.SetActive(false);
    }
}
