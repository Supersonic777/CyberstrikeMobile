using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
  public void OpenMenu()
  {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
  }

 public void QuitGame()
  {
    Debug.Log("Quit");
    Application.Quit();
  }
}

