using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public static bool GameISPaused = false;
  public GameObject StartButtonUI;
  public void PlayGame()
  {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }
  public void QuitGame()
  {
    Debug.Log("Quit");
    Application.Quit();
  }
  public void Resume()
  {
    StartButtonUI.SetActive(false);
    Time.timeScale = 1f;
    GameISPaused = false;
  }
}
