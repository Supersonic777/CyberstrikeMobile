using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{ 
  public static bool GameISPaused = false;
  public GameObject inventory;
  public GameObject player;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(GameISPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
       inventory.SetActive(false);
       player.SetActive(true);
       Time.timeScale = 1f;
       GameISPaused = false;
    }
    void Pause()
    {
       inventory.SetActive(true);
       player.SetActive(false);
       Time.timeScale = 0f;
       GameISPaused = true;
    }
}