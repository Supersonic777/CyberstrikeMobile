using UnityEngine;
using System.Collections;

public class ShotSound : MonoBehaviour 
{
   public AudioClip shot;
   public AudioClip reload;
   AudioSource audioSrs;

   void Start()
   {
      audioSrs = GetComponent<AudioSource>();
   }

   void Update()
   {
      if (Input.GetKeyDown(KeyCode.Mouse0)) //здесь задаете  любую кнопку
         audioSrs.PlayOneShot(shot);
      if (Input.GetKeyDown(KeyCode.R)) //здесь задаете  любую кнопку
         audioSrs.PlayOneShot(reload);
   }
   
}