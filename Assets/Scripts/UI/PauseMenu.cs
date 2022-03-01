using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
 
    public static bool GameISPaused = false;
  public GameObject pauseMenuUI;
  public GameObject player;
  public GameObject optionsMenu;
  public GameObject dieMessage;
  public GameObject reloadMessage;
  private bool reloadMessageIsDeactivated;
  private GameObject playerHealth;
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
      if(optionsMenu.activeSelf == false)//проверка активности объекта Options, если не активен, то выполняется скрипт
      {
        if(Input.GetKeyDown(KeyCode.Escape))
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
    }

    public void Resume()
    { 
      if(playerHealth.GetComponent<PlayerController>().playerHealth <= 0){dieMessage.SetActive(true);}
      if(reloadMessageIsDeactivated){reloadMessage.SetActive(true);}
      reloadMessageIsDeactivated = false;
      pauseMenuUI.SetActive(false);
      player.SetActive(true);
      Time.timeScale = 1f;
      GameISPaused = false;
    }
    void Pause()
    {
      if(reloadMessage.activeSelf == true)
      {
        reloadMessage.SetActive(false);
        reloadMessageIsDeactivated = true;
      }
      dieMessage.SetActive(false);
      pauseMenuUI.SetActive(true);
      player.SetActive(false);
      Time.timeScale = 0f;
      GameISPaused = true;
    }
}
