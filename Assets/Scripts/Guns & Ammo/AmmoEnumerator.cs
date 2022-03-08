using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoEnumerator : MonoBehaviour
{
    public int fullAmmo;
    public int ammo;
    public Text ammoEnumeratorText;

    // Start is called before the first frame update
    void Start()
    {
    ammo = GetComponent<GunController>().ammoInMag;
    fullAmmo = GetComponent<GunController>().allAmmo;
      if(PlayerPrefs.HasKey("Ammo"))
      {
        PlayerPrefs.GetInt("Ammo");
      }  
      if(PlayerPrefs.HasKey("FullAmmo"))
      {
        PlayerPrefs.GetInt("FullAmmo");
      }  
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Ammo", ammo);
        PlayerPrefs.SetInt("FullAmmo", fullAmmo);
        ammoEnumeratorText.text = "Ammo: " + ammo + " | " + fullAmmo;
    }
}
